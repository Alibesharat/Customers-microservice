using MessageBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService
{
    public class CustomerCreate
    {
        public CustomerCreate(IMessageSender message)
        {
            var s = message;
        }
    }
}
