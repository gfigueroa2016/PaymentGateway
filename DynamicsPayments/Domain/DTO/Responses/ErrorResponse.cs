namespace DynamicsPayments.Domain.DTO.Responses
{
    public class ErrorResponse
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
