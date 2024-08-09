using TechTalk.SpecFlow;
using TestAutomationBackEndExample.Infra;

namespace TestAutomationBackEndExample.Tests.Steps.Hooks
{
    [Binding]
    public class Hooks
    {
        public Hooks() { }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var root = Directory.GetCurrentDirectory().ToString().Replace("\\bin\\Debug\\net6.0","");
            var dotenv = Path.Combine(root, ".env");
            EnvConfig.Load(dotenv);
        }
    }
}
