using RestSharp;


namespace TestAutomationExample.Infra.RestConfig
{
    public class OpenWeather
    {
        protected readonly RestClient _client;
        protected readonly string _apiKey;
        public OpenWeather()
        {
            _client = new RestClient(Environment.GetEnvironmentVariable("WEATHER_URL"));
            _apiKey = Environment.GetEnvironmentVariable("WEATHER_APIKEY");
        }
       
    }
}
