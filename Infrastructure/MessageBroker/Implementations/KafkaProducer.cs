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
    public class KafkaProducer : IMessageSender
    {

        AdminClientConfig _adminConfig;
        ProducerConfig _producerConfig;
        ILogger<KafkaProducer> _logger;
        public KafkaProducer(ILogger<KafkaProducer> logger)
        {
            setup();
            _logger = logger;

        }



        public async Task CreateTopicAsync(string Name)
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


        public async Task SendMessage(string Topic, string Key, string Message)
        {
            using (var producer = new ProducerBuilder<string, string>(_producerConfig).Build())
            {
                var result = await producer.ProduceAsync(Topic, new Message<string, string> {Key=Key, Value = Message });
                _logger.LogInformation($"Your Message  is queued at offset { result.Offset.Value} in the Topic { result.Topic}");
            };

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
