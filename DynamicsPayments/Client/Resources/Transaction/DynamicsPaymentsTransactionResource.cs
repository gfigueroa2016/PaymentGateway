using DynamicsPayments.Domain.DTO.Transaction.Requests;
using DynamicsPayments.Domain.DTO.Transaction.Responses;
using DynamicsPayments.Domain.Services;
using DynamicsPayments.Extensions;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicsPayments.Client.Resources.Transaction
{
    public class DynamicsPaymentsTransactionResource : IDynamicsPaymentsTransactionResource
    {
        private readonly IDynamicsPaymentsBaseClient _dynamicsPaymentsClient;
        private readonly IDynamicsPaymentsConfigurationService _dynamicsPaymentsConfigurationService;
        private readonly IDynamicsPaymentsHttpRequestMessageContent _dynamicsPaymentsHttpRequestMessageContent;
        private readonly string _dynamicsPaymentsSecret;
        private readonly string _dynamicsPaymentsSessionId;
        private readonly string _dynamicsPaymentsSiteId;
        public DynamicsPaymentsTransactionResource(IDynamicsPaymentsConfigurationService dynamicsPaymentsConfigurationService, HttpClient dynamicsPaymentsHttpClient, IDynamicsPaymentsHttpRequestMessageContent httpRequestMessageContent)
        {
            _dynamicsPaymentsClient = new DynamicsPaymentsBaseClient(dynamicsPaymentsHttpClient, _dynamicsPaymentsConfigurationService.GetDynamicsPaymentsConfiguration().Url.ToString()); ;
            _dynamicsPaymentsConfigurationService = dynamicsPaymentsConfigurationService;
            _dynamicsPaymentsHttpRequestMessageContent = httpRequestMessageContent;
            _dynamicsPaymentsSecret = _dynamicsPaymentsConfigurationService.GetDynamicsPaymentsConfiguration().Secret;
            _dynamicsPaymentsSessionId = _dynamicsPaymentsConfigurationService.GetDynamicsPaymentsConfiguration().SessionId;
            _dynamicsPaymentsSiteId = _dynamicsPaymentsConfigurationService.GetDynamicsPaymentsConfiguration().Secret;
        }
        private Uri BuildUri(string path)
        {
            return _dynamicsPaymentsClient.BuildUri(string.Format("/{0}", path));
        }
        public async Task<GetTransactionByIDResponse> GetTransactionByIDAsync(GetTransactionByIDRequest getTransactionByIDRequest, CancellationToken cancellationToken = default)
        {
            var uri = BuildUri("GetTransactionByID");
            var messageHash = DynamicsPaymentsExtensions.GetSHA256Encryption(string.Concat(_dynamicsPaymentsSecret, _dynamicsPaymentsSiteId, _dynamicsPaymentsSessionId, getTransactionByIDRequest.IDTransaction));
            var httpRequestMessageContent = _dynamicsPaymentsHttpRequestMessageContent.SetHttpRequestMessageContent(_dynamicsPaymentsSessionId, _dynamicsPaymentsSiteId, messageHash, getTransactionByIDRequest, HttpMethod.Get, uri);
            return await _dynamicsPaymentsClient.SendAsync<GetTransactionByIDResponse>(httpRequestMessageContent, cancellationToken);
        }
        public async Task<MarkByIDResponse> PostMarkByIDAsync(MarkByIDRequest markByIDRequest, CancellationToken cancellationToken = default)
        {
            var uri = BuildUri("MarkByID");
            var messageHash = DynamicsPaymentsExtensions.GetSHA256Encryption(string.Concat(_dynamicsPaymentsSecret, _dynamicsPaymentsSiteId, _dynamicsPaymentsSessionId, markByIDRequest.MerchantKey, markByIDRequest.IDTransaction));
            var httpRequestMessageContent = _dynamicsPaymentsHttpRequestMessageContent.SetHttpRequestMessageContent(_dynamicsPaymentsSessionId, _dynamicsPaymentsSiteId, messageHash, markByIDRequest, HttpMethod.Post, uri);
            return await _dynamicsPaymentsClient.SendAsync<MarkByIDResponse>(httpRequestMessageContent, cancellationToken);
        }
        public async Task<VoidByIDResponse> PostVoidByIDAsync(VoidByIDRequest voidByIDRequest, CancellationToken cancellationToken = default)
        {
            var uri = BuildUri("VoidByID");
            var messageHash = DynamicsPaymentsExtensions.GetSHA256Encryption(string.Concat(_dynamicsPaymentsSecret, _dynamicsPaymentsSiteId, _dynamicsPaymentsSessionId, voidByIDRequest.MerchantKey, voidByIDRequest.IDTransaction));
            var httpRequestMessageContent = _dynamicsPaymentsHttpRequestMessageContent.SetHttpRequestMessageContent(_dynamicsPaymentsSessionId, _dynamicsPaymentsSiteId, messageHash, voidByIDRequest, HttpMethod.Post, uri);
            return await _dynamicsPaymentsClient.SendAsync<VoidByIDResponse>(httpRequestMessageContent, cancellationToken);
        }
    }
}