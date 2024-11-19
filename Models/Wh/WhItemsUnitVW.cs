using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.Models.Wh
{
    [Keyless]
    public partial class WhItemsUnitVw
    {
        [StringLength(150)]
        public string? UnitName { get; set; }
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
        [Column("Valuation_costing")]
        public int? ValuationCosting { get; set; }
        [Column("Authorize_negative_stock")]
        public bool? AuthorizeNegativeStock { get; set; }
        [Column("Account_ID")]
        public long? AccountId { get; set; }
        [Column("Facility_ID")]
        public long? FacilityId { get; set; }
        [Column("CC_ID")]
        public long? CcId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? AllowOverDiscount { get; set; }
        [StringLength(50)]
        public string? AllowOver { get; set; }
        [StringLength(50)]
        public string? AllowDown { get; set; }
        [StringLength(1500)]
        public string? ImgItem { get; set; }
        [Column("Item_Type")]
        public int? ItemType { get; set; }
        [Column("Unit_ID")]
        public int? UnitId { get; set; }
        [Column("Item_ID")]
        public long? ItemId { get; set; }
        [StringLength(250)]
        public string? Barcode { get; set; }
        [Column(TypeName = "decimal(18, 5)")]
        public decimal? Equivalent { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PriceSale { get; set; }
        [Column("Purchase_Price", TypeName = "decimal(18, 2)")]
        public decimal? PurchasePrice { get; set; }
        [Column("ID")]
        public long Id { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("Cat_Name")]
        [StringLength(2500)]
        public string? CatName { get; set; }
        public int? UnitItemId { get; set; }
        [Column("Item_Code")]
        [StringLength(250)]
        public string? ItemCode { get; set; }
        public bool? Expr1 { get; set; }
        [Column("VAT_Rate", TypeName = "decimal(18, 2)")]
        public decimal? VatRate { get; set; }
        [Column("VAT_ID")]
        public long? VatId { get; set; }
        [Column("Fixed_Or_Variable")]
        public int? FixedOrVariable { get; set; }
        public bool? IsDefault { get; set; }
        [Column("Supplier_Code")]
        [StringLength(250)]
        public string? SupplierCode { get; set; }
        [Column("Supplier_Name")]
        [StringLength(2500)]
        public string? SupplierName { get; set; }
        [Column("Supplier_ID")]
        public long? SupplierId { get; set; }
        public bool? PriceIncludeVat { get; set; }
        [Column("IU_ID")]
        public long IuId { get; set; }
        [Column("Has_Serial_No")]
        public bool? HasSerialNo { get; set; }
        [Column("Parent_ID")]
        public long? ParentId { get; set; }
    }
}
