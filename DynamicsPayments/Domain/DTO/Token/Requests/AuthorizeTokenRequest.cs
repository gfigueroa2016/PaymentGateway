using DynamicsPayments.Domain.DTO.Token.Responses;

namespace DynamicsPayments.Domain.DTO.Token.Requests
{
    public class AuthorizeTokenRequest
    {
        public string MerchantKey { get; set; }
        public string AccountToken { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public decimal Tax { get; set; }
        public string Invoice { get; set; }
        public string Transaction_Detail { get; set; }
        public bool ReserveFunds { get; set; }
    }
}
