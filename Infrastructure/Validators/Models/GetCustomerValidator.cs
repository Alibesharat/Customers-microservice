using FluentValidation;
using FluentValidation.Validators;
using Models.Dtos;

namespace Validators
{
    public class GetCustomerValidator : AbstractValidator<GetCustomerRequestDto>
    {
        public GetCustomerValidator()
        {
            RuleFor(c => c.Email).NotNull();
            RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);

        }
    }
}
