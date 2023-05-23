using DocVision.Dto.Models;
using FluentValidation;

namespace DocVision.Dto.Validation
{
    public class MailRequestValidator : AbstractValidator<MailDto>
    {
        public MailRequestValidator()
        {
            RuleFor(request => request.Sender).NotEmpty().NotNull();

            RuleFor(request => request.Addressee).NotEmpty().NotNull();

            RuleFor(request => request.Data).NotEmpty().NotNull();
        }
    }
}
