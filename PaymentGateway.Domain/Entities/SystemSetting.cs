using System;

namespace PaymentGateway.Domain.Entities
{
    public class SystemSetting
    {
        public string AccountId { get; set; }
        public bool Active { get; set; }
        public string ClientId { get; set; }
        public DateTime Created { get; set; }
        public string CustomerId { get; set; }
        public DateTime Modified { get; set; }
        public string PaymentGatewayUrl { get; set; }
        public int RecordId { get; set; }
        public string Secret { get; set; }
        public string StoreUrl { get; set; }
    }
}
