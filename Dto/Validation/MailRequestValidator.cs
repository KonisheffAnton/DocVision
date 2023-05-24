using DocVision.Dto.Models;
using FluentValidation;

namespace DocVision.Dto.Validation
{
    public class MailRequestValidator : AbstractValidator<MailDto>
    {
        public MailRequestValidator()
        {
            RuleFor(mail => mail.Name).NotEmpty().NotNull();

            RuleFor(mail => mail.Sender).NotEmpty().NotNull();

            RuleFor(mail => mail.Addressee).NotEmpty().NotNull();

            RuleFor(mail => mail.Data).NotEmpty().NotNull();
        }
    }
}
