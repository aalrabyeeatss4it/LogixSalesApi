using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Keyless]
    public partial class SalPosUsersVw
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("POS_ID")]
        public long? PosId { get; set; }
        [Column("User_ID")]
        public long? UserId { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("USER_FULLNAME")]
        [StringLength(50)]
        public string? UserFullname { get; set; }
    }
}
