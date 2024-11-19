
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.Repositories.Sales
{
    public class SalTransactionsProductRepository : GenericRepository<SalTransactionsProduct>, ISalTransactionsProductRepository
    {
        public SalTransactionsProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
