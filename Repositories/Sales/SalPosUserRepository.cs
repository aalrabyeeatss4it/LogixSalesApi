
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.Repositories.Sales
{
    public class SalPosUserRepository : GenericRepository<SalPosUser>,

        ISalPosUserRepository
    {
        public SalPosUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<SalPosUsersVw>> GetAllVW()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SalPosUsersVw>> GetById()
        {
            throw new NotImplementedException();
        }

      
    }

}
