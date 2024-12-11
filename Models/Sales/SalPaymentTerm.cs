using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Table("SAL_Payment_Terms")]
    public partial class SalPaymentTerm
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
       
        [Column("Payment_Terms")]
        [StringLength(50)]
        public string? PaymentTerms { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("Payment_Terms2")]
        [StringLength(50)]
        public string? PaymentTerms2 { get; set; }
    }
}
