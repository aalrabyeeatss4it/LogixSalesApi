namespace LogixApi_v02.ViewModels.Sales
{
    public class CountsVM
    {
        public int TransTypeId { get; set; }
        public string? TransTypeName { get; set; }
        public int Count { get; set; }
        public long? FacilityId { get; set; }
        public long? EmpId { get; set; }

        public string? Date1 { get; set; }

        //   public IEnumerable<TransactionVM> Sales_BillsCounts { get; set; }


    }

   



}
