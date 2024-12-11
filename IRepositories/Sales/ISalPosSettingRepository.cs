using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.IRepositories.Sales
{
    public interface ISalPosSettingRepository : IGenericRepository<SalPosSetting>
    {
        Task<IEnumerable<SalPosSettingVw>> GetAllVW();
        Task<IEnumerable<SalPosSettingVw>> GetById();
    }

}
