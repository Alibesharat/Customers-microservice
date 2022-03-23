using System.Threading.Tasks;

namespace MessageBroker
{
    public interface IMessgeSender
    {
     
        Task CreateTopicAsync(string Name);


        Task SendMessage(string Topic,string Key,string Message);
    }
}
