using LogixApi_v02.Controllers.Sales;
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Repositories.Sales
{
    public class SysBranchRepository : GenericRepository<SysBranch>, ISysBranchRepository
    {
        public SysBranchRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<SysBranchVw>> GetAllVW()
        {
            return await _context.SysBranchVws.ToListAsync();
        }

    }

}
