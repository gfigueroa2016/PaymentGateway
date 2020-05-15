using DynamicsPayments.Domain.DTO.Token.Requests;
using DynamicsPayments.Domain.DTO.Transaction.Requests;
using DynamicsPayments.DTO.Token.Requests;
using FluentValidation.TestHelper;
using Xunit;

namespace PaymentGateway.Domain.Tests.Requests.VoidByID
{
    public class Validators
    {
        public class VoidByIDRequestValidatorTests
        {
            private readonly VoidByIDRequestValidator _validator;
            public VoidByIDRequestValidatorTests()
            {
                _validator = new VoidByIDRequestValidator();
            }
            [Fact]
            public void Should_Have_Error_When_TransactionID_Is_Null()
            {
                var voidByIDRequest = new VoidByIDRequest
                {
                    IDTransaction = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.IDTransaction, voidByIDRequest);
            }
            [Fact]
            public void Should_Have_Error_When_MerchantId_Is_Null()
            {
                var getCustomerTokensRequest = new VoidByIDRequest
                {
                    MerchantKey = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.MerchantKey, getCustomerTokensRequest);
            }
        }
    }
}