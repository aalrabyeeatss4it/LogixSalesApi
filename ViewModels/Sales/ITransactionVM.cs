
namespace LogixApi_v02.ViewModels.Sales
{
    public interface ITransactionVM
    {
        IEnumerable<BranchesVM> AddBranches { get; set; }
        IEnumerable<CustomerDetailsVM> AddCustomDetails { get; set; }
        IEnumerable<WhInventoryVM> AddInventory { get; set; }
        IEnumerable<WhItemsVM> AddItems { get; set; }
        IEnumerable<SalPaymentTermsVM> AddPaymentsTerms { get; set; }
        decimal? AmountCost { get; set; }
        string? BraName { get; set; }
        string? Code { get; set; }
        long? CreatedBy { get; set; }
        DateTime? CreatedOn { get; set; }
        string? Customer_Name { get; set; }
        string? Date1 { get; set; }
        decimal? DiscountAmount { get; set; }
        long? EmpId { get; set; }
        string? ExpirationDate { get; set; }
        long? FacilityId { get; set; }
        long Id { get; set; }
        string? IdNo { get; set; }
        int? Payment_Terms_ID { get; set; }
        string? PaymentTerms { get; set; }
        int? SalesType { get; set; }
        decimal? Subtotal { get; set; }
        decimal? Total { get; set; }
        int? TransTypeId { get; set; }
        decimal? VatAmount { get; set; }
    }
}