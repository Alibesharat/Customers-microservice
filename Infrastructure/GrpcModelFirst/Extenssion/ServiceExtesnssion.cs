using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Server;

namespace GrpcModelFirst.Extenssion
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





    }
}
