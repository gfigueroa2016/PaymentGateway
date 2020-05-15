using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicsPayments.Domain.Entities
{
    public class RegisterToken
    {
        public string Account { get; set; }
        public string AccountToken { get; set; }
        public string CustomerName { get; set; }
        public bool IsDefault { get; set; }
        public string Status { get; set; }
        public string ZipCode { get; set; }
    }
}
