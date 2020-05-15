using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicsPayments.Domain.Entities
{
    public class MarkByID
    {
        public string Account { get; set; }
        public string AccountToken { get; set; }
        public string IDTransaction { get; set; }
        public string BatchCode { get; set; }
        public string AcquirerName { get; set; }
        public string Status { get; set; }
        public string CardHolderName { get; set; }
        public string AuditNumber { get; set; }
        public string ResponseCode { get; set; }
        public string DesicionResponseCode { get; set; }
        public string Message { get; set; }
        public string AuthNumber { get; set; }
        public DateTime HostDate { get; set; }
        public TimeSpan HostTime { get; set; }
    }
}
