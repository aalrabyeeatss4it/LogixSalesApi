
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.Repositories.Sales
{
    public class SalPaymentTermRepository : GenericRepository<SalPaymentTerm>, ISalPaymentTermRepository
    {
        public SalPaymentTermRepository(ApplicationDbContext context) : base(context)
        {
        }
       
    }


}
