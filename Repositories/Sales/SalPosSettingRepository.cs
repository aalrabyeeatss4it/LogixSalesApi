
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.Repositories.Sales
{
    public class SalPosSettingRepository : GenericRepository<SalPosSetting>,ISalPosSettingRepository
    {
        public SalPosSettingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<SalPosSettingVw>> GetAllVW()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SalPosSettingVw>> GetById()
        {
            throw new NotImplementedException();
        }
    }

}
