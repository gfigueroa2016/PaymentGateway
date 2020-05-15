using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace DynamicsPayments.Client.Resources
{
    public interface IDynamicsPaymentsHttpRequestMessageContent
    {
        HttpRequestMessage SetHttpRequestMessageContent<T>(string sessionId, string siteId, string messageHash, T request, HttpMethod method, Uri uri);
    }
    public class DynamicsPaymentsHttpRequestMessageContent : IDynamicsPaymentsHttpRequestMessageContent
    {
        public HttpRequestMessage SetHttpRequestMessageContent<T>(string sessionId, string siteId, string messageHash, T request, HttpMethod method, Uri uri)
        {
            var httpRequestMessage = new HttpRequestMessage(method, uri);
            httpRequestMessage.Content.Headers.ContentType.MediaType = "application/json";
            httpRequestMessage.Content.Headers.Add("SessionId", sessionId);
            httpRequestMessage.Content.Headers.Add("SiteId", siteId);
            httpRequestMessage.Content.Headers.Add("MessageHash", messageHash);
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            return httpRequestMessage;
        }
    }
}