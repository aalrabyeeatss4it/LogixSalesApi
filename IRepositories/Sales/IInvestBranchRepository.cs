using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.IRepositories.Sales
{
    public interface IInvestBranchRepository : IGenericRepository<InvestBranch>
    {
        Task<IEnumerable<InvestBranch>> GetAllVW();
        //Task<IEnumerable<InvestBranch>> GetById();
    }
    
     

}
