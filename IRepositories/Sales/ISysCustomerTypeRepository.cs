using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.IRepositories.Sales
{
    public interface ISysCustomerTypeRepository : IGenericRepository<SysCustomerType>
    {
        Task<IEnumerable<SysCustomerType>> GetAllVW();
        Task<IEnumerable<SysCustomerType>> GetById();
    }

}
