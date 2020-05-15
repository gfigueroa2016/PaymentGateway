using DynamicsPayments.Domain.DTO.Token.Requests;
using DynamicsPayments.Domain.DTO.Token.Responses;

namespace DynamicsPayments.Domain.Mappers
{
    public interface IDynamicsPaymentsTokenMapper
    {
        AuthorizeTokenRequest Map(AuthorizeTokenRequest authorizeTokenRequest, RegisterTokenResponse registerTokenResponse);
    }
}