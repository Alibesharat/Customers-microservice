using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Contracts
{
    public interface IStoreService
    {

        Task Append(string key,string @event);


        Task<string> Fetch(string Key);


    }
}
