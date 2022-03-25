using FluentValidation;
using FluentValidation.Validators;
using Models.Dtos;

namespace Validators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerAddressRequestDto>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(c => c.Email).NotNull();
            RuleFor(c => c.Address.Street).NotNull();
            RuleFor(c => c.Address.City).NotNull();
            RuleFor(c => c.Address.Country).NotNull();

        }
    }
}
