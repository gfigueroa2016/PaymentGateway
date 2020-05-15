using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DynamicsPayments.Domain.DTO.Token.Requests;
using DynamicsPayments.Domain.DTO.Token.Responses;
using DynamicsPayments.Domain.DTO.Transaction.Requests;
using DynamicsPayments.Domain.DTO.Transaction.Responses;
using DynamicsPayments.Domain.Entities;

namespace DynamicsPayments.Domain.Services
{
    public interface IDynamicsPaymentsTokenService
    {
        Task<AuthorizeTokenResponse> PostAuthorizeTokenAsync(AuthorizeTokenRequest authorizeTokenRequest, CancellationToken cancellationToken = default);
        Task<DeleteCustomerTokenResponse> PostDeleteCustomerTokenAsync(DeleteCustomerTokenRequest deleteCustomerTokenRequest, CancellationToken cancellationToken = default);
        Task<IEnumerable<GetCustomerTokensResponse>> GetCustomerTokensAsync(GetCustomerTokensRequest getCustomerTokenRequest, CancellationToken cancellationToken = default);
        Task<RegisterTokenResponse> PostRegisterTokenAsync(RegisterTokenRequest registerTokenRequest, CancellationToken cancellationToken = default);
    }
    public interface IDynamicsPaymentsTransactionService
    {
        Task<GetTransactionByIDResponse> GetTransactionByIDAsync(GetTransactionByIDRequest getTransactionByIDRequest, CancellationToken cancellationToken = default);
        Task<MarkByIDResponse> PostMarkByIDAsync(MarkByIDRequest markByIDRequest, CancellationToken cancellationToken = default);
        Task<VoidByIDResponse> PostVoidByIDAsync(VoidByIDRequest voidByIDRequest, CancellationToken cancellationToken = default);
    }
    public interface IDynamicsPaymentsConfigurationService
    {
        DynamicsPaymentsConfiguration GetDynamicsPaymentsConfiguration();
    }
}