using DynamicsPayments.Domain.DTO.Token.Requests;
using FluentValidation.TestHelper;
using Xunit;

namespace DynamicsPayment.Domain.Tests.Requests.GetTransactionByID
{
    public class Validators
    {
        public class GetTransactionByIDValidatorTests
        {
            private readonly GetCustomerTokensRequestValidator _validator;
            public GetTransactionByIDValidatorTests()
            {
                _validator = new GetCustomerTokensRequestValidator();
            }
            [Fact]
            public void Should_Have_Error_When_IDTransaction_Is_Null()
            {
                var getCustomerTokensRequest = new GetCustomerTokensRequest
                {
                    CustomerId = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId, getCustomerTokensRequest);
            }
            [Fact]
            public void Should_Have_Error_When_MerchantKey_Is_Null()
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