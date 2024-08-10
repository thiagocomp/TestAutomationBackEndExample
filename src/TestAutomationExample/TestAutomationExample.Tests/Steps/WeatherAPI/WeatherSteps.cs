using RestSharp;
using TechTalk.SpecFlow;
using TestAutomationBackEndExample.Tests.Validation;
using TestAutomationExample.Domain.Deserialize.Weather;
using TestAutomationExample.Services.Weather;


namespace TestAutomationExample.Tests.Steps.WeatherAPI
{
    [Binding]
    public sealed class WeatherSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly OpenWeatherRequests _weather;
        private readonly WeatherValidation _weatherValidation;
        private Root _response;
        private RestResponse _responseWrong;
        private int _cityId;
        public WeatherSteps(ScenarioContext scenarioContext, OpenWeatherRequests weather, WeatherValidation weatherValidation)
        {
            _scenarioContext = scenarioContext;
            _weather = weather;
            _weatherValidation = weatherValidation;
            _cityId = 0;
        }

        [Given(@"que tenho acesso a api de weather")]
        public void GivenQueTenhoAcessoAApiDeWeather()
        {
            _weatherValidation.ValidateCredentials();
        }

        [When(@"envio a requisição da cidade ""([^""]*)"" estado ""([^""]*)"" país ""([^""]*)""")]
        public void WhenEnvioARequisicaoDaCidadeEstadoPais(string city, string state, string country)
        {
            _response = _weather.GetWeather(city, state, country);
            _scenarioContext.TryAdd("City", city);
            _scenarioContext.TryAdd("Country", country);
            _cityId = _cityId == 0 ? _response.id : _cityId;
        }

        [Then(@"visualizo o retorno da requisição com sucesso")]
        public void ThenVisualizoORetornoDaRequisicaoComSucesso()
        {
            _scenarioContext.TryGetValue("City", out string? city);
            _scenarioContext.TryGetValue("Country", out string? country);
            _weatherValidation.ValidateReturnOk(_response, city, country);
        }

        [Then(@"visualizo o retorno da requisição com sucesso validando o id")]
        public void ThenVisualizoORetornoDaRequisicaoComSucessoValidandoOId()
        {
            _scenarioContext.TryGetValue("City", out string? city);
            _scenarioContext.TryGetValue("Country", out string? country);
            _weatherValidation.ValidateReturnOkAndCityId(_response, city, country, _cityId);
        }

        [When(@"envio a requisição da cidade ""([^""]*)"" estado ""([^""]*)"" país ""([^""]*)"" com metodo Put")]
        public void WhenEnvioARequisicaoDaCidadeEstadoPaisComMetodoPut(string city, string state, string country)
        {
            _responseWrong = _weather.GetWeatherPut(city, state, country);
        }

        [When(@"envio a requisição da cidade ""([^""]*)"" estado ""([^""]*)"" país ""([^""]*)"" com apikey inválida")]
        public void WhenEnvioARequisicaoDaCidadeEstadoPaisComApikeyInvalida(string city, string state, string country)
        {
            _responseWrong = _weather.GetWeatherApiKeyInvalida(city, state, country);
        }

        [Then(@"visualizo a mensagem de erro ""([^""]*)"" StatusCode ""([^""]*)""")]
        public void ThenVisualizoAMensagemDeErroStatusCode(string errorMessage, string statusCode)
        {
            _weatherValidation.ValidateErrorAndStatusCode(_responseWrong, errorMessage, statusCode);
        }

        [When(@"envio a requisição da cidade ""([^""]*)"" estado ""([^""]*)"" país ""([^""]*)"" sem informar apikey")]
        public void WhenEnvioARequisicaoDaCidadeEstadoPaisSemInformarApikey(string city, string state, string country)
        {
            _responseWrong = _weather.GetWeatherSemApiKey(city, state, country);
        }

        [Then(@"visualizo a mensagem de erro Cidade não localizada")]
        public void ThenVisualizoAMensagemDeErroCidadeNaoLocalizada()
        {
            _weatherValidation.ValidateCityNotFound(_response);
        }

    }
}
