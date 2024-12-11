using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.IRepositories.Sales
{
    public interface ISysLookupDataRepository : IGenericRepository<SysLookupData>
    {
        Task<IEnumerable<SysLookupDataVw>> GetAllVW();
        Task<IEnumerable<SysLookupDataVw>> GetById();
    }

}
