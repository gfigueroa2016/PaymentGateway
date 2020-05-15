using DynamicsPayments.Domain.Models;
using DynamicsPayments.DTO.Token.Requests;
using DynamicsPayments.DTO.Token.Responses;
using DynamicsPayments.DTO.Transaction.Requests;
using DynamicsPayments.DTO.Transaction.Responses;

namespace DynamicsPayments.Domain.Mappers
{
    public interface ITokenMapper
    {
        AuthorizeTokenRequest MapToAuthorizeTokenRequest(Token request);
        AuthorizeTokenResponse MapToAuthorizeTokenResponse(Token request);
        DeleteCustomerTokenResponse MapToDeleteCustomerTokenResponse(Token token);
        GetCustomerTokensResponse MapToGetCustomerTokensResponse(Token token);
        RegisterTokenResponse MapToRegisterTokenResponse(Token token);
    }
    public interface ITransactionMapper
    {
        GetTransactionByIDResponse MapToGetTransactionByIDResponse(Transaction transaction);
        MarkByIDResponse MapToMarkByIDResponse(Transaction transaction);
        VoidByIDResponse MapToVoidByIDResponse(Transaction transaction);
    }
}
