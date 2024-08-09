using RestSharp;
using System.Text.Json;
using TestAutomationBackEndExample.Domain.Deserialize.Direct;
using TestAutomationExample.Domain.Deserialize.Weather;
using TestAutomationExample.Infra.RestConfig;

namespace TestAutomationExample.Services.Weather
{
    public class OpenWeatherRequests : OpenWeather
    {
        public Root GetWeather(string cityName, string stateCode, string country)
        {
            var response = this.GetCoordinates(cityName, stateCode, country);
            var cityFound = response.FirstOrDefault();
            if (cityFound != null)
            {
                var request = new RestRequest($"/data/2.5/weather?lat={cityFound.lat}&lon={cityFound.lon}&appid={base._apiKey}");
                var responseWeather = _client.ExecuteGet(request);

                var obj = JsonSerializer.Deserialize<Root>(responseWeather.Content!)!;
                obj.StatusCode = responseWeather.StatusCode.ToString();
                return obj;
            }
            return new Root { name =  "Cidade não localizada"};
        }

        public RestResponse GetWeatherPut(string cityName, string stateCode, string country)
        {
            var response = this.GetCoordinates(cityName, stateCode, country);
            var cityFound = response.FirstOrDefault();
            var request = new RestRequest($"/data/2.5/weather?lat={cityFound.lat}&lon={cityFound.lon}&appid={base._apiKey}");
            return _client.ExecutePut(request);

        }

        public RestResponse GetWeatherApiKeyInvalida(string cityName, string stateCode, string country)
        {
            var response = this.GetCoordinates(cityName, stateCode, country);
            var cityFound = response.FirstOrDefault();
            var request = new RestRequest($"/data/2.5/weather?lat={cityFound.lat}&lon={cityFound.lon}&appid=sdfghjknbasdga3234");
            return _client.ExecuteGet(request);

        }

        public RestResponse GetWeatherSemApiKey(string cityName, string stateCode, string country)
        {
            var response = this.GetCoordinates(cityName, stateCode, country);
            var cityFound = response.FirstOrDefault();
            var request = new RestRequest($"/data/2.5/weather?lat={cityFound.lat}&lon={cityFound.lon}");
            return _client.ExecuteGet(request);

        }

        private IEnumerable<DirectRoot> GetCoordinates(string cityName, string stateCode, string country)
        {
            var request = new RestRequest($"/geo/1.0/direct?q={cityName},{stateCode},{country}&limit=10&appid={base._apiKey}");
            var response = _client.ExecuteGet(request);

            return JsonSerializer.Deserialize<IEnumerable<DirectRoot>>(response.Content!)!;
        }
    }
}
