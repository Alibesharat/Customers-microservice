using FluentValidation;
using FluentValidation.Validators;
using Models.Dtos;
using Models.Events;

namespace Validators
{
    public class OrderCompletedValidator : AbstractValidator<OrderCompleteRequestDto>
    {
        public OrderCompletedValidator()
        {
            RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
