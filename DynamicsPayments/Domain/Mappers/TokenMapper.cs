using DynamicsPayments.Domain.Models;
using System;
using DynamicsPayments.DTO.Token.Requests;

namespace DynamicsPayments.Domain.Mappers
{
    public class TokenMapper : ITokenMapper
    {
        public AuthorizeTokenRequest MapToAuthorizeTokenRequest(Token token)
        {
            if (token == null) return null;
            var authorizeTokenRequest = new AuthorizeTokenRequest
            {
                Amount = token.Amount,
                AccountToken = token.AccountToken,
                Currency = token.Currency,
                Invoice = token.Invoice,
                Merchantkey = token.AuthNumber,
                ReserveFunds = token.ReserveFunds,
                Tax = token.Tax,
                Transaction_Detail= token.Transaction_Detail,
            };
            return authorizeTokenRequest;
        }
        public AuthorizeTokenResponse MapToAuthorizeTokenResponse(Token token)
        {
            if (token == null) return null;
            var authorizeTokenResponse = new AuthorizeTokenResponse
            {
                Account = token.Account,
                AccountToken = token.AccountToken,
                AcquirerName = token.AcquirerName,
                AuditNumber = token.AuditNumber,
                AuthNumber = token.AuthNumber,
                Batch_Code = token.Batch_Code,
                CardHolderName = token.CardHolderName,
                DesicionResponseCode = token.DesicionResponseCode,
                Reference_Code = token.Reference_Code,
                ResponseCode = token.ResponseCode,
                HostDate = Convert.ToDateTime(token.HostDate),
                HostTime = Convert.ToDateTime(token.HostTime).TimeOfDay,
                IDTransaction = token.IDTransaction,
                Message = token.Message,
                Status = token.Status

            };
            return authorizeTokenResponse;
        }

        public DeleteCustomerTokenResponse MapToDeleteCustomerTokenResponse(Token token)
        {
            if (token == null) return null; 
            var deleteCustomerTokenResponse = new DeleteCustomerTokenResponse
            {
                Message = token.Message,
            };
            return deleteCustomerTokenResponse;
        }

        public GetCustomerTokensResponse MapToGetCustomerTokensResponse(Token token)
        {
            if (token == null) return null;
            var getCustomerTokensResponse = new GetCustomerTokensResponse
            {
                Account = token.Account,
                AccountToken = token.AccountToken,
                CustomerName = token.CustomerName,
                IsDefault = token.IsDefault,
                Status = token.Status,
                ZipCode = token.ZipCode
            };
            return getCustomerTokensResponse;
        }
        public RegisterTokenResponse MapToRegisterTokenResponse(Token token)
        {
            if (token == null) return null;
            var registerTokenResponse = new RegisterTokenResponse
            {
                Account = token.Account,
                AccountToken = token.AccountToken,
                CustomerName = token.CustomerName,
                IsDefault = token.IsDefault,
                Status = token.Status,
                ZipCode = token.ZipCode,
            };
            return registerTokenResponse;
        }
    }
}