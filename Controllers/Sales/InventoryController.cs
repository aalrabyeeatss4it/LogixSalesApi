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
    public class InventoryController : ControllerBase
    {
        private readonly IWhInventoryRepository whInventoryRepository;

        public InventoryController( IWhInventoryRepository whInventoryRepository)
        {
            this.whInventoryRepository = whInventoryRepository;
        }

        [HttpGet("getAll")]
        public async Task<Result<IEnumerable<WhInventory>>> GetAll()
        {
            try
            {
                if (whInventoryRepository.Entities == null)
                {
                    return Result<IEnumerable<WhInventory>>.Fail("There is no Data!!!");
                }
                var inventoryList = await whInventoryRepository.GetAll(d => d.IsDeleted == false);
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
                var res = await whInventoryRepository.GetAll();
                if (res == null)
                {
                    return Result<IEnumerable<WhInventoryVM>>.Fail("There is no Data!!!");
                }
                var InventoryList = new List<WhInventoryVM>();
                InventoryList = res.Where(d => d.IsDeleted == false).Select(d => new WhInventoryVM
                {
                    Id = d.Id,
                    InventoryName=d.InventoryName




                }).ToList();
                return Result<IEnumerable<WhInventoryVM>>.Sucess(InventoryList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<WhInventoryVM>>.Fail($"Exception: {ex.Message}");
            }

        }


    }
}
