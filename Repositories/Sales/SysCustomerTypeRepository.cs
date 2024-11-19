
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Repositories.Sales
{
    public class SysCustomerTypeRepository : GenericRepository<SysCustomerType>, ISysCustomerTypeRepository
    {
        public SysCustomerTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<SysCustomerType>> GetAllVW()
        {
            return await _context.SysCustomerTypes.ToListAsync();
        }

        public Task<IEnumerable<SysCustomerType>> GetById()
        {
            throw new NotImplementedException();
        }
    }

}
