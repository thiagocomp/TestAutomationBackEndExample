using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace TestAutomationExample.Infra.Driver
{
    public class AppiumDriverManager : IDisposable
    {
        private AndroidDriver<AndroidElement> driver;
        private bool _isDisposed;

        public AndroidDriver<AndroidElement> Current => driver;
        public void InitializeDriver()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("appium:platformName", Environment.GetEnvironmentVariable("platformName"));
            appiumOptions.AddAdditionalCapability("appium:deviceName", Environment.GetEnvironmentVariable("deviceName"));
            appiumOptions.AddAdditionalCapability("appium:automationName", "uiautomator2");
            appiumOptions.AddAdditionalCapability("appium:appPackage", Environment.GetEnvironmentVariable("appPackage"));
            appiumOptions.AddAdditionalCapability("appium:appActivity", Environment.GetEnvironmentVariable("appActivity"));
            appiumOptions.AddAdditionalCapability("unicodeKeyboard", "true");
            appiumOptions.AddAdditionalCapability("resetKeyboard", "true");
            driver = new AndroidDriver<AndroidElement>(new Uri(Environment.GetEnvironmentVariable("URL_APPIUM")), appiumOptions);
            driver.Context = "NATIVE_APP";
        }
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            driver?.Dispose();

            _isDisposed = true;
        }
    }
}
