using System.ComponentModel.DataAnnotations;

namespace DynamicsPayments.Domain.DTO.Token.Requests
{
    public class GetCustomerTokensRequest
    {
        public string CustomerId { get; set; }
        public string MerchantKey { get; set; }
    }
}