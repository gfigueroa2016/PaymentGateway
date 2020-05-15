using DynamicsPayments.Domain.DTO.Transaction.Requests;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace DynamicsPayments.Client.Resources
{
    public class HttpHeaderContent : IHttpHeaderContent
    {
        public HttpContent SetHttpContent<T>(T request, string sessionId, string siteId, string messageHash)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            httpContent.Headers.ContentType.MediaType = "application/json";
            httpContent.Headers.Add("SessionId", sessionId);
            httpContent.Headers.Add("SiteId", siteId);
            httpContent.Headers.Add("MessageHash", messageHash);
            return httpContent;
        }
    }
}
