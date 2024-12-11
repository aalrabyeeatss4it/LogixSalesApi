using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogixApi_v02.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysCustomerCoTypeController : ControllerBase
    {
        private readonly ISysCustomerCoTypeRepository customerCoTypeRepository;

        public SysCustomerCoTypeController(ISysCustomerCoTypeRepository customerCoTypeRepository)

        {
            this.customerCoTypeRepository = customerCoTypeRepository;
        }

        [HttpGet("getAll")]
        public async Task<Result<IEnumerable<SysCustomerCoType>>> GetAll()
        {
            try
            {
                if (customerCoTypeRepository.Entities == null)
                {
                    return Result<IEnumerable<SysCustomerCoType>>.Fail("There is no Data!!!");
                }
                var customerCoTypeList = await customerCoTypeRepository.GetAll();
                return Result<IEnumerable<SysCustomerCoType>>.Sucess(customerCoTypeList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SysCustomerCoType>>.Fail($"Exception: {ex.Message}");
            }

        }




        [HttpGet("GetcustomerCoType")]
        public async Task<Result<IEnumerable<SysCustomerCoType>>> GetcustomerCoType()
        {
            try
            {
                var res = await customerCoTypeRepository.GetAll();
                if (res == null)
                {
                    return Result<IEnumerable<SysCustomerCoType>>.Fail("There is no Data!!!");
                }
                var getcustomerCoTypeList = new List<SysCustomerCoType>();
                getcustomerCoTypeList = res.Select(d => new SysCustomerCoType
                {
                   
                    Id = d.Id,
                    Name = d.Name,



                }).ToList();
                return Result<IEnumerable<SysCustomerCoType>>.Sucess(getcustomerCoTypeList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SysCustomerCoType>>.Fail($"Exception: {ex.Message}");
            }

        }


    }
}
    
