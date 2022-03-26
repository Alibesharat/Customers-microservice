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
            var opt = options.Value;

            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            CustomerChannel = GrpcChannel.ForAddress(opt.CustomerUrl);
            OrderChannel = GrpcChannel.ForAddress(opt.OrderUrl);
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
