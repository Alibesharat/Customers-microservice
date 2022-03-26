using DAL;
using DAL.Options;
using EventStore.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAl.Impelimentions
{
    public class EventStoreService : IStoreService
    {
        EventStoreClient client;
        public EventStoreService(IOptions<EventStoreDebSetting> options)
        {
            var settings = EventStoreClientSettings.Create(options.Value.Connectionstring);
            client = new EventStoreClient(settings);
        }

        public async Task AppendAsync<T>(string Key, T @event)
        {

            var jsondata = JsonConvert.SerializeObject(@event);
            var eventData = new EventData(
                Uuid.NewUuid(),
                "Event",
                Encoding.UTF8.GetBytes(jsondata)
            );

            await client.AppendToStreamAsync(
           Key,
            StreamState.Any,
            new[] { eventData });


        }

        public async Task<T> FetchAsync<T>(string Key)
        {
            var result = await client.ReadStreamAsync(Direction.Backwards, Key, StreamPosition.End, 1).LastAsync();
            var jsondata = Encoding.UTF8.GetString(result.Event.Data.ToArray());
            return JsonConvert.DeserializeObject<T>(jsondata);
        }

        public async Task<bool> ISExist(string Key)
        {
            try
            {
                return await client.ReadStreamAsync(Direction.Backwards, Key, StreamPosition.End).AnyAsync();

            }
            catch
            {

                return false;
            }
        }
    }
}
