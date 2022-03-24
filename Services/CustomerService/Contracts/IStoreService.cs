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


        Task<string> FetchLatest(string Key);


        Task<List<string>> FeatchAll(string Key);



    }
}
