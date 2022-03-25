using FluentValidation;
using FluentValidation.Validators;
using Models.Dtos;

namespace Validators
{
    public class ArchiveCustomerValidator: AbstractValidator<ArchiveCustomerRequestDto>
    {

        public ArchiveCustomerValidator()
        {
            RuleFor(c => c.Email).NotNull();
            RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
