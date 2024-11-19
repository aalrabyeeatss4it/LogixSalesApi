using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.IRepositories.Sales
{
    public interface IWhInventoryRepository : IGenericRepository<WhInventory>
    {
         Task<IEnumerable<WhInventoriesVw>> GetAllVW();
    }



}
