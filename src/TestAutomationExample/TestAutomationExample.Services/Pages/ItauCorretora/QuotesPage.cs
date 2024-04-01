using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationExample.Domain.ItauCorretora;

namespace TestAutomationExample.Services.Pages.ItauCorretora
{
    public sealed class QuotesPage
    {
        private readonly AndroidDriver<AndroidElement> _androidDriver;

        public QuotesPage(AndroidDriver<AndroidElement> androidDriver)
        {
            _androidDriver = androidDriver;
        }

        private AndroidElement QuotesTextView => _androidDriver.FindElement(By.Id("com.itau.broker:id/footer_view"));
        private AndroidElement TitleQuotesTextView => _androidDriver.FindElement(By.Id("com.itau.broker:id/toolbar_title"));
        private AndroidElement FindQuotesTextView => _androidDriver.FindElement(By.Id("com.itau.broker:id/search_bar"));
        private AndroidElement StockTextView => _androidDriver.FindElement(By.XPath("//android.widget.TextView[@text=\"bolsas\"]"));
        private AndroidElement ExchangeTextView => _androidDriver.FindElement(By.XPath("//android.widget.TextView[@text=\"câmbio\"]"));
        private AndroidElement HighTextView => _androidDriver.FindElement(By.XPath("//android.widget.TextView[@text=\"altas\"]"));
        private AndroidElement LowTextView => _androidDriver.FindElement(By.XPath("//android.widget.TextView[@text=\"baixas\"]"));
        private AndroidElement LargerVolumesTextView => _androidDriver.FindElement(By.XPath("//android.widget.TextView[@text=\"maiores volumes\"]"));

        public void AccessQuotes()
        {
            QuotesTextView.Click();
        }

        public void AcessSearchEngine() { 
            QuotesTextView.Click(); 
            FindQuotesTextView.Click(); }

        public QuotesValidation ValidateElements()
        {
            return new QuotesValidation(
                TitleQuotesTextView.Text,
                FindQuotesTextView.Text,
                StockTextView.Text,
                ExchangeTextView.Text,
                HighTextView.Text,
                LowTextView.Text,
                LargerVolumesTextView.Text
                );
        }
    }
}
