namespace LogixApi_v02.ViewModels.Sales
{
    public class WhItemsVM
    {
        public long Id { get; set; }

        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }

        public decimal? PriceSale { get; set; }

        public decimal? PurchasePrice { get; set; }

        public string? UnitName { get; set; }

        public decimal? VatRate { get; set; }

        public string? CatName { get; set; }

        public int? UnitItemId { get; set; }
        public int? StatusId { get; set; }

        public bool? VatEnable { get; set; }

        public bool? PriceIncludeVat { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? EmpId { get; set; }

        public string? BarCode { get; set; }
    }
}
