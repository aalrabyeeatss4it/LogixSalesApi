using LogixApi_v02.DbContexts;
using LogixApi_v02.Models;
using LogixApi_v02.TestModels;
using LogixApi_v02.ViewModels;

namespace LogixApi_v02.IRepositories
{
    public interface IUsersRepository
    {
        Task<SysUserVw?> Login(string username, string password, MembersEntity member);
        string GetJWTToken(SysUserVw user, MembersEntity member);
       
        Task<MembersEntity?> GetMember(string memberId);

        Task<AccFacilitiesVw?> getLogo(MembersEntity member);
    }
}
