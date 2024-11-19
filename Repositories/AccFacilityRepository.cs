using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories;
using LogixApi_v02.Models;

namespace LogixApi_v02.Repositories
{
    public class AccFacilityRepository : GenericRepository<AccFacility>, IAccFacilityRepository
    {
        public AccFacilityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }


}
