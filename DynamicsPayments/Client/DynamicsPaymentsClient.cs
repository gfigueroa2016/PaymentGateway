using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicsPayments.Client
{
    public interface IDynamicsPaymentsClient
    {
        Task<T> SendAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken);
        Uri BuildUri(string format);
    }
    public class DynamicsPaymentsClient : IDynamicsPaymentsClient
    {
        private readonly HttpClient _dynamicsPaymentsClient;
        private readonly string _dynamicsPaymentsBaseUri;
        public DynamicsPaymentsClient(HttpClient dynamicsPaymentsClient, string dynamicsPaymentsBaseUri)
        {
            _dynamicsPaymentsClient = dynamicsPaymentsClient;
            _dynamicsPaymentsBaseUri = dynamicsPaymentsBaseUri;
        }
        public async Task<T> SendAsync<T>(HttpRequestMessage dynamicsPaymentsRequest, CancellationToken cancellationToken)
        {
            var result = await _dynamicsPaymentsClient.SendAsync(dynamicsPaymentsRequest, cancellationToken);
            result.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
        }
        public Uri BuildUri(string format)
        {
            return new UriBuilder(_dynamicsPaymentsBaseUri) { Path = format }.Uri;
        }
    }
}