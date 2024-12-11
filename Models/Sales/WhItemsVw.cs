using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Keyless]
    public partial class WhItemsVw
    {
        [Column("ID")]
        public long Id { get; set; }
        [Column("Item_Code")]
        [StringLength(250)]
        public string? ItemCode { get; set; }
        [Column("Item_Name")]
        [StringLength(2500)]
        public string? ItemName { get; set; }
        [Column("Item_Name2")]
        [StringLength(2500)]
        public string? ItemName2 { get; set; }
        [Column("Cat_ID")]
        public long? CatId { get; set; }
        [Column("Status_Id")]
        public int? StatusId { get; set; }
        [StringLength(50)]
        public string? CustomerCode { get; set; }
        [StringLength(50)]
        public string? BarCode { get; set; }
        [StringLength(1500)]
        public string? ImgItem { get; set; }
        [StringLength(50)]
        public string? AllowOver { get; set; }
        [StringLength(50)]
        public string? AllowDown { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? PriceSale { get; set; }
        public int? UnitItemId { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? AllowOverDiscount { get; set; }
        [StringLength(150)]
        public string? UnitName { get; set; }
        [Column("Account_ID")]
        public long? AccountId { get; set; }
        [Column("Authorize_negative_stock")]
        public bool? AuthorizeNegativeStock { get; set; }
        [Column("Valuation_costing")]
        public int? ValuationCosting { get; set; }
        [Column("Purchase_Price", TypeName = "decimal(18, 3)")]
        public decimal? PurchasePrice { get; set; }
        [Column("Item_Type")]
        public int? ItemType { get; set; }
        [Column("Facility_ID")]
        public long? FacilityId { get; set; }
        [Column("CC_ID")]
        public long? CcId { get; set; }
        [Column("CostCenter_Code")]
        [StringLength(50)]
        public string? CostCenterCode { get; set; }
        [Column("CostCenter_Name")]
        [StringLength(150)]
        public string? CostCenterName { get; set; }
        [Column("Acc_Account_Name")]
        [StringLength(255)]
        public string? AccAccountName { get; set; }
        [Column("Acc_Account_Code")]
        [StringLength(50)]
        public string? AccAccountCode { get; set; }
        [Column("Item_Type2_Name")]
        [StringLength(250)]
        public string? ItemType2Name { get; set; }
        [Column("Year_Name")]
        [StringLength(250)]
        public string? YearName { get; set; }
        [Column("Color_name")]
        [StringLength(250)]
        public string? ColorName { get; set; }
        [Column("Manufacture_Country")]
        public int? ManufactureCountry { get; set; }
        [Column("Manufacturing_Year")]
        [StringLength(50)]
        public string? ManufacturingYear { get; set; }
        [Column("External_Color")]
        public int? ExternalColor { get; set; }
        [Column("Enternal_Color")]
        public int? EnternalColor { get; set; }
        [Column("Seats_Color")]
        public int? SeatsColor { get; set; }
        [Column("Item_Type2")]
        public int? ItemType2 { get; set; }
        public string? Note { get; set; }
        [Column("Cat_Name")]
        [StringLength(2500)]
        public string? CatName { get; set; }
        [Column("Parent_Name")]
        [StringLength(2500)]
        public string? ParentName { get; set; }
        [Column("Country_name")]
        [StringLength(250)]
        public string? CountryName { get; set; }
        [Column("Parent_ID")]
        public long? ParentId { get; set; }
        [Column("Parent_Parent_ID")]
        public long? ParentParentId { get; set; }
        [Column("VAT_Enable")]
        public bool? VatEnable { get; set; }
        [Column("VAT_ID")]
        public long? VatId { get; set; }
        [Column("Supplier_ID")]
        public long? SupplierId { get; set; }
        [Column("Supplier_Code")]
        [StringLength(250)]
        public string? SupplierCode { get; set; }
        [Column("Supplier_Name")]
        [StringLength(2500)]
        public string? SupplierName { get; set; }
        [Column("Avg_Unit_Cost", TypeName = "decimal(18, 3)")]
        public decimal? AvgUnitCost { get; set; }
        public bool? PriceIncludeVat { get; set; }
        [Column("VAT_Rate", TypeName = "decimal(18, 2)")]
        public decimal? VatRate { get; set; }
        [Column("Has_Serial_No")]
        public bool? HasSerialNo { get; set; }
        [Column("Cat_Code")]
        [StringLength(50)]
        public string? CatCode { get; set; }
        [Column("Cat_Color")]
        [StringLength(50)]
        public string? CatColor { get; set; }
        [Column("ISWeighed")]
        public bool? Isweighed { get; set; }
    }
}
