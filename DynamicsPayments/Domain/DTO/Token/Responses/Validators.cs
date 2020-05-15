using FluentValidation;
using PaymentGateway.Domain.Requests.SystemSetting;

namespace DynamicsPayments.Domain.Requests.SystemSetting
{
    public class AddSystemSettingRequestValidator : AbstractValidator<AddSystemSettingRequest>
    {
        public AddSystemSettingRequestValidator()
        {
            RuleFor(a => a.AccountId).NotEmpty();
            RuleFor(a => a.ClientId).NotEmpty();
            RuleFor(a => a.CustomerId).NotEmpty();
            RuleFor(a => a.PaymentGatewayUrl).NotEmpty();
            RuleFor(a => a.Secret).NotEmpty();
            RuleFor(a => a.StoreUrl).NotEmpty();
        }
    }
    public class EditSystemSettingRequestValidator : AbstractValidator<EditSystemSettingRequest>
    {
        public EditSystemSettingRequestValidator()
        {
            RuleFor(a => a.AccountId).NotEmpty();
            RuleFor(a => a.ClientId).NotEmpty();
            RuleFor(a => a.CustomerId).NotEmpty();
            RuleFor(a => a.PaymentGatewayUrl).NotEmpty();
            RuleFor(a => a.Secret).NotEmpty();
            RuleFor(a => a.StoreUrl).NotEmpty();
        }
    }
}
