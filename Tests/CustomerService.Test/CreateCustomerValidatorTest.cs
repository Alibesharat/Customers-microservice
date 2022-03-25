using FluentValidation.TestHelper;
using Models.Dtos;
using NUnit.Framework;
using Validators;

namespace CustomerService.Test
{
    [TestFixture]
    public class CreateCustomerValidatorTest
    {
        CreateCustomerValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new();
        }

        [Test]
        public void Should_have_error_when_Email_is_Null()
        {
            var model = new CreateCustomerRequestDto { Email = null};
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Email);
        }


        [Test]
        public void Should_have_error_when_Email_is_Not_valid()
        {
            var model = new CreateCustomerRequestDto { Email = "12" };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Email);
        }


        [Test]
        public void Should_have_error_when_Street_is_Null()
        {
            var model = new CreateCustomerRequestDto
            {
                Address = new Address()
            };
            model.Address.Street = null;
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Address.Street);
        }

        [Test]
        public void Should_have_error_when_City_is_Null()
        {
            var model = new CreateCustomerRequestDto
            {
                Address = new Address()
            };
            model.Address.City = null;
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Address.City);
        }


        [Test]
        public void Should_have_error_when_Counrty_is_Null()
        {
            var model = new CreateCustomerRequestDto
            {
                Address = new Address()
            };
            model.Address.Country = null;
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(c => c.Address.Country);
        }


    }
}
