using BoDi;
using TechTalk.SpecFlow;
using TestAutomationExample.Infra.Driver;

namespace TestAutomationExample.Tests.Steps.Hooks
{
    [Binding]
    public class AppiumHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            //Initialize a shared BrowserDriver in the global container
            testThreadContainer.BaseContainer.Resolve<AppiumDriverManager>();
        }
    }
}
