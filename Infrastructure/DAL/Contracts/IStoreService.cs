using System.Threading.Tasks;

namespace DAL
{
    public interface IStoreService
    {

        Task AppendAsync(string key,string @event);


        Task<string> FetchAsync(string Key);


    }
}
