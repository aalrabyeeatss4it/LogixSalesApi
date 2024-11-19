namespace LogixApi_v02.ViewModels.Sales
{
    public class TransDetailsWithQr
    {
       public TransDetailsWithProductsVM TransactionsDetails { get; set; }
       public string QrText { get; set; }
       public string VatNumber { get; set; }
       public string FacilityAddress { get; set; }
       public string FacilityLogo { get; set; }
    }
}
