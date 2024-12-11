using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels.Sales
{
    public class SalTransactionVM
    {

        public long Id { get; set; }
        public long? No { get; set; }
        [StringLength(50)]
        public string? Code { get; set; }

        public long? CreatedBy { get; set; }
    } 
}
