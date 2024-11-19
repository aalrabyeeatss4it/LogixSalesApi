using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogixApi_v02.Controllers.Sales
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvestBranchController : ControllerBase
    {
        private readonly IInvestBranchRepository invBranchRepository;
        public InvestBranchController(IInvestBranchRepository invBranchRepository) { 

            this.invBranchRepository = invBranchRepository;
        }

    


        [HttpGet("getAll")]
        public async Task<Result<IEnumerable<InvestBranch>>> GetAll()
        {
            try
            {
                if (invBranchRepository.Entities == null)
                {
                    return Result<IEnumerable<InvestBranch>>.Fail("There is no Data!!!");
                }
                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId??"1");
                var branchList = await invBranchRepository.GetAll(d => d.Isdel == false && d.FacilityId == faId);
                return Result<IEnumerable<InvestBranch>>.Sucess(branchList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<InvestBranch>>.Fail($"Exception: {ex.Message}");
            }

        }




        [HttpGet("GetInvestBranch")]
        public async Task<Result<IEnumerable<BranchesVM>>> GetPaymentTerms()
        {
            try
            {
                var res = await invBranchRepository.GetAll();
                if (res == null)
                {
                    return Result<IEnumerable<BranchesVM>>.Fail("There is no Data!!!");
                }
                var branchList = new List<BranchesVM>();
                var facilityId = User.FindFirst("Facility_ID")?.Value;
                var faId = long.Parse(facilityId ?? "1");
                branchList = res.Where(d => d.Isdel == false && d.FacilityId == faId).Select(d => new BranchesVM
                {
                             BraName =d.BraName,
                             BranchId =d.BranchId.ToString(),



    }).ToList();
                return Result<IEnumerable<BranchesVM>>.Sucess(branchList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<BranchesVM>>.Fail($"Exception: {ex.Message}");
            }

        }
    }

    }

