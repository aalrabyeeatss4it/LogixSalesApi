namespace LogixApi_v02.ViewModels.Sales
{
    public class AddTransactionVM
    {
        public AddTransactionVM()
        {
            AddCustomDetails = new List<CustomerDetailsVM>();
            AddItems = new List<WhItemsVM>();
            AddBranches = new List<BranchesVM>();
            AddPaymentsTerms = new List<SalPaymentTermsVM>();
            AddInventory = new List<WhInventoryVM>();
        }
        public IEnumerable<CustomerDetailsVM> AddCustomDetails { get; set; }

       // public IEnumerable<TransactionVM> AddTransactions { get; set; }
        public IEnumerable<WhItemsVM> AddItems { get; set; }
        public IEnumerable<BranchesVM> AddBranches { get; set; }

        public IEnumerable<SalPaymentTermsVM> AddPaymentsTerms { get; set; }
        public IEnumerable<WhInventoryVM> AddInventory { get; set; }

    }
}
