using Models.Events;
using System.Threading.Tasks;

namespace MessageBroker
{
    public interface IMessageSender
    {
     
        Task CreateTopicAsync(string Name);


        Task SendMessageToOrderTopic(string Key,OrderCompleted Message);
    }
}
