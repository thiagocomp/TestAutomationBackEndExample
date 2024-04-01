using RestSharp;
using System.Text.Json.Nodes;
using TechTalk.SpecFlow;
using TestAutomationExample.Domain.Deserialize.Weather;
using TestAutomationExample.Infra.RestConfig;
using TestAutomationExample.Services.Weather;


namespace TestAutomationExample.Tests.Steps.WeatherAPI
{
    [Binding]
    public sealed class WeatherSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly OpenWeatherRequests _weather;
        private Root _response;
        private RestResponse _responseWrong;
        private string _city;
        private string _country;
        private int _cityId;
        public WeatherSteps(ScenarioContext scenarioContext, OpenWeatherRequests weather)
        {
            _scenarioContext = scenarioContext;
            _weather = weather;
            _cityId = 0;
        }

        [Given(@"que tenho acesso a api de weather")]
        public void GivenQueTenhoAcessoAApiDeWeather()
        {
            Assert.IsTrue(_weather != null);
        }

        [When(@"envio a requisição da cidade ""([^""]*)"" estado ""([^""]*)"" país ""([^""]*)""")]
        public void WhenEnvioARequisicaoDaCidadeEstadoPais(string city, string state, string country)
        {
            _response = _weather.GetWeather(city, state, country);
            _city = city;
            _country = country;
            _cityId = _cityId == 0 ? _response.id : _cityId;
        }

        [Then(@"visualizo o retorno da requisição com sucesso")]
        public void ThenVisualizoORetornoDaRequisicaoComSucesso()
        {
            Assert.AreEqual("OK", _response.StatusCode, true);
            Assert.AreEqual(_city, _response.name, true);
            Assert.AreEqual(_country, _response.sys.country, true);
        }

        [Then(@"visualizo o retorno da requisição com sucesso validando o id")]
        public void ThenVisualizoORetornoDaRequisicaoComSucessoValidandoOId()
        {
            Assert.AreEqual("OK", _response.StatusCode, true);
            Assert.AreEqual(_city, _response.name, true);
            Assert.AreEqual(_country, _response.sys.country, true);
            Assert.AreEqual(_cityId, _response.id);
        }

        [When(@"envio a requisição da cidade ""([^""]*)"" estado ""([^""]*)"" país ""([^""]*)"" com metodo Put")]
        public void WhenEnvioARequisicaoDaCidadeEstadoPaisComMetodoPut(string city, string state, string country)
        {
            _responseWrong = _weather.GetWeatherPut(city, state, country);
        }

        [Then(@"visualizo a mensagem de erro")]
        public void ThenVisualizoAMensagemDeErro()
        {
            
        }
        [When(@"envio a requisição da cidade ""([^""]*)"" estado ""([^""]*)"" país ""([^""]*)"" com apikey inválida")]
        public void WhenEnvioARequisicaoDaCidadeEstadoPaisComApikeyInvalida(string city, string state, string country)
        {
            _responseWrong = _weather.GetWeatherApiKeyInvalida(city, state, country);
        }

        [Then(@"visualizo a mensagem de erro ""([^""]*)"" StatusCode ""([^""]*)""")]
        public void ThenVisualizoAMensagemDeErroStatusCode(string mensagemErro, string statusCode)
        {
            Assert.AreEqual(statusCode, _responseWrong.StatusCode.ToString(), true);
            Assert.IsTrue(_responseWrong.Content.Contains(mensagemErro));
        }

        [When(@"envio a requisição da cidade ""([^""]*)"" estado ""([^""]*)"" país ""([^""]*)"" sem informar apikey")]
        public void WhenEnvioARequisicaoDaCidadeEstadoPaisSemInformarApikey(string city, string state, string country)
        {
            _responseWrong = _weather.GetWeatherSemApiKey(city, state, country);
        }

        [Then(@"visualizo a mensagem de erro Cidade não localizada")]
        public void ThenVisualizoAMensagemDeErroCidadeNaoLocalizada()
        {
            Assert.AreEqual("Cidade não localizada", _response.name, true);
        }

    }
}
