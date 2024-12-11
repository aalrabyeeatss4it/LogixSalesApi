using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Table("SAL_Transactions")]
    [Index("Code", "IsDeleted", "FacilityId", Name = "Indx_SalTCode", IsUnique = true)]
    [Index("RefranceId", Name = "NonClusteredIndex-20191118-125354")]
    public partial class SalTransaction
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        public long? No { get; set; }
        [StringLength(50)]
        public string? Code { get; set; }
        [Column("Trans_Type_ID")]
        public int? TransTypeId { get; set; }
        [Column("Branch_ID")]
        public int? BranchId { get; set; }
        [Column("CustomerID")]
        public long? CustomerId { get; set; }
        [Column("RecipientID")]
        public long? RecipientId { get; set; }
        [StringLength(2500)]
        public string? RecipientName { get; set; }
        [StringLength(2500)]
        public string? Address { get; set; }
        [Column("PO_Number")]
        [StringLength(50)]
        public string? PoNumber { get; set; }
        [StringLength(10)]
        public string? Date1 { get; set; }
        [StringLength(10)]
        public string? Date2 { get; set; }
        [Column("Delivery_Date")]
        [StringLength(10)]
        public string? DeliveryDate { get; set; }
        [Column("Expiration_Date")]
        [StringLength(10)]
        
        public string? ExpirationDate { get; set; }
        
        [Column("Due_Date")]
        [StringLength(10)]
        public string? DueDate { get; set; }


        [Column("Payment_Terms_ID")]
        public int? PaymentTermsId { get; set; }
        [Column("Document_Note")]
        public string? DocumentNote { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Subtotal { get; set; }
        [Column("Discount_Rate", TypeName = "decimal(18, 2)")]
        public decimal? DiscountRate { get; set; }
        
        [Column("Discount_Amount", TypeName = "decimal(18, 2)")]
        public decimal? DiscountAmount { get; set; }
        
        [Column("VAT", TypeName = "decimal(18, 2)")]
        public decimal? Vat { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Total { get; set; }
        [Column("Delivery_Contact")]
        public string? DeliveryContact { get; set; }
        [Column("Delivery_Address")]
        public string? DeliveryAddress { get; set; }
        [Column("Project_ID")]
        public long? ProjectId { get; set; }
        [Column("Private_Note")]
        public string? PrivateNote { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("Status_ID")]
        public int? StatusId { get; set; }
        /// <summary>
        /// رقم المرجع لعرض الاسعار او اوامر البيع
        /// </summary>
        [Column("Refrance_ID")]
        public long? RefranceId { get; set; }
        [Column("Contract_ID")]
        public long? ContractId { get; set; }
        [Column("Invoice_Month")]
        [StringLength(50)]
        public string? InvoiceMonth { get; set; }
        [Column("Service_Render")]
        public int? ServiceRender { get; set; }
        [Column("Emp_ID")]
        public long? EmpId { get; set; }
        [Column("Payment_Terms")]
        public string? PaymentTerms { get; set; }
        [Column("Delivery_Term")]
        public string? DeliveryTerm { get; set; }
        [Column("Inventory_ID")]
        public int? InventoryId { get; set; }
        [Column("Facility_ID")]
        public long? FacilityId { get; set; }
        [Column("Emp_ID2")]
        public long? EmpId2 { get; set; }
        [StringLength(500)]
        public string? Waybill { get; set; }
        [StringLength(50)]
        public string? Phone { get; set; }
        [Column("Currency_ID")]
        public int? CurrencyId { get; set; }
        [Column("Exchange_Rate", TypeName = "decimal(18, 10)")]
        public decimal? ExchangeRate { get; set; }
        [Column("POS_ID")]
        public long? PosId { get; set; }
        [Column("Amount_Paid", TypeName = "decimal(18, 2)")]
        public decimal? AmountPaid { get; set; }
        [Column("Amount_Remaining", TypeName = "decimal(18, 2)")]
        public decimal? AmountRemaining { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Points { get; set; }
        [Column("VAT_Amount", TypeName = "decimal(18, 2)")]
        public decimal? VatAmount { get; set; }
        [Column("Amount_Cost", TypeName = "decimal(18, 2)")]
        public decimal? AmountCost { get; set; }
        [Column("Due_Period_Days")]
        public int? DuePeriodDays { get; set; }
        [Column("Safety_Period_Days")]
        public int? SafetyPeriodDays { get; set; }
        [Column("Safety_Date")]
        [StringLength(10)]
        public string? SafetyDate { get; set; }
        [Column("App_ID")]
        public long? AppId { get; set; }
        [Column("CC_ID")]
        public long? CcId { get; set; }
        [Column("Return_Type")]
        public int? ReturnType { get; set; }
        [Column("Return_Account_ID")]
        public long? ReturnAccountId { get; set; }
        [Column("Has_Reservation")]
        public bool? HasReservation { get; set; }
        [Column("Cash_Amount", TypeName = "decimal(18, 2)")]
        public decimal? CashAmount { get; set; }
        [Column("Bank_Amount", TypeName = "decimal(18, 2)")]
        public decimal? BankAmount { get; set; }
        [Column("Acc_Account_Cash")]
        public long? AccAccountCash { get; set; }
        [Column("Acc_Account_Bank")]
        public long? AccAccountBank { get; set; }
        [Column("Sys_App_Type_Id")]
        public int? SysAppTypeId { get; set; }
        [Column("ISPosted")]
        public bool? Isposted { get; set; }
    }
}
