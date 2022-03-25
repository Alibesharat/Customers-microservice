using Models.Dtos;
using Models.Events;
using Validators.Extensssion;
using Validators.Models;

namespace Validators.Impelimetns
{
    public class CustomeValidator : ICustomeValidator
    {
        public CustomeValidationResult ValidateArchiveCustomer(ArchiveCustomerRequestDto archiveCustomer)
        {
            CustomeValidationResult result = new();
            ArchiveCustomerValidator validator = new();
            var validate = validator.Validate(archiveCustomer);
            result.IsValid = validate.IsValid;
            result.Errors = validate.GetErrors();
            return result;
        }

        public CustomeValidationResult ValidateCreateCustomer(CreateCustomerRequestDto customer)
        {
            CustomeValidationResult  result= new();
            CreateCustomerValidator validator = new();
            var validate = validator.Validate(customer);
            result.IsValid = validate.IsValid;
            result.Errors = validate.GetErrors();
            return result;

        }

        public CustomeValidationResult ValidateGetCustomer(GetCustomerRequestDto GetCustomer)
        {
            CustomeValidationResult result = new();
            GetCustomerValidator validator = new();
            var validate = validator.Validate(GetCustomer);
            result.IsValid = validate.IsValid;
            result.Errors = validate.GetErrors();
            return result;
        }

        public CustomeValidationResult ValidateOrderCompleted(OrderCompleteRequestDto Order)
        {
            CustomeValidationResult result = new();

            OrderCompletedValidator validator = new();
            var validate = validator.Validate(Order);
            result.IsValid = validate.IsValid;
            result.Errors = validate.GetErrors();
            return result;
        }

        public CustomeValidationResult ValidateUpdateCustomer(UpdateCustomerAddressRequestDto updateCustomer)
        {
            CustomeValidationResult result = new();
            UpdateCustomerValidator validator = new();
            var validate = validator.Validate(updateCustomer);
            result.IsValid = validate.IsValid;
            result.Errors = validate.GetErrors();
            return result;
        }
    }
}
