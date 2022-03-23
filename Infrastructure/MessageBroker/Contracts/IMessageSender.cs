using System.Threading.Tasks;

namespace MessageBroker
{
    public interface IMessageSender
    {
     
        Task CreateTopicAsync(string Name);


        Task SendMessage(string Topic,string Key,string Message);
    }
}
