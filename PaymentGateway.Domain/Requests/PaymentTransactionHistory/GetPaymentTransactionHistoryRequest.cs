namespace PaymentGateway.Domain.Requests.PaymentTransactionHistory
{
    public class GetPaymentTransactionHistoryRequest
    {
        public string CustomerId { get; set; }
        public string Invoice { get; set; }
    }
}
