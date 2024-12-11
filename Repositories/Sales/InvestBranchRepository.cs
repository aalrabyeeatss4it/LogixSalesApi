
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Repositories.Sales
{
    public class InvestBranchRepository : GenericRepository<InvestBranch>, IInvestBranchRepository
    {
        public InvestBranchRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<InvestBranch>> GetAllVW()
        {
            return await _context.InvestBranchs.ToListAsync();
        }
    }

}
