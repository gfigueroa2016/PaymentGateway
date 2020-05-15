using DynamicsPayments.Domain.DTO.Transaction.Requests;
using FluentValidation.TestHelper;
using Xunit;

namespace PaymentGateway.Domain.Tests.Requests.MarkByID
{
    public class Validators
    {
        public class MarkByIDRequestValidatorTests
        {
            private readonly MarkByIDRequestValidator _validator;
            public MarkByIDRequestValidatorTests()
            {
                _validator = new MarkByIDRequestValidator();
            }
            [Fact]
            public void Should_Have_Error_When_TransactionID_Is_Null()
            {
                var markByIDRequest = new MarkByIDRequest
                {
                    IDTransaction = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.IDTransaction, markByIDRequest);
            }
            [Fact]
            public void Should_Have_Error_When_MerchantId_Is_Null()
            {
                var getCustomerTokensRequest = new MarkByIDRequest
                {
                    MerchantKey = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.MerchantKey, getCustomerTokensRequest);
            }
        }
    }
}