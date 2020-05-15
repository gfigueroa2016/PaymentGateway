using System.ComponentModel.DataAnnotations;

namespace DynamicsPayments.Domain.DTO.Token.Requests
{
    public class DeleteCustomerTokenRequest
    {
        public string AccountToken { get; set; }
        public string CustomerId { get; set; }
    }
}