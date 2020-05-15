using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Requests.SystemSetting
{
    public class EditSystemSettingRequest
    {
        public string AccountId { get; set; }
        public bool Active { get; set; }
        public string ClientId { get; set; }
        public string CustomerId { get; set; }
        public string Secret { get; set; }
        public string PaymentGatewayUrl { get; set; }
        public string StoreUrl { get; set; }
    }
}
