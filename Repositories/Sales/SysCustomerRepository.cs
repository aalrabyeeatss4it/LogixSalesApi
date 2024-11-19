
using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;
using ZXing.QrCode.Internal;

namespace LogixApi_v02.Repositories.Sales
{
    public class SysCustomerRepository : GenericRepository<SysCustomer>, ISysCustomerRepository
    {
        public SysCustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> InsertSys_CustomerAsync(SysCustomer objRecord)
        {
            int objRet = 0;
          
            try {
            
            
                List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ID", objRecord.Id),

new SqlParameter("@Code", DBNull.Value)
           ,
                new SqlParameter("@Facility_ID", objRecord.FacilityId),
                new SqlParameter("@Cus_Type_Id", objRecord.CusTypeId),
                new SqlParameter("@Branch_ID", objRecord.BranchId),
                new SqlParameter("@Name", objRecord.Name),

                new SqlParameter("@ID_No", objRecord.IdNo),
                new SqlParameter("@ID_Date", objRecord.IdDate),


                new SqlParameter("@ID_Type", objRecord.IdType),

                new SqlParameter("@ID_Issuer", objRecord.IdIssuer),

                new SqlParameter("@Mobile", objRecord.Mobile),
                new SqlParameter("@Address", objRecord.Address),

                new SqlParameter("@CreatedBy", objRecord.CreatedBy),
                new SqlParameter("@Group_ID", objRecord.GroupId), 


                new SqlParameter("@Credit_limit", objRecord.CreditLimit),

                new SqlParameter("@Comany_Type", objRecord.ComanyType),
                new SqlParameter("@Emp_ID", objRecord.EmpId),

                   new SqlParameter("@Status_ID",objRecord.StatusId),
                new SqlParameter("@Currency_ID", objRecord.CurrencyId),
                new SqlParameter("@Industry_ID", objRecord.IndustryId),
                new SqlParameter("@VAT_Enable", objRecord.VatEnable),
                new SqlParameter("@Due_Period_Days", objRecord.DuePeriodDays),

                new SqlParameter("@Created_Date", objRecord.CreatedDate),
                new SqlParameter("@Latitude", objRecord.Latitude),
                new SqlParameter("@Longitude", objRecord.Longitude),
                new SqlParameter("@Safety_Period_Days", objRecord.SafetyPeriodDays),
                new SqlParameter("@CMDTYPE", 1),


            };


            var sql = "Sys_Customer_SP " + String.Join(", ", parameters.Select(x =>
      $"{x.ParameterName} = {x.ParameterName}" +
      (x.Direction == ParameterDirection.Output ? " OUTPUT" : "")
      ));

            var outputId = await _context.Database.ExecuteSqlRawAsync(sql, parameters);
            objRet = int.Parse(outputId.ToString());
           
            
            }catch(Exception) { 
            
            }

            return objRet;

        }

        //public async Task<int> InsertSys_CustomerAsync(SysCustomer objRecord)
        //{
        //    int objRet = 0;
        //    try
        //    {


        //        using (SqlConnection objCnn = new SqlConnection(_context.Database.GetConnectionString()))
        //        {
        //            await objCnn.OpenAsync();

        //            using (SqlCommand objCmd = objCnn.CreateCommand())
        //            {
        //                objCmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                objCmd.CommandText = "[Sys_Customer_SP]";

        //                objCmd.Parameters.AddWithValue("@ID", objRecord.Id);
        //                objCmd.Parameters.AddWithValue("@Cus_Type_Id", objRecord.CusTypeId);
        //                objCmd.Parameters.AddWithValue("@Branch_ID", objRecord.BranchId);
                       
        //                SqlParameter sp = new SqlParameter("@Code", SqlDbType.NVarChar, 50)
        //                {
        //                    Direction = ParameterDirection.Output
        //                };
        //                objCmd.Parameters.Add(sp);
        //                objCmd.Parameters.AddWithValue("@Name", objRecord.Name);
        //                //objCmd.Parameters.AddWithValue("@Name2", objRecord.Name2);
        //                objCmd.Parameters.AddWithValue("@ID_No", objRecord.IdNo);
        //                objCmd.Parameters.AddWithValue("@ID_Date", objRecord.IdDate);
        //                objCmd.Parameters.AddWithValue("@ID_Type", objRecord.IdType);
        //                objCmd.Parameters.AddWithValue("@ID_Issuer", objRecord.IdIssuer);
        //                //objCmd.Parameters.AddWithValue("@Nationality_ID", objRecord.NationalityId);
        //                //objCmd.Parameters.AddWithValue("@Email", objRecord.Email);
        //                //objCmd.Parameters.AddWithValue("@Phone", objRecord.Phone);
        //                //objCmd.Parameters.AddWithValue("@Fax", objRecord.Fax);
        //                objCmd.Parameters.AddWithValue("@Mobile", objRecord.Mobile);
        //                objCmd.Parameters.AddWithValue("@Address", objRecord.Address);
        //                //objCmd.Parameters.AddWithValue("@Note", objRecord.Note);
        //                //objCmd.Parameters.AddWithValue("@Represented_by", objRecord.RepresentedBy);
        //                //objCmd.Parameters.AddWithValue("@Job_Name", objRecord.JobName);
        //                //objCmd.Parameters.AddWithValue("@Job_Address", objRecord.JobAddress);
        //                //objCmd.Parameters.AddWithValue("@Photo", objRecord.Photo);
        //                //objCmd.Parameters.AddWithValue("@Sponsor_ID", objRecord.SponsorId);
        //                //objCmd.Parameters.AddWithValue("@Sponsor_Name", objRecord.SponsorName);
        //                //objCmd.Parameters.AddWithValue("@Sponsor_Job_Name", objRecord.SponsorJobName);
        //                //objCmd.Parameters.AddWithValue("@Sponsor_Job_Address", objRecord.SponsorJobAddress);
        //                //objCmd.Parameters.AddWithValue("@Sponsor_Mobile", objRecord.SponsorMobile);
        //                //objCmd.Parameters.AddWithValue("@Sponsor_Phone", objRecord.SponsorPhone);
        //                //objCmd.Parameters.AddWithValue("@Bank_ID", objRecord.BankId);
        //                //objCmd.Parameters.AddWithValue("@Bank_Account", objRecord.BankAccount);
        //                //objCmd.Parameters.AddWithValue("@Sponsor_Email", objRecord.SponsorEmail);
        //                //objCmd.Parameters.AddWithValue("@Customer_Name", objRecord.CustomerName);
        //                //objCmd.Parameters.AddWithValue("@Email2", objRecord.Email2);
        //                objCmd.Parameters.AddWithValue("@CreatedBy", objRecord.CreatedBy);
        //                //objCmd.Parameters.AddWithValue("@Acc_separate", objRecord.AccSeparate);
        //                objCmd.Parameters.AddWithValue("@Facility_ID", objRecord.FacilityId);
        //                objCmd.Parameters.AddWithValue("@Group_ID", objRecord.GroupId);
        //                objCmd.Parameters.AddWithValue("@Credit_limit", objRecord.CreditLimit);
        //                objCmd.Parameters.AddWithValue("@Comany_Type", objRecord.ComanyType);
        //                objCmd.Parameters.AddWithValue("@Emp_ID", objRecord.EmpId);
        //                objCmd.Parameters.AddWithValue("@Currency_ID", objRecord.CurrencyId);
        //                //objCmd.Parameters.AddWithValue("@Item_Price_M_ID", objRecord.ItemPriceMId);
        //                //objCmd.Parameters.AddWithValue("@Source_ID", objRecord.SourceId);
        //                objCmd.Parameters.AddWithValue("@Status_ID", objRecord.StatusId);
        //                //objCmd.Parameters.AddWithValue("@Share_with_users", objRecord.ShareWithUsers);
        //                objCmd.Parameters.AddWithValue("@Industry_ID", objRecord.IndustryId);
        //                //objCmd.Parameters.AddWithValue("@Number_of_Employees", objRecord.NumberOfEmployees);
        //                //objCmd.Parameters.AddWithValue("@VAT_Enable", objRecord.VatEnable);
        //                //objCmd.Parameters.AddWithValue("@VAT_Number", objRecord.VatNumber);
        //                //objCmd.Parameters.AddWithValue("@City_ID", objRecord.CityId);
        //                objCmd.Parameters.AddWithValue("@Due_Period_Days", objRecord.DuePeriodDays);
        //                //objCmd.Parameters.AddWithValue("@Collector_Name", objRecord.CollectorName);
        //                objCmd.Parameters.AddWithValue("@Created_Date", objRecord.CreatedDate);
        //                objCmd.Parameters.AddWithValue("@Latitude", objRecord.Latitude);
        //                objCmd.Parameters.AddWithValue("@Longitude", objRecord.Longitude);
        //                objCmd.Parameters.AddWithValue("@Safety_Period_Days", objRecord.SafetyPeriodDays);
        //                //objCmd.Parameters.AddWithValue("@Enable", objRecord.Enable);
        //                //objCmd.Parameters.AddWithValue("@Payment_Type", objRecord.PaymentType);
        //                //objCmd.Parameters.AddWithValue("@Sales_Type", objRecord.SalesType);
        //                //objCmd.Parameters.AddWithValue("@Sales_Area", objRecord.SalesArea);
        //                //objCmd.Parameters.AddWithValue("@POS_ID", objRecord.PosId);
        //                //objCmd.Parameters.AddWithValue("@Days_of_Visit", objRecord.DaysOfVisit);
        //                //objCmd.Parameters.AddWithValue("@Gender", objRecord.Gender);
        //                //objCmd.Parameters.AddWithValue("@Refrance_Code", objRecord.RefranceCode);
        //                //objCmd.Parameters.AddWithValue("@Member_ID", objRecord.MemberId);
        //                //objCmd.Parameters.AddWithValue("@Frist_Name", objRecord.FristName);
        //                //objCmd.Parameters.AddWithValue("@Second_Name", objRecord.SecondName);
        //                //objCmd.Parameters.AddWithValue("@Third_Name", objRecord.ThirdName);
        //                //objCmd.Parameters.AddWithValue("@Fourth_Name", objRecord.FourthName);
        //                //objCmd.Parameters.AddWithValue("@Title_ID", objRecord.TitleId);
        //                //objCmd.Parameters.AddWithValue("@Veneration", objRecord.Veneration);
        //                //objCmd.Parameters.AddWithValue("@Contact_By", objRecord.ContactBy);
        //                //objCmd.Parameters.AddWithValue("@DateOfBirth", objRecord.DateOfBirth);
        //                //objCmd.Parameters.AddWithValue("@Parent_ID", objRecord.ParentId);
        //                //objCmd.Parameters.AddWithValue("@Parent_RelativeType", objRecord.ParentRelativeType);
        //                //objCmd.Parameters.AddWithValue("@Std_Status_ID", objRecord.StdStatusId);
        //                //objCmd.Parameters.AddWithValue("@Std_Grade_ID", objRecord.StdGradeId);
        //                //objCmd.Parameters.AddWithValue("@App_ID", objRecord.AppId);
        //                //objCmd.Parameters.AddWithValue("@Owner_ID_No", objRecord.OwnerIdNo);
        //                //objCmd.Parameters.AddWithValue("@ID_Expire_Date", objRecord.IdExpireDate);
        //                //objCmd.Parameters.AddWithValue("@Free_Maintenance", objRecord.FreeMaintenance);
        //                //objCmd.Parameters.AddWithValue("@Preventive_Maintenance", objRecord.PreventiveMaintenance);
        //                //objCmd.Parameters.AddWithValue("@Correctional_Maintenance", objRecord.CorrectionalMaintenance);
        //                //objCmd.Parameters.AddWithValue("@JobID", objRecord.JobId);
        //                //objCmd.Parameters.AddWithValue("@Vission", objRecord.Vission);
        //                //objCmd.Parameters.AddWithValue("@Mission", objRecord.Mission);
        //                //objCmd.Parameters.AddWithValue("@Objective", objRecord.Objective);
        //                //objCmd.Parameters.AddWithValue("@ISBusinessPartner", objRecord.IsbusinessPartner);
        //                //objCmd.Parameters.AddWithValue("@AcademicDegree", objRecord.AcademicDegree);
        //                //objCmd.Parameters.AddWithValue("@RateFileCompletion", objRecord.RateFileCompletion);
        //                //objCmd.Parameters.AddWithValue("@ISCompleted", objRecord.Iscompleted);
        //                //objCmd.Parameters.AddWithValue("@PortalCusType_Id", objRecord.PortalCusTypeId);
        //                //// ... (previous code)

        //                //objCmd.Parameters.AddWithValue("@PortalCondition", objRecord.PortalCondition);
        //                //objCmd.Parameters.AddWithValue("@Sponsor_POBox", objRecord.SponsorPobox);
        //                //objCmd.Parameters.AddWithValue("@Sponsor_ZipCode", objRecord.SponsorZipCode);
        //                //objCmd.Parameters.AddWithValue("@Sponsor_Attachment", objRecord.SponsorAttachment);
        //                //objCmd.Parameters.AddWithValue("@POBox", objRecord.Pobox);
        //                //objCmd.Parameters.AddWithValue("@ZipCode", objRecord.ZipCode);
        //                //objCmd.Parameters.AddWithValue("@Attachment_IBN", objRecord.AttachmentIbn);
        //                //objCmd.Parameters.AddWithValue("@Attachment_Profile", objRecord.AttachmentProfile);
        //                //objCmd.Parameters.AddWithValue("@Count_Employee_primary", objRecord.CountEmployeePrimary);
        //                //objCmd.Parameters.AddWithValue("@Count_Employee_foreign", objRecord.CountEmployeeForeign);
        //                //objCmd.Parameters.AddWithValue("@Attachment_Organizationalchart", objRecord.AttachmentOrganizationalchart);
        //                //objCmd.Parameters.AddWithValue("@OtherDetails", objRecord.OtherDetails);
        //                //objCmd.Parameters.AddWithValue("@Attachment", objRecord.Attachment);
        //                //objCmd.Parameters.AddWithValue("@Owner_Property", objRecord.OwnerProperty);
        //                //objCmd.Parameters.AddWithValue("@LocationURL", objRecord.LocationUrl);
                       
        //                objCmd.Parameters.AddWithValue("@CMDTYPE", 1);
        //                var reader = objCmd.ExecuteScalar();
        //                objRet = Convert.ToInt32(reader);
        //                //using (var reader = await objCmd.ExecuteReaderAsync())
        //                //{
        //                //    if (await reader.ReadAsync())
        //                //    {
        //                //        objRecord.Code = reader["Code"] != DBNull.Value ? reader["Code"].ToString() : null;
        //                //        objRet = Convert.ToInt32(reader["ID"]);
        //                //        objRecord.Id = objRet;
        //                //    }
        //                //}
        //            }
        //        }


        //    }
        //    catch (Exception exp)
        //    { }

        //        return objRet;
        //}

        /*public Task GetById(object p)
        {
            throw new NotImplementedException();
        }*/
        /* public async Task<IEnumerable<SysCustomerVM>> GetAllVW()
{
    return await _context.SysCustomerVws.ToListAsync();
}*/
    }



}
