using FluentValidation;
using FluentValidation.Validators;
using Models.Dtos;

namespace Validators.Models
{
    public class GetCustomerValidator : AbstractValidator<GetCustomerRequestDto>
    {
        public GetCustomerValidator()
        {
            RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);

        }
    }
}
