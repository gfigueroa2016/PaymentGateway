using FluentValidation;
using System;

namespace DynamicsPayments.Domain.DTO.Token.Requests
{
    public class AuthorizeTokenRequestValidator : AbstractValidator<AuthorizeTokenRequest>
    {
        public AuthorizeTokenRequestValidator()
        {
            RuleFor(x => x.AccountToken).NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.Currency).NotEmpty().Length(3).Equals("840");
            RuleFor(x => x.MerchantKey).NotEmpty();
        }
    }
    public class DeleteCustomerTokenRequestValidator : AbstractValidator<DeleteCustomerTokenRequest>
    {
        public DeleteCustomerTokenRequestValidator()
        {
            RuleFor(x => x.AccountToken).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
        }
    }
    public class GetCustomerTokensRequestValidator : AbstractValidator<GetCustomerTokensRequest>
    {
        public GetCustomerTokensRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.MerchantKey).NotEmpty();
        }
    }
    public class RegisterTokenRequestValidator : AbstractValidator<RegisterTokenRequest>
    {
        public RegisterTokenRequestValidator()
        {
            RuleFor(x => x.CreditCard).NotEmpty().CreditCard();
            RuleFor(x => x.CustomerEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.ExpirationMonth).GreaterThanOrEqualTo(DateTime.Now.Month).LessThanOrEqualTo(12);
            RuleFor(x => x.ExpirationYear).GreaterThanOrEqualTo(DateTime.Now.Year);
            RuleFor(x => x.MerchantKey).NotEmpty();
        }
    }
}