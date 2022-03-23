using System.Threading.Tasks;

namespace MessageBroker
{
    public interface IMessgeSender
    {
        /// <summary>
        ///  Can create  a "Topic" in Kafka or a "queue" in RabbitMQ
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        Task CreateHubAsync(string Name);


        Task SendMessage(string Message);
    }
}
