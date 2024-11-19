namespace LogixApi_v02.ViewModels.sales
{
    public class TransProductsVM
    {
        public long? Id { get; set; }
        public long? ProductID { get; set; }
        public string? ItemName { get; set; }
        public decimal? Price { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Vat { get; set; }
        public decimal? Disc_rate { get; set; }
        public decimal? VaT_Amount { get; set; }
       public decimal? Discount_Amount { get; set; }
    }
}
