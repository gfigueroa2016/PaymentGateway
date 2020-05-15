using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace DynamicsPayments.Filters
{
    public class CustomerPaymentGatewayActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
        public class CustomerPaymentGatewayActionFilterAsync : IAsyncActionFilter
        {
            public async Task OnActionExecutionAsync(ActionExecutingContext
            context, ActionExecutionDelegate next)
            {
                //Before
                var resultContext = await next();
                //After
            }
        }
    }
}
