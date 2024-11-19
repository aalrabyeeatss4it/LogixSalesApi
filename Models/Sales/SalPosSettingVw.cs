using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Keyless]
    public partial class SalPosSettingVw
    {
        [Column("ID")]
        public long Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Code { get; set; }
        [Column("Branch_ID")]
        public int? BranchId { get; set; }
        [Column("CustomerID")]
        public int? CustomerId { get; set; }
        [Column("Inventory_ID")]
        public int? InventoryId { get; set; }
        [Column("Facility_ID")]
        public int? FacilityId { get; set; }
        [Column("Currency_ID")]
        public int? CurrencyId { get; set; }
        [Column("Exchange_Rate", TypeName = "decimal(18, 10)")]
        public decimal? ExchangeRate { get; set; }
        [Column("Printer_Name")]
        public string? PrinterName { get; set; }
        [Column("Cash_Account_ID")]
        public long? CashAccountId { get; set; }
        [Column("Bank_Account_ID")]
        public long? BankAccountId { get; set; }
        [Column("Lnk_Inventory")]
        public bool? LnkInventory { get; set; }
        [Column("Drawer_Port_No")]
        [StringLength(50)]
        public string? DrawerPortNo { get; set; }
        [Column("Drawer_Code")]
        [StringLength(50)]
        public string? DrawerCode { get; set; }
        public bool? IsDeleted { get; set; }
        [Column("BRA_NAME")]
        public string? BraName { get; set; }
        [StringLength(50)]
        public string? InventoryName { get; set; }
        [Column("CustomerCodeVW")]
        [StringLength(250)]
        public string? CustomerCodeVw { get; set; }
        [Column("CustomerNameVW")]
        [StringLength(2500)]
        public string? CustomerNameVw { get; set; }
        [Column("Bank_ID")]
        public long? BankId { get; set; }
        public string? Header { get; set; }
        public string? Footer { get; set; }
        public int? CountPrinter { get; set; }
        [StringLength(50)]
        public string? CustomerCode { get; set; }
        [StringLength(50)]
        public string? CustomerName { get; set; }
        [Column("Bank_Name")]
        [StringLength(255)]
        public string? BankName { get; set; }
        [Column("Cach_on_Ohda_Name")]
        [StringLength(250)]
        public string? CachOnOhdaName { get; set; }
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
        public bool? Online { get; set; }
        [Column("Increment_Qty")]
        public bool? IncrementQty { get; set; }
        [Column("Lnk_Accounting")]
        public long? LnkAccounting { get; set; } 
        [Column("Pos_Type")]
        public int? PosType { get; set; }
    }
}
