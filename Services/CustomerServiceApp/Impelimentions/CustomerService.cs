using DAL;
using GrpcModelFirst;
using Mapster;
using MessageBroker;
using Microsoft.Extensions.Logging;
using Models.Dtos;
using Models.Entites;
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



        public async Task<CreateCustomerResultDto> CreateCustomer(CreateCustomerRequestDto dto)
        {
            var result = new CreateCustomerResultDto();
            try
            {
                if (await _storeService.ISExist(dto.Email))
                {
                    result.IsSuccess = false;
                    result.Message = "The Email is already Exist";
                    return result;
                }
                var customer = new Customer()
                {
                    CreatedAt = DateTime.Now.ToUniversalTime(),
                    Email = dto.Email,
                    Address = dto.Address.Adapt<Models.Entites.Address>()
                };

             
                await _storeService.AppendAsync(dto.Email, customer);
                result.IsSuccess = true;
                result.Message = "Customer Created Successfully";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Customer not Added ";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }


        public async Task<AchiveCustomerResultDto> ArchiveCustomer(ArchiveCustomerRequestDto dto)
        {
            var result = new AchiveCustomerResultDto();
            try
            {

                var customer = await _storeService.FetchAsync<Customer>(dto.Email);

                if (customer == null)
                {
                    result.IsSuccess = false;
                    result.Message = "The Email is Not Exist";
                    return result;
                }

                customer.IsArchived = true;
                await _storeService.AppendAsync(dto.Email, customer);
                result.IsSuccess = true;
                result.Message = "Customer Archived Successfully";

            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = "Customer not Archived";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }


        public async Task<UpdateCustomerAddressResultDto> UpdateCustomerAdress(UpdateCustomerAddressRequestDto dto)
        {
            var result = new UpdateCustomerAddressResultDto();
            try
            {

                var customer = await _storeService.FetchAsync<Customer>(dto.Email);

                if (customer == null)
                {
                    result.Message = "The Email is not Exist";
                    result.IsSuccess = false;
                    return result;
                }
                customer.Address = dto.Address.Adapt<Models.Entites.Address>();
                await _storeService.AppendAsync(dto.Email, customer);
                result.IsSuccess = true;
                result.Message = "Customer Address Updated Successfully";

            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = "Customer not Updated Addres";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }




        private async void OrderMessageRecived(object sender, Kafka.Public.RawKafkaRecord e)
        {


            try
            {

                _logger.LogInformation($"Order recived {e.GetKey()}");



                var customer = await _storeService.FetchAsync<Customer>(e.GetKey());
                if (customer != null && customer.PurchasedAt==null)
                {
                    customer.PurchasedAt = DateTime.Now.ToUniversalTime();
                    await _storeService.AppendAsync(customer.Email, customer);

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, " Order not Purchesed  ");
            }

        }

        public async Task<GetCustomerResultDto> GetCustomer(GetCustomerRequestDto dto)
        {
            GetCustomerResultDto result = new();
            try
            {
                var Customer = await _storeService.FetchAsync<Customer>(dto.Email);
                result = Customer.Adapt<GetCustomerResultDto>();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Fetch Data from Store is faced a problem ";
                _logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
