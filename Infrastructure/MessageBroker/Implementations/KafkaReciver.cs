﻿using Kafka.Public;
using Kafka.Public.Loggers;
using Microsoft.Extensions.Logging;
using System;

namespace MessageBroker.Implementations
{
    public class KafkaReciver : IMessageReciver
    {
        ILogger<KafkaReciver> _logger;
        ClusterClient _Cluster;

        public event EventHandler<RawKafkaRecord> MessageRecived;

        public KafkaReciver(ILogger<KafkaReciver> logger)
        {
            setup();
            _logger = logger;
        }

        public void Subscribe(string Topic)
        {
            _Cluster.ConsumeFromEarliest(Topic);
            _Cluster.MessageReceived += Cluster_MessageReceived;

        }

        private void Cluster_MessageReceived(RawKafkaRecord rec)
        {
            MessageRecived?.Invoke(this, rec);
            _logger.LogInformation("Message recived");
        }

        private void setup()
        {
            string Servers = "localhost:9092";

            _Cluster = new ClusterClient(new Configuration()
            {
                Seeds = Servers
            }, new ConsoleLogger());
        }
    }
}
