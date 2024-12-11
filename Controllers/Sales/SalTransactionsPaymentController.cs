using LogixApi_v02.IRepositories.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogixApi_v02.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalTransactionsPaymentController : ControllerBase
    {
        private readonly ISalTransactionsPaymentRepository repository;

        public SalTransactionsPaymentController(ISalTransactionsPaymentRepository repository)

        { 
            this.repository = repository;

        }

    }
}
