using DAL;
using Entites;
using Events;
using GrpcModelFirst;
using GrpcModelFirst.Models;
using Mapster;
using MessageBroker;
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
        public CustomerService(IStoreService storeService, ILogger<CustomerService> logger, IMessageReciver messageReciver)
        {
            _storeService = storeService;
            _logger = logger;
            messageReciver.SubscribeToOrderTopic();
            messageReciver.MessageRecived += OrderMessageRecived;
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




        private async Task OrderMessageRecived(object sender, Kafka.Public.RawKafkaRecord e)
        {

           
            try
            {
                var customer = await _storeService.FetchAsync<Customer>(e.GetKey());
                customer.PurchasedAt = DateTime.Now;
                await _storeService.AppendAsync(customer.Email, customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, " Order not Purchesed  ");
            }

        }



    }
}
