using DAL;
using EventStore.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAl.Impelimentions
{
    public class EventStoreService : IStoreService
    {
        EventStoreClient client;
        public EventStoreService()
        {
            var settings = EventStoreClientSettings
    .Create("esdb://localhost:2113?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000");
            client = new EventStoreClient(settings);
        }

        public async Task Append(string Key, string @event)
        {

            var eventData = new EventData(
                Uuid.NewUuid(),
                "Event",
                Encoding.UTF8.GetBytes(@event)
            );

            await client.AppendToStreamAsync(
           Key,
            StreamState.Any,
            new[] { eventData });


        }

        public async Task<string> Fetch(string Key)
        {
            var result =await client.ReadStreamAsync(Direction.Backwards, Key, StreamPosition.End, 1).LastAsync();
            return Encoding.UTF8.GetString(result.Event.Data.ToArray());
        }


    }
}
