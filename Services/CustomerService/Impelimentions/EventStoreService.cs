using CustomerService.Contracts;
using EventStore.Client;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomerService.Impelimentions
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

        public async Task Save(string Key, string @event)
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
    }
}
