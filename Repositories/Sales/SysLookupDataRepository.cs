using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace LogixApi_v02.Repositories.Sales
{
    public class SysLookupDataRepository : GenericRepository<SysLookupData>, ISysLookupDataRepository
    {
        public SysLookupDataRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<SysLookupDataVw>> GetAllVW()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SysLookupDataVw>> GetById()
        {
            throw new NotImplementedException();
        }




        /*public Task GetById(object p)
        {
            throw new NotImplementedException();
        }*/
        /* public async Task<IEnumerable<SysCustomerVM>> GetAllVW()
{
    return await _context.SysCustomerVws.ToListAsync();
}*/
    }
}
