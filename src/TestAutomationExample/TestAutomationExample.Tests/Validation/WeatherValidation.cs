using OpenQA.Selenium.Remote;
using RestSharp;
using TestAutomationExample.Domain.Deserialize.Weather;

namespace TestAutomationBackEndExample.Tests.Validation
{
    public class WeatherValidation
    {
        public void ValidateCredentials() 
        {
            Assert.IsNotNull(Environment.GetEnvironmentVariable("WEATHER_APIKEY"));
        }

        public void ValidateReturnOk(Root response, string? city, string? country) 
        {
            Assert.AreEqual("OK", response.StatusCode, true);
            Assert.AreEqual(city, response.name, true);
            Assert.AreEqual(country, response.sys.country, true);
        }

        public void ValidateReturnOkAndCityId(Root response, string? city, string? country, int cityId) 
        {
            this.ValidateReturnOk(response, city, country);
            Assert.AreEqual(cityId, response.id);
        }

        public void ValidateErrorAndStatusCode(RestResponse response, string erroMessage, string statusCode)
        {
            Assert.AreEqual(statusCode, response.StatusCode.ToString(), true);
            Assert.IsTrue(response.Content.Contains(erroMessage));
        }

        public void ValidateCityNotFound(Root response)
        {
            Assert.AreEqual("Cidade não localizada", response.name, true);
        }
    }
}
