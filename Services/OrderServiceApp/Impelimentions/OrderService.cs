using DAL;
using Entites;
using GrpcModelFirst;
using GrpcModelFirst.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace OrderServiceApp.Impelimentions
{
    public class OrderService : IOrderService
    {
        readonly IStoreService _StoreService;
        readonly ILogger<OrderService> _logger;

        public OrderService(IStoreService storeService, ILogger<OrderService> logger)
        {
            _StoreService = storeService;
            _logger = logger;
        }



        public async Task<OrderCompleteResultDto> OrderComplete(OrderCompleteRequestDto dto)
        {
            var result = new OrderCompleteResultDto();
            try
            {
                var customer = await _StoreService.FetchAsync<Customer>(dto.Email);
                customer.PurchasedAt= DateTime.Now;
                await _StoreService.AppendAsync(dto.Email, customer);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = "Order not Complete See The logs";
                _logger.LogError(ex, "Customer not set PurchasedAt  in storeDb");
            }
            return result;
        }
    }
}
