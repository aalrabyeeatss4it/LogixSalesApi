using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Keyless]
    public partial class SysTargetEmployeeVw
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("Emp_ID")]
        public long? EmpId { get; set; }
        [Column("Target_Value", TypeName = "decimal(18, 2)")]
        public decimal? TargetValue { get; set; }
        [Column("T_M_ID")]
        public long? TMId { get; set; }
        [Column("T_D_ID")]
        public long? TDId { get; set; }
        public string? Note { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("Emp_Code")]
        [StringLength(50)]
        public string EmpCode { get; set; } = null!;
        [Column("Emp_name")]
        [StringLength(250)]
        public string? EmpName { get; set; }
        [Column("Start_Date")]
        [StringLength(10)]
        public string? StartDate { get; set; }
        [Column("End_date")]
        [StringLength(10)]
        public string? EndDate { get; set; }
        [Column("Fin_year")]
        public long? FinYear { get; set; }
        [Column("BRA_NAME")]
        public string? BraName { get; set; }
        [StringLength(2000)]
        public string? Name { get; set; }
        [Column("Period_Name")]
        [StringLength(2000)]
        public string? PeriodName { get; set; }
        [Column("Target_Type")]
        public int? TargetType { get; set; }
        [StringLength(10)]
        public string? Expr1 { get; set; }
        [StringLength(10)]
        public string? Expr2 { get; set; }
        [Column("Branch_ID")]
        public int? BranchId { get; set; }
        [Column("Target_Master_ID")]
        public long TargetMasterId { get; set; }
        public bool? IsDeletedM { get; set; }
    }
}
