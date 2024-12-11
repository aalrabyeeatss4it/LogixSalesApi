
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Repositories.Sales
{
    public class SysCustomerGroupRepository : GenericRepository<SysCustomerGroup>, ISysCustomerGroupRepository

    {
        public SysCustomerGroupRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<SysCustomerGroup>> GetAllVW()
        {
            return await _context.SysCustomerGroups.ToListAsync();
        }
    }

}
