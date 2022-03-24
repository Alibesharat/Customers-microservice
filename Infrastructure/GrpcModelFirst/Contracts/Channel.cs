using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace GrpcModelFirst.Contracts
{
    public class Channel
    {
        readonly GrpcChannel CustomerChannel;
        readonly GrpcChannel OrderChannel;
        public Channel()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;

            CustomerChannel = GrpcChannel.ForAddress("localhost:10042");
            OrderChannel = GrpcChannel.ForAddress("localhost:10043");

        }


        public IOrderService GetOrderService()
        {
            return OrderChannel.CreateGrpcService<IOrderService>();
        }


        public ICustomerService GetCustomerService()
        {
            return CustomerChannel.CreateGrpcService<ICustomerService>();
        }




    }
}
