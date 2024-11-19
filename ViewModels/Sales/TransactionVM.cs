using LogixApi_v02.ViewModels.sales;
using System.ComponentModel.DataAnnotations;

namespace LogixApi_v02.ViewModels.Sales
{
    public class TransactionQuaryVM
    {
        public TransactionVM TransactionVM { get; set; }
        public List<TransProductsVM> ProductsVMs  { get; set; }
    } 
    public class TransactionVM
    {
        [StringLength(2500)]

        public long Id { get; set; }

        public long? FacilityId { get; set; }
        public string? Customer_Name { get; set; }

        public string? IdNo { get; set; }
        public string? ExpirationDate { get; set; }

        public string? Code { get; set; }
        public DateTime? CreatedOn { get; set; }

        public int? Payment_Terms_ID { get; set; }

        public string? PaymentTerms { get; set; }

        public decimal? Total { get; set; }
        public decimal? Net { get; set; }

        public decimal? Subtotal { get; set; }
        public decimal? VatAmount { get; set; }
        public string? BraName { get; set; }
        public decimal? DiscountAmount { get; set; }

        public string? Date1 { get; set; } 

        public decimal? AmountCost { get; set; }
        public decimal? CashAmount { get; set; }
        public decimal? BankAmount { get; set; }
        public int? TransTypeId { get; set; }
        public long? CreatedBy { get; set; }
        public long? EmpId { get; set; }

        public int? SalesType { get; set; }

    }
    }

