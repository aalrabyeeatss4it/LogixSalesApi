using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels.Sales
{
    public class WhInventoryVM
    {

        public long Id { get; set; }

        [StringLength(50)]
        public string? InventoryName { get; set; }
    }
}
