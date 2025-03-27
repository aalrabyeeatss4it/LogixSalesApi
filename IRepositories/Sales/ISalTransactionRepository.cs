using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels.Sales;

namespace LogixApi_v02.IRepositories.Sales
{
    public interface ISalTransactionRepository : IGenericRepository<SalTransaction>
    {
        Task<IEnumerable<SalTransactionsVw>> GetAllVW();
         
        Task<string> AddUsingProcedure(SalTransaction trans);
        Task<EmployeeTarget> GetEmployeeTarget(long facilityId, string empCode, int transTypeId, string fromDate, string toDate);
        public string GenerateToken(string userId);

        Task<long> GetLatestTransactionIdAsync(int posId);
        Task<bool> IsInvoiceCodeExistsAsync(int pos, string invoiceDate, decimal invoiceTotal, string invoiceCode);

    }

}
