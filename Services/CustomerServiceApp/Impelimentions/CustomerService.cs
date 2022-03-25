﻿using DAL;
using Entites;
using GrpcModelFirst;
using GrpcModelFirst.Models;
using Mapster;
using MessageBroker;
using Microsoft.Extensions.Logging;
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
                result.BaseResult.IsSuccess = true;
                result.BaseResult.Message = "Customer Created Successfully";
            }
            catch (Exception ex)
            {
                result.BaseResult.IsSuccess = false;
                result.BaseResult.Message = "Customer not Added ";
                _logger.LogError(ex, result.BaseResult.Message);
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
                result.BaseResult.IsSuccess = true;
                result.BaseResult.Message = "Customer Archived Successfully";

            }
            catch (Exception ex)
            {

                result.BaseResult.IsSuccess = false;
                result.BaseResult.Message = "Customer not Archived";
                _logger.LogError(ex, result.BaseResult.Message);
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
                result.BaseResult.IsSuccess = true;
                result.BaseResult.Message = "Customer Address Updated Successfully";

            }
            catch (Exception ex)
            {

                result.BaseResult.IsSuccess = false;
                result.BaseResult.Message = "Customer not Updated Addres";
                _logger.LogError(ex, result.BaseResult.Message);
            }
            return result;
        }




        private async void OrderMessageRecived(object sender, Kafka.Public.RawKafkaRecord e)
        {


            try
            {
                _logger.LogInformation($"Order recived {e.GetKey()}");
                var customer = await _storeService.FetchAsync<Customer>(e.GetKey());
                customer.PurchasedAt = DateTime.Now;
                await _storeService.AppendAsync(customer.Email, customer);

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
                result.BaseResult.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.BaseResult.IsSuccess = false;
                result.BaseResult.Message = "Fetch Data from Store is faced a problem ";
                _logger.LogError(ex, result.BaseResult.Message);
            }
            return result;
        }
    }
}
