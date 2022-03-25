using GrpcModelFirst.Models;

namespace GrpcModelFirst
{
    public interface IOrderService
    {

        void OrderComplete(OrderCompleteRequestDto dto);
    }
}
