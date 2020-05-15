using DynamicsPayments.Domain.DTO.Token.Requests;
using DynamicsPayments.Domain.Entities;
using PaymentGateway.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicsPayments.Domain.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        public Task<TokenSession> AuthorizeTokenAsync(AuthorizeTokenRequest authorizeTokenRequest)
        {
            throw new NotImplementedException();
        }

        public Task<TokenSession> DeleteCustomerTokenAsync(DeleteCustomerTokenRequest deleteCustomerTokenRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TokenSession>> GetCustomerTokensAsync(GetCustomerTokensRequest getCustomerTokensRequest)
        {
            throw new NotImplementedException();
        }

        public Task<TokenSession> RegisterTokenAsync(RegisterTokenRequest registerTokenRequest)
        {
            throw new NotImplementedException();
        }
    }
}