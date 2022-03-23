using Events;
using MessageBroker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AggregateGateway.Extenssions
{
    public static class MessageSenderExtenssion
    {
        /// <summary>
        ///Try create Topics If they are not  Exist
        /// </summary>
        /// <param name="messageSender"></param>
        public static void EnusreTopicsExist(this IMessageSender messageSender)
        {
            var assembly = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "Events.dll")
                        .Select(x => Assembly.Load(AssemblyName.GetAssemblyName(x))).First();

            foreach (Type type in assembly.GetTypes()
                .Where(c => !c.IsInterface && !c.IsAbstract && typeof(IEvent).IsAssignableFrom(c)))
            {
                messageSender.CreateTopicAsync(type.Name);

            }

        }
    }
}
