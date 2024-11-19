using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogixApi_v02.ViewModels.sales;
using LogixApi_v02.ViewModels.Sales;
using LogixApi_v02.ViewModels;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LogixApi_v02.Controllers.Sales
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SysCustomerController : ControllerBase
    {
        private readonly ISysCustomerRepository repository;
        private readonly ISysCustomerTypeRepository typeRepository;
        private readonly IInvestBranchRepository brachRepository;
        private readonly ISalTransactionRepository  transrepository;



        public SysCustomerController(ISysCustomerRepository repository, ISysCustomerTypeRepository typeRepository, 
            IInvestBranchRepository brachRepository, ISalTransactionRepository transrepository)
            
        {
            this.repository = repository;
            this.typeRepository = typeRepository;
            this.brachRepository = brachRepository;
            this.transrepository = transrepository;
            
        }


          [HttpGet("GetAllCustomer")]

        public async Task<Result<IEnumerable<SysCustomerVM>>> GetAllCustomer()
        {

            try
            {
                if (repository.Entities == null)
                {
                    return Result<IEnumerable<SysCustomerVM>>.Fail("There is no Data!!!");
                }
                var sysCustomers = await repository.GetAll(d => d.IsDeleted == false);

                var list = sysCustomers.Select(s => new SysCustomerVM
                {
                    Id = s.Id,
                    code = s.Code,
                    Name = s.Name,
                    Name2=s.Name2,
                    IdNo = s.IdNo,
                    Email = s.Email,
                    address = s.Address,
                    Mobile = s.Mobile,
                    CreatedOn = s.CreatedOn,
                    CreatedDate = s.CreatedDate,
                    EmpId = s.EmpId,
                    SalesType = s.SalesType,
                }).OrderByDescending(a => a.Id)
           
         .ToList();
                return Result<IEnumerable<SysCustomerVM>>.Sucess(list, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SysCustomerVM>>.Fail($"Exception: {ex.Message}");
            }
        }




        
        [HttpGet("GetAll")]
        public async Task<ResultPagination<IEnumerable<SysCustomerVM>>> GetAll(int? page, int? size,
            
            string? Customer_NAME,
             string? NAME,
             string? Code,
             string? mobile
          
           // ,string? brunch
            )
        {
            try
            {
                {

                   

                  

                    var facilityId = User.FindFirst("Facility_ID")?.Value;
                    var faId = long.Parse(facilityId);
                    long Emp_ID = long.Parse(User.FindFirst("Emp_ID")?.Value);
                 
                    string SalesType = long.Parse(User.FindFirst("Sales_Type")?.Value).ToString();

                    if (repository.Entities == null)
                    {
                        return ResultPagination<IEnumerable<SysCustomerVM>>.Fail("There is no Data!!!");
                    }
                   
                    
                   
                    
                    var getCustomer = await repository.GetAllOther<SysCustomerVw>(d => d.IsDeleted == false && d.FacilityId == faId);
                   
             
                    var getCustomer1 = new List<SysCustomerVw>();
                    
                    if (SalesType != "0")
                    {
                        getCustomer1 = getCustomer.Where(d => d.EmpId == Emp_ID).ToList();

                    }
                    else
                    {
                        getCustomer1 = getCustomer.ToList();
                    }

                    var mvlist = new List<SysCustomerVM>();

                    if (!string.IsNullOrEmpty(Customer_NAME))
                    {
                        getCustomer = getCustomer.Where(t => t.CustomerName != null && t.CustomerName.IndexOf(Customer_NAME, StringComparison.OrdinalIgnoreCase) >= 0);
                    }
                    if (!string.IsNullOrEmpty(Code))
                    {
                        getCustomer = getCustomer.Where(t => t.IdNo != null && t.IdNo.Contains(Code));
                    }
                    if (!string.IsNullOrEmpty(NAME))
                    {
                        getCustomer = getCustomer.Where(t => t.Name != null && t.Name.ToString().IndexOf(NAME, StringComparison.OrdinalIgnoreCase) >= 0);

                    }

                    if (!string.IsNullOrEmpty(mobile))
                    {
                        getCustomer = getCustomer.Where(t => t.Mobile != null && t.Mobile.ToString().Contains(mobile));
                    }
                   

                
                    Pagination pagination = new Pagination(page ?? 1, getCustomer.Count(), size ?? 25);
                    mvlist = getCustomer.Select(s => new SysCustomerVM
                    {
                        Id = s.Id,
                        code = s.Code,
                        Name = s.Name,
                        IdNo = s.IdNo,
                        Email = s.Email,
                        address = s.Address,
                        Mobile = s.Mobile,
                        CreatedOn = s.CreatedOn,
                        CreatedDate=s.CreatedDate,
                        EmpId = s.EmpId,
                        SalesType = s.SalesType,
                    }).OrderByDescending(a => a.Id)
              .Skip(pagination.Size * (pagination.CurrentPage - 1))
             .Take(pagination.Size)
           .ToList();
                    return ResultPagination<IEnumerable<SysCustomerVM>>.Sucess(pagination, mvlist );

                }
            }
            catch (Exception ex)
            {
                return ResultPagination<IEnumerable<SysCustomerVM>>.Fail($"Exception: {ex.Message}");
            }

        }

        [HttpGet("GetCustomerDetails")]
        public async Task<Result<CustomerDetailsVM>> GetCustomerDetails(long customerId)
        {
            try
            {
                if (repository.Entities == null)
                {
                    return Result<CustomerDetailsVM>.Fail("There is no Data!!!");
                }
                var getCustomer = await repository.GetById(customerId);
               // var getCustomer1 = await brachRepository.GetAllOther<CustomerDetailsVM>();
                if (getCustomer == null)
                {
                    return Result<CustomerDetailsVM>.Fail("There is no Data!!!");
                }


                var custDetails = new CustomerDetailsVM
                {
                    Id = getCustomer.Id,                 
                    IdNo=getCustomer.IdNo, 
                    Name = getCustomer.Name,
                    Email = getCustomer.Email,
                    Mobile = getCustomer.Mobile,
                    CreatedOn = getCustomer.CreatedOn,
                    Code = getCustomer.Code,
                    Longitude = getCustomer.Longitude,
                    Latitude = getCustomer.Latitude,
                   

                };

                var customerType = await typeRepository.GetById(getCustomer.CusTypeId ?? 0);
                if (customerType != null)
                {
                    custDetails.CusTypeName = customerType.CusTypeName;
                   
                }
                else
                {
                    custDetails.CusTypeName = "Unknown";
                }

                var branch = await brachRepository.GetById(getCustomer.BranchId ?? 0);
                if (branch != null)
                {
                    custDetails.BraName = branch.BraName;

                }
                else
                {
                    custDetails.CusTypeName = "Unknown";
                }
                return Result<CustomerDetailsVM>.Sucess(custDetails, "");

            }
            catch (Exception ex)
            {
                return Result<CustomerDetailsVM>.Fail($"Exception: {ex.Message}");
            }

        }

        [HttpGet("GetAllCutomeTrans")]
        public async Task<Result<CustomDetialsWithTransVM>> GetAllCutomeTrans( long customerId)
        {
            try
            {
                if (customerId == 0)
                {
                    return Result<CustomDetialsWithTransVM>.Fail($"no id found");
                }
               var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                var getAll = await repository.GetAllOther<SysCustomerVw>(s=>s.Id == customerId);
                var getCustomDetails = getAll.Select(d => new CustomerDetailsVM
                    
                {
                    Id = d.Id,
                    IdNo = d.IdNo,
                    Name = d.Name,
                    Email = d.Email,
                    Mobile = d.Mobile,
                    CreatedOn = d.CreatedOn,
                    Code = d.Code,
                    Longitude = d.Longitude,
                    Latitude = d.Latitude,
                    BraName=d.BraName,
                   

                });

                var transList = new List<TransactionVM>();
                var getCustomTrans= await transrepository.GetAllOther<SalTransactionsVw>(d=> d.IsDeleted == false &&
                d.FacilityId == faId && d.CustomerId == customerId);
                if (getCustomTrans != null)
                {
                    transList = getCustomTrans.Select(d => new TransactionVM
                    {

                        Id = d.Id,
                        Code = d.Code,
                        Customer_Name = d.CustomerName,
                        Payment_Terms_ID = d.PaymentTermsId,
                        PaymentTerms = d.PaymentTerms,
                        Total = d.Total,
                        VatAmount = d.VatAmount,
                        BraName = d.BraName,
                        DiscountAmount = d.DiscountAmount,
                        Date1 = d.Date1,
                        ExpirationDate = d.ExpirationDate,
                        CreatedOn = d.CreatedOn,
                        Subtotal = d.Subtotal,
                        TransTypeId = d.TransTypeId
                    }).ToList();
                }

               if(getCustomDetails != null && getCustomDetails.Count() >0)
                {
                    CustomDetialsWithTransVM transWithCustomerVm = new CustomDetialsWithTransVM
                    {
                        CustomDetails = getCustomDetails.FirstOrDefault(),
                        Sales_Bills = transList.Where(s => s.TransTypeId == 1),
                        Sales_Orders = transList.Where(s => s.TransTypeId == 2),
                        Sales_Quotes = transList.Where(s => s.TransTypeId == 3),
                        Sales_Returns = transList.Where(s => s.TransTypeId == 4),
                        Sales_DiscountNotice = transList.Where(s => s.TransTypeId == 5),
                    };

                    return Result<CustomDetialsWithTransVM>.Sucess(transWithCustomerVm, "");
                }
               
                return Result<CustomDetialsWithTransVM>.Fail($"Error, no customer found for this id {customerId}");


            }
            catch (Exception ex)
            {
                return Result<CustomDetialsWithTransVM>.Fail($"Exception: {ex.Message}");
            }
        }


        [HttpPost("AddCustomer")]
        public async Task<Result<SysCustomer>> AddCustomer(SysCustomer obj)
        {
            if (obj == null)
            {
                return Result<SysCustomer>.Fail("There is no Data!!!");
            }
            long Emp_ID = long.Parse(User.FindFirst("Emp_ID")?.Value);
            var facilityId = long.Parse(User.FindFirst("Facility_ID")?.Value);
            obj.CreatedOn = DateTime.Now;
            obj.SafetyPeriodDays = 0;
            obj.DuePeriodDays = 0;
            obj.CreditLimit = 0;
            obj.StatusId = 1;
            obj.CusTypeId = 2;
            obj.EmpId = Emp_ID;
            obj.CurrencyId = 1;
            obj.VatEnable = false;
            obj.CreatedBy = long.Parse(User.FindFirst("USER_ID")?.Value);
            obj.CreatedDate = DateTime.Now.ToString("yyyy/MM/dd");
            obj.FacilityId = facilityId;

            var addRes = await repository.AddAndReturn(obj);

            try
            {
                await repository.SaveChanges();
                return Result<SysCustomer>.Sucess(addRes, "Added Successfylly");
            }
            catch (Exception exp)
            {
                return Result<SysCustomer>.Fail($"Exp in add of: {GetType().Name}, Message: {exp.Message} --- {(exp.InnerException != null ? "InnerExp: " + exp.InnerException.Message : "no inner")} .");
            }
        }
        [HttpPost("AddCustomerProcedure")]
        public async Task<Result<int>> AddCustomerProcedure(SysCustomer obj)
        {
            if (obj == null)
            {
                return Result<int>.Fail("There is no Data!!!");
            }
            long Emp_ID = long.Parse(User.FindFirst("Emp_ID")?.Value);
            var facilityId = long.Parse(User.FindFirst("Facility_ID")?.Value);
            obj.CreatedOn = DateTime.Now;
            obj.SafetyPeriodDays = 0;
            obj.DuePeriodDays = 0;
            obj.CreditLimit = 0;
            obj.StatusId = 1;
            obj.VatEnable = false;
            obj.CusTypeId = 2;
            obj.EmpId = Emp_ID;
            obj.CurrencyId = 1;
            obj.CreatedBy = long.Parse(User.FindFirst("USER_ID")?.Value);
            obj.CreatedDate = DateTime.Now.ToString("yyyy/MM/dd");
            obj.FacilityId = facilityId;

            var addRes = await repository.InsertSys_CustomerAsync(obj);

            try
            {
                await repository.SaveChanges();
                return Result<int>.Sucess(addRes, "Added Successfylly");
            }
            catch (Exception exp)
            {
                return Result<int>.Fail($"Exp in add of: {GetType().Name}, Message: {exp.Message} --- {(exp.InnerException != null ? "InnerExp: " + exp.InnerException.Message : "no inner")} .");
            }
        }







    }






            }
