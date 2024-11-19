using LogixApi_v02.ViewModels.sales;

namespace LogixApi_v02.ViewModels.Sales
{
    public class TransDetailsWithProductsVM
    {
        public TransDetailsVM Details { get; set; }
        public IEnumerable<TransProductsVM> Products { get; set; }  
    }
}
