using System;

namespace DynamicsPayments.Domain.Entities
{
    public class DynamicsPaymentsConfiguration
    {
        public string SessionId { get; set; }
        public string SiteId { get; set; }
        public string Secret { get; set; }
        public Uri Url { get; set; }
    }
}