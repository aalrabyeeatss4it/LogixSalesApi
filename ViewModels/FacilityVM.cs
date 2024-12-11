using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels
{
    public class FacilityVM
    {
        public long FacilityId { get; set; }
       
        [StringLength(500)]
        public string? FacilityName { get; set; }
       
        [StringLength(500)]
        public string? FacilityName2 { get; set; }
       
        [StringLength(2000)]
        public string? FacilityLogo { get; set; }
       
        [StringLength(50)]
        public string? FacilityPhone { get; set; }
        
        [StringLength(50)]
        public string? FacilityMobile { get; set; }
      
        [StringLength(50), EmailAddress]
        public string? FacilityEmail { get; set; }
       
        [StringLength(50) ]
        public string? FacilitySite { get; set; }
       
        public string? FacilityAddress { get; set; }
    }
}
