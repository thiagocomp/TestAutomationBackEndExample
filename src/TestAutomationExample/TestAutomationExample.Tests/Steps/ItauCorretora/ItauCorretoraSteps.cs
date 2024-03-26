using TechTalk.SpecFlow;

namespace TestAutomationExample.Tests.Steps.ItauCorretora
{
    [Binding]
    public class ItauCorretoraSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ItauCorretoraSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"que tenho o aplicativo do Itaú Corretora instalado")]
        public void GivenQueTenhoOAplicativoDoItauCorretoraInstalado()
        {
            throw new PendingStepException();
        }

        [When(@"insiro credenciais inválidas no login")]
        public void QuandoInsiroCredenciaisInvalidasNoLogin()
        {
            throw new PendingStepException();
        }
        [Then(@"visualizo a mensagem de erro no login")]
        public void EntaoVisualizoAMensagemDeErroNoLogin()
        {
            throw new PendingStepException();
        }
    }
}
