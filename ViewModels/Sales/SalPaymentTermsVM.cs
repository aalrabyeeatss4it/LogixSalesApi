using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels.Sales
{
    public class SalPaymentTermsVM
    {
        public long IdPayment { get; set; }

      
        [StringLength(50)]
        public string? PaymentTerms { get; set; }

        public string? PaymentTerms2 { get; set; }
    }
}
