using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels.Sales
{
    public class SalPosSettingVM
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        public int? CustomerId { get; set; }
        public int? BranchId { get; set; }

        [StringLength(50)]
        public string? CustomerName { get; set; }

        public int? InventoryId { get; set; }

        public int? FacilityId { get; set; }
        public string? FacilityName { get; set; }
        public string? FacilityName2 { get; set; }
        public string? VatNumber { get; set; }
        public string? FacilityMobile { get; set; }
        public string? Address { get; set; }
        public long? CashAccountId { get; set; }
        public long? LnkAccounting { get; set; }
        public bool? LnkInventory { get; set; }

        public long? BankAccountId { get; set; }

        public long? BankId { get; set; }

    }
}
