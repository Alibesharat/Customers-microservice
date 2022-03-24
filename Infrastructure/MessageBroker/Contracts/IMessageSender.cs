using Events;
using System.Threading.Tasks;

namespace MessageBroker
{
    public interface IMessageSender
    {
     
        Task CreateTopicAsync(string Name);


        Task SendMessageToCustomerTopic(string Key,Event Message);
    }
}
