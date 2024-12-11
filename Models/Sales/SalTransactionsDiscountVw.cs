using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.TestModels
{
    [Keyless]
    public partial class SalTransactionsDiscountVw
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
        [Column("Discount_Date")]
        [StringLength(10)]
        public string? DiscountDate { get; set; }
        [Column("Discount_Date2")]
        [StringLength(10)]
        public string? DiscountDate2 { get; set; }
        [Column("Discount_Amount", TypeName = "decimal(18, 2)")]
        public decimal? DiscountAmount { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("Invoice_Code")]
        [StringLength(50)]
        public string? InvoiceCode { get; set; }
        [StringLength(250)]
        public string? CustomerCode { get; set; }
        [StringLength(2500)]
        public string? CustomerName { get; set; }
        [Column("Project_ID")]
        public long? ProjectId { get; set; }
        [Column("Project_Name")]
        [StringLength(2500)]
        public string? ProjectName { get; set; }
        [Column("Currency_ID")]
        public int? CurrencyId { get; set; }
        [Column("Exchange_Rate", TypeName = "decimal(18, 10)")]
        public decimal? ExchangeRate { get; set; }
        public string? Note { get; set; }
        [Column("Type_ID")]
        public int? TypeId { get; set; }
        [Column("Emp_ID")]
        public long? EmpId { get; set; }
        [Column("Emp_Code")]
        [StringLength(50)]
        public string? EmpCode { get; set; }
        [Column("Emp_name")]
        [StringLength(250)]
        public string? EmpName { get; set; }
        [Column("VAT", TypeName = "decimal(18, 2)")]
        public decimal? Vat { get; set; }
        [Column("VAT_Amount", TypeName = "decimal(18, 2)")]
        public decimal? VatAmount { get; set; }
        [Column("Discount_Rate", TypeName = "decimal(18, 2)")]
        public decimal? DiscountRate { get; set; }
        [Column("Facility_ID")]
        public int? FacilityId { get; set; }
        [StringLength(10)]
        public string? Date1 { get; set; }
        [Column("Invoice_Total", TypeName = "decimal(18, 2)")]
        public decimal? InvoiceTotal { get; set; }
        [Column("Invoice_NewSubtotal", TypeName = "decimal(19, 2)")]
        public decimal? InvoiceNewSubtotal { get; set; }
        [Column("CC_ID")]
        public long? CcId { get; set; }
        [Column("CostCenter_Code")]
        [StringLength(50)]
        public string? CostCenterCode { get; set; }
        [Column("CostCenter_Name")]
        [StringLength(150)]
        public string? CostCenterName { get; set; }
        [Column("CostCenter_Name2")]
        [StringLength(150)]
        public string? CostCenterName2 { get; set; }
        [Column("CustomerID")]
        public long? CustomerId { get; set; }
        [Column("BRA_NAME")]
        public string? BraName { get; set; }
        [Column("BRA_NAME2")]
        public string? BraName2 { get; set; }
        [Column("Trans_Type_ID")]
        public int? TransTypeId { get; set; }
        [Column("Payment_Terms")]
        [StringLength(50)]
        public string? PaymentTerms { get; set; }
        [Column("Payment_Terms2")]
        [StringLength(50)]
        public string? PaymentTerms2 { get; set; }
        [StringLength(2500)]
        public string? RecipientName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Total { get; set; }
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? NewSubtotal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Subtotal { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public bool? IsReportedToZatca { get; set; }
        [Column("Payment_Terms_ID")]
        public int? PaymentTermsId { get; set; }
        [Column("Zatca_CreditDebitNotes_ID")]
        public long? ZatcaCreditDebitNotesId { get; set; }
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? TotalDiscount { get; set; }
    }
}
