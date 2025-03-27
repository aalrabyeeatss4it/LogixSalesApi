using System.Data;

namespace LogixApi_v02.Models.Sales
{
    public class NearpayTransactionReceipt
    {
        public String? receipt_id {  get; set; }
        public String? transaction_uuid { get; set; }
        public String? start_date { get; set; }
        public String? start_time { get; set; }
        public String? tid { get; set; }
        public String? transactionId { get; set; }
    }
}
