using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories;
using LogixApi_v02.TestModels;

namespace LogixApi_v02.Repositories
{
    public class SysPropertyValuesVwRepository : GenericRepository<SysPropertyValuesVw>, ISysPropertyValuesVwRepository
    {
        public SysPropertyValuesVwRepository(ApplicationDbContext context) : base(context)
        {
        }
    }  


}
