using DynamicsPayments.Domain.DTO.Token.Requests;
using DynamicsPayments.Domain.DTO.Transaction.Requests;
using DynamicsPayments.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicsPayments.Domain.Repositories
{
    public interface ITokenRepository
    {
        Task<TokenSession> AuthorizeTokenAsync(AuthorizeTokenRequest authorizeTokenRequest);
        Task<TokenSession> DeleteCustomerTokenAsync(DeleteCustomerTokenRequest deleteCustomerTokenRequest);
        Task<IEnumerable<TokenSession>> GetCustomerTokensAsync(GetCustomerTokensRequest getCustomerTokensRequest);
        Task<TokenSession> RegisterTokenAsync(RegisterTokenRequest registerTokenRequest);
    }
    public interface ITransactionRepository
    {
        Task<TransactionSession> GetTransactionByIDAsync(GetTransactionByIDRequest getTransactionByIDRequest);
        Task<TransactionSession> MarkByIDAsync(MarkByIDRequest markByIDRequest);
        Task<TransactionSession> VoidByIDAsync(VoidByIDRequest voidByIDRequest);
    }
}
