using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.IRepositories.Sales
{
    public interface ISalPosUserRepository : IGenericRepository<SalPosUser>
    {
        Task<IEnumerable<SalPosUsersVw>> GetAllVW();
        Task<IEnumerable<SalPosUsersVw>> GetById();
    }

}
