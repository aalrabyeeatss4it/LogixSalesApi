using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels.Sales
{

    public class AddCustomerVM
    {
        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(maximumLength: 15, MinimumLength = 9)]
        public string Mobile { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(maximumLength: 0, MinimumLength = 50)]
        public int? BranchId { get; set; }

        [StringLength(50)]
        public string? Address { get; set; }

        /* [StringLength(50)]
         public string? Mobile { get; set; }*/

        [StringLength(50)]
        public string? Phone { get; set; }

        /* [StringLength(50)]
         public string? Email { get; set; }*/

        [StringLength(250)]
        public string? CustomerName { get; set; }
        [StringLength(2400)]
        public string? Latitude { get; set; }

        [StringLength(2400)]
        public string? Longitude { get; set; }

    }
}

// DataAnnotation
