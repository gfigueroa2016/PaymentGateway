using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicsPayments.Domain.Entities
{
    public class TransactionSession
    {
        public string CustomerId { get; set; }
        public string SessionId { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public DateTimeOffset ValidityDate { get; set; }
    }
}
