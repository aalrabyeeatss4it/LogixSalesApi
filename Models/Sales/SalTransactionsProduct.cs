using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Table("SAL_Transactions_Products")]
    public partial class SalTransactionsProduct
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Column("Transaction_ID")]
        public long? TransactionId { get; set; }
        [Column("Product_ID")]
        public long? ProductId { get; set; }
        [Column("Unit_ID")]
        public long? UnitId { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Qty { get; set; }
        [Column("Disc_rate", TypeName = "decimal(18, 2)")]
        public decimal? DiscRate { get; set; }
        [Column("Discount_Amount", TypeName = "decimal(18, 2)")]
        public decimal? DiscountAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Total { get; set; }
        [Column("VAT", TypeName = "decimal(18, 2)")]
        public decimal? Vat { get; set; }
        [Column("Branch_ID")]
        public int? BranchId { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("Account_ID")]
        public long? AccountId { get; set; }
        [Column("CC_ID")]
        public long? CcId { get; set; }//مركز التكلفة
        [Column("Currency_ID")]
        public int? CurrencyId { get; set; }
        [Column("Exchange_Rate", TypeName = "decimal(18, 10)")]
        public decimal? ExchangeRate { get; set; }
        [Column("VAT_Amount", TypeName = "decimal(18, 2)")]
        public decimal? VatAmount { get; set; }
        [Column("Unit_Cost", TypeName = "decimal(18, 2)")]
        public decimal? UnitCost { get; set; }
        [Column("Type_ID")]
        public int? TypeId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Equivalent { get; set; }
        [Column("Batch_ID")]
        public long? BatchId { get; set; }
        [Column("Sal_T_ID")]
        public long? SalTId { get; set; }
        [Column("Sal_P_ID")]
        public long? SalPId { get; set; }
        [Column("Inventory_ID")]
        public long? InventoryId { get; set; }
    }


}
