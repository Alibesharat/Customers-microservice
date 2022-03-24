using GrpcModelFirst.Models;
using System.Threading.Tasks;

namespace GrpcModelFirst
{
    public interface IOrderService
    {

        Task<OrderCompleteResultDto> OrderComplete(OrderCompleteRequestDto dto);
    }
}
