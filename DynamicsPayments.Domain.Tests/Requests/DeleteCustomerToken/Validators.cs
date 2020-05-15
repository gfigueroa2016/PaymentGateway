using DynamicsPayments.Domain.DTO.Token.Requests;
using DynamicsPayments.DTO.Token.Requests;
using FluentValidation.TestHelper;
using Xunit;

namespace PaymentGateway.Domain.Tests.Requests.DeleteCustomerRequest
{
    public class Validators
    {
        public class DeleteCustomerRequestValidatorTests
        {
            private readonly DeleteCustomerTokenRequestValidator _validator;
            public DeleteCustomerRequestValidatorTests()
            {
                _validator = new DeleteCustomerTokenRequestValidator();
            }
            [Fact]
            public void Should_Have_Error_When_AccountToken_Is_Null()
            {
                var deleteCustomerTokenRequest = new DeleteCustomerTokenRequest
                {
                    AccountToken = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.AccountToken, deleteCustomerTokenRequest);
            }
            [Fact]
            public void Should_Have_Error_When_CustomerId_Is_Null()
            {
                var deleteCustomerTokenRequest = new DeleteCustomerTokenRequest
                {
                    CustomerId = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId, deleteCustomerTokenRequest);
            }
        }
    }
}