using DAL;
using Entites;
using GrpcModelFirst;
using GrpcModelFirst.Models;
using Mapster;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CustomerServiceApp.Impelimentions
{
    public class CustomerService : ICustomerService
    {
        IStoreService _storeService;
        ILogger<CustomerService> _logger;
        public CustomerService(IStoreService storeService, ILogger<CustomerService> logger)
        {
            _storeService = storeService;
            _logger = logger;
        }


        public async Task<CreateCustomerResultDto> CreateCustomer(CreatCustomerRequestDto dto)
        {
            var result = new CreateCustomerResultDto();
            try
            {

                var Customer = new Customer()
                {
                    CreatedAt = DateTime.Now,
                    Email = dto.Email,
                    Address = dto.Address.Adapt<Entites.Address>()
                };
                await _storeService.AppendAsync(dto.Email, Customer);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Customer not Added To storeDb See The logs";
                _logger.LogError(ex, "Customer not Added To storeDb");
            }
            return result;
        }


        public async Task<AchiveCustomerResultDto> ArchiveCustomer(ArchiveCustomerRequestDto dto)
        {
            var result = new AchiveCustomerResultDto();
            try
            {
                var customer = await _storeService.FetchAsync<Customer>(dto.Email);
                customer.IsArchived = true;
                await _storeService.AppendAsync(dto.Email, customer);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = "Customer not Archived To storeDb See The logs";
                _logger.LogError(ex, "Customer not Archived in storeDb");
            }
            return result;
        }


        public async Task<UpdateCustomerAddressResultDto> UpdateCustomerAdress(UpdateCustomerAddressRequestDto dto)
        {
            var result = new UpdateCustomerAddressResultDto();
            try
            {
                var customer = await _storeService.FetchAsync<Customer>(dto.Email);
                customer.Address = dto.Address.Adapt<Entites.Address>();
                await _storeService.AppendAsync(dto.Email, customer);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = "Customer not Updated Address To storeDb See The logs";
                _logger.LogError(ex, "Customer not Updated Address in storeDb");
            }
            return result;
        }
    }
}
