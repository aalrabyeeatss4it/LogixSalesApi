using LogixApi_v02.Models;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels;
using System.Reflection.PortableExecutable;

namespace LogixApi_v02.IRepositories
{
    public interface ISysSystemRepository : IGenericRepository<SysSystem>

    {
        Task<SysSystem?> GetById(int Id);
        Task<SysSystem?> GetById(long Id);
        Task<IEnumerable<MainListDto>> GetMainList(long userId, int sysId, int cmdType);
        Task<IEnumerable<SubListDto>> GetSubList(long userId, int sysId, int cmdType, int parent);

    }

}
