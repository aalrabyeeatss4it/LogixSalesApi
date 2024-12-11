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
    public class WhInventoryController : ControllerBase
    {

        private readonly IWhInventoryRepository inventoryRepository;

        public WhInventoryController(IWhInventoryRepository inventoryRepository)
        {

            this.inventoryRepository = inventoryRepository;

        }
        [HttpGet("getAll")]
        public async Task<Result<IEnumerable<WhInventory>>> GetAll()
        {
            try
            {
                if (inventoryRepository.Entities == null)
                {
                    return Result<IEnumerable<WhInventory>>.Fail("There is no Data!!!");
                }
                var inventoryList = await inventoryRepository.GetAll(d => d.IsDeleted == false);
                return Result<IEnumerable<WhInventory>>.Sucess(inventoryList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<WhInventory>>.Fail($"Exception: {ex.Message}");
            }

        }

        [HttpGet("GetInventory")]
        public async Task<Result<IEnumerable<WhInventoryVM>>> GetInventory()
        {
            try
            {
                var res = await inventoryRepository.GetAll();
                if (res == null)
                {
                    return Result<IEnumerable<WhInventoryVM>>.Fail("There is no Data!!!");
                }
                var getInventoryList = new List<WhInventoryVM>();
                getInventoryList = res.Where(d => d.IsDeleted == false).Select(d => new WhInventoryVM
                {
                   
                  Id = d.Id,  
                  InventoryName = d.InventoryName,


                }).ToList();
                return Result<IEnumerable<WhInventoryVM>>.Sucess(getInventoryList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<WhInventoryVM>>.Fail($"Exception: {ex.Message}");
            }

        }
    }
}
