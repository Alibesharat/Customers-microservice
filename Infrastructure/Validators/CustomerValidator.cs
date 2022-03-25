using FluentValidation;
using FluentValidation.Validators;
using Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Email).EmailAddress(EmailValidationMode.AspNetCoreCompatible);

        }
    }
}
