using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models
{
    [Table("Sys_Mobile_Members")]
    public partial class SysMobileMember
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Column("Member_ID")]
        public string? MemberId { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("Api_URL")]
        public string? ApiUrl { get; set; }
        [Column("ERP_URL")]
        public string? ErpUrl { get; set; }
        [Column("DBName")]
        public string? Dbname { get; set; }
        [Column("DBUsername")]
        public string? Dbusername { get; set; }
        [Column("DBPassword")]
        public string? Dbpassword { get; set; }
        [Column("DBUrl")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Dburl { get; set; }
        [Column("Customer_ID")]
        public long? CustomerId { get; set; }
        public long? No { get; set; }
    }
}
