using FluentValidation;
using FluentValidation.Validators;
using Models.Dtos;

namespace Validators.Models
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequestDto>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c => c.Email).NotNull();
            RuleFor(c => c.Address).NotNull();
            RuleFor(c => c.Address.Street).NotNull();
            RuleFor(c => c.Address.City).NotNull();
            RuleFor(c => c.Address.Country).NotNull();
            RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
