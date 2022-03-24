using GrpcModelFirst;
using GrpcModelFirst.Models;
using System;
using System.Threading.Tasks;

namespace OrderServiceApp.Impelimentions
{
    public class OrderService : IOrderService
    {
        public Task<OrderCompleteResultDto> OrderComplete(OrderCompleteRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
