using Models.Dtos;
using Models.Events;

namespace Validators
{
    public interface ICustomeValidator
    {

        CustomeValidationResult ValidateCreateCustomer(CreateCustomerRequestDto customer);
        CustomeValidationResult ValidateUpdateCustomer(UpdateCustomerAddressRequestDto updateCustomer);
        CustomeValidationResult ValidateArchiveCustomer(ArchiveCustomerRequestDto archiveCustomer);
        CustomeValidationResult ValidateGetCustomer(GetCustomerRequestDto GetCustomer);
        CustomeValidationResult ValidateOrderCompleted(OrderCompleted Order);



    }
}
