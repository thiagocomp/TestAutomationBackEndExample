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

        public ItauCorretoraSteps(ScenarioContext scenarioContext, AppiumDriverManager driver)
        {
            _scenarioContext = scenarioContext;
            _loginPage = new LoginPage(driver.Current);

        }

        [Given(@"que tenho o aplicativo do Itaú Corretora instalado")]
        public void GivenQueTenhoOAplicativoDoItauCorretoraInstalado()
        {
            _loginPage.LoadLogin();
        }

        [When(@"insiro credenciais inválidas no login")]
        public void QuandoInsiroCredenciaisInvalidasNoLogin()
        {
            _loginPage.Login(RandomNumber.Generate(0,9999,"D4"), RandomNumber.Generate(0, 999999, "D6"), RandomNumber.Generate(0, 999999, "D6"));
        }
        [Then(@"visualizo a mensagem de erro no login")]
        public void EntaoVisualizoAMensagemDeErroNoLogin()
        {
            Assert.AreEqual("Ocorreu um erro no tratamento da resposta.", _loginPage.GetMessageBox(), true);
            Assert.AreEqual("Ok, Entendi", _loginPage.GetTextButton1(), true);
        }
    }
}
