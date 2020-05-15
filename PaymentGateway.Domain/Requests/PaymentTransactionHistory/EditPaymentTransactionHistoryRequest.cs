using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Requests.PaymentTransactionHistory
{
    public class EditPaymentTransactionHistoryRequest
    {
        public decimal Amount { get; set; }
        public string CustomerId { get; set; }
        public string Invoice { get; set; }
        public decimal Tax { get; set; }
        public string Transaction_Detail { get; set; }
    }
}
