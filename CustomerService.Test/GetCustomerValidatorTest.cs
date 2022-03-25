using FluentValidation.TestHelper;
using Models.Dtos;
using NUnit.Framework;
using Validators;

namespace CustomerService.Test
{
    [TestFixture]
    public class GetCustomerValidatorTest
    {
        GetCustomerValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new();

        }

        [Test]
        public void Should_have_error_when_Email_is_Null()
        {
            var model = new GetCustomerRequestDto { Email = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Email);
        }


        [Test]
        public void Should_have_error_when_Email_is_Not_valid()
        {
            var model = new GetCustomerRequestDto { Email = "" };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Email);
        }


    }
}
