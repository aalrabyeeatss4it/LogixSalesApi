
using LogixApi_v02.DbContexts;
using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LogixApi_v02.Repositories.Sales
{
    public class SalTransactionRepository : GenericRepository<SalTransaction>, ISalTransactionRepository
    {
        public SalTransactionRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<SalTransactionsVw>> GetAllVW()
        {
            return await _context.SalTransactionsVws.ToListAsync();
        }

        public async Task<long> GetLatestTransactionIdAsync(int posId)
        {
            var latestTransaction = await _context.SalTransactionsVws
                .Where(t => t.PosId == posId)
                .OrderByDescending(t => t.Id)
                .FirstOrDefaultAsync();

            return latestTransaction.Id; // Return null if not found
        }


        public string GenerateToken(string userId)
        {
            try
            {
                int length = 32;
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[length];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                using (SqlConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UPDATE sys_user SET SSO_Token = @SSO_Token, SSO_Token_Expiry_Date = DATEADD(ss, @SecondNumber, GETDATE()) WHERE USER_ID = @USER_ID", connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@SecondNumber", 1111120);
                        command.Parameters.AddWithValue("@SSO_Token", new string(stringChars));
                        command.Parameters.AddWithValue("@USER_ID", userId);

                        command.ExecuteNonQuery();
                    }
                }

                string token = new string(stringChars);
                return token;
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        public async Task<string> AddUsingProcedure(SalTransaction trans)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID", trans.Id),
                new SqlParameter("@No", trans.No),
                new SqlParameter("@Code", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Output
            },
               // new SqlParameter("@Code", trans.Code),
                new SqlParameter("@Facility_ID", trans.FacilityId),
                new SqlParameter("@Trans_Type_ID", trans.TransTypeId),
                new SqlParameter("@Branch_ID", trans.BranchId),
                new SqlParameter("@CustomerID", trans.CustomerId),
                new SqlParameter("@RecipientID", trans.RecipientId),
                new SqlParameter("@RecipientName", trans.RecipientName),
                new SqlParameter("@Contract_ID", trans.ContractId),
                new SqlParameter("@Service_Render", trans.ServiceRender),
                new SqlParameter("@Invoice_Month", trans.InvoiceMonth),
                new SqlParameter("@Address", trans.Address),
                new SqlParameter("@PO_Number", trans.PoNumber),
                new SqlParameter("@Date1", trans.Date1),
                new SqlParameter("@Date2", trans.Date2),
                new SqlParameter("@Due_Date", trans.DueDate),
                new SqlParameter("@Delivery_Date", trans.DeliveryDate),
                new SqlParameter("@Expiration_Date", trans.ExpirationDate),
                new SqlParameter("@Payment_Terms_ID", trans.PaymentTermsId),
                new SqlParameter("@Document_Note", trans.DocumentNote),
                new SqlParameter("@Subtotal", trans.Subtotal),
                new SqlParameter("@Discount_Rate", trans.DiscountRate),
                new SqlParameter("@Discount_Amount", trans.DiscountAmount),
                new SqlParameter("@VAT", trans.Vat),
                new SqlParameter("@Total", trans.Total),
                new SqlParameter("@Delivery_Contact", trans.DeliveryContact),
                new SqlParameter("@Delivery_Address", trans.DeliveryAddress),
                new SqlParameter("@Project_ID", trans.ProjectId),
                new SqlParameter("@Private_Note", trans.PrivateNote),
                new SqlParameter("@CreatedBy", trans.CreatedBy),
                new SqlParameter("@Status_ID", trans.StatusId),
                new SqlParameter("@Refrance_ID", trans.RefranceId),
                new SqlParameter("@Emp_ID", trans.EmpId),
                new SqlParameter("@Inventory_ID", trans.InventoryId),
                new SqlParameter("@Delivery_Term", trans.DeliveryTerm),
                new SqlParameter("@Payment_Terms", trans.PaymentTerms),
                new SqlParameter("@Phone", trans.Phone),
                new SqlParameter("@Waybill", trans.Waybill),
                new SqlParameter("@Emp_ID2", trans.EmpId2),
                new SqlParameter("@Currency_ID", trans.CurrencyId),
                new SqlParameter("@Exchange_Rate", trans.ExchangeRate),
                new SqlParameter("@POS_ID", trans.PosId),
                new SqlParameter("@Amount_Paid", trans.AmountPaid),
                new SqlParameter("@Amount_Remaining", trans.AmountRemaining),
                new SqlParameter("@Points", trans.Points),
                new SqlParameter("@VAT_Amount", trans.VatAmount),
                new SqlParameter("@Due_Period_Days", trans.DuePeriodDays),
                new SqlParameter("@Safety_Period_Days", trans.SafetyPeriodDays),
                new SqlParameter("@Safety_Date", trans.SafetyDate),
                new SqlParameter("@App_ID", trans.AppId),
                new SqlParameter("@Return_Type", trans.ReturnType),
                new SqlParameter("@Return_Account_ID", trans.ReturnAccountId),
                new SqlParameter("@CC_ID", trans.CcId),
                new SqlParameter("@Has_Reservation", trans.HasReservation),
                new SqlParameter("@Cash_Amount", trans.CashAmount),
                new SqlParameter("@Bank_Amount", trans.BankAmount),
                new SqlParameter("@Acc_Account_Cash", trans.AccAccountCash),
                new SqlParameter("@Acc_Account_Bank", trans.AccAccountBank),
                new SqlParameter("@Sys_App_Type_Id", trans.SysAppTypeId)
            };


            var sql = "SAL_Transactions_Add_SP " + String.Join(", ", parameters.Select(x =>
      $"{x.ParameterName} = {x.ParameterName}" +
      (x.Direction == ParameterDirection.Output ? " OUT" : "")
      ));

            var outputId = await _context.Database.ExecuteSqlRawAsync(sql, parameters);

            if (outputId > 0)
            {
                var test = (parameters.First(p => p.Direction == ParameterDirection.Output).Value);
                if (test != null)
                {
                    var code = test.ToString();
                    return code ?? "";
                }
            }

            return "";

        }

        public async Task<EmployeeTarget> GetEmployeeTarget(long facilityId, string empCode,
            int transTypeId, string fromDate, string toDate)
        {

            List<EmployeeTarget> res3 = new List<EmployeeTarget>();
           

            try
            {
                var queryResult = _context.SalTransactionsVws
                .Where(t => t.IsDeleted == false && t.FacilityId == facilityId && t.TransTypeId == transTypeId && t.EmpCode == empCode
                //&& new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13 }.Contains(t.BranchId) &&
                // && DateHelper.StringToDate1(t.Date1) >= DateHelper.StringToDate1(fromDate) && DateHelper.StringToDate1(t.Date1) <= DateHelper.StringToDate1(toDate)

                ).AsEnumerable().Where(r => r.Date1 != null && DateHelper.StringToDate1(r.Date1) >= DateHelper.StringToDate1(fromDate)
                  && DateHelper.StringToDate1(r.Date1) <= DateHelper.StringToDate1(toDate));

                var res2 = queryResult.GroupBy(t => new { t.EmpCode, t.EmpName, t.EmpId })
                 .Where(g => g.Key.EmpCode == empCode);

                 res3 = res2.Select(g => new EmployeeTarget
                {
                    EmpCode = g.Key.EmpCode,
                    EmpName = g.Key.EmpName,
                    Subtotal = g.Sum(t => t.TransTypeId == 4 ? -t.Subtotal : t.Subtotal) ?? 0,
                    DiscountAmount = g.Sum(t => t.DiscountAmount != null ? t.DiscountAmount : 0) ?? 0,
                    TargetValue = _context.SysTargetEmployeeVws
                          .Where(t => t.IsDeleted == false && t.EmpId == g.Key.EmpId)
                          .Sum(t => t.TargetValue != null ? t.TargetValue : 0) ?? 0,

                    Debit_Memo = _context.SalTransactionsDiscountVw
                          .Where(t => t.IsDeleted == false && t.EmpId == g.Key.EmpId)
                          .Sum(t => t.DiscountAmount != null ? t.DiscountAmount : 0) ?? 0
                })
                  .ToList();

                var res = queryResult;
                return res3.FirstOrDefault();
            }
            catch (Exception ex)
            {
                
            }

            return res3.FirstOrDefault();
        }

        



        
    }
}
