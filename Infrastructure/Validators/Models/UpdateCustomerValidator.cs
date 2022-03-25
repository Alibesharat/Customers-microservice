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

        }
    }
}
