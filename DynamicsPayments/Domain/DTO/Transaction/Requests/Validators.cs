using FluentValidation;

namespace DynamicsPayments.Domain.DTO.Transaction.Requests
{
    public class GetTransactionByIDRequestValidator : AbstractValidator<GetTransactionByIDRequest>
    {
        public GetTransactionByIDRequestValidator()
        {
            RuleFor(x => x.IDTransaction).NotEmpty();
            RuleFor(x => x.MerchantKey).NotEmpty();
        }
    }
    
    public class MarkByIDRequestValidator : AbstractValidator<MarkByIDRequest>
    {
        public MarkByIDRequestValidator()
        {
            RuleFor(x => x.IDTransaction).NotEmpty();
            RuleFor(x => x.MerchantKey).NotEmpty();
        }
    }
    public class VoidByIDRequestValidator : AbstractValidator<VoidByIDRequest>
    {
        public VoidByIDRequestValidator()
        {
            RuleFor(x => x.IDTransaction).NotEmpty();
            RuleFor(x => x.MerchantKey).NotEmpty();
        }
    }
}