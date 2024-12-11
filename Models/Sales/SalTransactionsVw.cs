using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Models.Sales
{
    [Keyless]
    public partial class SalTransactionsVw
    {
        [StringLength(2500)]
        public string? CustomerName { get; set; }
        
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
        [Column("Refrance_ID")]
        public long? RefranceId { get; set; }
        [StringLength(250)]
        public string? CustomerCode { get; set; }
        [Column("Payment_Terms")]
        [StringLength(50)]
        public string? PaymentTerms { get; set; }
        
        [Column("BRA_NAME")]
        public string? BraName { get; set; }

        [Column("Project_Name")]
        [StringLength(2500)]
        public string? ProjectName { get; set; }
        [Column("Project_Name2")]
        [StringLength(2500)]
        public string? ProjectName2 { get; set; }
        [Column("Due_Date")]
        [StringLength(10)]
        public string? DueDate { get; set; }
        [Column("Project_Code")]
        public long? ProjectCode { get; set; }
        [Column("Contract_ID")]
        public long? ContractId { get; set; }
        [Column("Invoice_Month")]
        [StringLength(50)]
        public string? InvoiceMonth { get; set; }
        [Column("Service_Render")]
        public int? ServiceRender { get; set; }
        [Column("Name_Service")]
        [StringLength(250)]
        public string? NameService { get; set; }
        [Column("Payment_Terms_Name")]
        public string? PaymentTermsName { get; set; }
        [Column("Delivery_Term")]
        public string? DeliveryTerm { get; set; }
        [Column("Inventory_ID")]
        public int? InventoryId { get; set; }
        [Column("Emp_ID")]
        public long? EmpId { get; set; }
        [Column("Facility_ID")]
        public long? FacilityId { get; set; }
        [Column("Emp_ID2")]
        public long? EmpId2 { get; set; }
        [StringLength(500)]
        public string? Waybill { get; set; }
        [StringLength(50)]
        public string? Phone { get; set; }
        [Column("Emp_name")]
        [StringLength(250)]
        public string? EmpName { get; set; }
        [Column("Emp_Code")]
        [StringLength(50)]
        public string? EmpCode { get; set; }
        [Column("Emp_Code2")]
        [StringLength(50)]
        public string? EmpCode2 { get; set; }
        [Column("Emp_Name2")]
        [StringLength(250)]
        public string? EmpName2 { get; set; }
        [Column("Currency_ID")]
        public int? CurrencyId { get; set; }
        [Column("Exchange_Rate", TypeName = "decimal(18, 10)")]
        public decimal? ExchangeRate { get; set; }
        [StringLength(50)]
        public string? InventoryName { get; set; }
        public int AmountPaid { get; set; }
        [Column("POS_ID")]
        public long? PosId { get; set; }
        [Column("USER_FULLNAME")]
        [StringLength(50)]
        public string? UserFullname { get; set; }
        [StringLength(50)]
        public string? Mobile { get; set; }
        [Column("Amount_Paid", TypeName = "decimal(18, 2)")]
        public decimal? AmountPaid1 { get; set; }
        [Column("Amount_Remaining", TypeName = "decimal(18, 2)")]
        public decimal? AmountRemaining { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Points { get; set; }
        [Column("Cus_Type_Id")]
        public int? CusTypeId { get; set; }
        [Column("Group_ID")]
        public int? GroupId { get; set; }
        [Column("User_Emp_Code")]
        [StringLength(50)]
        public string? UserEmpCode { get; set; }
        
        [Column("VAT_Amount", TypeName = "decimal(18, 2)")]
        
       public decimal? VatAmount { get; set; }
       
        [Column("Cus_VAT_Number")]
        [StringLength(250)]
        public string? CusVatNumber { get; set; }
        [Column("Fac_VAT_Number")]
        [StringLength(250)]
        public string? FacVatNumber { get; set; }
        
        [Column("Amount_Cost", TypeName = "decimal(18, 2)")]
        public decimal? AmountCost { get; set; }
       
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
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? NewSubtotal { get; set; }
        [Column("Due_Period_Days")]
        public int? DuePeriodDays { get; set; }
        [Column("Safety_Period_Days")]
        public int? SafetyPeriodDays { get; set; }
        [Column("Safety_Date")]
        [StringLength(10)]
        public string? SafetyDate { get; set; }
        [Column("App_ID")]
        public long? AppId { get; set; }
        [Column("VAT_Enable")]
        public bool? VatEnable { get; set; }
        [Column("CC_ID")]
        public long? CcId { get; set; }
        [Column("Return_Type")]
        public int? ReturnType { get; set; }
        [Column("Return_Account_ID")]
        public long? ReturnAccountId { get; set; }
        [Column("Sales_Area")]
        public int? SalesArea { get; set; }
        [Column("Sales_Area_Name")]
        [StringLength(500)]
        public string? SalesAreaName { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [StringLength(50)]
        public string? Email2 { get; set; }
        [Column("Group_Name")]
        [StringLength(50)]
        public string? GroupName { get; set; }
        [Column("Project_Value", TypeName = "decimal(18, 4)")]
        public decimal? ProjectValue { get; set; }
        [Column("CostCenter_Code")]
        [StringLength(50)]
        public string? CostCenterCode { get; set; }
        [Column("CostCenter_Name")]
        [StringLength(150)]
        public string? CostCenterName { get; set; }
        [Column("CostCenter_Name2")]
        [StringLength(150)]
        public string? CostCenterName2 { get; set; }
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
        [Column("Cust_Branch_ID")]
        public int? CustBranchId { get; set; }
        [Column("User_Emp_Name")]
        [StringLength(250)]
        public string? UserEmpName { get; set; }
        [Column("User_Emp_ID")]
        public int? UserEmpId { get; set; }
        [Column("BRA_NAME2")]
        public string? BraName2 { get; set; }
        [Column("Payment_Terms2")]
        [StringLength(50)]
        public string? PaymentTerms2 { get; set; }
        [Column("Emp_name_EN2")]
        [StringLength(250)]
        public string? EmpNameEn2 { get; set; }
        [Column("Emp_name_EN")]
        [StringLength(250)]
        public string? EmpNameEn { get; set; }
        [Column("Customer_Address")]
        public string? CustomerAddress { get; set; }
        [Column("Customer_ID_No")]
        [StringLength(50)]
        public string? CustomerIdNo { get; set; }
        [Column("Fac_ID_Number")]
        [StringLength(50)]
        public string? FacIdNumber { get; set; }
        [Column("Emp_Mobile")]
        [StringLength(20)]
        public string? EmpMobile { get; set; }
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
        [Column("ISPosted")]
        public bool? Isposted { get; set; }
        [Column("Sys_App_Type_Id")]
        public int? SysAppTypeId { get; set; }
        [Column("BRA_MOBILE")]
        [StringLength(50)]
        public string? BraMobile { get; set; }
        [Column("BRA_ADDRESS")]
        public string? BraAddress { get; set; }
       
    }
}
