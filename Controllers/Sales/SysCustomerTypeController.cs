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
    public class SysCustomerTypeController : ControllerBase
    {
        private readonly ISysCustomerTypeRepository customerTypeRepository;

        public SysCustomerTypeController(ISysCustomerTypeRepository customerTypeRepository)
        {
            this.customerTypeRepository = customerTypeRepository;
        }

        [HttpGet("getAll")]
        public async Task<Result<IEnumerable<SysCustomerType>>> GetAll()
        {
            try
            {
                if (customerTypeRepository.Entities == null)
                {
                    return Result<IEnumerable<SysCustomerType>>.Fail("There is no Data!!!");
                }
                var customerTypeList = await customerTypeRepository.GetAll();
                return Result<IEnumerable<SysCustomerType>>.Sucess(customerTypeList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SysCustomerType>>.Fail($"Exception: {ex.Message}");
            }

        }




        [HttpGet("GetcustomerType")]
        public async Task<Result<IEnumerable<SysCustomerTypeVM>>> GetcustomerType()
        {
            try
            {
                var res = await customerTypeRepository.GetAll();
                if (res == null)
                {
                    return Result<IEnumerable<SysCustomerTypeVM>>.Fail("There is no Data!!!");
                }
                var InventoryList = new List<SysCustomerTypeVM>();
                InventoryList = res.Select(d => new SysCustomerTypeVM
                {
                
                    TypeId = d.TypeId,
                    CusTypeName = d.CusTypeName,



                }).ToList();
                return Result<IEnumerable<SysCustomerTypeVM>>.Sucess(InventoryList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SysCustomerTypeVM>>.Fail($"Exception: {ex.Message}");
            }

        }


    }
}
