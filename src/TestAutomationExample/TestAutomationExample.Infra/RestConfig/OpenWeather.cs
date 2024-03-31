using RestSharp;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace TestAutomationExample.Infra.RestConfig
{
    public class OpenWeather
    {
        protected readonly RestClient _client;
        protected readonly string _apiKey;
        public OpenWeather()
        {
            _client = new RestClient("https://api.openweathermap.org");
            _apiKey = "";
        }
       
    }
}
