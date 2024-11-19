//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.IdentityModel.Tokens.Jwt;
//using System.Text;
//using LogixApi_v02.DbContexts;
//using LogixApi_v02.Helpers;
//using LogixApi_v02.IRepositories;

//public static class DbContextRegistration
//{
//    public static void RegisterDbContext(IServiceCollection services, IConfiguration configuration , IHttpContextAccessor httpContextAccessor)
//    {
//        services.AddScoped<ApplicationDbContext>(provider => CreateDbContextAsync(provider, configuration,  httpContextAccessor).GetAwaiter().GetResult());
//    }

//    private static async Task<ApplicationDbContext> CreateDbContextAsync(IServiceProvider provider, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
//    {
//        //var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
//        var path = httpContextAccessor.HttpContext.Request.Path;

//        if (path.HasValue && !string.IsNullOrEmpty(path.Value) && path.Value == "/api/users/authenticate")
//        {
//            var genericConnectionString = configuration.GetConnectionString("DefaultConnection");
//            return new UserDbContextFactory(genericConnectionString).CreateDbContext();
//        }

//        var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
//        if (!string.IsNullOrEmpty(token))
//        {
//            // Validate and decode the JWT token
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var jwtToken = tokenHandler.ReadJwtToken(token);

//            if (jwtToken.Payload.TryGetValue("MemberId", out var memberId))
//            {
//                var memberIdValue = memberId.ToString();
//                var userRepository = provider.GetRequiredService<IUsersRepository>();
//                var userConnectionString = await userRepository.GetconnactionstringByMember(memberIdValue).ConfigureAwait(false);
//                return new UserDbContextFactory(userConnectionString).CreateDbContext();
//            }
//        }

//        throw new Exception("Connection string not found in JWT token.");
//    }
//}
