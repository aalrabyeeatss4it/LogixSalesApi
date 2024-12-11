
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Repositories.Sales
{
    public class WhInventoryRepository : GenericRepository<WhInventory>, IWhInventoryRepository
    {
        public WhInventoryRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<WhInventoriesVw>> GetAllVW()
        {
            return await _context.WhInventoriesVws.ToListAsync();
        }

        Task<IEnumerable<WhInventoriesVw>> IWhInventoryRepository.GetAllVW()
        {
            throw new NotImplementedException();
        }
    }

}
