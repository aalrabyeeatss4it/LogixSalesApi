using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories;
using LogixApi_v02.Models;
using LogixApi_v02.ViewModels;
using LogixApi_v02.ViewModels.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace LogixApi_v02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : Controller
    {
        private readonly ISysSystemRepository sysSystemRepository;

        public MasterController(ISysSystemRepository sysSystemRepository )
        {
            this.sysSystemRepository = sysSystemRepository;
        }
      
        [HttpGet("GetSysScreens")]
        public async Task<IActionResult> GetSysScreens(int sysId)
        {
            try
            {
                var UserId = int.Parse(User.FindFirst("USER_ID")?.Value);

                var getSys = await sysSystemRepository.GetById(sysId);
                if (getSys!=null)
                {
                    var parentsList = new List<MainListDto>();
                    var getParentsList = await sysSystemRepository.GetMainList(UserId, sysId, 13);
                    if (getParentsList != null)
                    {
                        parentsList = getParentsList.ToList();
                    }

                    foreach (var parent in parentsList)
                    {
                        var subList = new List<SubListDto>();
                        var getSubList = await sysSystemRepository.GetSubList(UserId, sysId, 14, (int)parent.SCREEN_ID);
                        if (getSubList != null)
                        {
                            subList = getSubList.ToList();
                            parent.SubScreens = subList;
                        }
                    }
                    var temp =  Result<object>.Sucess(new { system = getSys, screens = parentsList }, "");
                    return Ok(temp);
                }

                return Ok(getSys);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }



}
