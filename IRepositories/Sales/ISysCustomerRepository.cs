using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.IRepositories.Sales
{
    public interface ISysCustomerRepository : IGenericRepository<SysCustomer>
    {
        Task<int> InsertSys_CustomerAsync(SysCustomer objRecord);
    }
   
}
