using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Api.Settings
{
    public class PaymentGatewaySettings
    {
        public string[] DynamicsPaymentsDomainPolicyProduction { get; set; }
        public string[] DynamicsPaymentsDomainPolicyDevelopment { get; set; }
    }
}
