using LogixApi_v02.Models.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextToQRImagePackage;

namespace LogixApi_v02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public QRController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("GetQRImage")]
        public IActionResult GetQRImage(string text)
        {
            

             return Ok();
        }
    }
}
