
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace LogixApi_v02.Repositories.Sales
{
    public class WhItemRepository : GenericRepository<WhItem>, IWhItemRepository
    {
        private readonly ApplicationDbContext context;

        public WhItemRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<WhItemsVw>> GetAllVW(Expression<Func<WhItemsVw, bool>> expression)
        {
            return await context.WhItemsVws.Where(expression).ToListAsync();
        }
        public async Task<IEnumerable<WhItemsGetBalance>>  WhItemsGetBalance(long ItemID, long FacilityID, int UnitItemId, long InventoryID, long Finyear,string ItemCode)
        {
            var r = context.Set<WhItemsGetBalance>().FromSqlRaw($"exec Wh_Items_GetBalance_Sp @Item_ID={ItemID}, @Facility_ID={FacilityID}, @UnitItemId={UnitItemId}, @Inventory_ID={InventoryID},@Fin_year={Finyear},@Item_Code={ItemCode}").AsEnumerable().ToList();

            return r;


        }

        public async Task< List<SysLookupDataVM>> SAL_Items_Price_M(long userId)
        {
            List<SysLookupDataVM> sysLookups = new List<SysLookupDataVM>();

      


            Connect(Comm =>
            {
                string sql = "select * from SAL_Items_Price_M where IsDeleted=0 and ID in (select Value from dbo.fn_Split((select top 1 Value from Sys_Screen_Permission_Properties where  IsDeleted=0  and Property_ID=13 and User_ID =@UserID),','))"; //'" + User.FindFirst("Emp_Code")?.Value + "'";

                Comm.CommandType = CommandType.Text;
                Comm.CommandText = sql;
                Comm.Parameters.AddWithValue("UserID", userId);
                var reader = Comm.ExecuteReader();

                while (reader.Read())
                {
                    sysLookups.Add(new SysLookupDataVM
                    {
                        Code = long.Parse(reader["ID"].ToString()),
                        Name = reader["Name"].ToString(),
                        Name2 = reader["Name2"].ToString(),
                        CatagoriesId=0
                     
                    });
                }

                return true;
            });

            return sysLookups;
        }

        public async Task<int> CheckPriceIsBetween(long Item_ID, long Unit_ID, long PriceList_ID, string Price)
        {
            int objRet = 0;
            using (SqlConnection objCnn = new SqlConnection(_context.Database.GetConnectionString()))
            {
                objCnn.Open();
                using (SqlCommand objCmd = objCnn.CreateCommand())
                {
                    objCmd.CommandType = System.Data.CommandType.Text;
                    objCmd.CommandText = "select count(ID) from SAL_Items_Price_D where Item_Price_M_ID=@Item_Price_M_ID and IsDeleted=0 and Item_ID=@Item_ID and Unit_ID=@Unit_ID and @Price between Min_Price and Max_Price";
                    objCmd.Parameters.Add(new SqlParameter("@Item_Price_M_ID", PriceList_ID));
                    objCmd.Parameters.Add(new SqlParameter("@Item_ID", Item_ID));
                    objCmd.Parameters.Add(new SqlParameter("@Unit_ID", Unit_ID));
                    objCmd.Parameters.Add(new SqlParameter("@Price", Price));
                    object obj = objCmd.ExecuteScalar();
                    if (obj != null)
                    {
                        objRet = Convert.ToInt32(obj);
                    }
                }
            }
            return objRet;
        }

        public DataTable GetPriceDT(long Item_ID, long Unit_ID, long PriceList_ID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection objCnn = new SqlConnection(_context.Database.GetConnectionString()))
            {
                objCnn.Open();
                using (SqlCommand objCmd = objCnn.CreateCommand())
                {
                    objCmd.CommandType = System.Data.CommandType.Text;
                    objCmd.CommandText = "select * from SAL_Items_Price_D where (@Item_Price_M_ID=0 or Item_Price_M_ID=@Item_Price_M_ID) and IsDeleted=0 and Item_ID=@Item_ID and Unit_ID=@Unit_ID ";
                    objCmd.Parameters.Add(new SqlParameter("@Item_Price_M_ID", PriceList_ID));
                    objCmd.Parameters.Add(new SqlParameter("@Item_ID", Item_ID));
                    objCmd.Parameters.Add(new SqlParameter("@Unit_ID", Unit_ID));
                  
                    objCmd.CommandText += " order by ID desc";
                    SqlDataReader myreader = objCmd.ExecuteReader();
                    dt.Load(myreader);
                    return dt;
                }
            }
      
        }


        public async Task<int> CheckStatus(long Item_ID)
        {
            int objRet = 0;
            using (SqlConnection objCnn = new SqlConnection(_context.Database.GetConnectionString()))
            {
                objCnn.Open();
                using (SqlCommand objCmd = objCnn.CreateCommand())
                {
                    objCmd.CommandType = System.Data.CommandType.Text;
                    objCmd.CommandText = "select isnull(status_ID,1) from Wh_Items where ID=@Item_ID";
                    objCmd.Parameters.Add(new SqlParameter("@Item_ID", Item_ID));
                    object obj = objCmd.ExecuteScalar();
                    if (obj != null)
                    {
                        objRet = Convert.ToInt32(obj);
                    }
                }
            }
            return objRet;

        }
        public async Task<int> Get_Account_Revenue_by_ItemID(int Item_Id)
        {
            long Account_ID = 0;
            using (SqlConnection objCnn = new SqlConnection(_context.Database.GetConnectionString()))
            {
                objCnn.Open();
                using (SqlCommand objCmd = objCnn.CreateCommand())
                {
                    objCmd.Parameters.Clear();
                    objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    objCmd.CommandText = "[WH_Items_Catagories_SP]";
                    objCmd.Parameters.Add(new SqlParameter("@Item_Id", Item_Id));
                    objCmd.Parameters.Add(new SqlParameter("@CMDTYPE", 7));
                    Account_ID = (long)objCmd.ExecuteScalar();
                    if (Account_ID == 0)
                    {
                        throw new System.Exception("Revenue for some categories of items accounts did not specify حسابات الإيرادات لبعض فئات الأصناف لم تحدد.");
                    }
                    objCmd.Parameters.Clear();
                }
            }
            return (int)Account_ID;
        }


        public async  Task<decimal> GetCheck_Price_Last_Items(string Item_Code,string CustomerCode,string Facility_ID)
        {
            decimal result = 0;
            using (SqlConnection objCnn = new SqlConnection(_context.Database.GetConnectionString()))
            {
                objCnn.Open();
                using (SqlCommand objCmd = objCnn.CreateCommand())
                {
                    objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    objCmd.CommandText = "[SAL_Transactions_SP]";
                    objCmd.Parameters.Add(new SqlParameter("@Item_Code", Item_Code));
                    objCmd.Parameters.Add(new SqlParameter("@CustomerCode", CustomerCode));
                    objCmd.Parameters.Add(new SqlParameter("@Facility_ID", Facility_ID));
                    objCmd.Parameters.Add(new SqlParameter("@CMDTYPE", 14));
                    result = Convert.ToDecimal(objCmd.ExecuteScalar());
                }
            }
            return result;
        }



        public async Task<decimal> GetQuantityItem(long itemID, long unitID, long inventoryID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
            {
                connection.Open();

                string query = @"SELECT Balance / (SELECT top 1 isnull(Equivalent, 1) 
                             FROM Wh_Items_Unit 
                             WHERE Item_ID = whi.Item_ID 
                               AND Unit_ID = @Unit_ID 
                               AND Fin_year = (SELECT MAX(Fin_year) 
                                              FROM WH_Items_Balance 
                                              WHERE Item_ID = whi.Item_ID)) as Balance
                             FROM WH_Items_Balance as whi 
                             WHERE Fin_year = (SELECT MAX(Fin_year) 
                                              FROM WH_Items_Balance 
                                              WHERE Item_ID = whi.Item_ID) 
                               AND Item_ID = @Item_ID 
                               AND Inventory_ID = @Inventory_ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Inventory_ID", inventoryID);
                    command.Parameters.AddWithValue("@Item_ID", itemID);
                    command.Parameters.AddWithValue("@Unit_ID", unitID);

                    using (SqlDataReader myReader = command.ExecuteReader())
                    {
                        dt.Load(myReader);
                    }
                }
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return   Convert.ToDecimal(row["Balance"]);
            }
            else
            {
                return 0;
            }
        }
    }

}
