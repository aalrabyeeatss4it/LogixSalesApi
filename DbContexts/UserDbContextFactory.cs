using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace LogixApi_v02.DbContexts
{

    public class UserDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        private readonly string _connectionString;

        public UserDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(_connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

