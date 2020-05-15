using DynamicsPayments.Domain.DTO.Token.Requests;
using DynamicsPayments.Domain.DTO.Token.Responses;
using DynamicsPayments.Domain.Services;
using DynamicsPayments.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicsPayments.Client.Resources.Token
{
    public class DynamicsPaymentsTokenResource : IDynamicsPaymentsTokenResource
    {
        private readonly IDynamicsPaymentsBaseClient _dynamicsPaymentsClient;
        private readonly IDynamicsPaymentsConfigurationService _dynamicsPaymentsConfigurationService;
        private readonly IDynamicsPaymentsHttpRequestMessageContent _dynamicsPaymentsHttpRequestMessageContent;
        private readonly string _dynamicsPaymentsSecret;
        private readonly string _dynamicsPaymentsSessionId;
        private readonly string _dynamicsPaymentsSiteId;
        public DynamicsPaymentsTokenResource(HttpClient dynamicsPaymentsHttpClient, IDynamicsPaymentsConfigurationService dynamicsPaymentsConfigurationService, IDynamicsPaymentsHttpRequestMessageContent httpRequestMessageContent)
        {
            _dynamicsPaymentsClient = new DynamicsPaymentsBaseClient(dynamicsPaymentsHttpClient, _dynamicsPaymentsConfigurationService.GetDynamicsPaymentsConfiguration().Url.ToString());
            _dynamicsPaymentsConfigurationService = dynamicsPaymentsConfigurationService;
            _dynamicsPaymentsHttpRequestMessageContent = httpRequestMessageContent;
            _dynamicsPaymentsSecret = _dynamicsPaymentsConfigurationService.GetDynamicsPaymentsConfiguration().Secret;
            _dynamicsPaymentsSessionId = _dynamicsPaymentsConfigurationService.GetDynamicsPaymentsConfiguration().SessionId;
            _dynamicsPaymentsSiteId = _dynamicsPaymentsConfigurationService.GetDynamicsPaymentsConfiguration().SiteId;
        }
        private Uri BuildUri(string path)
        {
            return _dynamicsPaymentsClient.BuildUri(string.Format("/{0}", path));
        }
        public async Task<AuthorizeTokenResponse> PostAuthorizeTokenAsync(AuthorizeTokenRequest authorizeTokenRequest, CancellationToken cancellationToken = default)
        {
            var uri = BuildUri("AuthorizeToken");
            var messageHash = DynamicsPaymentsExtensions.GetSHA256Encryption(string.Concat(_dynamicsPaymentsSecret, _dynamicsPaymentsSiteId, _dynamicsPaymentsSessionId, authorizeTokenRequest.MerchantKey, authorizeTokenRequest.AccountToken, authorizeTokenRequest.Amount, authorizeTokenRequest.Currency));
            var httpRequestMessageContent = _dynamicsPaymentsHttpRequestMessageContent.SetHttpRequestMessageContent(_dynamicsPaymentsSessionId, _dynamicsPaymentsSiteId, messageHash, authorizeTokenRequest, HttpMethod.Post, uri);
            return await _dynamicsPaymentsClient.SendAsync<AuthorizeTokenResponse>(httpRequestMessageContent, cancellationToken);
        }
        public async Task<DeleteCustomerTokenResponse> PostDeleteCustomerTokenAsync(DeleteCustomerTokenRequest deleteCustomerTokenRequest, CancellationToken cancellationToken = default)
        {
            var uri = BuildUri("DeleteCustomerToken");
            var messageHash = DynamicsPaymentsExtensions.GetSHA256Encryption(string.Concat(_dynamicsPaymentsSecret, _dynamicsPaymentsSiteId, _dynamicsPaymentsSessionId, deleteCustomerTokenRequest.CustomerId, deleteCustomerTokenRequest.AccountToken));
            var httpRequestMessageContent = _dynamicsPaymentsHttpRequestMessageContent.SetHttpRequestMessageContent(_dynamicsPaymentsSessionId, _dynamicsPaymentsSiteId, messageHash, deleteCustomerTokenRequest, HttpMethod.Post, uri);
            return await _dynamicsPaymentsClient.SendAsync<DeleteCustomerTokenResponse>(httpRequestMessageContent, cancellationToken);
        }
        public async Task<IEnumerable<GetCustomerTokensResponse>> GetCustomerTokensAsync(GetCustomerTokensRequest getCustomerTokensRequest, CancellationToken cancellationToken = default)
        {
            var uri = BuildUri("GetCustomerTokens");
            var messageHash = DynamicsPaymentsExtensions.GetSHA256Encryption(string.Concat(_dynamicsPaymentsSecret, _dynamicsPaymentsSiteId, _dynamicsPaymentsSessionId, getCustomerTokensRequest.CustomerId));
            var httpRequestMessage = _dynamicsPaymentsHttpRequestMessageContent.SetHttpRequestMessageContent(_dynamicsPaymentsSessionId, _dynamicsPaymentsSiteId, messageHash, getCustomerTokensRequest, HttpMethod.Post, uri);
            return await _dynamicsPaymentsClient.SendAsync<IEnumerable<GetCustomerTokensResponse>>(httpRequestMessage, cancellationToken);
        }
        public async Task<RegisterTokenResponse> PostRegisterTokenAsync(RegisterTokenRequest registerTokenRequest, CancellationToken cancellationToken = default)
        {
            var uri = BuildUri("RegisterToken");
            var messageHash = DynamicsPaymentsExtensions.GetSHA256Encryption(string.Concat(_dynamicsPaymentsSecret, _dynamicsPaymentsSiteId, _dynamicsPaymentsSessionId, registerTokenRequest.AccountNumber, registerTokenRequest.CustomerName, registerTokenRequest.CustomerId, registerTokenRequest.AccountType));
            var httpRequestMessage = _dynamicsPaymentsHttpRequestMessageContent.SetHttpRequestMessageContent(_dynamicsPaymentsSessionId, _dynamicsPaymentsSiteId, messageHash, registerTokenRequest, HttpMethod.Post, uri);
            return await _dynamicsPaymentsClient.SendAsync<RegisterTokenResponse>(httpRequestMessage, cancellationToken);
        }
    }
}