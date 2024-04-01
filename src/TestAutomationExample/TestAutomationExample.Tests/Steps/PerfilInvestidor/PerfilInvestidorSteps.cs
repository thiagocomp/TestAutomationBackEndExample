using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationExample.Domain.PerfilCliente;
using TestAutomationExample.Services.PerfilCliente;

namespace TestAutomationExample.Tests.Steps.PerfilInvestidor
{
    [Binding]
    public sealed class PerfilInvestidorSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly CriarPerfilClienteServices _criarPerfilClienteServices;
        private CriarPerfilCliente _perfilClienteDomain;
        private RestResponse _response;

        public PerfilInvestidorSteps(ScenarioContext scenarioContext, CriarPerfilClienteServices criarPerfilCliente)
        {
            _scenarioContext = scenarioContext;
            _criarPerfilClienteServices = criarPerfilCliente;
        }

        [Given(@"que tenho um investidor ""([^""]*)"" e ""([^""]*)"" investimentos")]
        public void GivenQueTenhoUmInvestidorEInvestimentos(string perfil, string possui)
        {
            _perfilClienteDomain = new CriarPerfilCliente(
                "João Farias", 1500, 7612, 6, (Domain.PerfilCliente.PerfilInvestidor)Enum.Parse(typeof(Domain.PerfilCliente.PerfilInvestidor), perfil), possui.ToUpper() == "POSSUI");
        }

        [When(@"realizo o cadastro dele")]
        public void WhenRealizoOCadastroDele()
        {
            _response = _criarPerfilClienteServices.criarPerfilCliente(_perfilClienteDomain);
        }

        [Then(@"o investidor é cadastrado com sucesso")]
        public void ThenOInvestidorECadastradoComSucesso()
        {
            Assert.AreEqual("Accepted", _response.StatusCode.ToString(), true);

        }

        [Then(@"o cadastro é negado com Status Code ""([^""]*)"" Mensagem ""([^""]*)""")]
        public void ThenOCadastroENegadoComStatusCodeMensagem(string statusCode, string mensagem)
        {
            Assert.AreEqual(statusCode, _response.StatusCode.ToString(), true);
            Assert.IsTrue(_response.Content.Contains(mensagem));
        }

        [Given(@"que tenho um investidor com informações incorretas")]
        public void GivenQueTenhoUmInvestidorComInformacoesIncorretas()
        {
            _perfilClienteDomain = new CriarPerfilCliente(
                "", 0, 0, 6, Domain.PerfilCliente.PerfilInvestidor.CONSERVADOR, true);
        }

        [When(@"realizo o cadastro dele com bearer token inválido")]
        public void WhenRealizoOCadastroDeleComBearerTokenInvalido()
        {
            _response = _criarPerfilClienteServices.criarPerfilClienteBearerTokenInvalido(_perfilClienteDomain);
        }

        [When(@"realizo o cadastro dele sem bearer token")]
        public void WhenRealizoOCadastroDeleSemBearerToken()
        {
            _response = _criarPerfilClienteServices.criarPerfilClienteBearerTokenInvalido(_perfilClienteDomain);
        }
    }
}
