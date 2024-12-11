using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Table("WH_Inventories")]
    public partial class WhInventory
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [StringLength(50)]
        public string? InventoryName { get; set; }
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
        public long? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        [Column("Account_ID")]
        public long? AccountId { get; set; }
        [Column("Branchs_ID")]
        public string? BranchsId { get; set; }
        [Column("Users_Permission")]
        public string? UsersPermission { get; set; }
        [StringLength(50)]
        public string? InventoryName2 { get; set; }
    }
}
