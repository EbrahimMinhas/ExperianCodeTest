using System.Threading.Tasks;

namespace Experian.Services.WebRequest
{
    public interface IWebRequestService
    {
        T GetRequestData<T>(string url) where T : class;
    }
}
