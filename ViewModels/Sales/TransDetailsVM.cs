namespace LogixApi_v02.ViewModels.Sales
{
    public class TransDetailsVM
    {
       public long? Id { get; set; }
        public string? Code { get; set; }
        public decimal? AmountCost { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? Vat { get; set; }
        public decimal? Total { get; set; }
        public decimal? SubTotal { get; set; }
        public string? BraName { get; set; }
        public string? CustomerName { get; set; }
        public string? PaymentTerms { get; set; }   
        public string? Date1 { get; set; }
        public string? DueDate { get; set; }
        public string? DocumentNote { get; set; }
        public string? FacVatNumber { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? AmountRemaining { get; set; }
        public decimal? VaTAmount { get; set; }
        public decimal? Net { get; set; }
        public string? InventoryName { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
