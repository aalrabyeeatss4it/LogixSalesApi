using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models;

namespace LogixApi_v02.Repositories
{
    public class WhItemsInventoryVwRepository : GenericRepository<WhItemsInventoryVw>, IWhItemsInventoryVwRepository
    {
        public WhItemsInventoryVwRepository(ApplicationDbContext context) : base(context)
        {
        }
    }   


}
