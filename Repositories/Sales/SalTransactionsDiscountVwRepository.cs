
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.TestModels;

namespace LogixApi_v02.Repositories.Sales
{
    public class SalTransactionsDiscountVwRepository : GenericRepository<SalTransactionsDiscountVw>, ISalTransactionsDiscountVwRepository
    {
        public SalTransactionsDiscountVwRepository(ApplicationDbContext context) : base(context)
        {
        }

    }


}
