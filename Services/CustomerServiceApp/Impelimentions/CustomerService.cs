using DAL;
using GrpcModelFirst;
using GrpcModelFirst.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

        public async Task<AchiveCustomerResultDto> ArchiveCustomer(ArchiveCustomerRequestDto dto)
        {

            await _storeService.AppendAsync(dto.Email, "");
        }

        public async Task<CreateCustomerResultDto> CreateCustomer(CreatCustomerRequestDto dto)
        {
            var result = new CreateCustomerResultDto();
            try
            {
                var jsondata = JsonConvert.SerializeObject(dto);
                await _storeService.AppendAsync(dto.Email, jsondata);
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


        public async Task<UpdateCustomerAddressResultDto> UpdateCustomerAdress(UpdateCustomerAddressRequestDto dto)
        {
            await _storeService.AppendAsync(dto.Email, "");
        }
    }
}
