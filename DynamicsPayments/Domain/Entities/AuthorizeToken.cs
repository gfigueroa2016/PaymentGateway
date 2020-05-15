﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicsPayments.Domain.Entities
{
    public class AuthorizeToken
    {
        public string Account { get; set; }
        public string AccountToken { get; set; }
        public string AuditNumber { get; set; }
        public string AuthNumber { get; set; }
        public string Batch_Code { get; set; }
        public string CardHolderName { get; set; }
        public string DesicionResponseCode { get; set; }
        public string HostDate { get; set; }
        public string HostTime { get; set; }
        public string IDTransaction { get; set; }
        public string AcquirerName { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Reference_Code { get; set; }
        public string ResponseCode { get; set; }
    }
}
