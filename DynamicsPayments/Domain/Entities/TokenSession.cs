using System;
using System.Collections.Generic;

namespace DynamicsPayments.Domain.Entities
{
    public class TokenSession
    {
        public string CustomerId { get; set; }
        public string SessionId { get; set; }
        public IList<Token> Tokens { get; set; }
        public DateTimeOffset ValidityDate { get; set; }
    }
}
