using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Home_16.Clients
{
    public class BaseApiClient
    {
        private RestClient restClient;

        public BaseApiClient(string url)
        {
            var option = new RestClientOptions(url)
            {
                MaxTimeout = 10000,
                ThrowOnAnyError = false
            };

            restClient = new RestClient(option);
            restClient.AddDefaultHeader("Content-Type", "application/json");
        }

        public void AddToken()
        {
            var token = JObject.Parse(File.ReadAllText("appdata.json"))["Token"].ToString();
            restClient.AddDefaultHeader("Token", token);
        }

        public RestResponse Execute(RestRequest request)
        {
            var response = restClient.Execute(request);
            return response;
        }

        public T Execute<T>(RestRequest request)
        {
            var response = restClient.Execute<T>(request);
            return response.Data;
        }
    }
}