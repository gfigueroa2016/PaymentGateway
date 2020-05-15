using DynamicsPayments.Domain.DTO.Token.Requests;
using DynamicsPayments.DTO.Token.Requests;
using FluentValidation.TestHelper;
using Xunit;

namespace PaymentGateway.Domain.Tests.Requests.GetCustomerTokens
{
    public class Validators
    {
        public class GetCustomerTokensRequestValidatorTests
        {
            private readonly GetCustomerTokensRequestValidator _validator;
            public GetCustomerTokensRequestValidatorTests()
            {
                _validator = new GetCustomerTokensRequestValidator();
            }
            [Fact]
            public void Should_Have_Error_When_CustomerId_Is_Null()
            {
                var getCustomerTokensRequest = new GetCustomerTokensRequest
                {
                    CustomerId = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId, getCustomerTokensRequest);
            }
            [Fact]
            public void Should_Have_Error_When_MerchantId_Is_Null()
            {
                var getCustomerTokensRequest = new GetCustomerTokensRequest
                {
                    MerchantKey = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.MerchantKey, getCustomerTokensRequest);
            }
        }
    }
}