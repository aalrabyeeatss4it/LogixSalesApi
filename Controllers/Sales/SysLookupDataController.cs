using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogixApi_v02.Controllers.Sales
{
    [Authorize]
    // [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SysLookupDataController : ControllerBase
    {

        private readonly ISysLookupDataRepository repository;

        public SysLookupDataController(ISysLookupDataRepository repository)
        { 
        this.repository = repository;   
        
        }


       [HttpGet("getAll")]
        public async Task<Result<IEnumerable<SysLookupData>>> GetAll()
        {
            try
            {
                if (repository.Entities == null)
                {
                    return Result<IEnumerable<SysLookupData>>.Fail("There is no Data!!!");
                }
                var customerActivityList = await repository.GetAll();
                return Result<IEnumerable<SysLookupData>>.Sucess(customerActivityList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SysLookupData>>.Fail($"Exception: {ex.Message}");
            }

        } 
        
        [HttpGet("identityType")]
        public async Task<Result<IEnumerable<SysLookupDataVM>>> GetidentityType()
        {
            try
            {
                if (repository.Entities == null)
                {
                    return Result<IEnumerable<SysLookupDataVM>>.Fail("There is no Data!!!");
                }
                var sysLookups = await repository.GetAll(d=>d.CatagoriesId==16);
                var identityTypeList =  sysLookups.Select(d => new SysLookupDataVM
                {

                    CatagoriesId = d.CatagoriesId,
                    Name = d.Name,
                    Code = d.Code,

                }).ToList();
                return Result<IEnumerable<SysLookupDataVM>>.Sucess(identityTypeList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SysLookupDataVM>>.Fail($"Exception: {ex.Message}");
            }

        }



        [HttpGet("GetCustomerActivity")]
        public async Task<Result<IEnumerable<SysLookupDataVM>>> GetCustomerActivity()
        {
            try
            {
                var res = await repository.GetAll();
                if (res == null)
                {
                    return Result<IEnumerable<SysLookupDataVM>>.Fail("There is no Data!!!");
                }
                var getCustomerActivList = new List<SysLookupDataVM>();
                getCustomerActivList = res.Where(d => d.Isdel == false  && d.CatagoriesId == 300 ).Select(d => new SysLookupDataVM
                {

                    CatagoriesId = d.CatagoriesId,
                    Name = d.Name,
                    Code= d.Code,

                }).ToList();
                return Result<IEnumerable<SysLookupDataVM>>.Sucess(getCustomerActivList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SysLookupDataVM>>.Fail($"Exception: {ex.Message}");
            }

        }


    }
    }

