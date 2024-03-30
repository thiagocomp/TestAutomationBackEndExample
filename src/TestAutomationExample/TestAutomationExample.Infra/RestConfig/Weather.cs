using RestSharp;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace TestAutomationExample.Infra.RestConfig
{
    public class Weather
    {
        public void GetWeather(string cityName, string stateCode, string country) 
        {
            var client = new RestClient("https://api.openweathermap.org");
            var request = new RestRequest("/data/2.5/weather?lat=-23.5506507&lon=-46.6333824&appid=9d4fde1d2a9428dd11a666afb948281b");
            var response = client.ExecuteGet(request);

            var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
        }

    }
}
