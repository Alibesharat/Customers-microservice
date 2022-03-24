using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace GrpcModelFirst
{
    public class GrpcBaseChannel : IGrpcBaseChannel
    {
        readonly GrpcChannel CustomerChannel;
        readonly GrpcChannel OrderChannel;
        public GrpcBaseChannel()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;

            CustomerChannel = GrpcChannel.ForAddress("http://localhost:10042");
            OrderChannel = GrpcChannel.ForAddress("http://localhost:10043");

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
