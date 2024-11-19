using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogixApi_v02.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysCustomerGroupController : ControllerBase
    {
        private readonly ISysCustomerGroupRepository sysCustomerGroupRepository;

        public SysCustomerGroupController(ISysCustomerGroupRepository sysCustomerGroupRepository)
        {
            this.sysCustomerGroupRepository = sysCustomerGroupRepository;
        }

        [HttpGet("getAll")]
        public async Task<Result<IEnumerable<SysLookupDataVM>>> GetAll()
        {
            try
            {
                if (sysCustomerGroupRepository.Entities == null)
                {
                    return Result<IEnumerable<SysLookupDataVM>>.Fail("There is no Data!!!");
                }
                var sysCustomerGroupList = await sysCustomerGroupRepository.GetAll(d => d.IsDeleted == false&&d.CusTypeId==2);
                var getlookup = sysCustomerGroupList.Select(d => new SysLookupDataVM { 
                    
                    CatagoriesId=0,
                        Code=d.Id,
                        Name=d.Name,
                        


                
                });
                return Result<IEnumerable<SysLookupDataVM>>.Sucess(getlookup, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SysLookupDataVM>>.Fail($"Exception: {ex.Message}");
            }

        }




        [HttpGet("GetSysCustomerGroup")]
        public async Task<Result<IEnumerable<SysCustomerGroupVM>>> GetSysCustomerGroup()
        {
            try
            {
                var res = await sysCustomerGroupRepository.GetAll();
                if (res == null)
                {
                    return Result<IEnumerable<SysCustomerGroupVM>>.Fail("There is no Data!!!");
                }
                var getSysCustomerGroupList = new List<SysCustomerGroupVM>();
                getSysCustomerGroupList = res.Where(d => d.IsDeleted == false).Select(d => new SysCustomerGroupVM
                {

                    CusTypeId = d.CusTypeId,
                        Name = d.Name,  

                }).ToList();
                return Result<IEnumerable<SysCustomerGroupVM>>.Sucess(getSysCustomerGroupList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SysCustomerGroupVM>>.Fail($"Exception: {ex.Message}");
            }

        }


    }

}
