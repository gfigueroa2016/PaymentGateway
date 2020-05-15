using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Api.Models;

namespace PaymentGateway.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SwaggerController : ControllerBase
    {
        public IActionResult Index()
        {
            return Redirect("https://localhost:5001/swagger/v1/index.html");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ErrorResponse Error()
        {
            return new ErrorResponse { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
        }
    }
}