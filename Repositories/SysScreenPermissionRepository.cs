using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models;
using LogixApi_v02.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Repositories
{
    public class SysScreenPermissionRepository : GenericRepository<SysScreenPermission>, ISysScreenPermissionRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration config;

        public SysScreenPermissionRepository(ApplicationDbContext context, IConfiguration config) : base(context)
        {
            this.context = context;
            this.config = config;
        }

        public async Task<SysScreenPermission> GetByScreenAndGroup(long screenId, int groupId)
        {
            return await context.SysScreenPermissions.Where(s => s.ScreenId == screenId && s.GroupId == groupId).SingleAsync();
        }



    }
}
