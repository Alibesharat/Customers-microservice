using Kafka.Public;
using Kafka.Public.Loggers;
using MessageBroker.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace MessageBroker
{
    public class KafkaReciver : IMessageReciver
    {
        ILogger<KafkaReciver> _logger;
        ClusterClient _Cluster;

        public event EventHandler<RawKafkaRecord> MessageRecived;

        public KafkaReciver(ILogger<KafkaReciver> logger,IOptions<KafkaSettings> options)
        {
            Setup(options.Value);
            _logger = logger;
        }

        public void SubscribeToOrderTopic()
        {
            _Cluster.Subscribe("ConsumerGroup", new[] { "Order"},new ConsumerGroupConfiguration());
            _Cluster.MessageReceived += Cluster_MessageReceived;

        }

        private void Cluster_MessageReceived(RawKafkaRecord rec)
        {
            
            MessageRecived?.Invoke(this, rec);
            _logger.LogInformation("Message recived");
        }

        private void Setup(KafkaSettings settings)
        {
            _Cluster = new ClusterClient(new Configuration()
            {
                Seeds = settings.Servers,
               
                
            }, new ConsoleLogger());
        }
    }
}
