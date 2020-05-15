namespace DynamicsPayments.Domain.DTO.Transaction.Requests
{
    public class MarkByIDRequest
    {
        public string IDTransaction { get; set; }
        public string MerchantKey { get; set; }
    }
}
