using Kafka.Public;
using System;

namespace MessageBroker
{
    public interface IMessageReciver
    {
        public event EventHandler<RawKafkaRecord> MessageRecived;


        public void SubscribeToOrderTopic();
    }
}
