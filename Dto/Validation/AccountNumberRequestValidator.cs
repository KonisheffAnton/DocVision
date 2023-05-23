using DocVision.Dto.Models;
using FluentValidation;

namespace DocVision.Dto.Validation
{
    public class AccountNumberRequestValidator: AbstractValidator<AccountDto>
    {
        public AccountNumberRequestValidator()
        {
            RuleFor(ac => ac.AccountNumber).NotNull().NotEmpty().MaximumLength(30);
        }
    }
}
