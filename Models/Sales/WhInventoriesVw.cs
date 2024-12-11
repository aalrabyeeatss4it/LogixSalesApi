using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Keyless]
    public partial class WhInventoriesVw
    {
        [Column("ID")]
        public long Id { get; set; }
        [StringLength(50)]
        public string? InventoryName { get; set; }
        [StringLength(50)]
        public string? InventoryName2 { get; set; }
        [StringLength(50)]
        public string? Code { get; set; }
        [StringLength(50)]
        public string? Phone { get; set; }
        [Column("Storekeeper_ID")]
        public long? StorekeeperId { get; set; }
        [Column("Storekeeper_Name")]
        [StringLength(50)]
        public string? StorekeeperName { get; set; }
        
        [Column("Branch_ID")]
        public int? BranchId { get; set; }
        [Column("Facility_ID")]
        public long? FacilityId { get; set; }
        [Column("Status_Id")]
        public int? StatusId { get; set; }
        [StringLength(255)]
        public string? Location { get; set; }
        public string? Note { get; set; }
        public bool IsDeleted { get; set; }
        [Column("Emp_name")]
        [StringLength(250)]
        public string? EmpName { get; set; }
        [Column("Emp_ID")]
        [StringLength(50)]
        public string? EmpId { get; set; }
        [Column("BRA_NAME")]
        public string? BraName { get; set; }
        [Column("Account_ID")]
        public long? AccountId { get; set; }
        [Column("Acc_Account_Name")]
        [StringLength(255)]
        public string? AccAccountName { get; set; }

        [Column("Acc_Account_Code")]
        [StringLength(50)]
        public string? AccAccountCode { get; set; }
        
        [Column("Branchs_ID")]
        public string? BranchsId { get; set; }

        [Column("Users_Permission")]
        public string? UsersPermission { get; set; }
    }
}
