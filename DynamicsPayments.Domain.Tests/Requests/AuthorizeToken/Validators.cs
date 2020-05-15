using DynamicsPayments.Domain.DTO.Token.Requests;
using FluentValidation.TestHelper;
using Xunit;

namespace DynamicsPayments.Domain.Tests.Requests.AuthorizeToken
{
    public class Validators
    {
        public class AuthorizeTokenRequestValidatorTests
        {
            private readonly AuthorizeTokenRequestValidator _validator;
            public AuthorizeTokenRequestValidatorTests()
            {
                _validator = new AuthorizeTokenRequestValidator();
            }
            [Fact]
            public void Should_Have_Error_When_AccountToken_Is_Null()
            {
                var authorizeTokenRequest = new AuthorizeTokenRequest
                {
                    AccountToken = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.AccountToken, authorizeTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_Amount_Is_Not_Greater_Than_Zero()
            {
                var authorizeTokenRequest = new AuthorizeTokenRequest
                {
                    Amount = 0
                };
                _validator.ShouldHaveValidationErrorFor(x => x.Amount, authorizeTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_Currency_Is_Null()
            {
                var authorizeTokenRequest = new AuthorizeTokenRequest
                {
                    Currency = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.Currency, authorizeTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_Currency_Is_Not_Equals_840()
            {
                var authorizeTokenRequest = new AuthorizeTokenRequest
                {
                    Currency = "841"
                };
                _validator.ShouldHaveValidationErrorFor(x => x.Currency, authorizeTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_Currency_Is_Not_Length_Of_Three()
            {
                var authorizeTokenRequest = new AuthorizeTokenRequest
                {
                    Currency = "8441"
                };
                _validator.ShouldHaveValidationErrorFor(x => x.Currency, authorizeTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_MerchantKey_Is_Null()
            {
                var authorizeTokenRequest = new AuthorizeTokenRequest
                {
                    MerchantKey = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.MerchantKey, authorizeTokenRequest);
            }
        }
    }
}