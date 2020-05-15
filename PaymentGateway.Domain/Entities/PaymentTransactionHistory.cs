using System;

namespace PaymentGateway.Domain.Entities
{
    public class PaymentTransactionHistory
    {
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }
        public string CustomerId { get; set; }
        public string Invoice { get; set; }
        public DateTime Modified { get; set; }
        public int RecordId { get; set; }
        public bool ReserveFunds { get; set; }
        public decimal Tax { get; set; }
        public string Transaction_Detail { get; set; }
    }
}
