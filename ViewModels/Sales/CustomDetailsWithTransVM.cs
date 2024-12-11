using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.ViewModels.Sales
{
    public class CustomDetialsWithTransVM
    {

        public CustomerDetailsVM CustomDetails { get; set; }
        public IEnumerable<TransactionVM> Sales_Bills { get; set; }
        public IEnumerable<TransactionVM> Sales_Orders { get; set; }
        public IEnumerable<TransactionVM> Sales_Quotes { get; set; }
        public IEnumerable<TransactionVM> Sales_Returns { get; set; }
        public IEnumerable<TransactionVM> Sales_DiscountNotice { get; set; }



    }


}

