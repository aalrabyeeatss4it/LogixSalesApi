using Microsoft.EntityFrameworkCore;
using LogixApi_v02.Helpers;
using LogixApi_v02.IRepositories.Sales;
using LogixApi_v02.Models.Sales;
using Microsoft.AspNetCore.Mvc;
using LogixApi_v02.ViewModels.Sales;

namespace LogixApi_v02.Controllers.Sales
{
    [Route("api/[controller]")]

    [ApiController]
    public class SalPaymentTermControllr : ControllerBase

    {
        private readonly ISalPaymentTermRepository paymentRepository;

        public SalPaymentTermControllr(ISalPaymentTermRepository paymentRepository)

        {
            this.paymentRepository = paymentRepository;
        }

        [HttpGet("getAll")]
        public async Task<Result<IEnumerable<SalPaymentTerm>>> GetAll()
        {
            try
            {
                if (paymentRepository.Entities == null)
                {
                    return Result<IEnumerable<SalPaymentTerm>>.Fail("There is no Data!!!");
                }
                var paymentList = await paymentRepository.GetAll(d => d.IsDeleted == false);
                return Result<IEnumerable<SalPaymentTerm>>.Sucess(paymentList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SalPaymentTerm>>.Fail($"Exception: {ex.Message}");
            }

        }




        [HttpGet("GetPaymentTerms")]
        public async Task<Result<IEnumerable<SalPaymentTermsVM>>> GetPaymentTerms()
        {
            try
            {
                var res = await paymentRepository.GetAll();
                if (res == null)
                {
                    return Result<IEnumerable<SalPaymentTermsVM>>.Fail("There is no Data!!!");
                }
                var vmList = new List<SalPaymentTermsVM>();
                vmList = res.Where(d => d.IsDeleted == false).Select(d => new SalPaymentTermsVM
                {
                    IdPayment = d.Id,
                    PaymentTerms = d.PaymentTerms,  
                    PaymentTerms2 = d.PaymentTerms2,  
                    


                }).ToList();
                return Result<IEnumerable<SalPaymentTermsVM>>.Sucess(vmList, "");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SalPaymentTermsVM>>.Fail($"Exception: {ex.Message}");
            }

        }

    }
}
