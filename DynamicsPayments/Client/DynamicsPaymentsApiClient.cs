using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicsPayments.Client
{
    public interface IDynamicsPaymentsApiClient
    {
        Task<T> SendAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken);
        Uri BuildUri(string format);
    }
}