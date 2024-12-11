using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace LogixApi_v02.Models
{
    [Keyless]
    public partial class WhItemsInventoryVw
    {
        [StringLength(50)]
        public string? InventoryName { get; set; }
        [Column("ID")]
        public long Id { get; set; }
        [Column("Item_ID")]
        public long? ItemId { get; set; }
        [Column("Inventory_ID")]
        public long? InventoryId { get; set; }
        [Column("Re_order_Level", TypeName = "decimal(18, 2)")]
        public decimal? ReOrderLevel { get; set; }
        [Column("Re_order_Qty", TypeName = "decimal(18, 2)")]
        public decimal? ReOrderQty { get; set; }
        [Column("Request_Type")]
        public int? RequestType { get; set; }
        public long? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("Branch_ID")]
        public int? BranchId { get; set; }
        [Column("Branchs_ID")]
        public string? BranchsId { get; set; }
        [Column("Cat_ID")]
        public long? CatId { get; set; }
        [Column("Item_Code")]
        [StringLength(250)]
        public string? ItemCode { get; set; }
        [Column("Item_Name")]
        [StringLength(2500)]
        public string? ItemName { get; set; }
        [Column("Item_Name2")]
        [StringLength(2500)]
        public string? ItemName2 { get; set; }
        public bool? PriceIncludeVat { get; set; }
        public string? Sku { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? PriceSale { get; set; }
        [Column("Purchase_Price", TypeName = "decimal(18, 3)")]
        public decimal? PurchasePrice { get; set; }
        [Column("Valuation_costing")]
        public int? ValuationCosting { get; set; }
        public int? UnitItemId { get; set; }
    }
}