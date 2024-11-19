using LogixApi_v02.Models.Sales;

namespace LogixApi_v02.ViewModels.Sales
{
    public class SalTransactionAddVM
    {

        public SalTransaction SalTransaction { get; set; }
        public List<SalTransactionsProduct> SalTransactionsProducts { get; set; }

    }
}
