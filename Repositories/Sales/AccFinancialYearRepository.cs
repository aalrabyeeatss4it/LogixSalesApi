
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.Repositories.Sales
{
    public class AccFinancialYearRepository : GenericRepository<AccFinancialYear>, IAccFinancialYearRepository
    {
        public AccFinancialYearRepository(ApplicationDbContext context) : base(context)
        {
        }
    }


}
