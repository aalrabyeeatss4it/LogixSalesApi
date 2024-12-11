using LogixApi_v02.Helpers;
using Microsoft.AspNetCore.Mvc;
namespace LogixApi_v02.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SysConfigController : ControllerBase
    {
    

        public SysConfigController()
        {
          
        }
       


        [HttpGet("GetAll")]
        public  Result<List<SysConfigAppDto>> GetAll()
        {
            try
            {
                List<SysConfigAppDto> tempConfig = new List<SysConfigAppDto>();
                tempConfig.Add(new SysConfigAppDto
                {

                    Code = 1,
                    Name = "maintenance",
                    Required = false,
                    Value = "1",
                }) ; 
                
                tempConfig.Add(new SysConfigAppDto
                {

                    Code = 2,
                    Name = "version",
                    Required = false,
                    Value = "1",
                }) ;

               
                return  Result<List<SysConfigAppDto>>.Sucess(tempConfig);


            }
            catch (Exception exp)
            {
                return  Result<List<SysConfigAppDto>>.Fail($"EXP in {this.GetType().Name} , Message: {exp.Message}");
            }
        }

        [HttpGet("qrimages/invoices/{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            try
            {
                var imagePath = Path.Combine("Images", imageName);
                var file = new FileStream($"Files/QrCode/Sales/Invoice/{imageName}.jpg", FileMode.Open, FileAccess.Read);
                return File(file, "image/jpeg");
            }
            catch (Exception exc)
            {
                var imagePath = Path.Combine("Images", "default-product");
                var file = new FileStream($"Files/QrCode/Sales/Invoice/default-product.jpg", FileMode.Open, FileAccess.Read);
                return File(file, "image/jpeg");

            }
            // Adjust the content type based on your image type
        }

        [HttpGet("qrimages/zacat/{imageName}")]
        public IActionResult GetZacatImage(string imageName)
        {


            try
            {
                var imagePath = Path.Combine("Images", imageName);
                var file = new FileStream($"Files/QrCode/Sales/Invoice/{imageName}.jpg", FileMode.Open, FileAccess.Read);
                return File(file, "image/jpeg");
            }
            catch (Exception exc)
            {
                var imagePath = Path.Combine("Images", "default-product");
                var file = new FileStream($"Files/QrCode/Sales/Invoice/default-product.jpg", FileMode.Open, FileAccess.Read);
                return File(file, "image/jpeg");

            }// Adjust the content type based on your image type
        }


    }

  public class SysConfigAppDto
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public bool? Required { get; set; } = false;

    }


}
