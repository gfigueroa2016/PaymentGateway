using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DynamicsPayments.Domain.Entities
{
    public class Token
    {
        public string Account { get; set; }
        public string AccountToken { get; set; }
        public string AccountType { get; set; }
        public string AcquirerName { get; set; }
        public string Amount { get; set; }
        public string AuditNumber { get; set; }
        public string AuthNumber { get; set; }
        public string Batch_Code { get; set; }
        public string CardHolderName { get; set; }
        public string Currency { get; set; }
        public string CustomerName { get; set; }
        public string DesicionResponseCode { get; set; }
        public string HostDate { get; set; }
        public string HostTime { get; set; }
        public string IDTransaction { get; set; }
        public string Message { get; set; }
        public string Tax { get; set; }
        public string Invoice { get; set; }
        public bool IsDefault { get; set; }
        public string Transaction_Detail { get; set; }
        public string Reference_Code { get; set; }
        public bool ReserveFunds { get; set; }
        public string ResponseCode { get; set; }
        public string Status { get; set; }
        public string ZipCode { get; set; }
    }
}
