using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Confluent.SchemaRegistry;
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
        SchemaRegistryConfig _schemaRegistryConfig;
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
                NumPartitions = 3
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


        public void SendMessage(string Messsage)
        {
            //
        }

        private void setup()
        {
            _adminConfig = new AdminClientConfig
            { BootstrapServers = "localhost:9092" };


            _schemaRegistryConfig = new SchemaRegistryConfig
            { Url = "http://localhost:8081" };

            _producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                // Guarantees delivery of message to topic.
                EnableDeliveryReports = true,
                ClientId = Dns.GetHostName()
            };
        }
    }
}
