
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.TestModels;

namespace LogixApi_v02.Repositories.Sales
{
    public class AccFacilitiesVwRepository : GenericRepository<AccFacilitiesVw>, IAccFacilitiesVwRepository
    {
        public AccFacilitiesVwRepository(ApplicationDbContext context) : base(context)
        {
        }
    }


}
