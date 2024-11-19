using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Keyless]
    public partial class SalTransactionsPaymentVw
    {
        [Column("ID")]
        public long Id { get; set; }
        public long? No { get; set; }
        [StringLength(50)]
        public string? Code { get; set; }
        [Column("Branch_ID")]
        public int? BranchId { get; set; }
        [Column("Transaction_ID")]
        public long? TransactionId { get; set; }
        [Column("Payment_Date")]
        [StringLength(10)]
        public string? PaymentDate { get; set; }
        [Column("Payment_Date2")]
        [StringLength(10)]
        public string? PaymentDate2 { get; set; }
        [Column("Amount_Received", TypeName = "decimal(18, 2)")]
        public decimal? AmountReceived { get; set; }
        [Column("Payment_Method_ID")]
        public int? PaymentMethodId { get; set; }
        [Column("Bank_ID")]
        public int? BankId { get; set; }
        [Column("Bank_Reference")]
        [StringLength(50)]
        public string? BankReference { get; set; }
        [Column("Days_Late")]
        public int? DaysLate { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("Account_ID")]
        public long? AccountId { get; set; }
        [Column("JID")]
        public long? Jid { get; set; }
    }
}
