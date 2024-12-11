using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Table("INVEST_BRANCH")]
    public partial class InvestBranch
    {
        [Key]
        [Column("BRANCH_ID")]
        public int BranchId { get; set; }
        [Column("BRA_NAME")]
        public string? BraName { get; set; }

        [Column("ISDEL")]
        public bool? Isdel { get; set; }

        public bool? IsActive { get; set; }
        [Column("Facility_ID")]
        public long? FacilityId { get; set; }
      
    }
}
