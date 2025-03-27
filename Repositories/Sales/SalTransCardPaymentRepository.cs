using System.Data;
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Repositories.Sales
{
    public class DatabaseRepository
    {
        public string DB;

        // ip, db, um, pw
        public DatabaseRepository(string DB)
        {
            this.DB = DB;
        }

        public static string CreateConnectionString(string server, string database, string username, string password)
        {
            return $"server={server};database={database};UID={username};PWD={password};Max Pool Size=1000;Encrypt=False;";
        }

        public void Connect(Func<SqlCommand, bool> lambda)
        {
            using (SqlConnection Conn = new SqlConnection(DB))
            {
                Conn.Open();

                using (SqlCommand Comm = Conn.CreateCommand())
                {
                    try
                    {
                        lambda(Comm);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error Connectcing to DB: --- " + e.Message);
                    }
                }
            }

        }
    }

    public class SalTransCardPaymentRepository : GenericRepository<SalTransaction>, ISalTransCardPaymentRepository
    {
        public SalTransCardPaymentRepository(ApplicationDbContext context) : base(context)
        {
        }

        //public bool AddTransPayment(NearpayTransactionReceipt receipt)
        //{
        //    //DB = CreateConnectionString(member.DBUrl, member.DBName, member.DBUsername, member.DBPassword);
        //    bool result = false;
        //    Connect(objCmd =>
        //    {
        //        objCmd.CommandType = CommandType.StoredProcedure;
        //        objCmd.CommandText = "[SAL_Transactions_CardPayment_SP]";
        //        objCmd.Parameters.Add(new SqlParameter("@CMDTYPE", 1));
        //        objCmd.Parameters.Add(new SqlParameter("@transaction_id",receipt.transactionId));
        //        objCmd.Parameters.Add(new SqlParameter("@tid",receipt.tid));
        //        objCmd.Parameters.Add(new SqlParameter("@receiptId",receipt.receiptId));
        //        objCmd.Parameters.Add(new SqlParameter("@transactionUuid", receipt.transactionUuid));
        //        objCmd.Parameters.Add(new SqlParameter("@startDate",receipt.startDate));
        //        objCmd.Parameters.Add(new SqlParameter("@startTime",receipt.startTime));
        //        objCmd.Parameters.Add(new SqlParameter("@CreatedBy",null));
        //        objCmd.Parameters.Add(new SqlParameter("@IsDeleted", 0));

        //        // Execute the stored procedure
        //        objCmd.ExecuteScalar();

        //        result = true;
        //        return true;
        //    });
        //    return result;
        //}

        public async Task<bool> AddTransPayment(NearpayTransactionReceipt receipt)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@CMDTYPE", 1),
                new SqlParameter("@transaction_id",receipt.transactionId),
                new SqlParameter("@tid",receipt.tid),
                new SqlParameter("@receiptId",receipt.receipt_id),
                new SqlParameter("@transactionUuid", receipt.transaction_uuid),
                new SqlParameter("@startDate",receipt.start_date),
                new SqlParameter("@startTime",receipt.start_time),
            };
            var sql = "SAL_Transactions_CardPayment_SP " + String.Join(", ", parameters.Select(x => $"{x.ParameterName} = {x.ParameterName}" + (x.Direction == ParameterDirection.Output ? " OUT" : "")));
            var outputId = await _context.Database.ExecuteSqlRawAsync(sql, parameters);

            return true;

        }
    }

}
