using FluentValidation;
using FluentValidation.Validators;
using Models.Events;

namespace Validators
{
    public class OrderCompletedValidator : AbstractValidator<OrderCompleted>
    {
        public OrderCompletedValidator()
        {
            RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
