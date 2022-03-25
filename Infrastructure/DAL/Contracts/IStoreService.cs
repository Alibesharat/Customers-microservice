using System.Threading.Tasks;

namespace DAL
{
    public interface IStoreService
    {

        Task AppendAsync<T>(string key,T @event);


        Task<T> FetchAsync<T>(string Key);


        Task<bool> ISExist(string Key);


    }
}
