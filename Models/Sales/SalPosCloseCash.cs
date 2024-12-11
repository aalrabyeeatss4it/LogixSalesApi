using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.TestModels
{
    [Table("SAL_POS_Close_Cash")]
    public partial class SalPosCloseCash
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [StringLength(50)]
        public string? Code { get; set; }
        [StringLength(50)]
        public string? StarDate { get; set; }
        [StringLength(50)]
        public string? EndDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? AmounCash { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? AmountBank { get; set; }
        [Column("Branch_ID")]
        public int? BranchId { get; set; }
        [Column("Facility_ID")]
        public int? FacilityId { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("POS_ID")]
        public long? PosId { get; set; }
        [Column("Account_ID_TO")]
        public long? AccountIdTo { get; set; }
        [Column("Account_ID_From")]
        public long? AccountIdFrom { get; set; }
        [Column("sales_Amount", TypeName = "decimal(18, 2)")]
        public decimal? SalesAmount { get; set; }
        [Column("RE_salas_Amount", TypeName = "decimal(18, 2)")]
        public decimal? ReSalasAmount { get; set; }
    }
}
