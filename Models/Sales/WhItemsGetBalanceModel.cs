using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Keyless]
    public class WhItemsGetBalance
    {
        public long IU_ID { get; set; }
        public long Item_ID { get; set; }
        public string Item_Code { get; set; }
        public decimal Remaining_Balance { get; set; }
        public decimal Remaining_All_Inventories { get; set; }
    }
}
