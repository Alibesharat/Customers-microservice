using GrpcModelFirst;
using ProtoBuf.Grpc.Server;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtesnssion
    {


        public static void AddGrpcServer(this IServiceCollection services)
        {
            services.AddCodeFirstGrpc(config =>
            {
                config.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal;
            });

        }


        public static void AddGrpcClient(this IServiceCollection services)
        {
            services.AddSingleton<IGrpcBaseChannel, GrpcBaseChannel>();
        }





    }
}
