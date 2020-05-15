namespace DynamicsPayments.Domain.DTO.Token.Requests
{
    public class RegisterTokenRequest
    {
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string CreditCard { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public bool IsDefault { get; set; }
        public string MerchantKey { get; set; }
        public int ZipCode { get; set; }
    }
}