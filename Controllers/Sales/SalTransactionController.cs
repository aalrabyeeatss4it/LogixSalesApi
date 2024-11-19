
using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels;
using LogixApi_v02.ViewModels.sales;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using TextToQRImagePackage;

namespace LogixApi_v02.Controllers.Sales
{
    [Authorize]
    // [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SalTransactionController : ControllerBase
    {
        private readonly ISalTransactionRepository repository;
        private readonly ISalTransactionsProductRepository productRepository;
        private readonly ISysCustomerRepository customrepository;
        private readonly IWhItemRepository whItemRepository;
        private readonly IInvestBranchRepository investBranchRepository;
        private readonly IWhInventoryRepository whInventoryRepository;
        private readonly ISalPaymentTermRepository salPaymentTermRepository;
        private readonly ISalTransactionsPaymentRepository repositoryTransPayment;
        private readonly IPermissionHelper permission;
        private readonly IUsersRepository userRepository;

        public SalTransactionController(ISalTransactionRepository repository,
               ISalTransactionsProductRepository productRepository,
               ISysCustomerRepository customrepository,
               IWhItemRepository whItemRepository,

            IInvestBranchRepository investBranchRepository,
            IWhInventoryRepository whInventoryRepository,
            ISalPaymentTermRepository salPaymentTermRepository,
            IUsersRepository userRepository,
            ISalTransactionsPaymentRepository repositoryTransPayment,
            IPermissionHelper permission

            )
        {
            this.repository = repository;
            this.productRepository = productRepository;
            this.customrepository = customrepository;
            this.whItemRepository = whItemRepository;
            this.investBranchRepository = investBranchRepository;
            this.whInventoryRepository = whInventoryRepository;
            this.salPaymentTermRepository = salPaymentTermRepository;
            this.userRepository = userRepository;
            this.repositoryTransPayment = repositoryTransPayment;
            this.permission = permission;
        }



        [HttpGet("getEmployeeTarget")]
        public async Task<Result<EmployeeTarget>> getEmployeeTarget(int transTypeId, string? fromDate = "", string? toDate = "")
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                int currentYear = currentDate.Year;
                int month = currentDate.Month;
                var lastDay = DateTime.DaysInMonth(currentYear, month);
                string currentMonth = month > 9 ? month.ToString() : $"0{month}";


                if (string.IsNullOrEmpty(fromDate))
                {
                    fromDate = $"{currentYear}/{currentMonth}/01";
                }
                if (string.IsNullOrEmpty(toDate))
                {
                    toDate = $"{currentYear}/{currentMonth}/{lastDay}";
                }

                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                string empCode = User.FindFirst("Emp_Code")?.Value;

                var res = await repository.GetEmployeeTarget(faId, empCode, transTypeId, fromDate, toDate);
                if (res == null)

                {
                    res = new EmployeeTarget();
                    //Result<EmployeeTarget>.Sucess(new EmployeeTarget( ), "");
                }
                if (res.TargetValue > 0)
                {
                    res.Percentage = (res.Subtotal-res.Debit_Memo) / res.TargetValue * 100;
                    res.Percentage = Math.Round(res.Percentage, 2);
                }

                return Result<EmployeeTarget>.Sucess(res, "");
            }
            catch (Exception ex)
            {
                return Result<EmployeeTarget>.Fail($"Exception: {ex.Message}");
            }

        }


        /*   [HttpGet("getCounts")]
           public async Task<Result<IEnumerable<CountsVM>>> GetCounts()
           {

               try
               {
                   var facilityId = User.FindFirst("Facility_ID")?.Value;
                   var faId = long.Parse(facilityId);
                   var EmpId = User.FindFirst("Emp_ID")?.Value;
                   var EmpIdLong = long.Parse(EmpId);

                   if (repository.Entities == null)
                   {
                       return Result<IEnumerable<CountsVM>>.Fail("There is no Data!!!");
                   }
                   var list = new List<CountsVM>
                   {
                      new CountsVM{TransTypeId = 0, TransTypeName="الكل", Count= 0 ,EmpId=EmpIdLong}, // كل العمليات
                      new CountsVM{TransTypeId = 1, TransTypeName="فاتورة مبيعات", Count= 0,EmpId=EmpIdLong},
                      new CountsVM{TransTypeId = 2, TransTypeName="أمر بيع", Count= 0,EmpId=EmpIdLong},
                      new CountsVM{TransTypeId = 3, TransTypeName="عرض سعر", Count= 0,EmpId=EmpIdLong},
                      new CountsVM{TransTypeId = 4, TransTypeName=" مرتجعات", Count= 0,EmpId=EmpIdLong},
                      new CountsVM{TransTypeId = 5, TransTypeName="اشعار  دائن", Count= 0,EmpId=EmpIdLong},
                      new CountsVM{TransTypeId = 6, TransTypeName="فاتورة مبدئية", Count= 0,EmpId=EmpIdLong},
                   };
                   foreach (var item in list)
                   {
                       if(item.TransTypeId == 0)
                       {
                           item.Count = repository.Entities.Where(t => t.TransTypeId==1 && t.IsDeleted == false  && t.EmpId == EmpIdLong).Count();
                       }
                       else
                       {
                           item.Count = repository.Entities.Where(t => t.IsDeleted == false && t.TransTypeId == item.TransTypeId && t.EmpId == EmpIdLong).Count();
                       }

                   }


                   var customers = customrepository.Entities.Count(s=>s.IsDeleted == false && s.EmpId == EmpIdLong);
                   var customerCount = new CountsVM { TransTypeId = 7, TransTypeName = "العملاء", Count = customers , EmpId = EmpIdLong };
                   list.Add(customerCount);

                   var receiptBonds = repositoryTransPayment.Entities.Count(s => s.IsDeleted == false );
                   var  bondsCount = new CountsVM { TransTypeId = 8, TransTypeName = "سندات قبض", Count = receiptBonds, EmpId = EmpIdLong };
                   list.Add(bondsCount);

                   return Result<IEnumerable<CountsVM>>.Sucess(list, "");
               }
               catch (Exception ex)
               {
                   return Result<IEnumerable<CountsVM>>.Fail($"Exception: {ex.Message}");
               }

           }*/

        [HttpGet("getCounts")]
        public async Task<Result<IEnumerable<CountsVM>>> GetCounts(
          string? start_date,
          string? end_date)

        {

            DateTime currentDate = DateTime.Now;
            int currentYear = currentDate.Year;
            int month = currentDate.Month;
            var lastDay = DateTime.DaysInMonth(currentYear, month);
            string currentMonth = month > 9 ? month.ToString() : $"0{month}";


            if (string.IsNullOrEmpty(start_date))
            {
                start_date = $"{currentYear}/{currentMonth}/01";
            }
            if (string.IsNullOrEmpty(end_date))
            {
                end_date = $"{currentYear}/{currentMonth}/{lastDay}";
            }

            try
            {
                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                var EmpId = User.FindFirst("Emp_ID")?.Value;
                var EmpIdLong = long.Parse(EmpId);
                string SalesType = long.Parse(User.FindFirst("Sales_Type")?.Value).ToString();

                if (repository.Entities == null)
                {
                    return Result<IEnumerable<CountsVM>>.Fail("There is no Data!!!");
                }

                var res = new List<CountsVM>();



                var listCount = new List<CountsVM>
                {
                   new CountsVM{TransTypeId = 0, TransTypeName="الكل", Count= 0 ,EmpId=EmpIdLong}, // كل العمليات
                   new CountsVM{TransTypeId = 1, TransTypeName="فاتورة مبيعات", Count= 0,EmpId=EmpIdLong},
                   new CountsVM{TransTypeId = 2, TransTypeName="أمر بيع", Count= 0,EmpId=EmpIdLong},
                   new CountsVM{TransTypeId = 3, TransTypeName="عرض سعر", Count= 0,EmpId=EmpIdLong},
                   new CountsVM{TransTypeId = 4, TransTypeName=" مرتجعات", Count= 0,EmpId=EmpIdLong},
                   new CountsVM{TransTypeId = 5, TransTypeName="اشعار  دائن", Count= 0,EmpId=EmpIdLong},
                   new CountsVM{TransTypeId = 6, TransTypeName="فاتورة مبدئية", Count= 0,EmpId=EmpIdLong},
                };

                foreach (var item in listCount)
                {


                    /*  if (SalesType != "0")
                      {
                          res = listCount.Where(d => d.EmpId == EmpIdLong).ToList();

                      }
                      else
                      {
                          res = listCount.ToList();
                      }*/

                    if (item.TransTypeId == 0 && SalesType != "0")


                    {
                        var queryResult = repository.Entities.Where(t => t.IsDeleted == false).AsEnumerable().Where(r => r.IsDeleted == false);


                        if (!string.IsNullOrEmpty(start_date) && !string.IsNullOrEmpty(end_date))
                        {
                            queryResult = queryResult.Where(t => t.IsDeleted == false).AsEnumerable().Where(r => r.Date1 != null && DateHelper.StringToDate1(r.Date1) >= DateHelper.StringToDate1(start_date)
                            && DateHelper.StringToDate1(r.Date1) <= DateHelper.StringToDate1(end_date));

                        }

                        item.Count = queryResult.Count();
                    }

                    else if (item.TransTypeId == 0 && SalesType == "0")
                    {

                        //  item.Count = repository.Entities.Where(t => t.IsDeleted == false && t.EmpId == EmpIdLong).Count();
                        var queryResult = repository.Entities.Where(t => t.IsDeleted == false && t.EmpId == EmpIdLong).AsEnumerable().Where(r => r.IsDeleted == false);


                        if (!string.IsNullOrEmpty(start_date) && !string.IsNullOrEmpty(end_date))
                        {
                            queryResult = queryResult.Where(t => t.IsDeleted == false).AsEnumerable().Where(r => r.Date1 != null && DateHelper.StringToDate1(r.Date1) >= DateHelper.StringToDate1(start_date)
                            && DateHelper.StringToDate1(r.Date1) <= DateHelper.StringToDate1(end_date));

                        }

                        item.Count = queryResult.Count();

                    }
                    else if (item.TransTypeId > 0 && SalesType != "0")
                    {
                        //item.Count = repository.Entities.Where(t => t.IsDeleted == false && t.TransTypeId == item.TransTypeId).Count();
                        var queryResult = repository.Entities.Where(t => t.IsDeleted == false && t.TransTypeId == item.TransTypeId).AsEnumerable().Where(r => r.IsDeleted == false);


                        if (!string.IsNullOrEmpty(start_date) && !string.IsNullOrEmpty(end_date))
                        {
                            queryResult = queryResult.Where(t => t.IsDeleted == false).AsEnumerable().Where(r => r.Date1 != null && DateHelper.StringToDate1(r.Date1) >= DateHelper.StringToDate1(start_date)
                            && DateHelper.StringToDate1(r.Date1) <= DateHelper.StringToDate1(end_date));

                        }

                        item.Count = queryResult.Count();
                    }
                    else
                    {

                        // item.Count = repository.Entities.Where(t => t.IsDeleted == false && t.TransTypeId == item.TransTypeId && t.EmpId == EmpIdLong).Count();
                        var queryResult = repository.Entities.Where(t => t.IsDeleted == false && t.TransTypeId == item.TransTypeId && t.EmpId == EmpIdLong).AsEnumerable().Where(r => r.IsDeleted == false);


                        if (!string.IsNullOrEmpty(start_date) && !string.IsNullOrEmpty(end_date))
                        {
                            queryResult = queryResult.Where(t => t.IsDeleted == false).AsEnumerable().Where(r => r.Date1 != null && DateHelper.StringToDate1(r.Date1) >= DateHelper.StringToDate1(start_date)
                            && DateHelper.StringToDate1(r.Date1) <= DateHelper.StringToDate1(end_date));

                        }

                        item.Count = queryResult.Count();

                    }
                }


                /*  var customers = customrepository.Entities.Count(s=>s.IsDeleted == false && s.EmpId == EmpIdLong);

                  var customerCount = new CountsVM { TransTypeId = 7, TransTypeName = "العملاء", Count = customers , EmpId = EmpIdLong };
                  listCount.Add(customerCount);

                  var receiptBonds = repositoryTransPayment.Entities.Count(s => s.IsDeleted == false );
                  var  bondsCount = new CountsVM { TransTypeId = 8, TransTypeName = "سندات قبض", Count = receiptBonds, EmpId = EmpIdLong };
                  listCount.Add(bondsCount);*/

                return Result<IEnumerable<CountsVM>>.Sucess(listCount, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<CountsVM>>.Fail($"Exception: {ex.Message}");
            }

        }

        [HttpGet("getAll")]
        public async Task<Result<IEnumerable<SalTransaction>>> GetAll()
        {
            try
            {
                var GroupID = int.Parse(User.FindFirst("Group_ID")?.Value);
                var chk = await permission.HasPermission(370, PermissionType.Show, GroupID);
                if (!chk)
                {

                    return Result<IEnumerable<SalTransaction>>.Fail("NoPermission!!!");


                }
                if (repository.Entities == null)
                {
                    return Result<IEnumerable<SalTransaction>>.Fail("There is no Data!!!");
                }
                var list = await repository.GetAll(d => d.IsDeleted == false);
                return Result<IEnumerable<SalTransaction>>.Sucess(list, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SalTransaction>>.Fail($"Exception: {ex.Message}");
            }

        }
        [HttpGet("getLastInv")]
        public async Task<Result<long>> GetLastInv(int pos)
        {
            try
            {
             
               
                if (repository.Entities == null)
                {
                    return Result<long>.Fail("There is no Data!!!");


                }
               
                long id =await  repository.GetLatestTransactionIdAsync(pos);
                return Result<long>.Sucess(id, "");
            }
            catch (Exception ex)
            {
                return Result<long>.Fail($"Exception: {ex.Message}");
            }

        }


        /*    [HttpGet("getForAdd")]
            public async Task<Result<TransactionVM>> GetForAdd()
            {
                var GroupID =int.Parse(User.FindFirst("Group_ID")?.Value);
                var chk = await permission.HasPermission(285, PermissionType.Add, GroupID);
                if (!chk)
                {
                    return Result<TransactionVM>.Fail($"NoPermission");

                }
                try
                {
                    IEnumerable<CustomerDetailsVM> customers= new List<CustomerDetailsVM>();
                    var facilityId = User.FindFirst("Facility_ID")?.Value;
                    var faId = long.Parse(facilityId);
                    var getCustomers = await customrepository.GetAll(c=>c.IsDeleted == false && c.FacilityId == faId);
                    if(getCustomers != null)
                    {
                        customers = getCustomers.Select(d => new CustomerDetailsVM {
                            Id = d.Id,
                            IdNo = d.IdNo,
                            Name = d.Name,
                            Email = d.Email,
                            Mobile = d.Mobile,
                            CreatedOn = d.CreatedOn,
                            Code = d.Code,
                            Longitude = d.Longitude,
                            Latitude = d.Latitude,
                        }).ToList();
                    }

                    IEnumerable<WhItemsVM> items = new List<WhItemsVM>();
                    var getItems = await whItemRepository.GetAllVW(c => c.IsDeleted == false);
                    if (getCustomers != null)
                    {
                        items = getItems.Select(s => new WhItemsVM
                        {
                            Id = s.Id,
                            ItemCode = s.ItemCode,
                            ItemName = s.ItemName,
                            PriceSale = s.PriceSale,
                            PurchasePrice = s.PurchasePrice,
                            UnitName = s.UnitName,
                            VatRate = s.VatRate,
                            CatName = s.CatName,
                            UnitItemId = s.UnitItemId,
                            VatEnable = s.VatEnable,
                            PriceIncludeVat = s.PriceIncludeVat,
                            CreatedOn = s.CreatedOn

                        }).ToList();
                    }


                    IEnumerable<BranchesVM> branches = new List<BranchesVM>();
                    var getBranches = await investBranchRepository.GetAll(c => c.Isdel == false);
                    if (getBranches != null)
                    {
                        branches = getBranches.Select(s => new BranchesVM
                        {
                            BranchId = s.BranchId,
                            BraName = s.BraName

                        }).ToList();
                    }

                    IEnumerable<SalPaymentTermsVM> PaymentTerms = new List<SalPaymentTermsVM>();
                    var getTerms = await salPaymentTermRepository.GetAll(c => c.IsDeleted == false);
                    if (getBranches != null)
                    {
                        PaymentTerms = getTerms.Select(s => new SalPaymentTermsVM
                        {
                            PaymentTerms = s.PaymentTerms,
                            IdPayment = s.Id

                        }).ToList();
                    }


                    IEnumerable<WhInventoryVM> inventtory = new List<WhInventoryVM>();
                    var getInventtory = await whInventoryRepository.GetAll(c => c.IsDeleted == false);
                    if (getBranches != null)
                    {
                        inventtory = getInventtory.Select(s => new WhInventoryVM
                        {
                            Id = s.Id,
                            InventoryName = s.InventoryName

                        }).ToList();
                    }


                    TransactionVM finalVm = new TransactionVM
                    {
                        AddCustomDetails= customers,
                        AddBranches= branches,
                        AddItems= items,
                        AddPaymentsTerms = PaymentTerms,
                        AddInventory = inventtory
                    };





                    return Result<TransactionVM>.Sucess(finalVm,"");
                }
                catch (Exception ex)
                {
                    return Result<TransactionVM>.Fail($"Exception: {ex.Message}");
                }

            }*/


        // getALLTransaction By transTypeId Filter With Date***** 
        /* [HttpGet("GetAllByDate")]
         public async Task<Result<IEnumerable<TransactionVM>>> GetAllVW(int transTypeId )
         {
             try
             {
                 var facilityId = User.FindFirst("Facility_ID")?.Value;
                 var faId = long.Parse(facilityId);
                 var res = await repository.GetAllOther<SalTrGetAllTransWithPaginationansactionsVw>();
                 if (res == null)
                 {
                     return Result<IEnumerable<TransactionVM>>.Fail("ThGetAllTransWithPaginationere is no Data!!!");
                 }
                 var vmList = new List<TransactionVM>();
                 DateTime startDate = DateTime.ParseExact("2021/03/01", "yyyy/MM/dd", CultureInfo.InvariantCulture);
                 DateTime endDate = DateTime.ParseExact("2021/03/30", "yyyy/MM/dd", CultureInfo.InvariantCulture);
                 vmList = res.Where(d => d.IsDeleted == false && d.TransTypeId == transTypeId && d.FacilityId == faId && d.Date1 != null && DateTime.ParseExact(d.Date1, "yyyy/MM/dd", CultureInfo.InvariantCulture) >= startDate && DateTime.ParseExact(d.Date1, "yyyy/MM/dd", CultureInfo.InvariantCulture) <= endDate).Select(d => new TransactionVM
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
                     Subtotal = d.Subtotal,

                 }).ToList();
                 return Result<IEnumerable<TransactionVM>>.Sucess(vmList, "");
             }
             catch (Exception ex)
             {
                 return Result<IEnumerable<TransactionVM>>.Fail($"Exception: {ex.Message}");
             }

         }*/


        // getALLTransaction By transTypeId ***** 
        [HttpGet("GetAllTrans")]
        public async Task<Result<IEnumerable<TransactionVM>>> GetAllTrans(int transTypeId, long empId)
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                int currentMonth = currentDate.Month;
                int currentYear = currentDate.Year;


                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                var EmpId = User.FindFirst("Emp_ID")?.Value;
                var EmpIdLong = long.Parse(EmpId ?? "0");
                var res = await repository.GetAllOther<SalTransactionsVw>();
                if (res == null)
                {
                    return Result<IEnumerable<TransactionVM>>.Fail("There is no Data!!!");
                }

                var vmList = new List<TransactionVM>();
                vmList = res.Where(d => d.IsDeleted == false && d.TransTypeId == transTypeId && d.FacilityId == faId && d.EmpId == EmpIdLong
                &&
                d.Date1 != null && d.Date1 != "string" && d.Date1.Length == 10 && DateTime.ParseExact(d.Date1, "yyyy/MM/dd", CultureInfo.InvariantCulture).Month == currentMonth
               && DateTime.ParseExact(d.Date1, "yyyy/MM/dd", CultureInfo.InvariantCulture).Year == currentYear

                ).Select(d => new TransactionVM
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
                    Subtotal = d.Subtotal,
                    FacilityId = d.FacilityId,
                    CreatedBy = d.CreatedBy,


                }).ToList();
                return Result<IEnumerable<TransactionVM>>.Sucess(vmList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<TransactionVM>>.Fail($"Exception: {ex.Message}");
            }

        }

        [HttpGet("GetAllTransWithPagination")]
        public async Task<ResultPagination<IEnumerable<TransactionVM>>> GetAllTransWithPagination( int? page, int? size,
         int transTypeId,
         int screenId,
         string? Customer_NAME,
         string? Code,
         string? Total,
         string? Branch_ID,
         string? Inventory_ID,
         string? Payment_Terms_ID,
         string? start_date,
         string? end_date

         )
        {
            var GroupID = int.Parse(User.FindFirst("Group_ID")?.Value);
            //var chk = await permission.HasPermission(screenId, PermissionType.Show, GroupID);
            //if (!chk)
            //{

            //    //return Result<IEnumerable<SalTransaction>>.Fail("NoPermission!!!");
            //    return Result<IEnumerable<TransactionVM>>.Fail("NoPermission!!!");

            //}

            try
            {

                if (transTypeId == 0)
                {
                    transTypeId = 1;
                }

                //if (paginationParams != null)
                //{
                //    if (paginationParams.PageNumber < 1)
                //    {
                //        paginationParams.PageNumber = 1;
                //    }
                //    if (paginationParams.PageSize < 1)
                //    {
                //        paginationParams.PageSize = 5;
                //    }
                //}
                //else
                //{
                //    paginationParams = new PaginationParams
                //    {
                //        PageNumber = 1,
                //        PageSize = 5
                //    };
                //}

                DateTime currentDate = DateTime.Now;
                int currentYear = currentDate.Year;
                int month = currentDate.Month;
                var lastDay = DateTime.DaysInMonth(currentYear, month);
                string currentMonth = month > 9 ? month.ToString() : $"0{month}";


                if (string.IsNullOrEmpty(start_date))
                {
                    start_date = $"{currentYear}/{currentMonth}/01";
                }
                if (string.IsNullOrEmpty(end_date))
                {
                    end_date = $"{currentYear}/{currentMonth}/{lastDay}";
                }



                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                long Emp_ID = long.Parse(User.FindFirst("Emp_ID")?.Value);
                string SalesType = long.Parse(User.FindFirst("Sales_Type")?.Value).ToString();


                var res2 = await repository.GetAllOther<SalTransactionsVw>(d => d.IsDeleted == false && d.TransTypeId == transTypeId && d.FacilityId == faId);



                var res = new List<SalTransactionsVw>();
                if (SalesType != "0")
                {
                    res = res2.Where(d => d.EmpId == Emp_ID).ToList();

                }
                else
                {

                    res = res2.ToList();



                }/*else
                {
                    res = res2.ToList();
                }*/


                var vmList = new List<TransactionVM>();



                if (!string.IsNullOrEmpty(Customer_NAME))
                {
                    try
                    {
                    res = res.Where(t => t.CustomerName.IndexOf(Customer_NAME, StringComparison.OrdinalIgnoreCase) >= 0 || t.Code.IndexOf(Code, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                    }
                    catch (Exception exc)
                    {

                    }
                }
                if (!string.IsNullOrEmpty(Code))
                {
                    try
                    {
                       res = res.Where(t => t.Code.IndexOf(Code, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    }catch(Exception exc)
                    {

                    }
                  
                }
                if (!string.IsNullOrEmpty(Total))
                {
                    try
                    {
                    res = res.Where(t => t.Total != null && t.Total.ToString().Contains(Total)).ToList();

                    }
                    catch (Exception exc)
                    {

                    }
                }

                if (!string.IsNullOrEmpty(Branch_ID))
                {
                    try
                    {
                    res = res.Where(t => t.BranchId != null && t.BranchId == int.Parse(Branch_ID)).ToList();

                    }
                    catch (Exception exc)
                    {

                    }
                }

                if (!string.IsNullOrEmpty(Inventory_ID))
                {
                    try
                    {
                        res = res.Where(t => t.InventoryId != null && t.InventoryId == int.Parse(Inventory_ID)).ToList();
                    }
                    catch (Exception exc)
                    {

                    }
                }

                if (!string.IsNullOrEmpty(Payment_Terms_ID))
                {
                    try
                    {
                      res = res.Where(t => t.PaymentTermsId != null && t.PaymentTermsId == int.Parse(Payment_Terms_ID)).ToList();
                    }
                    catch (Exception exc)
                    {

                    }
                }

                if (!string.IsNullOrEmpty(start_date) && !string.IsNullOrEmpty(end_date))
                {
                    List<SalTransactionsVw> templist = new List<SalTransactionsVw>();
                    foreach (var item in res)
                    {

                        var dateTemp = DateHelper.FixConvertDateFormate(item.Date1);
                        if (dateTemp != null)
                        {
                            if (DateHelper.StringToDate1(item.Date1) >= DateHelper.StringToDate1(start_date) &&
                                 DateHelper.StringToDate1(item.Date1) <= DateHelper.StringToDate1(end_date))
                            {
                                templist.Add(item);
                            }
                        }
                    }
                    res = templist;
                }
                //var count = res.Count();
                //int totalPages = (int)Math.Ceiling((double)count / paginationParams.PageSize);
                //paginationParams.Count = count;
                //paginationParams.PageNumber = paginationParams.PageNumber;
                //paginationParams.TotalPages = totalPages;
                //paginationParams.HasNextPage = paginationParams.PageSize < totalPages;
                //paginationParams.HasPreviousPage = paginationParams.PageNumber > 1;
                //paginationParams.NextPage = paginationParams.HasNextPage ? paginationParams.PageNumber + 1 : (int?)null;
                //paginationParams.PreviousPage = paginationParams.HasPreviousPage ? paginationParams.PageNumber - 1 : (int?)null;
                Pagination pagination = new Pagination(page ?? 1, res.Count(), size ?? 25);

                vmList = res.Select(d => new TransactionVM
                {
                    Id = d.Id,
                    Code = d.Code,
                    Customer_Name = d.CustomerName,
                    Payment_Terms_ID = d.PaymentTermsId,
                    PaymentTerms = d.PaymentTerms,
                    Total = d.Total,
                    VatAmount = d.VatAmount,
                    BraName = d.BraName,
                    Net = d.Total + d.VatAmount ,
                    DiscountAmount = d.DiscountAmount,
                    Date1 = d.Date1,
                    Subtotal = d.Subtotal,
                    AmountCost= d.AmountCost,
                    CashAmount= d.CashAmount,
                    BankAmount= d.BankAmount,

                }).OrderByDescending(a => a.Id)
              .Skip(pagination.Size * (pagination.CurrentPage - 1))
             .Take(pagination.Size)
           .ToList();

                return ResultPagination<IEnumerable<TransactionVM>>.Sucess(pagination, vmList, "");



            }
            catch (Exception ex)
            {
                return ResultPagination<IEnumerable<TransactionVM>>.Fail($"Exception: {ex.Message}");
                // return Result<IEnumerable<TransactionVM>>.Fail(ex:$"NoPermission");
            }

        }



        [HttpGet("GetAllTransWithDetailsPagination")]
        public async Task<Result<List<TransactionQuaryVM>>> GetAllTransWithDetailsPagination([FromQuery] PaginationParams paginationParams,
            int transTypeId,
            int screenId,
            string? Customer_NAME,
            string? Code,
            string? Total,
            string? Branch_ID,
            string? Inventory_ID,
            string? Payment_Terms_ID,
            string? start_date,
            string? end_date

            )
        {

            var GroupID = int.Parse(User.FindFirst("Group_ID")?.Value);
            var chk = await permission.HasPermission(screenId, PermissionType.Show, GroupID);
            if (!chk)
            {

                //return Result<IEnumerable<SalTransaction>>.Fail("NoPermission!!!");
                return Result<List<TransactionQuaryVM>>.Fail("NoPermission!!!");

            }

            try
            {

                if (transTypeId == 0)
                {
                    transTypeId = 1;
                }

                if (paginationParams != null)
                {
                    if (paginationParams.PageNumber < 1)
                    {
                        paginationParams.PageNumber = 1;
                    }
                    if (paginationParams.PageSize < 1)
                    {
                        paginationParams.PageSize = 5;
                    }
                }
                else
                {
                    paginationParams = new PaginationParams
                    {
                        PageNumber = 1,
                        PageSize = 5
                    };
                }

                DateTime currentDate = DateTime.Now;
                int currentYear = currentDate.Year;
                int month = currentDate.Month;
                var lastDay = DateTime.DaysInMonth(currentYear, month);
                string currentMonth = month > 9 ? month.ToString() : $"0{month}";


                if (string.IsNullOrEmpty(start_date))
                {
                    start_date = $"{currentYear}/{currentMonth}/01";
                }
                if (string.IsNullOrEmpty(end_date))
                {
                    end_date = $"{currentYear}/{currentMonth}/{lastDay}";
                }



                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                long Emp_ID = long.Parse(User.FindFirst("Emp_ID")?.Value);
                string SalesType = long.Parse(User.FindFirst("Sales_Type")?.Value).ToString();


                var res2 = await repository.GetAllOther<SalTransactionsVw>(d => d.IsDeleted == false && d.TransTypeId == transTypeId && d.FacilityId == faId);



                var res = new List<SalTransactionsVw>();
                if (SalesType != "0")
                {
                    res = res2.Where(d => d.EmpId == Emp_ID).ToList();

                }
                else
                {

                    res = res2.ToList();



                }/*else
                {
                    res = res2.ToList();
                }*/


                var vmList = new List<TransactionVM>();



                if (!string.IsNullOrEmpty(Customer_NAME))
                {
                    res = res.Where(t => t.CustomerName != null && t.CustomerName.Contains(Customer_NAME)).ToList();
                }
                if (!string.IsNullOrEmpty(Code))
                {
                    res = res.Where(t => t.Code != null && t.Code.Contains(Code)).ToList();
                }
                if (!string.IsNullOrEmpty(Total))
                {
                    res = res.Where(t => t.Total != null && t.Total.ToString().Contains(Total)).ToList();
                }

                if (!string.IsNullOrEmpty(Branch_ID))
                {
                    res = res.Where(t => t.BranchId != null && t.BranchId == int.Parse(Branch_ID)).ToList();
                }

                if (!string.IsNullOrEmpty(Inventory_ID))
                {
                    res = res.Where(t => t.InventoryId != null && t.InventoryId == int.Parse(Inventory_ID)).ToList();
                }

                if (!string.IsNullOrEmpty(Payment_Terms_ID))
                {
                    res = res.Where(t => t.PaymentTermsId != null && t.PaymentTermsId == int.Parse(Payment_Terms_ID)).ToList();
                }

                if (!string.IsNullOrEmpty(start_date) && !string.IsNullOrEmpty(end_date))
                {

                    List<SalTransactionsVw> templist = new List<SalTransactionsVw>();
                    foreach (var item in res)
                    {

                        var dateTemp = DateHelper.FixConvertDateFormate(item.Date1);
                        if (dateTemp != null)
                        {
                            if (DateHelper.StringToDate1(item.Date1) >= DateHelper.StringToDate1(start_date) &&
                                 DateHelper.StringToDate1(item.Date1) <= DateHelper.StringToDate1(end_date))
                            {
                                templist.Add(item);
                            }
                        }
                    }
                    res= templist;
                }

                var count = res.Count();
                int totalPages = (int)Math.Ceiling((double)count / paginationParams.PageSize);
                paginationParams.Count = count;
                paginationParams.PageNumber = paginationParams.PageNumber;
                paginationParams.TotalPages = totalPages;
                paginationParams.HasNextPage = paginationParams.PageSize < totalPages;
                paginationParams.HasPreviousPage = paginationParams.PageNumber > 1;
                paginationParams.NextPage = paginationParams.HasNextPage ? paginationParams.PageNumber + 1 : (int?)null;
                paginationParams.PreviousPage = paginationParams.HasPreviousPage ? paginationParams.PageNumber - 1 : (int?)null;



                vmList = res.Select(d => new TransactionVM
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
                    Subtotal = d.Subtotal,

                }).Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize).Take(paginationParams.PageSize).OrderByDescending(d => d.Id).ToList();

                List<TransactionQuaryVM> transactionQuaryVM = new List<TransactionQuaryVM>();
                foreach (var vm in vmList)
                {
                    TransactionQuaryVM temp = new TransactionQuaryVM();
                    temp.TransactionVM = vm;

                    var prodList = new List<TransProductsVM>();
                    var getProducts = await productRepository.GetAllOther<SalTransactionsProductsVw>(d => d.TransactionId == vm.Id);
                    if (getProducts != null)
                    {
                        prodList = getProducts.Select(s => new TransProductsVM
                        {
                            Discount_Amount = s.DiscountAmount,
                            Disc_rate = s.DiscRate,
                            Id = s.Id,
                            ItemName = s.ItemName,
                            Price = s.Price,
                            ProductID = s.ProductId,
                            Qty = s.Qty,
                            Vat = s.Vat,
                            VaT_Amount = s.VatAmount
                        }).ToList();
                    }
                    temp.ProductsVMs = prodList;
                    transactionQuaryVM.Add(temp);


                }



                return Result<List<TransactionQuaryVM>>.Sucess(transactionQuaryVM, "", paginationParams);



            }
            catch (Exception ex)
            {
                return Result<List<TransactionQuaryVM>>.Fail($"Exception: {ex.Message}");
                // return Result<IEnumerable<TransactionVM>>.Fail(ex:$"NoPermission");
            }

        }

        // Discount_notifi_By_CusTransitions
        [HttpGet("GetAllVMDiscouNotifiByCustomer")]
        public async Task<Result<IEnumerable<TransactionVM>>>
            GetAllVMDiscouNotifiByCustomer(int transTypeId, long customerId)
        {
            try
            {
                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                var getTrans = await repository.GetAllOther<SalTransactionsVw>();
                if (getTrans == null)
                {
                    return Result<IEnumerable<TransactionVM>>.Fail("There is no Data!!!");
                }
                var transList = new List<TransactionVM>();
                transList = getTrans.Where(d => d.IsDeleted == false &&
                d.TransTypeId == transTypeId && d.FacilityId == 1 && d.CustomerId == customerId).Select(d => new TransactionVM
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
                    ExpirationDate = d.ExpirationDate,
                    Date1 = d.Date1,
                    CreatedOn = d.CreatedOn,
                    Subtotal = d.Subtotal,

                }).ToList();

                var idNo_custom = await customrepository.GetById(customerId);
                if (idNo_custom != null)
                {
                    foreach (TransactionVM trans in transList)
                    {
                        trans.IdNo = idNo_custom.IdNo;
                    }

                }
                else
                {
                    foreach (TransactionVM trans in transList)
                    {
                        trans.IdNo = "Unknown";
                    }
                }

                return Result<IEnumerable<TransactionVM>>.Sucess(transList, "");


            }

            catch (Exception ex)
            {
                return Result<IEnumerable<TransactionVM>>.Fail($"Exception: {ex.Message}");
            }

        }

        // *****End******



        //********SalesQuoteByCustomer********

        [HttpGet("GetAllSalesQuoteByCustomer")]
        public async Task<Result<IEnumerable<TransactionVM>>>
           GetAllVMSalesQuoteByCustomer(int transTypeId, long customerId)
        {
            try
            {
                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                var getTrans = await repository.GetAllOther<SalTransactionsVw>();
                if (getTrans == null)
                {
                    return Result<IEnumerable<TransactionVM>>.Fail("There is no Data!!!");
                }
                var vmList = new List<TransactionVM>();
                vmList = getTrans.Where(d => d.IsDeleted == false &&
                d.TransTypeId == transTypeId && d.FacilityId == faId &&
                d.CustomerId == customerId).Select(d => new TransactionVM
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
                    ExpirationDate = d.ExpirationDate,
                    Date1 = d.Date1,
                    Subtotal = d.Subtotal,
                    CreatedOn = d.CreatedOn,

                }).ToList();
                return Result<IEnumerable<TransactionVM>>.Sucess(vmList, "");

                /*    var idNo_custom = await customrepository.GetById(getTrans ?? 0);
                    if (idNo_custom != null)
                    {
                        vmList.IdNo = idNo_custom.IdNo;

                    }
                    else
                    {
                        idNo_custom.IdNo = "Unknown";
                    }
                    return Result<CustomerDetailsVM>.Sucess(idNo_custom, "");*/
            }

            catch (Exception ex)
            {
                return Result<IEnumerable<TransactionVM>>.Fail($"Exception: {ex.Message}");
            }

        }

        //*********End SalesQuoteByCustomer*********

        // *********SaleReturnByCustomer*********
        [HttpGet("GetAllSaleReturn")]
        public async Task<Result<IEnumerable<TransactionVM>>> GetAllVMSaleReturn(int transTypeId, long customerId)
        {
            try
            {
                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                var res = await repository.GetAllOther<SalTransactionsVw>();
                if (res == null)
                {
                    return Result<IEnumerable<TransactionVM>>.Fail("There is no Data!!!");
                }
                var vmList = new List<TransactionVM>();
                vmList = res.Where(d => d.IsDeleted == false && d.TransTypeId == transTypeId && d.FacilityId == faId && d.CustomerId == customerId).Select(d => new TransactionVM
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

                }).ToList();
                return Result<IEnumerable<TransactionVM>>.Sucess(vmList, "");
            }

            catch (Exception ex)
            {
                return Result<IEnumerable<TransactionVM>>.Fail($"Exception: {ex.Message}");
            }

        }

        //***** End **SaleReturnByCustomer**********


        // *********billsByCustomerId***********

        [HttpGet("GetAllBillsByCustomer")]
        public async Task<Result<IEnumerable<TransactionVM>>> GetAllVMBillsByCustomer(int transTypeId, long customerId)
        {
            try
            {
                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                var res = await repository.GetAllOther<SalTransactionsVw>();
                if (res == null)
                {
                    return Result<IEnumerable<TransactionVM>>.Fail("There is no Data!!!");
                }
                var vmList = new List<TransactionVM>();
                vmList = res.Where(d => d.IsDeleted == false && d.TransTypeId == transTypeId && d.FacilityId ==
                faId && d.CustomerId == customerId).Select(d => new TransactionVM
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

                }).ToList();
                return Result<IEnumerable<TransactionVM>>.Sucess(vmList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<TransactionVM>>.Fail($"Exception: {ex.Message}");
            }

        }

        // End billsByCustomerId***************




        //**************sale OrderByCustomerId************
        [HttpGet("GetAllByCustomerId")]
        public async Task<Result<IEnumerable<TransactionVM>>> GetAllByCustomerId(int transTypeId, long customerId)
        {
            try
            {
                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                var res = await repository.GetAllOther<SalTransactionsVw>();
                if (res == null)
                {
                    return Result<IEnumerable<TransactionVM>>.Fail("There is no Data!!!");
                }
                var vmList = new List<TransactionVM>();
                vmList = res.Where(d => d.IsDeleted == false && d.TransTypeId == transTypeId && d.FacilityId == faId
                && d.CustomerId == customerId).
                  Select(d => new TransactionVM
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

                  }).ToList();
                return Result<IEnumerable<TransactionVM>>.Sucess(vmList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<TransactionVM>>.Fail($"Exception: {ex.Message}");
            }

        }

        //********* End sale OrderByCustomerId *******************

        [HttpGet("DetailTransaction")]
        public async Task<Result<TransDetailsWithQr>> DetailTransaction(long Trans_ID)
        {
            try
            {
                if (Trans_ID == 0)
                {
                    return Result<TransDetailsWithQr>.Fail($"no id found");
                }
                var getAll = await repository.GetAllOther<SalTransactionsVw>();
                var getTrans = getAll.Where(d => d.Id == Trans_ID).FirstOrDefault();
                if (getTrans == null)
                {
                    return Result<TransDetailsWithQr>.Fail($"no data found for this id {Trans_ID}");
                }
                var transDetailsVm = new TransDetailsVM
                {
                    Id = getTrans.Id,
                    AmountCost = getTrans.AmountCost,
                    AmountPaid = getTrans.AmountPaid,
                    AmountRemaining = getTrans.AmountRemaining,
                    BraName = getTrans.BraName,
                    Code = getTrans.Code,
                    CreatedOn = getTrans.CreatedOn,
                    CustomerName = getTrans.CustomerName,
                    Date1 = getTrans.Date1,
                    DiscountAmount = getTrans.DiscountAmount,
                    DiscountRate = getTrans.DiscountRate,
                    DocumentNote = getTrans.DocumentNote,
                    DueDate = getTrans.DueDate,
                    InventoryName = getTrans.InventoryName,
                    PaymentTerms = getTrans.PaymentTerms,
                    Total = getTrans.Total,
                    Net = getTrans.Total+getTrans.VatAmount,
                    SubTotal = getTrans.Subtotal,
                    Vat = getTrans.Vat,
                    VaTAmount = getTrans.VatAmount,
                    FacVatNumber = getTrans.FacVatNumber
                };

                var prodList = new List<TransProductsVM>();
                var getProducts = await productRepository.GetAllOther<SalTransactionsProductsVw>(d => d.TransactionId == Trans_ID);
                if (getProducts != null)
                {
                    prodList = getProducts.Select(s => new TransProductsVM
                    {
                        Discount_Amount = s.DiscountAmount,
                        Disc_rate = s.DiscRate,
                        Id = s.Id,
                        ItemName = s.ItemName,
                        Price = s.Price,
                        ProductID = s.ProductId,
                        Qty = s.Qty,
                        Vat = s.Vat,
                        VaT_Amount = s.VatAmount
                    }).ToList();
                }

                var transWithProductsVm = new TransDetailsWithProductsVM
                {
                    Details = transDetailsVm,
                    Products = prodList
                };
                var facilityId =long.Parse(User.FindFirst("Facility_ID")?.Value);
                var getFacility = await repository.GetAllOther<AccFacility>(f => f.FacilityId == facilityId);
                string codeText = "";
               
                AccFacility accFacility =new AccFacility();
                if (getFacility != null)

                {
                    var facility = getFacility.FirstOrDefault();
                     accFacility = facility;
                   
                    decimal total = transDetailsVm.Total - transDetailsVm.DiscountAmount??0 + transDetailsVm.VaTAmount??0;
                    ZATCA objZATCo = new ZATCA(facility.FacilityName, facility.VatNumber, DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss"), (double)total, (double)transDetailsVm.VaTAmount );
                    codeText = objZATCo.ToBase64();
                }
                var transWithQr = new TransDetailsWithQr
                {
                    TransactionsDetails = transWithProductsVm,
                    QrText = codeText,
                    VatNumber = accFacility.VatNumber,
                    FacilityAddress = accFacility.FacilityAddress,
                    FacilityLogo = "/images/"+  accFacility.FacilityLogo,
                };

                return Result<TransDetailsWithQr>.Sucess(transWithQr, "");

            }
            catch (Exception ex)
            {
                return Result<TransDetailsWithQr>.Fail($"Exception: {ex.Message}");
            }
        }

        //[AllowAnonymous]
        [HttpGet("getById/{id}")]
        public async Task<Result<SalTransaction>> GetById(long id)
        {
            try 
            {
                if (repository.Entities == null)
                {
                    return Result<SalTransaction>.Fail("There is no Data!!!");
                }
                var item = await repository.GetById(id);

                if (item == null)
                {
                    return Result<SalTransaction>.Fail($"There is no Data with Id: {id} !!!");
                }

                return Result<SalTransaction>.Sucess(item, "");
            }
            catch (Exception ex)
            {
                return Result<SalTransaction>.Fail($"Exception: {ex.Message}");
            }
        }
        [HttpGet("GetSalTransById/{id}")]
        public async Task<Result<List<SalTransactionsProduct>>> GetSalTransById(long id)
        {
            try
            {
                if (productRepository.Entities == null)
                {
                    return Result<List<SalTransactionsProduct>>.Fail("There is no Data!!!");
                }
                var item = await productRepository.GetAll(x => x.TransactionId == id);

                if (item == null)
                {
                    return Result<List<SalTransactionsProduct>>.Fail($"There is no Data with Id: {id} !!!");
                }

                return Result<List<SalTransactionsProduct>>.Sucess(item.ToList(), "");
            }
            catch (Exception ex)
            {
                return Result<List<SalTransactionsProduct>>.Fail($"Exception: {ex.Message}");
            }
        }

        [HttpPost("Edit/{id}")]
        public async Task<Result<SalTransaction>> Edit(int id, SalTransaction obj)
        {
            if (id != obj.Id)
            {
                return Result<SalTransaction>.Fail("There is no Data!!!");
            }

            repository.Update(obj);

            try
            {
                await repository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!IsExists(id))
                {
                    return Result<SalTransaction>.Fail("There is no Data!!!");
                }
                else
                {
                    return Result<SalTransaction>.Fail($"Exp: {ex.Message}");
                }
            }

            return Result<SalTransaction>.Sucess(obj, "Update Done !");
        }

        [HttpPost("AddSaleOrder")]
        public async Task<Result<SalTransactionAddVM>> AddSaleOrder(SalTransactionAddVM entity)
        {
            SalTransactionAddVM resultVM = new SalTransactionAddVM();
            SalTransaction obj = entity.SalTransaction;
            var GroupID = int.Parse(User.FindFirst("Group_ID")?.Value);
            var chk = await permission.HasPermission(285, PermissionType.Add, GroupID);
            if (!chk)
            {

                // return Result<IEnumerable<SalTransaction>>.Fail("NoPermission!!!");
                return Result<SalTransactionAddVM>.Fail("NoPermission!!!");
            }
            if (entity == null)
            {
                return Result<SalTransactionAddVM>.Fail("There is no Data!!!");
            }
            if (entity.SalTransactionsProducts == null)
            {
                return Result<SalTransactionAddVM>.Fail("There is no product in SalTransaction Data!!!");
            }
            if (obj == null)
            {
                return Result<SalTransactionAddVM>.Fail("There is no Data!!!");
            }
            //var getNo = await repository.GetAll(s => s.TransTypeId == obj.TransTypeId);
            //var no = getNo.Max(s => s.No) ?? 1;
            // obj.Code = $"{obj.TransTypeId}-{DateTime.Now}";
            // obj.No = no+1;
            obj.IsDeleted = false;
            var facilityId = User.FindFirst("Facility_ID")?.Value;
            var empId = User.FindFirst("Emp_ID")?.Value;
            obj.EmpId = long.Parse(empId ?? "0");
            obj.FacilityId = long.Parse(facilityId ?? "1");
            obj.Date1 = DateTime.Now.ToString("yyyy/MM/dd");
            obj.SysAppTypeId = 1;
            obj.CreatedBy = long.Parse(User.FindFirst("UserID")?.Value ?? "1");
            obj.CreatedOn = DateTime.Now;
            obj.AmountCost = 0;
            obj.Vat = 0;
            obj.VatAmount = 0;
            obj.ModifiedBy = 0;
            obj.ModifiedOn = DateTime.Now;
            obj.PaymentTerms = $"{obj.PaymentTermsId}";


            //  var addRes = await repository.AddAndReturn(obj);

            try
            {
                var code = await repository.AddUsingProcedure(obj);
                if (!string.IsNullOrEmpty(code))
                {
                    var newTrans = await repository.GetAll(s => s.Code == code);
                    if (newTrans != null)
                    {
                        var addedTrans = newTrans.FirstOrDefault();
                        if (addedTrans != null)
                        {

                            resultVM.SalTransaction = addedTrans;


                            List<SalTransactionsProduct> SalTransactionsProducts = new List<SalTransactionsProduct>();
                            foreach (var item in entity.SalTransactionsProducts)
                            {
                                item.TransactionId = addedTrans.Id;

                                item.IsDeleted = false;

                                item.CreatedBy = long.Parse(User.FindFirst("UserID")?.Value ?? "1");
                                item.CreatedOn = DateTime.Now;
                                //item.BranchId = addedTrans.BranchId;

                                item.ModifiedBy = 0;
                                item.ModifiedOn = DateTime.Now;



                                var tempPro = await productRepository.AddAndReturn(item);
                                await productRepository.SaveChanges();
                                if (tempPro != null)
                                {
                                    SalTransactionsProducts.Add(tempPro);
                                }
                            }

                            resultVM.SalTransactionsProducts = SalTransactionsProducts;



                            var getFacility = await repository.GetAllOther<AccFacility>(f => f.FacilityId == addedTrans.FacilityId);
                            if (getFacility != null)
                            {
                                var facility = getFacility.FirstOrDefault();   
                                if (facility != null)

                                {
                               

                                    string teken= GenerateGetToken();
                                  //  var qrResInvoice = QRHelper.GenerateQRforInvoice(addedTrans.Id, facility.FacilityName, facility.VatNumber, addedTrans.Total ?? 0, addedTrans.DiscountAmount ?? 0, addedTrans.VatAmount ?? 0, addedTrans.Date1, addedTrans.Code);
                                    int qrweService =await QRHelper.GenerateQRWebService(User.FindFirst("ErpUrl")?.Value, addedTrans.Id, teken, User.FindFirst("USER_ID")?.Value);
                                   // var qrResZATAC = QRHelper.GenerateQRforZATCA(addedTrans.Id, facility.FacilityName, facility.VatNumber, addedTrans.Total ?? 0, addedTrans.DiscountAmount ?? 0, addedTrans.VatAmount ?? 0, addedTrans.Date1, addedTrans.Code);
                                    if (qrweService==200)
                                    {
                                        return Result<SalTransactionAddVM>.Sucess(resultVM, "Added Successfully");
                                    }
                                }
                            }

                        }
                    }
                }
                // await repository.SaveChanges();
                return Result<SalTransactionAddVM>.Fail("لم يتم الاضافة ");
            }
            catch (Exception exp)
            {
                return Result<SalTransactionAddVM>.Fail($"Exp in add of:" +
                    $" {GetType().Name}, Message: {exp.Message} --- {(exp.InnerException != null ? "InnerExp: " + exp.InnerException.Message : "no inner")} .");
            }
        }

        [HttpPost("CountsOfTransactions")]
        public async Task<Result<SalTransaction>> CountsOfTransactions(SalTransaction obj)
        {
            if (obj == null)
            {
                return Result<SalTransaction>.Fail("There is no Data!!!");
            }

            var addRes = await repository.AddAndReturn(obj);

            try
            {
                await repository.SaveChanges();
                return Result<SalTransaction>.Sucess(addRes, "Added Successfylly");
            }
            catch (Exception exp)
            {
                return Result<SalTransaction>.Fail($"Exp in add of: {GetType().Name}, Message: {exp.Message} --- {(exp.InnerException != null ? "InnerExp: " + exp.InnerException.Message : "no inner")} .");
            }
        }





        [HttpDelete("Delete/{id}")]
        public async Task<Result<SalTransaction>> Delete(int id)
        {
            if (await repository.GetAll() == null)
            {
                return Result<SalTransaction>.Fail("There is no Data!!!");
            }
            var item = await repository.GetById(id);
            if (item == null)
            {
                return Result<SalTransaction>.Fail("There is no Data!!!");
            }

            var deleteRes = repository.RemoveAndReturn(item);
            try
            {
                await repository.SaveChanges();
                return Result<SalTransaction>.Sucess(deleteRes, "Deleted Successfylly");
            }
            catch (Exception ex)
            {
                return Result<SalTransaction>.Fail($"Exp: {ex.Message}");
            }

        }

        private bool IsExists(int id)
        {
            return (repository.Entities?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        [HttpGet("GetBalance")]

        public async Task<Result<IEnumerable<WhItemsGetBalance>>> GetBalance(long ItemID,
            int UnitItemId, string ItemCode)
        {
            try
            {
                long Finyear = 22;
                long InventoryID = 1;
                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);


                var list = await whItemRepository.WhItemsGetBalance(ItemID, faId, UnitItemId,
                    InventoryID, Finyear, ItemCode);
                return Result<IEnumerable<WhItemsGetBalance>>.Sucess(list, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<WhItemsGetBalance>>.Fail($"Exception: {ex.Message}");
            }

        }    
        
        



        [HttpGet("qrimages/invoices/{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            try
            {
                var imagePath = Path.Combine("Images", imageName);
                var file = new FileStream($"Files/QrCode/Sales/Invoice/{imageName}.jpg", FileMode.Open, FileAccess.Read);
                return File(file, "image/jpeg");
            }
            catch (Exception exc)
            {
                var imagePath = Path.Combine("Images", "default-product");
                var file = new FileStream($"Files/QrCode/Sales/Invoice/default-product.jpg", FileMode.Open, FileAccess.Read);
                return File(file, "image/jpeg");
               
            }
           // Adjust the content type based on your image type
        }

        [HttpGet("qrimages/zacat/{imageName}")]
        public IActionResult GetZacatImage(string imageName)
        {
      

            try
            {
                var imagePath = Path.Combine("Images", imageName);
                var file = new FileStream($"Files/QrCode/Sales/Invoice/{imageName}.jpg", FileMode.Open, FileAccess.Read);
                return File(file, "image/jpeg");
            }
            catch (Exception exc)
            {
                var imagePath = Path.Combine("Images", "default-product");
                var file = new FileStream($"Files/QrCode/Sales/Invoice/default-product.jpg", FileMode.Open, FileAccess.Read);
                return File(file, "image/jpeg");

            }// Adjust the content type based on your image type
        }





        [HttpPost("Generate_Token")]
        public ActionResult Generate_Token()
        {

            string USER_ID = User.FindFirst("USER_ID")?.Value;
            string token = repository.GenerateToken(USER_ID);


            return Ok(new { Token = token, USER_ID = USER_ID });

        }

        private string GenerateGetToken() {

            string USER_ID = User.FindFirst("USER_ID")?.Value;
            string token = repository.GenerateToken(USER_ID);
            return token;
        }
    }
}
