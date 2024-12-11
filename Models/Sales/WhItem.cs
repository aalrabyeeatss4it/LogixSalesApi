using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Table("Wh_Items")]
    public partial class WhItem
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        /// <summary>
        /// 1 products 2 services
        /// </summary>
        [Column("Item_Type")]
        public int? ItemType { get; set; }
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
        [Column("Purchase_Price", TypeName = "decimal(18, 3)")]
        public decimal? PurchasePrice { get; set; }
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
        /// <summary>
        /// 1 products 2 services
        /// </summary>
        [Column("Item_Type2")]
        public int? ItemType2 { get; set; }
        public string? Note { get; set; }
        [Column("VAT_Enable")]
        public bool? VatEnable { get; set; }
        [Column("VAT_ID")]
        public long? VatId { get; set; }
        [Column("Supplier_ID")]
        public long? SupplierId { get; set; }
        [Column("Level_Item")]
        public int? LevelItem { get; set; }
        [Column("Parent_ID")]
        public int? ParentId { get; set; }
        [Column("Parent_Code")]
        [StringLength(50)]
        public string? ParentCode { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Equivalent { get; set; }
        [Column("Has_Batch_No")]
        public bool? HasBatchNo { get; set; }
        [Column("Avg_Unit_Cost", TypeName = "decimal(18, 3)")]
        public decimal? AvgUnitCost { get; set; }
        public bool? PriceIncludeVat { get; set; }
        [Column("Has_Serial_No")]
        public bool? HasSerialNo { get; set; }
        [Column("ISWeighed")]
        public bool? Isweighed { get; set; }
    }
}
