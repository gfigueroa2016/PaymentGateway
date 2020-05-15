using AutoMapper;
using DynamicsPayments.Domain.DTO.Token.Requests;
using DynamicsPayments.Domain.DTO.Token.Responses;

namespace DynamicsPayments.Domain.Mappers
{
    public class DynamicsPaymentsTokenMapper : IDynamicsPaymentsTokenMapper
    {
        public AuthorizeTokenRequest Map(AuthorizeTokenRequest authorizeTokenRequest, RegisterTokenResponse registerTokenResponse)
        {
            if (authorizeTokenRequest == null && registerTokenResponse == null) return null;
            var paymentTransactionHistory = new AuthorizeTokenRequest
            {
                AccountToken = registerTokenResponse.AccountToken,
                Amount = authorizeTokenRequest.Amount,
                Currency = authorizeTokenRequest.Currency,
                Invoice = authorizeTokenRequest.Invoice,
                MerchantKey = authorizeTokenRequest.MerchantKey,
                ReserveFunds = authorizeTokenRequest.ReserveFunds,
                Tax = authorizeTokenRequest.Tax,
                Transaction_Detail = authorizeTokenRequest.Transaction_Detail
            };
            return paymentTransactionHistory;
        }
    }
}