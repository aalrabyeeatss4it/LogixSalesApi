using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories;
using LogixApi_v02.Models;
using LogixApi_v02.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace LogixApi_v02.Repositories
{
    public class SysSystemRepository : GenericRepository<SysSystem>, ISysSystemRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration config;

        public SysSystemRepository(ApplicationDbContext context, IConfiguration config) : base(context)
        {
            this.context = context;
            this.config = config;
        }



        public async Task<IEnumerable<MainListDto>> GetMainList(long userId, int sysId, int cmdType)
        {
            var r = context.Set<MainListDto>().FromSqlRaw($"exec SYS_USER_SP @cmdType={cmdType}, @User_id={userId}, @system_id={sysId}").AsEnumerable().ToList();

            return r;


        }
        public async Task<IEnumerable<SubListDto>> GetSubList(long userId, int sysId, int cmdType, int parent)
        {

            var r = context.Set<SubListDto>().FromSqlRaw($"exec SYS_USER_SP @cmdType={cmdType}, @User_id={userId}, @system_id={sysId}, @parent_id={parent}").AsEnumerable().ToList();

            return r;

        }

        public async Task<SysSystem?> GetById(int Id)
        {
            return await _context.Set<SysSystem>().FindAsync(Id);
            //return await _context.SysSystem.FindAsync(Id);
        }
        public async Task<SysSystem?> GetById(long Id)
        {
            return await _context.Set<SysSystem>().FindAsync(Id);
        }

    }
}
