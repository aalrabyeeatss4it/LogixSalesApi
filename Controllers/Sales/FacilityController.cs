using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories;
using LogixApi_v02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogixApi_v02.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
         
        private readonly IAccFacilityRepository facilityRepository;

        public FacilityController(IAccFacilityRepository facilityRepository)
        {
            this.facilityRepository = facilityRepository;
        }

        [HttpGet("getAll")]
        public async Task<Result<IEnumerable<AccFacility>>> GetAll()
        {
            try
            {
                if (facilityRepository.Entities == null)
                {
                    return Result<IEnumerable<AccFacility>>.Fail("There is no Data!!!");
                }
                var inventoryList = await facilityRepository.GetAll();
                return Result<IEnumerable<AccFacility>>.Sucess(inventoryList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<AccFacility>>.Fail($"Exception: {ex.Message}");
            }

        }




    }
}
