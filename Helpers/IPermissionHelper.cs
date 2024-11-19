using LogixApi_v02.IRepositories;
using LogixApi_v02.Models;

namespace LogixApi_v02.Helpers
{
    public interface IPermissionHelper
    {
        Task<bool> HasPermission(long screenId, PermissionType permissionType,int GroupsId);
    }


    public class PermissionHelper : IPermissionHelper
    {
        private readonly ISession _session;
        private readonly ISysScreenPermissionRepository sysScreenPermissionRepository;

        public PermissionHelper(ISysScreenPermissionRepository sysScreenPermissionRepository)
        {
            this.sysScreenPermissionRepository = sysScreenPermissionRepository;
        }
        public async Task<bool> HasPermission(long screenId, PermissionType permissionType,int GroupsId)
        {
            try
            {

                if (GroupsId ==0)
                {
                    return false;
                }

                var getPerm = await sysScreenPermissionRepository.GetByScreenAndGroup(screenId, GroupsId);
                if (getPerm==null)
                {
                    return false;
                }

                switch (permissionType)
                {
                    case PermissionType.Add: return getPerm.ScreenAdd ?? false; break;
                    case PermissionType.Edit: return getPerm.ScreenEdit ?? false; break;
                    case PermissionType.Delete: return getPerm.ScreenDelete ?? false; break;
                    case PermissionType.Show: return getPerm.ScreenShow ?? false; break;
                    case PermissionType.Print: return getPerm.ScreenPrint ?? false; break;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
