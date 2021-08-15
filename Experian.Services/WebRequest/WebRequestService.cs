using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Experian.Services.WebRequest
{
    public class WebRequestService : IWebRequestService
    {

        public T GetRequestData<T>(string url) where T : class
        {
            Task<string> requestData = GetRequest(url);

            T output = JsonConvert.DeserializeObject<T>(requestData.Result);

            return output;
        }

        private async Task<string> GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage requestResult = await client.GetAsync(url);

                if (requestResult.IsSuccessStatusCode)
                {
                    return await requestResult.Content.ReadAsStringAsync();
                }

                return null;
            }
        }
}
}
