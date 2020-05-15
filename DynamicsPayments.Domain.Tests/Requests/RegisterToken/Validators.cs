using DynamicsPayments.Domain.DTO.Token.Requests;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace DynamicsPayments.Domain.Tests.Requests.RegisterToken
{
    public class Validators
    {
        public class RegisterTokenRequestValidatorTests
        {
            private readonly RegisterTokenRequestValidator _validator;
            public RegisterTokenRequestValidatorTests()
            {
                _validator = new RegisterTokenRequestValidator();
            }
            [Fact]
            public void Should_Have_Error_When_CreditCard_Is_Null()
            {
                var registerTokenRequest = new RegisterTokenRequest
                {
                    CreditCard = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CreditCard, registerTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_CreditCard_Is_Not_Valid()
            {
                var registerTokenRequest = new RegisterTokenRequest
                {
                    CreditCard = "9292929292929292"
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CreditCard, registerTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_CustomerEmail_Is_Not_Valid()
            {
                var registerTokenRequest = new RegisterTokenRequest
                {
                    CustomerEmail = "test@test"
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerEmail, registerTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_CustomerEmail_Is_Null()
            {
                var registerTokenRequest = new RegisterTokenRequest
                {
                    CustomerEmail = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerEmail, registerTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_CustomerId_Is_Null()
            {
                var registerTokenRequest = new RegisterTokenRequest
                {
                    CustomerId = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId, registerTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_CustomerName_Is_Null()
            {
                var registerTokenRequest = new RegisterTokenRequest
                {
                    CustomerId = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId, registerTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_ExpirationMonth_Is_Not_GreaterThanOrEqualTo()
            {
                var registerTokenRequest = new RegisterTokenRequest
                {
                    ExpirationMonth = DateTime.Now.AddMonths(-1).Month
                };
                _validator.ShouldHaveValidationErrorFor(x => x.ExpirationMonth, registerTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_ExpirationMonth_Is_Not_LessThanOrEqualTo()
            {
                var registerTokenRequest = new RegisterTokenRequest
                {
                    ExpirationMonth = 13
                };
                _validator.ShouldHaveValidationErrorFor(x => x.ExpirationMonth, registerTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_ExpirationYear_Is_Not_GreaterThanOrEqualTo()
            {
                var registerTokenRequest = new RegisterTokenRequest
                {
                    ExpirationYear = DateTime.Now.AddYears(-1).Year
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId, registerTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_MerchantKey_Is_Null()
            {
                var registerTokenRequest = new RegisterTokenRequest
                {
                    MerchantKey = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.MerchantKey, registerTokenRequest);
            }
        }
    }
}