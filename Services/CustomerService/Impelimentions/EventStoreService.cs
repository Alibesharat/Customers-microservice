using CustomerService.Contracts;
using EventStore.Client;
using System;
using System.Collections.Generic;
using System.Linq;
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



        public async Task<string> FetchLatest(string Key)
        {
            var result = await client.ReadStreamAsync(Direction.Backwards, Key, StreamPosition.End, 1).LastAsync();
            return Encoding.UTF8.GetString(result.Event.Data.ToArray());
        }

        public async Task<List<string>> FeatchAll(string Key)
        {
            List<string> events = new();
            var result = await client.ReadStreamAsync(Direction.Backwards, Key, StreamPosition.End).ToListAsync();
            
            foreach (var ev in result)
            {
                events.Add(Encoding.UTF8.GetString(ev.Event.Data.ToArray()));
            }

            return events;


        }
    }
}
