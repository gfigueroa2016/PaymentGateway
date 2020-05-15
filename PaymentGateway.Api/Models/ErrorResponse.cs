namespace PaymentGateway.Api.Models
{
    public class ErrorResponse
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
