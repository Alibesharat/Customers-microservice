using FluentValidation;
using FluentValidation.Validators;
using Models.Dtos;

namespace Validators.Models
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequestDto>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
