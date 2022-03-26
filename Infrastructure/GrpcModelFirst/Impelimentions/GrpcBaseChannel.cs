using Grpc.Net.Client;
using GrpcModelFirst.Options;
using Microsoft.Extensions.Options;
using ProtoBuf.Grpc.Client;

namespace GrpcModelFirst
{
    public class GrpcBaseChannel : IGrpcBaseChannel
    {
        readonly GrpcChannel CustomerChannel;
        readonly GrpcChannel OrderChannel;

        public GrpcBaseChannel(IOptions<GrpcSettings> options)
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            CustomerChannel = GrpcChannel.ForAddress(options.Value.CustomerUrl);
            OrderChannel = GrpcChannel.ForAddress(options.Value.OrderUrl);
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
