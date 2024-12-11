using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories;
using LogixApi_v02.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text;

namespace LogixApi_v02.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UsersAuthController : ControllerBase
    {
        private IUsersRepository userRepository;
        private readonly IPermissionHelper permission;
        private readonly ISysScreenPermissionPropertiesVwRepository sysScreenPermissionPropertiesVw;
        private readonly ISysPropertyValuesVwRepository sysPropertyValuesVw;

        public UsersAuthController(IUsersRepository userRepository, IPermissionHelper permission, ISysScreenPermissionPropertiesVwRepository sysScreenPermissionPropertiesVw, ISysPropertyValuesVwRepository sysPropertyValuesVw)
        {
            this.userRepository = userRepository;
            this.permission = permission;
            this.sysScreenPermissionPropertiesVw = sysScreenPermissionPropertiesVw;
            this.sysPropertyValuesVw = sysPropertyValuesVw;
        }

    

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Login(LoginVM login)
        {


            if (!ModelState.IsValid)
            {
                return Ok(Result<string>.Fail($"No id found"));
            }

            if (string.IsNullOrEmpty(login.MemberId))
            {
                //Console.WriteLine("No id found");
                return Ok(Result<string>.Fail($"noor"));
                //return BadRequest(new { message = "No Member ID Provided" });
            }

            var member = await userRepository.GetMember(login.MemberId);

            if (member == null)
            {
                //Console.WriteLine("Incorrect id found");
                return Ok(Result<string>.Fail($"No Member ID Provided"));
                // return BadRequest(new { message = "member ID is incorrect" });
            }

            if (string.IsNullOrEmpty(member.ErpUrl) || string.IsNullOrEmpty(member.DBName) || string.IsNullOrEmpty(member.DBUrl) || string.IsNullOrEmpty(member.DBUsername) || string.IsNullOrEmpty(member.DBPassword))
            {
                //Console.WriteLine("Empty Data found");
                return Ok(Result<string>.Fail($"member ID is in correct"));
                //return BadRequest(new { message = "member ID is incorrect" });
            }

            //var header = Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(login.UserName) && !string.IsNullOrEmpty(login.Password))
            {
                try
                {
                    var user = await userRepository.Login(login.UserName, login.Password, member);

                    if (user == null)
                    {
                        return Ok(Result<string>.Fail($"Username or Password is in correct"));
                        // return BadRequest(new { message = "Username or password is incorrect" });
                    }

                    string token = userRepository.GetJWTToken(user, member);
                    return Ok(Result<object>.Sucess(new
                    {
                        erpUrl = member.ErpUrl,
                        userId = user.UserId,
                        userName = user.UserName,
                        userFullname = user.UserFullname,
                        branchId = user.UserPkId,
                        branchName = user.BraName,
                        // invetoryId=user.inventory
                        apiUrl = member.ApiUrl,
                        memberId = member.Member_ID,
                        facilityId = user.FacilityId,
                        facilityName = user.FacilityName,
                        facilityName2 = user.FacilityName2,
                        deptId = user.DeptId,
                        groupsId = user.GroupsId,
                        userTypeId = user.UserTypeId,
                        empId = user.EmpId,
                        empCode = user.EmpCode,
                        empName = user.EmpName,
                        SalesType = user.SalesType,
                        groupName = user.GroupName,
                        userEmail = user.UserEmail,
                        mobile = user.Mobile,
                        location = user.Location,
                        empPhoto = user.EmpPhoto,
                        token = token,


                    }, $"done"));

                }
                catch (Exception e)
                {
                    return Ok(Result<string>.Fail(e.Message));
                    // return BadRequest(new { message = "Error: " + e.Message });
                }
            }

            return Ok(Result<string>.Fail($"please send login data"));
            // return BadRequest("please send login data");
        }



        [AllowAnonymous]
        [HttpPost("GetCompany")]
        public async Task<IActionResult> GetMember(string MemberId)
        {
            if (string.IsNullOrEmpty(MemberId))
            {
                //Console.WriteLine("No id found");
                return BadRequest(new { message = "No Member ID Provided" });
            }

            var member = await userRepository.GetMember(MemberId);

            if (member == null)
            {
                //Console.WriteLine("Incorrect id found");
                return BadRequest(new { message = "member ID is incorrect" });
            }

            if (string.IsNullOrEmpty(member.ErpUrl) || string.IsNullOrEmpty(member.DBName) || string.IsNullOrEmpty(member.DBUrl) || string.IsNullOrEmpty(member.DBUsername) || string.IsNullOrEmpty(member.DBPassword))
            {
                //Console.WriteLine("Empty Data found");
                return BadRequest(new { message = "member ID is incorrect" });
            }

            try
            {

                var getLogo = await userRepository.getLogo(member);


                return Ok(
                      new
                      {
                          ErpUrl = member.ErpUrl,
                          getLogo

                      });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Error: " + e.Message });
            }
        }


        //[AllowAnonymous]
        //[HttpPost("getlogo")]
        //public IActionResult getlogo()
        //{

        //    if (Request.ContentLength == 0)
        //    {
        //        return BadRequest();
        //    }
        //    if (Request.Form.ContainsKey("memberId") == false)
        //    {
        //        return BadRequest(new { message = "No Member ID Provided" });
        //    }
        //    MembersEntity? member = userRepository.GetMember(Request.Form["memberId"]);
        //    if (member == null)
        //    {
        //        return BadRequest(new { message = "member ID is incorrect" });
        //    }
        //    if (string.IsNullOrEmpty(member.ErpUrl) || string.IsNullOrEmpty(member.DBName) || string.IsNullOrEmpty(member.DBUrl) || string.IsNullOrEmpty(member.DBUsername) || string.IsNullOrEmpty(member.DBPassword))
        //    {
        //        return BadRequest(new { message = "member ID is incorrect" });
        //    }

        //    return Ok(new { Url = member.ErpUrl, CompanyDetail = userRepository.getCompany(member) });
        //}


        [HttpPost("permissionScreen")]
        public async Task<IActionResult> permissionScreen()
        {
            try
            {
                var GroupID = int.Parse(User.FindFirst("Group_ID")?.Value);




                return Ok(new
                {
                    saleBill = await permission.HasPermission(285, PermissionType.Show, GroupID),
                    add_saleBill = await permission.HasPermission(285, PermissionType.Add, GroupID),
                    salesOrder = await permission.HasPermission(284, PermissionType.Show, GroupID),
                    add_salesOrder = await permission.HasPermission(284, PermissionType.Add, GroupID),
                    offerpriceScreen = await permission.HasPermission(283, PermissionType.Show, GroupID),
                    add_offerpriceScreen = await permission.HasPermission(283, PermissionType.Add, GroupID),
                    returnOrderScreen = await permission.HasPermission(286, PermissionType.Show, GroupID),
                    add_returnOrderScreen = await permission.HasPermission(286, PermissionType.Add, GroupID),
                    customerScreen = await permission.HasPermission(370, PermissionType.Show, GroupID),
                    add_customerScreen = await permission.HasPermission(370, PermissionType.Add, GroupID),
                    discountNoticeScreen = await permission.HasPermission(250, PermissionType.Show, GroupID),
                    add_discountNoticeScreen = await permission.HasPermission(250, PermissionType.Add, GroupID),
                    updatePrice = await HasPermissionProperty(3),
                    allowPurchasePrice = await HasPermissionProperty(14),
                    updateDiscount = await HasPermissionProperty(5),
                    Rate_Disc_Item = await HasPermissionProperty(57),
                    Rate_Disc_Item_value = await HasPermissionPropertyValue(57),
                    Rate_Disc_Invoice = await HasPermissionProperty(56),
                    Rate_Disc_Invoice_value = await HasPermissionPropertyValue(56),
                    allowVatAfterDiscountInInv = await Property_Value(314),

                });
            }



            catch (Exception e) { return Ok(Result<string>.Fail(e.Message));}
        }


       


        private async Task<bool> HasPermissionProperty(int propertyId)
        {
            try
            {
                bool allow = false;

                var userId = int.Parse(User.FindFirst("USER_ID")?.Value);

                var getPerm = await sysScreenPermissionPropertiesVw.GetAll(d=>d.UserId== userId & d.PropertyId==propertyId);
                if (getPerm == null)
                {
                    return false;
                }
                else {
                    var row = getPerm.FirstOrDefault();
                    if (row != null)
                    {
                        allow = row.Allow ?? false;
                    }
                }
               
                  

                return allow;
            }
            catch (Exception ex)
            {
                return false;
            }
        }   
        
        private async Task<string> Property_Value(int propertyId)
        {
            try
            {
                string allow = "0";

                var Facility_ID = int.Parse(User.FindFirst("Facility_ID")?.Value);

                var getPerm = await sysPropertyValuesVw.GetAll(d=>d.FacilityId== Facility_ID & d.PropertyId==propertyId);
                if (getPerm == null)
                {
                    return "0";
                }
                else {
                    var row = getPerm.FirstOrDefault();
                    if (row != null) {
                        allow = row.PropertyValue ?? "0";
                    }
                     
                }
               
                  

                return allow;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }


        private async Task<long> HasPermissionPropertyValue(int propertyId)
        {
            try
            {
                long allow = 0;

                var userId = int.Parse(User.FindFirst("USER_ID")?.Value);

                var getPerm = await sysScreenPermissionPropertiesVw.GetAll(d => d.UserId == userId && d.PropertyId == propertyId);
                if (getPerm == null)
                {
                    return 0;
                }
                else
                {
                    var row = getPerm.FirstOrDefault();
                    if (row != null)
                    {
                        long parsedValue = 0;
                        if (long.TryParse(row.Value, out  parsedValue))
                        {
                            allow = parsedValue;
                        }
                        else
                        {
                            allow = 0;
                            // Parsing failed. Handle the error or use a default value.
                            // Here, we keep allow as 0 since the parsing failed.
                        }
                    }
                    else
                    {
                        allow = 0;
                        // No row found. Handle the case accordingly.
                    }
                }

                return allow;
            }
            catch (Exception ex)
            {
                // Exception occurred. Log or handle the exception as needed.
                // Returning 0 as a default value.
                return 0;
            }
        }


        [HttpPost("checkPermission")]
        public async Task<Result<bool>> CheckPermission(CheckPermissionVM entity)
        {
            PermissionType type= PermissionType.Delete;
            var GroupID = int.Parse(User.FindFirst("Group_ID")?.Value);
                    switch (entity.PermissionType)
            {
                case 1:
                    type = PermissionType.Add;
                    break; 
                case 2:
                    type = PermissionType.Edit;
                    break; case 3:
                    type = PermissionType.Delete;
                    break; 
                case 4:
                    type = PermissionType.Show;
                    break;
                case 5:
                    type = PermissionType.Print;
                    break;
                    
            }
            if(type == PermissionType.Delete)
            {
                return Result<bool>.Fail("NoPermission!!!");
            }

            var chk = await permission.HasPermission(entity.ScreenId,type , GroupID);
            if (!chk)
            {

                // return Result<IEnumerable<SalTransaction>>.Fail("NoPermission!!!");
                return Result<bool>.Sucess(false,"NoPermission!!!");
            }
            return Result<bool>.Sucess(true,"has Permission!!!");
        }
    }

}