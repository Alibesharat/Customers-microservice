using System.Threading.Tasks;

namespace DAL
{
    public interface IStoreService
    {

        Task Append(string key,string @event);


        Task<string> Fetch(string Key);


    }
}
