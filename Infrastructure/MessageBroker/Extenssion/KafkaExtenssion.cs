using Kafka.Public;
using System.Text;

namespace MessageBroker
{
    public static class  KafkaExtenssion
    {
        /// <summary>
        /// Recive Message as string 
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        public static string GetValue(this RawKafkaRecord rec)
        {
            return Encoding.UTF8.GetString(rec.Value as byte[]);

        }


        /// <summary>
        /// Recive Key as string 
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        public static string GetKey(this RawKafkaRecord rec)
        {
            return Encoding.UTF8.GetString(rec.Key as byte[]);

        }
    }
}
