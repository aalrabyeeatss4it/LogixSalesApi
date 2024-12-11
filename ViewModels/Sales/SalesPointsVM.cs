using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels.Sales
{
    public class SalesPointsVM

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

        public long? CashAccountId { get; set; }

        public long? BankAccountId { get; set; }

        public long? BankId { get; set; }

        public long? UserId { get; set; }

    }
}
