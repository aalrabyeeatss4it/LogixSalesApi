namespace LogixApi_v02.ViewModels.Sales
{
    public class EmployeeTarget
    {
        public string? EmpCode { get; set; }
        public string? EmpName { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Debit_Memo { get; set; }
        public decimal TargetValue { get; set; }
        public decimal Percentage { get; set; }

        // Constructor to set default values
        public EmployeeTarget()
        {
            // Set default values here
            EmpCode = ""; // You can change this to the default value you want
            EmpName = ""; // You can change this to the default value you want
            Subtotal = 0;
            DiscountAmount = 0;
            Debit_Memo = 0;
            TargetValue = 0;
            Percentage = 0;
        }
    }
}
