namespace PaymentGateway.Domain.Models
{
    public class PaymentDetail
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string CustomerId { get; set; }
        public bool ReserveFunds { get; set; }
        public string Invoice { get; set; }
        public decimal Tax { get; set; }
        public string Transaction_Detail { get; set; }
    }
}