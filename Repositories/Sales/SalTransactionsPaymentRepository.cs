
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.Repositories.Sales
{
    public class SalTransactionsPaymentRepository : GenericRepository<SalTransactionsPayment>,  ISalTransactionsPaymentRepository
    {
        public SalTransactionsPaymentRepository(ApplicationDbContext context) : base(context)
        {
        }

    }


}
