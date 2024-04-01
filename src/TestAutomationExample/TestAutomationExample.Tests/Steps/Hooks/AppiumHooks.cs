using TechTalk.SpecFlow;
using TestAutomationExample.Infra.Driver;


namespace TestAutomationExample.Tests.Steps.Hooks
{
    [Binding]
    public class AppiumHooks
    {   
        private readonly AppiumDriverManager _driver;
        private readonly ScenarioContext _scenarioContext;
        public AppiumHooks(AppiumDriverManager driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Environment.SetEnvironmentVariable("WEATHER_APIKEY", "9d4fde1d2a9428dd11a666afb948281b");
            Environment.SetEnvironmentVariable("WEATHER_URL", "https://api.openweathermap.org");
            Environment.SetEnvironmentVariable("PERFIL_URL", "https://teste");
            Environment.SetEnvironmentVariable("PERFIL_BEARER", "9d4fde1d2a9428dd11a666afb948281b");

            Environment.SetEnvironmentVariable("platformName", "Android");
            Environment.SetEnvironmentVariable("deviceName", "emulator-5554");
            Environment.SetEnvironmentVariable("appPackage", "com.itau.broker");
            Environment.SetEnvironmentVariable("appActivity", "com.itau.broker.activity.LoginActivity_");
            Environment.SetEnvironmentVariable("URL_APPIUM", "http://localhost:4723");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Dispose();
        }
    }
}
