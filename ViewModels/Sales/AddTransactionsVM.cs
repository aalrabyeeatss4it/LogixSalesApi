using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels.Sales
{
    public class AddTransactionsVM
    {
        [StringLength(50)]
        public long? CustomerId { get; set; }

        [StringLength(50)]
        public int? TransTypeId { get; set; }

        [StringLength(50)]
        public int? BranchId { get; set; }

        [StringLength(50)]
        public long? FacilityId { get; set; }

        [StringLength(50)]
        public string? Date1 { get; set; }

       [StringLength(maximumLength: 15, MinimumLength = 9)]
        public string? Phone { get; set; }

        [StringLength(50)]
        public decimal? DiscountRate { get; set; }

        [StringLength(50)]
        public decimal? DiscountAmount { get; set; }

    }
}
