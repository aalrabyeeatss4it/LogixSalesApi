using LogixApi_v02.Controllers.Sales;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels.Sales;
using System.Data;
using System.Linq.Expressions;

namespace LogixApi_v02.IRepositories.Sales
{
    public interface IWhItemRepository : IGenericRepository<WhItem>
    {
        Task<IEnumerable<WhItemsVw>> GetAllVW(Expression<Func<WhItemsVw, bool>> expression);
        Task<IEnumerable<WhItemsGetBalance>> WhItemsGetBalance(long ItemID, long FacilityID, int UnitItemId, long InventoryID, long Finyear, string ItemCode);
        Task<decimal> GetQuantityItem(long itemID, long unitID, long inventoryID);
         Task<List<SysLookupDataVM>> SAL_Items_Price_M(long userId);
        Task<int> CheckPriceIsBetween(long Item_ID, long Unit_ID, long PriceList_ID, string Price);
        public DataTable GetPriceDT(long Item_ID, long Unit_ID, long PriceList_ID);
        Task<int> CheckStatus(long Item_ID);
        Task<int> Get_Account_Revenue_by_ItemID(int Item_Id);
        Task<decimal> GetCheck_Price_Last_Items(string Item_Code, string CustomerCode, string Facility_ID);

    }

}
