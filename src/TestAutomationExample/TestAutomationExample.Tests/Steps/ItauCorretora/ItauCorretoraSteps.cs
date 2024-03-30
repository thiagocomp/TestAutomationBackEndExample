using TechTalk.SpecFlow;
using TestAutomationExample.Infra.Driver;
using TestAutomationExample.Services.Pages.ItauCorretora;
using TestAutomationExample.Tests.Utils;

namespace TestAutomationExample.Tests.Steps.ItauCorretora
{
    [Binding]
    public sealed class ItauCorretoraSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPage _loginPage;
        private readonly QuotesPage _quotesPage;
        private readonly SearchEnginePage _searchEnginePage;
        private readonly AppiumDriverManager _driver;

        public ItauCorretoraSteps(ScenarioContext scenarioContext, AppiumDriverManager driver)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _loginPage = new LoginPage(_driver.Current);
            _quotesPage = new QuotesPage(_driver.Current);
            _searchEnginePage = new SearchEnginePage(_driver.Current);
        }

        [Given(@"que tenho o aplicativo do Itaú Corretora instalado")]
        public void GivenQueTenhoOAplicativoDoItauCorretoraInstalado()
        {
            _loginPage.LoadLogin();
        }

        [When(@"insiro credenciais inválidas no login")]
        public void QuandoInsiroCredenciaisInvalidasNoLogin()
        {
            _loginPage.Login(RandomNumber.Generate(0, 9999, "D4"), RandomNumber.Generate(0, 999999, "D6"), RandomNumber.Generate(0, 999999, "D6"));
        }
        [Then(@"visualizo a mensagem de erro no login")]
        public void EntaoVisualizoAMensagemDeErroNoLogin()
        {
            Assert.AreEqual("Ocorreu um erro no tratamento da resposta.", _loginPage.GetMessageBox(), true);
            Assert.AreEqual("Ok, Entendi", _loginPage.GetTextButton1(), true);
            _driver.Dispose();
        }

        [When(@"acesso a sessão de cotações")]
        public void WhenAcessoASessaoDeCotacoes()
        {
            _quotesPage.AccessQuotes();
        }

        [Then(@"visualizo os dados necessários para o cliente")]
        public void ThenVisualizoOsDadosNecessariosParaOCliente()
        {
            var _elementes = _quotesPage.ValidateElements();
            Assert.AreEqual("cotações", _elementes.TitleQuotes, true);
            Assert.AreEqual("buscar cotação", _elementes.FindQuotes, true);
            Assert.AreEqual("bolsas", _elementes.Stock, true);
            Assert.AreEqual("câmbio", _elementes.Exchange, true);
            Assert.AreEqual("altas", _elementes.High, true);
            Assert.AreEqual("baixas", _elementes.Low, true);
            Assert.AreEqual("maiores volumes", _elementes.LargerVolumes, true);
            _driver.Dispose();
        }

        [Given(@"que estou na sessão cotações")]
        public void GivenQueEstouNaSessaoCotacoes()
        {
            _loginPage.LoadLogin();
            _quotesPage.AcessSearchEngine();
        }


        [When(@"preencho o ativo ""([^""]*)"" ativo para consultar a cotação")]
        public void WhenPreenchoOAtivoAtivoParaConsultarACotacao(string ticker)
        {
            _searchEnginePage.FillSearchField(ticker);
        }

        [Then(@"a mensagem que o ativo não foi encontrado deve ser exibida com sucesso")]
        public void ThenAMensagemQueOAtivoNaoFoiEncontradoDeveSerExibidaComSucesso()
        {
            Assert.AreEqual("ABCD não encontrado", _searchEnginePage.GetEmptyLabelText(), true);
            _driver.Dispose();
        }


        [When(@"clico no botão X")]
        public void WhenClicoNoBotaoX()
        {
            _searchEnginePage.ClickClearTextImage();
        }

        [Then(@"os caracteres devem ser apagados com sucesso")]
        public void ThenOsCaracteresDevemSerApagadosComSucesso()
        {
            Assert.AreEqual("empresa/código/índice", _searchEnginePage.GetSearchFieldText(), true);
            _driver.Dispose();
        }


    }
}
