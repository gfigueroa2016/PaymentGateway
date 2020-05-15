using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Requests.PaymentTransactionHistory
{
    public class DeletePaymentTransactionHistoryRequest
    {
        public string Invoice { get; set; }
    }
}
