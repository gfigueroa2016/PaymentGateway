using FluentValidation.TestHelper;
using PaymentGateway.Domain.Requests.PaymentTransactionHistory;
using PaymentGateway.Domain.Requests.SystemSetting;
using Xunit;

namespace PaymentGateway.Domain.Tests.Requests.SystemSetting
{
    public class Validators
    {
        public class AddSystemSettingRequestValidatorTests
        {
            private readonly AddSystemSettingRequestValidator _validator;
            public AddSystemSettingRequestValidatorTests()
            {
                _validator = new AddSystemSettingRequestValidator();
            }
            [Fact]
            public void Should_Have_Error_When_AccountId_Is_Null()
            {
                var addSystemSettingRequest = new AddSystemSettingRequest
                {
                    AccountId = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.AccountId, addSystemSettingRequest);
            }
            [Fact]
            public void Should_Have_Error_When_ClientId_Is_Null()
            {
                var addSystemSettingRequest = new AddSystemSettingRequest
                {
                    ClientId = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId,
                addSystemSettingRequest);
            }
            [Fact]
            public void Should_Have_Error_When_CustomerId_Is_Null()
            {
                var addSystemSettingRequest = new AddSystemSettingRequest
                {
                    CustomerId = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId,
                addSystemSettingRequest);
            }
            [Fact]
            public void Should_Have_Error_When_PaymentGatewayUrl_Is_Null()
            {
                var addSystemSettingRequest = new AddSystemSettingRequest
                {
                    PaymentGatewayUrl = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId,
                addSystemSettingRequest);
            }
            [Fact]
            public void Should_Have_Error_When_Secret_Is_Null()
            {
                var addSystemSettingRequest = new AddSystemSettingRequest
                {
                    Secret = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId,
                addSystemSettingRequest);
            }
            [Fact]
            public void Should_Have_Error_When_StoreUrl_Is_Null()
            {
                var addSystemSettingRequest = new AddSystemSettingRequest
                {
                    StoreUrl = null
                };
                _validator.ShouldHaveValidationErrorFor(x => x.CustomerId,
                addSystemSettingRequest);
            }
        }
    }
}