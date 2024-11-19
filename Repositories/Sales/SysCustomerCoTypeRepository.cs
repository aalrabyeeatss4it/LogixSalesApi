
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models;
using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.Repositories.Sales
{
    public class SysCustomerCoTypeRepository : GenericRepository<SysCustomerCoType>,
        ISysCustomerCoTypeRepository
    {
        public SysCustomerCoTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }


}
