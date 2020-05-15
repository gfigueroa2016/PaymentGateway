using System;
using System.Net.Http;

namespace DynamicsPayments.Client.Resources
{
    public interface IDynamicsPaymentsHttpRequestMessageContent
    {
        HttpRequestMessage SetHttpRequestMessageContent<T>(string sessionId, string siteId, string messageHash, T request, HttpMethod method, Uri uri);
    }
}
