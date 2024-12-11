using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels.Sales
{
    public class GetPriceItemVM
    {

        [StringLength(250)]
        public decimal? price { get; set; }
        public decimal? min_price { get; set; }

        
        public decimal? max_price { get; set; }


    }
}
