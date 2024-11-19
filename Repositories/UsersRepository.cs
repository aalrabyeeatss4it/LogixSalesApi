using LogixApi_v02.DbContexts;
using LogixApi_v02.IRepositories;
using LogixApi_v02.Models;
using LogixApi_v02.TestModels;
using LogixApi_v02.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogixApi_v02.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext context;
        //private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;
        private readonly IConfiguration config;

        public UsersRepository(ApplicationDbContext context, IConfiguration config)
        {
            this.context = context;
            //this.dbContextFactory = dbContextFactory;
            this.config = config;
        }

        public async Task<SysUserVw?> Login(string username, string password, MembersEntity member)
        {
            try
            {
                if (!string.IsNullOrEmpty(member.ConnectionString))
                {
                    using (var dbContext = new UserDbContextFactory(member.ConnectionString).CreateDbContext())
                    {
                        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                        {
                            throw new ArgumentNullException("Enter your username and password");
                        }
                        var getuser = dbContext.SysUserVws.FromSqlRaw
                            ("SELECT * FROM [SYS_USER_VW] WHERE USER_NAME={0} AND dbo.Sys_DECRYPT(USER_PASSWORD)={1} and isdel=0 and enable=1", username, password);
                        if (getuser == null || await getuser.CountAsync() != 1)
                        {
                            //throw new ArgumentException("  username or password");
                        }
                        return await getuser.FirstOrDefaultAsync();

                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetJWTToken(SysUserVw user, MembersEntity member)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var appSetting = config.GetSection("AppSettings");
            var secret = appSetting.GetValue<string>("Secret");
            var key = Encoding.UTF8.GetBytes(secret);

            var userType = "invalid";

            if (user.UserTypeId == 1)
                userType = "employee";

            if (user.UserTypeId == 2)
                userType = "customer";

            List<Claim> claims = new List<Claim>
                {
                    new Claim("FullName", user.UserFullname),
                    new Claim("Emp_Code", user.EmpCode),
                    new Claim("Emp_ID", user.EmpId.ToString()),
                    new Claim("Group_ID", user.GroupsId),
                    new Claim("USER_ID", user.UserId.ToString()),
                    new Claim("Dept_ID", user.DeptId.ToString()),
                    new Claim("BRANCHS_ID", user.BranchsId),
                    new Claim("Branch_ID", user.UserPkId.ToString()),
                    new Claim("Location", user.Location.ToString()),
                    new Claim("Facility_ID", user.FacilityId.ToString()),
                    new Claim("Fin_Year", user.FacilityId.ToString()), // this must get the fin_year 
                    new Claim("Sales_Type", user.SalesType.ToString()),
                    new Claim("ErpUrl", member.ErpUrl),
                     new Claim("ApiUrl", member.ApiUrl),
                    new Claim("User_Type", userType),
                    new Claim("UserEmail",user.UserEmail.ToString()),
                    new Claim("FacilityName2",user.FacilityName2.ToString()),
                    new Claim("FacilityName",user.FacilityName.ToString()),
                    new Claim("Mobile",user.Mobile),
                    new Claim("EmpPhoto",user.EmpPhoto??""),
                    new Claim("User_Type_ID", user.UserTypeId.ToString()),
                    new Claim("MemberId", member.Member_ID),
                    //new Claim("ConnectionString", member.ConnectionString),

                };
            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken
            (

            claims: claims,
            expires: DateTime.UtcNow.AddYears(30),
            signingCredentials: signingCredentials
            );

            var token = tokenHandler.WriteToken(tokenOptions);

            return token;
        }


        public MembersEntity TestMember()
        {
            return new MembersEntity()
            {
                Member_ID = "test",
                ApiUrl = "http://192.168.100.10:6070/",
                ErpUrl = "http://192.168.100.10:6070/",
                DBName = "Logix",
                DBUsername = "sa",
                DBPassword = "123",
                DBUrl = "."
            };
        }
        //public Facilities getCompany(MembersEntity member)
        //{
        //    Facility = new Facilities
        //    {
        //        Facility_Address = "الرياض - شارع الرياض",
        //        Facility_Phone = "006773127769",
        //        Facility_Logo = "/images/logoColor.png",
        //        Facility_Name2 = "نظام لجان تك",
        //        Facility_Name = "Lijan Tech"
        //    };
        //    if (Facility == null)
        //    {
        //        return null;
        //    }
        //    return Facility;
        //}

        public async Task<MembersEntity?> GetMember(string memberId)
        {
            try
            {
                var mobileMember = await context.SysMobileMembers.SingleOrDefaultAsync(s => s.MemberId == memberId && s.IsDeleted == false);
                if (mobileMember != null)
                {
                    var member = new MembersEntity
                    {
                        ApiUrl = mobileMember.ApiUrl ?? "",
                        DBName = mobileMember.Dbname ?? "",
                        DBPassword = mobileMember.Dbpassword ?? "",
                        DBUrl = mobileMember.Dburl ?? "",
                        DBUsername = mobileMember.Dbusername ?? "",
                        ErpUrl = mobileMember.ErpUrl ?? "",
                        Member_ID = mobileMember.MemberId ?? ""
                    };

                    return member;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<AccFacilitiesVw?> getLogo(MembersEntity member)
        {
            try
            {
                if (!string.IsNullOrEmpty(member.ConnectionString))
                {
                    using (var dbContext = new UserDbContextFactory(member.ConnectionString).CreateDbContext())
                    {


                        var getlogo = await dbContext.AccFacilitiesVw.SingleOrDefaultAsync(s => s.FacilityId == 1);

                        return getlogo;

                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public MembersEntity GetMemberr(string memberId)
        //{
        //    MembersEntity memberData = null;
        //    //return $"server={server};database={database};UID={username};PWD={password};Max Pool Size=1000;";

        //    //return TestMember();
        //    if (TableExists("Sys_Mobile_Members"))
        //    {
        //        Connect(Comm =>
        //        {
        //            Comm.CommandType = CommandType.Text;
        //            Comm.CommandText = "Select * from Sys_Mobile_Members where Member_ID=@Member_ID AND IsDeleted = 0";
        //            Comm.Parameters.AddWithValue("@Member_ID", memberId);
        //            var memberReader = Comm.ExecuteReader();
        //            while (memberReader.Read())
        //            {
        //                memberData = new MembersEntity
        //                {
        //                    Member_ID = memberReader["Member_ID"].ToString(),
        //                    ApiUrl = memberReader["Api_URL"].ToString(),
        //                    ErpUrl = memberReader["ERP_URL"].ToString(),
        //                    DBName = memberReader["DBName"].ToString(),
        //                    DBUsername = memberReader["DBUsername"].ToString(),
        //                    DBPassword = memberReader["DBPassword"].ToString(),
        //                    DBUrl = memberReader["DBUrl"].ToString()
        //                };
        //            }
        //            return true;
        //        });
        //    }
        //    return memberData;
        //}

    }
}
