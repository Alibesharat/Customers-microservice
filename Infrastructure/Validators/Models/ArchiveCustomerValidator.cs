using FluentValidation;
using FluentValidation.Validators;
using Models.Dtos;

namespace Validators.Models
{
    public class ArchiveCustomerValidator: AbstractValidator<ArchiveCustomerRequestDto>
    {

        public ArchiveCustomerValidator()
        {
            RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
