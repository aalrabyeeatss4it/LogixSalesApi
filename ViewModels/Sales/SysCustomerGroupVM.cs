using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels.Sales
{
    public class SysCustomerGroupVM
    {
        public int? CusTypeId { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }
    }
}
