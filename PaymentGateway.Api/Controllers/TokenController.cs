using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DynamicsPayments.Domain.Services;
using DynamicsPayments.Extensions;
using DynamicsPayments.Domain.DTO.Token.Requests;

namespace PaymentGateway.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IDynamicsPaymentsTokenService _dynamicsPaymentstokenService;
        //private readonly ILogger<TokenController> _logger;
        public TokenController(IDynamicsPaymentsTokenService tokenService) //ILogger<TokenController> logger)
        {
            _dynamicsPaymentstokenService = tokenService;
            //_logger = logger;
        }
        [HttpGet("dynamicspayments/token")]
        public async Task<IActionResult> GetByCustomerIdAsync(GetCustomerTokensRequest customerTokensRequest)
        {
            var result = await _dynamicsPaymentstokenService.GetCustomerTokensAsync(new GetCustomerTokensRequest { CustomerId = DynamicsPaymentsExtensions.GetConcatCustomerId(customerTokensRequest.CustomerId) });
            return Ok(result);
        }
        [HttpPost("dynamicspayments/token/authorize")]
        public async Task<IActionResult> PostAuthorizeTokenAsync(RegisterTokenRequest registerTokenRequest, AuthorizeTokenRequest authorizeTokenRequest)
        {
            var registerTokenResponse = await _dynamicsPaymentstokenService.PostRegisterTokenAsync(registerTokenRequest);
            authorizeTokenRequest.AccountToken = registerTokenResponse.AccountToken;
            return Ok(await _dynamicsPaymentstokenService.PostAuthorizeTokenAsync(authorizeTokenRequest));
        }
        [HttpPost("dynamicspayments/token/authorize")]
        public async Task<IActionResult> PostDeleteCustomerTokenAsync(DeleteCustomerTokenRequest deleteCustomerTokenRequest)
        {
            return Ok(await _dynamicsPaymentstokenService.PostDeleteCustomerTokenAsync(deleteCustomerTokenRequest));
        }
    }
}