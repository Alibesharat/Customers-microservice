using GrpcModelFirst.Models;
using System.Threading.Tasks;

namespace GrpcModelFirst.Contracts
{
    public interface IOrderService
    {

        Task<OrderCompleteResultDto> OrderComplete(OrderCompleteRequestDto dto);
    }
}
