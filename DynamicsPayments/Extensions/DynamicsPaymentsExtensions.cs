using System;
using System.Security.Cryptography;
using System.Text;

namespace DynamicsPayments.Extensions
{
    public static class DynamicsPaymentsExtensions
    {
        public static string GetConcatCustomerId(string customerId)
        {
            return string.Concat("eComm", "@", customerId);
        }
        public static string GetSHA256Encryption(string concatenatedMessage)
        {
            var encoder = new UTF8Encoding();
            var sha256hasher = new SHA256Managed();
            return Convert.ToBase64String(sha256hasher.ComputeHash(encoder.GetBytes(concatenatedMessage)));
        }
    }
}