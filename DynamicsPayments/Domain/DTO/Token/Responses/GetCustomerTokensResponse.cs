namespace DynamicsPayments.Domain.DTO.Token.Responses
{
    public class GetCustomerTokensResponse
    {
        public string Account { get; set; }
        public string AccountToken { get; set; }
        public string CustomerName { get; set; }
        public bool IsDefault { get; set; }
        public string Status { get; set; }
        public string ZipCode { get; set; }
    }
}
