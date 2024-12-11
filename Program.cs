using Autofac;
using Autofac.Extensions.DependencyInjection;
using LogixApi_v02.DbContexts;
using LogixApi_v02.DI;
using LogixApi_v02.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ApplicationDbContext>(provider =>
{
    var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();

    var path = httpContextAccessor.HttpContext.Request.Path;

    // Check for specific paths where a generic connection string is used
    if (path.HasValue && !string.IsNullOrEmpty(path.Value))
    {
        if (path.Value == "/api/users/authenticate" || path.Value == "/api/SysConfig/GetAll"||path.Value== "/api/users/GetCompany")
        {
            var genericConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            return new UserDbContextFactory(genericConnectionString).CreateDbContext();
        }
    }

    var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

    if (!string.IsNullOrEmpty(token))
    {
        try
        {
            // Validate and decode the JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Extract the connection string or member ID from the token
            if (jwtToken.Payload.TryGetValue("MemberId", out var MemberId))
            {
                var genericConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                // Create a new instance of the database context
                var dbContextFactory = new UserDbContextFactory(genericConnectionString);
                var dbContext = dbContextFactory.CreateDbContext();

                // Retrieve the connection string based on the member ID
                var memberId = MemberId.ToString();
                var userConnectionString = GetConnectionString.GetconnactionstringByMember(dbContext, memberId).Result;

                // Create DbContext using the user-specific connection string
                return new UserDbContextFactory(userConnectionString).CreateDbContext();
            }
        }
        catch (Exception ex)
        {
            // Log the exception and fall back to the default connection string
            // log.Error(ex, "Error parsing JWT token or fetching connection string.");
        }
    }

    // Fallback to the default connection string
    var fallbackConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new UserDbContextFactory(fallbackConnectionString).CreateDbContext();
});

// Add additional services
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ==================================== Inject Repositories =======================================

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// ConfigureContainer for Autofac
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    // ================= Repositories =======================
    builder.RegisterModule(new MainModule());
});

// JWT Authentication setup
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
var secret = appSettingsSection.GetValue<string>("Secret");
var key = Encoding.UTF8.GetBytes(secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Authorization and other middlewares
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

// Swagger setup
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Logix API",
        Version = "v1",
        Description = "API Services.",
        Contact = new OpenApiContact
        {
            Name = "Logix Contact"
        },
    });

    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Dependency injections
builder.Services.AddTransient<IPermissionHelper, PermissionHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Authentication & Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Swagger UI mapping
app.MapControllers();

app.Run();
