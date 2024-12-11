using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Keyless]
    public partial class SalTransactionsProductsVw
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("Transaction_ID")]
        public long? TransactionId { get; set; }
        [Column("Product_ID")]
        public long? ProductId { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Qty { get; set; }
        [Column("Disc_rate", TypeName = "decimal(18, 2)")]
        public decimal? DiscRate { get; set; }
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
        public long? CcId { get; set; }
        [Column("Item_Code")]
        [StringLength(250)]
        public string? ItemCode { get; set; }
        [Column("Item_Name")]
        [StringLength(2500)]
        public string? ItemName { get; set; }
        [Column("Cat_Name")]
        [StringLength(2500)]
        public string? CatName { get; set; }
        [Column("Trans_Type_ID")]
        public int? TransTypeId { get; set; }
        public bool? IsDeletedM { get; set; }
        [Column("IsDeletedItem_Unit")]
        public bool? IsDeletedItemUnit { get; set; }
        [Column("CustomerID")]
        public long? CustomerId { get; set; }
        [StringLength(10)]
        public string? Date1 { get; set; }
        [Column("Expiration_Date")]
        [StringLength(10)]
        public string? ExpirationDate { get; set; }
        [Column("Due_Date")]
        [StringLength(10)]
        public string? DueDate { get; set; }
        [Column("Delivery_Date")]
        [StringLength(10)]
        public string? DeliveryDate { get; set; }
        [Column("Inventory_ID")]
        public int? InventoryId { get; set; }
        [Column("Emp_ID")]
        public long? EmpId { get; set; }
        [StringLength(50)]
        public string? Code { get; set; }
        [Column("Unit_ID")]
        public long? UnitId { get; set; }
        [Column("Discount_Amount", TypeName = "decimal(18, 2)")]
        public decimal? DiscountAmount { get; set; }
        [StringLength(2500)]
        public string? CustomerName { get; set; }
        [StringLength(250)]
        public string? CustomerCode { get; set; }
        [Column("Emp_Code")]
        [StringLength(50)]
        public string? EmpCode { get; set; }
        [Column("Emp_name")]
        [StringLength(250)]
        public string? EmpName { get; set; }
        [Column("Cat_ID")]
        public long? CatId { get; set; }
        [StringLength(2500)]
        public string? RecipientName { get; set; }
        [StringLength(2500)]
        public string? Address { get; set; }
        [StringLength(50)]
        public string? Phone { get; set; }
        [StringLength(500)]
        public string? Waybill { get; set; }
        [Column("Discount_Amount_M", TypeName = "decimal(18, 2)")]
        public decimal? DiscountAmountM { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Subtotal { get; set; }
        [Column("Discount_Rate_M", TypeName = "decimal(18, 2)")]
        public decimal? DiscountRateM { get; set; }
        [Column("Payment_Terms_Name")]
        public string? PaymentTermsName { get; set; }
        [Column("Payment_Terms")]
        [StringLength(50)]
        public string? PaymentTerms { get; set; }
        [Column("Document_Note")]
        public string? DocumentNote { get; set; }
        [Column("Delivery_Term")]
        public string? DeliveryTerm { get; set; }
        [Column("Facility_ID")]
        public long? FacilityId { get; set; }
        [Column("Amount_Paid", TypeName = "decimal(18, 2)")]
        public decimal? AmountPaid { get; set; }
        [Column("Amount_Remaining", TypeName = "decimal(18, 2)")]
        public decimal? AmountRemaining { get; set; }
        [StringLength(150)]
        public string? UnitName { get; set; }
        [Column("PO_Number")]
        [StringLength(50)]
        public string? PoNumber { get; set; }
        [Column("Purchase_Price", TypeName = "decimal(18, 2)")]
        public decimal? PurchasePrice { get; set; }
        [Column("VAT_Amount", TypeName = "decimal(18, 2)")]
        public decimal? VatAmount { get; set; }
        [Column("VAT_AmountM", TypeName = "decimal(18, 2)")]
        public decimal? VatAmountM { get; set; }
        [Column("Cus_VAT_Number")]
        [StringLength(250)]
        public string? CusVatNumber { get; set; }
        [Column("Fac_VAT_Number")]
        [StringLength(250)]
        public string? FacVatNumber { get; set; }
        [Column("Amount_Cost", TypeName = "decimal(18, 2)")]
        public decimal? AmountCost { get; set; }
        [Column("Unit_Cost", TypeName = "decimal(18, 2)")]
        public decimal? UnitCost { get; set; }
        [Column("VAT_ID")]
        public long? VatId { get; set; }
        public int? Expr3 { get; set; }
        [Column(TypeName = "decimal(38, 4)")]
        public decimal? Profit { get; set; }
        [Column("Transaction_Type_name")]
        [StringLength(50)]
        public string? TransactionTypeName { get; set; }
        [Column("Trans_Type_Code")]
        [StringLength(50)]
        public string? TransTypeCode { get; set; }
        [Column("Trans_Type_Name")]
        [StringLength(50)]
        public string? TransTypeName { get; set; }
        [Column("Trans_Type_Name2")]
        [StringLength(50)]
        public string? TransTypeName2 { get; set; }
        [StringLength(2550)]
        public string? CustomerName2 { get; set; }
        public long? No { get; set; }
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? NewTotal { get; set; }
        [Column("Project_Code")]
        public long? ProjectCode { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Equivalent { get; set; }
        [Column("POS_ID")]
        public long? PosId { get; set; }
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? NewSubtotal { get; set; }
        [Column("Due_Period_Days")]
        public int? DuePeriodDays { get; set; }
        [Column("Safety_Period_Days")]
        public int? SafetyPeriodDays { get; set; }
        [Column("Safety_Date")]
        [StringLength(10)]
        public string? SafetyDate { get; set; }
        [Column("Type_ID")]
        public int? TypeId { get; set; }
        [Column("Type_Name")]
        [StringLength(250)]
        public string? TypeName { get; set; }
        [Column("Sales_Area_Name")]
        [StringLength(500)]
        public string? SalesAreaName { get; set; }
        [Column("Payment_Terms_ID")]
        public int? PaymentTermsId { get; set; }
        [Column("Refrance_ID")]
        public long? RefranceId { get; set; }
        [Column("Batch_ID")]
        public long? BatchId { get; set; }
        [Column("Batch_Code")]
        [StringLength(2511)]
        public string? BatchCode { get; set; }
        [Column("Supplier_Code")]
        [StringLength(250)]
        public string? SupplierCode { get; set; }
        [Column("Supplier_Name")]
        [StringLength(2500)]
        public string? SupplierName { get; set; }
        [Column("Supplier_ID")]
        public long? SupplierId { get; set; }
        [Column("Sal_T_ID")]
        public long? SalTId { get; set; }
        [Column("Sal_P_ID")]
        public long? SalPId { get; set; }
        [Column("Amount_Write")]
        [StringLength(1)]
        [Unicode(false)]
        public string AmountWrite { get; set; } = null!;
        [Column("Amount_WriteE")]
        [StringLength(1)]
        [Unicode(false)]
        public string AmountWriteE { get; set; } = null!;
        [Column("Has_Reservation")]
        public bool? HasReservation { get; set; }
        [Column("Mobile_Cus")]
        [StringLength(50)]
        public string? MobileCus { get; set; }
        [StringLength(50)]
        public string? InventoryName { get; set; }
        [Column("Inventory_D_ID")]
        public long? InventoryDId { get; set; }
        [Column("Inventory_D_Name")]
        [StringLength(50)]
        public string? InventoryDName { get; set; }
        [Column("Cash_Amount", TypeName = "decimal(18, 2)")]
        public decimal? CashAmount { get; set; }
        [Column("Bank_Amount", TypeName = "decimal(18, 2)")]
        public decimal? BankAmount { get; set; }
        [Column("Net_Total_Write")]
        [StringLength(1000)]
        public string? NetTotalWrite { get; set; }
        [Column("Item_Name2")]
        [StringLength(2500)]
        public string? ItemName2 { get; set; }
        [Column("Inventory_D_Name2")]
        [StringLength(50)]
        public string? InventoryDName2 { get; set; }
        [Column("Customer_Address")]
        public string? CustomerAddress { get; set; }
        [Column("Customer_ID_No")]
        [StringLength(50)]
        public string? CustomerIdNo { get; set; }
        [Column("Customer_Email")]
        [StringLength(50)]
        public string? CustomerEmail { get; set; }
        [Column("Fac_ID_Number")]
        [StringLength(50)]
        public string? FacIdNumber { get; set; }
        [Column("Payment_Terms2")]
        [StringLength(50)]
        public string? PaymentTerms2 { get; set; }
        [Column("Parent_ID")]
        public long? ParentId { get; set; }
        [Column("BRA_NAME")]
        public string? BraName { get; set; }
        [StringLength(20)]
        public string? Mobile { get; set; }
        [Column("CostCenter_Name")]
        [StringLength(150)]
        public string? CostCenterName { get; set; }
        [Column("CostCenter_Code")]
        [StringLength(50)]
        public string? CostCenterCode { get; set; }
        [Column("CostCenter_Name2")]
        [StringLength(150)]
        public string? CostCenterName2 { get; set; }
        [Column("City_Name")]
        [StringLength(500)]
        public string? CityName { get; set; }
        [Column("City_Code")]
        [StringLength(50)]
        public string? CityCode { get; set; }
        [Column("City_ID")]
        public int? CityId { get; set; }
        [Column("Manager_ID")]
        public long? ManagerId { get; set; }
        [Column("Manager_Code")]
        [StringLength(50)]
        public string? ManagerCode { get; set; }
        [Column("Manager_Name")]
        [StringLength(250)]
        public string? ManagerName { get; set; }
        [Column("Currency_ID")]
        public int? CurrencyId { get; set; }
        [Column("Exchange_Rate", TypeName = "decimal(18, 10)")]
        public decimal? ExchangeRate { get; set; }
        [Column("Item_Type")]
        public int? ItemType { get; set; }
        [Column(TypeName = "decimal(18, 5)")]
        public decimal? EquivalentUnit { get; set; }
        [StringLength(150)]
        public string? UnitNameDefault { get; set; }
        [Column("BRA_MOBILE")]
        [StringLength(50)]
        public string? BraMobile { get; set; }
        [Column("BRA_ADDRESS")]
        public string? BraAddress { get; set; }
        [Column("Additional_Amount", TypeName = "decimal(18, 2)")]
        public decimal? AdditionalAmount { get; set; }
    }
}
