using Home_16.Clients;
using Newtonsoft.Json.Linq;

namespace Home_16.Services
{
    public class BaseService
    {
        protected BaseApiClient apiClient;
        public string BaseUrl = JObject.Parse(File.ReadAllText("appdata.json"))["BaseUrl"].ToString();

        public BaseService()
        {
            apiClient = new BaseApiClient(BaseUrl);
        }
    }
}
