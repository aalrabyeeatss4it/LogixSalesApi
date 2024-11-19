using LogixApi_v02.Models;
using LogixApi_v02.ViewModels;

namespace LogixApi_v02.IRepositories
{
    public interface ISysScreenPermissionRepository : IGenericRepository<SysScreenPermission>

    {
        Task<SysScreenPermission> GetByScreenAndGroup(long screenId, int groupId);
    }
}
