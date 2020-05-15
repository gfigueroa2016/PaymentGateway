using DynamicsPayments.Domain.DTO.Transaction.Requests;
using DynamicsPayments.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IDynamicsPaymentsTransactionService _dynamicsPaymentsTransactionService;
        //private readonly ILogger<TokenController> _logger;
        public TransactionController(IDynamicsPaymentsTransactionService dynamicsPaymentsTransactionService)
        {
            _dynamicsPaymentsTransactionService = dynamicsPaymentsTransactionService;
            //_logger = logger;
        }
        [HttpGet("dynamicspayments/transaction")]
        public async Task<IActionResult> GetDynamicsPaymentsTransactionByID(GetTransactionByIDRequest getTransactionByIDRequest)
        {
            return base.Ok(await _dynamicsPaymentsTransactionService.GetTransactionByIDAsync(getTransactionByIDRequest));
        }
        [HttpPost("dynamicspayments/transaction/approve")]
        public async Task<IActionResult> PostDynamicsPaymentsMarkByID(MarkByIDRequest markByIDRequest)
        {
            return base.Ok(await _dynamicsPaymentsTransactionService.PostMarkByIDAsync(markByIDRequest));
        }
        [HttpGet("dynamicspayments/transaction/void")]
        public async Task<IActionResult> PostDynamicsPaymentsVoidByID(VoidByIDRequest voidByIDRequest)
        {
            return base.Ok(await _dynamicsPaymentsTransactionService.PostVoidByIDAsync(voidByIDRequest));
        }
    }
}