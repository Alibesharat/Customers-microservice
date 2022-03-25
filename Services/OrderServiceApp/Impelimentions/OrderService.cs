using GrpcModelFirst;
using Mapster;
using MessageBroker;
using Models.Dtos;
using Models.Events;

namespace OrderServiceApp.Impelimentions
{
    public class OrderService : IOrderService
    {
        readonly IMessageSender _MessageSender;

        public OrderService(IMessageSender messageSender)
        {
            _MessageSender = messageSender;
        }



        public void OrderComplete(OrderCompleteRequestDto dto)
        {
            var OrderEvent = dto.Adapt<OrderCompleted>();
            _MessageSender.SendMessageToOrderTopic(dto.Email, OrderEvent);
        }
    }
}
