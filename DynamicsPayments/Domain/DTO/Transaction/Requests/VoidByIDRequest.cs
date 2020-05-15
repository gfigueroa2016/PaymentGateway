using System.ComponentModel.DataAnnotations;

namespace DynamicsPayments.Domain.DTO.Transaction.Requests
{
    public class VoidByIDRequest
    {
        public string IDTransaction { get; set; }
        public string MerchantKey { get; set; }
    }
}
