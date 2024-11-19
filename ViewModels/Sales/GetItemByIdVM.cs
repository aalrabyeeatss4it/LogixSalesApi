namespace LogixApi_v02.ViewModels.Sales
{
    public class GetItemByIdVM
    {
        public WhItemsVM ItemsById { get; set; }

        public decimal? VatRate { get; set; }
        public decimal? VaTAmount { get; set; }

       // public decimal? vatAmount { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? SalePrice { get; set; }



    }
}
