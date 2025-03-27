using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels;

namespace LogixApi_v02.IRepositories.Sales
{
    public interface ISalTransCardPaymentRepository : IGenericRepository<SalTransaction>
    {
        Task<bool> AddTransPayment(NearpayTransactionReceipt receipt);

    }
}
