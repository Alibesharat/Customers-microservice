using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MessageBroker
{
    public class KafkaProducer : IMessgeSender
    {

        AdminClientConfig _adminConfig;
        ProducerConfig _producerConfig;
        ILogger<KafkaProducer> _logger;
        public KafkaProducer(ILogger<KafkaProducer> logger)
        {
            setup();
            _logger = logger;

        }



        public async Task CreateHubAsync(string Name)
        {
            using var adminClient = new AdminClientBuilder(_adminConfig).Build();

            TopicSpecification topic = new()
            {
                Name = Name,
                ReplicationFactor = 1,
                NumPartitions = 1
            };
            List<TopicSpecification> topics = new();
            topics.Add(topic);

            try
            {
                await adminClient.CreateTopicsAsync(topics);
            }
            catch (CreateTopicsException e) when (e.Results.Select(r => r.Error.Code)
                .Any(el => el == ErrorCode.TopicAlreadyExists))
            {
                _logger.LogInformation($"Topic {e.Results[0].Topic} already exists");

            }
            catch (Exception ex)
            {
                _logger.LogError("", ex);

            }
        }


        public Task SendMessage(string Messsage)
        {
            //

        }

      

        private void setup()
        {
            //TODO : Config Should Read from AppSettings.Json I just hard Coded for demo 
            string Servers = "localhost:9092";
            _adminConfig = new AdminClientConfig
            { BootstrapServers = Servers };


          

            _producerConfig = new ProducerConfig
            {
                BootstrapServers = Servers,
                // Guarantees delivery of message to topic.
                EnableDeliveryReports = true,
                ClientId = Dns.GetHostName()
            };
        }
    }
}
