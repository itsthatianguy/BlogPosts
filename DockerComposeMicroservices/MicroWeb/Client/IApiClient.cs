using System.Threading.Tasks;

namespace MicroWeb.Client
{
    public interface IApiClient
    {
        Task<T> Get<T>(string url);
    }
}