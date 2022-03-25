using FluentValidation;
using FluentValidation.Validators;
using Models.Dtos;

namespace Validators
{
    public class OrderCompletedValidator : AbstractValidator<OrderCompleteRequestDto>
    {
        public OrderCompletedValidator()
        {
            RuleFor(c => c.Email).NotNull();
            RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
