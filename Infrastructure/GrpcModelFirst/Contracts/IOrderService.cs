using GrpcModelFirst.Models;
using System.ServiceModel;

namespace GrpcModelFirst
{
    [ServiceContract]

    public interface IOrderService
    {
        [OperationContract]
        void OrderComplete(OrderCompleteRequestDto dto);
    }
}
