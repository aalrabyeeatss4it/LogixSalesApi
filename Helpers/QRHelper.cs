using System;
using System.Drawing.Imaging;
using System.Globalization;
using TextToQRImagePackage;
using ZXing;
using ZXing.Aztec.Internal;
using ZXing.QrCode.Internal;

namespace LogixApi_v02.Helpers
{
    public static class QRHelper
    {
        public static string GenerateQRforZATCA(long transactionId, string companyName, string vatNumber, decimal totalWithoutVat, decimal discount, decimal vatAmount, string tDate, string code)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                string codeText = "";
                decimal total = totalWithoutVat - discount + vatAmount;
                ZATCA objZATCo = new ZATCA(companyName, vatNumber, DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss"), (double)total, (double)vatAmount);
                codeText = objZATCo.ToBase64();

                string qrName = transactionId.ToString();
                string ext = "jpg";
                string currentPath = Directory.GetCurrentDirectory();
                string folderName = Path.Combine(currentPath, "Files", "QRCode", "Sales", "ZATCA");
                //string qrCodePath = Path.Combine(folderName, $"{qrName}.{ext}");
                var qrModel = new QRModel(objZATCo.ToBase64(), folderName, qrName, ext: ext);
                var res = QRGenerator.GenerateImage(qrModel);




                return res;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string GenerateQRforInvoice(long transactionId, string companyName, string vatNumber, decimal totalWithoutVat, decimal discount, decimal vatAmount, string tDate, string code)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                string codeText = "";
                decimal total = totalWithoutVat - discount + vatAmount;
                codeText = "المورد: " + companyName + "\n" +
                           "رقم تسجيل ضريبة القيمة المضافة للمورد: " + vatNumber + "\n" +
                           "تاريخ ووقت الفاتورة: " + tDate + " - " + DateTime.Now.ToString("hh:mm:ss") + "\n" +
                           "إجمالي ضريبة القيمة المضافة: " + vatAmount + "\n" +
                           "إجمالي الفاتورة مع ضريبة القيمة المضافة: " + total;

                string qrName = transactionId.ToString();
                string ext = "jpg";
                string currentPath = Directory.GetCurrentDirectory();
                string folderName = Path.Combine(currentPath, "Files", "QRCode", "Sales", "Invoice");
                //string qrCodePath = Path.Combine(folderName, $"{qrName}.{ext}");

                var qrModel = new QRModel(codeText, folderName, qrName, ext: ext);


                var res = QRGenerator.GenerateImage(qrModel);
                return res;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }


        public static async Task<int> GenerateQRWebService(string url, long tranId,string token, string userId)
        {
            int StatusCode=0;
            try {
                using (HttpClient client = new HttpClient())
                {
                    // Specify the URL of the web service
                    string apiUrl = url+"/WebService/SalesServices.asmx/CreateQRCode?Transaction_ID="+tranId;

                    // Add headers to the request
                    client.DefaultRequestHeaders.Add("token", token);
                    client.DefaultRequestHeaders.Add("USER_ID", userId);

        client.Timeout = TimeSpan.FromSeconds(30);
                    // Send GET request and receive response
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and deserialize the response content if needed
                        var responseData = await response.Content.ReadAsStringAsync();

                        // Do something with the data (e.g., print it)
                        Console.WriteLine(responseData);
                         StatusCode = (int)response.StatusCode;

                        return (int)response.StatusCode;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");

                        return (int)response.StatusCode;
                    }
                }
               
            }catch (Exception) { 
            }

            return StatusCode;
        }
    }
}
