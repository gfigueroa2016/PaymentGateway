using FluentValidation;

namespace PaymentGateway.Domain.Requests.PaymentTransactionHistory
{
    public class AddPaymentTransactionHistoryRequestValidator : AbstractValidator<AddPaymentTransactionHistoryRequest>
    {
        public AddPaymentTransactionHistoryRequestValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Invoice).NotEmpty();
        }
    }
    public class EditPaymentTransactionHistoryRequestValidator : AbstractValidator<EditPaymentTransactionHistoryRequest>
    {
        public EditPaymentTransactionHistoryRequestValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Invoice).NotEmpty();
        }
    }
}
