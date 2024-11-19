using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.TestModels;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogixApi_v02.Controllers.Sales
{
    //  [Authorize]
    // [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SalPosSettingController : ControllerBase
    {
        private readonly ISalPosSettingRepository salPosSettingRepository;
        private readonly ISalPosUserRepository salPosUserRepository;
        private readonly ISalPosCloseCashRepository salPosCloseCashRepository;
        private readonly IAccFacilitiesVwRepository facilitiesVwRepository;

        public SalPosSettingController(ISalPosSettingRepository salPosSettingRepository, ISalPosUserRepository salPosUserRepository, ISalPosCloseCashRepository salPosCloseCashRepository,
            IAccFacilitiesVwRepository facilitiesVwRepository
            )

        {

            this.salPosSettingRepository = salPosSettingRepository;
            this.salPosUserRepository = salPosUserRepository;
            this.salPosCloseCashRepository = salPosCloseCashRepository;
            this.facilitiesVwRepository = facilitiesVwRepository;
        }
        [HttpGet("GetAllSalesPoints")]

        public async Task<Result<List<SalPosSettingVM>>> GetAllSalesPoints()
        {
            try
            {
                //if (User_ID == 0)
                //{
                //   return Result<List<SalesPointsVM>>.Fail($"no id found");
                //}

                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId);
                var userID = long.Parse(User.FindFirst("USER_ID")?.Value);
                var getSalesPoint = await salPosUserRepository
          .GetAllOther<SalPosUsersVw>(d => d.IsDeleted == false && d.UserId == userID)
         ;
                var SalesPointList = getSalesPoint.ToList();

                var getAll = await salPosSettingRepository
             .GetAllOther<SalPosSettingVw>(s => s.FacilityId == faId);

                AccFacilitiesVw facilitiesVw=await facilitiesVwRepository.GetFirst(d=>d.FacilityId==faId);


                var getDetails = getAll.Where(d => SalesPointList.Any(sp => sp.PosId == d.Id)).Select(d => new SalPosSettingVM
                {
                    Id = d.Id,
                    InventoryId = d.InventoryId,
                    CustomerId = d.CustomerId,
                    BankId = d.BankId,
                    BranchId = d.BranchId,
                    FacilityId = d.FacilityId,
                    CustomerName = d.CustomerName,
                    Name = d.Name,
                    FacilityName=facilitiesVw.FacilityName,
                    FacilityName2 = facilitiesVw.FacilityName2,
                    FacilityMobile = facilitiesVw.FacilityMobile,
                    Address=facilitiesVw.FacilityAddress,
                    VatNumber=facilitiesVw.VatNumber,
                    
                    BankAccountId = d.BankAccountId,
                    CashAccountId = d.CashAccountId,
                    LnkAccounting = d.LnkAccounting,
                    LnkInventory = d.LnkInventory,

                }).ToList();

                // var salePointList = new List<SalesPointsVM>();


                //if (getSalesPoint != null)
                //{
                //    List<SalesPointsVM> posList = new List<SalesPointsVM>();
                //foreach (var s in getSalesPoint)
                //    {
                //        foreach(var p in getDetails)
                //        {
                //            if(s.PosId == p.Id)
                //            {
                //                posList.Add(new SalesPointsVM
                //                {
                //                    Id=p.Id,
                //                    BankAccountId=p.BankAccountId,
                //                    BankId=p.BankId,
                //                    Name = p.Name,
                //                    BranchId=p.BranchId,
                //                    CustomerId=p.CustomerId,
                //                    CashAccountId=p.CashAccountId,
                //                    CustomerName=p.CustomerName,
                //                    FacilityId=p.FacilityId,
                //                    InventoryId=p.InventoryId,
                //                    UserId= s.UserId,

                //                });
                //            }
                //        }
                //    }

                return Result<List<SalPosSettingVM>>.Sucess(getDetails, "");
                //}

                //return Result<List<SalesPointsVM>>.Fail("Error, no customer found for this id}");           
            }
            catch (Exception ex)
            {
                return Result<List<SalPosSettingVM>>.Fail($"Exception: {ex.Message}");


            }


        }

        [HttpPost("insertsalPosCloseCash")]

        public async Task<Result<SalPosCloseCash>> InsertsalPosCloseCash( SalPosCloseCash salPosCloseCash)
        {


            try
            {
                var userID = long.Parse(User.FindFirst("USER_ID")?.Value);
                salPosCloseCash.CreatedBy = userID;

                await salPosCloseCashRepository.AddISalPosCloseCash( salPosCloseCash);



                return Result<SalPosCloseCash>.Sucess(salPosCloseCash, "");

            }
            catch (Exception ex)
            {

                return Result<SalPosCloseCash>.Fail($"Exception: {ex.Message}");
            }
        }

    }

}     

