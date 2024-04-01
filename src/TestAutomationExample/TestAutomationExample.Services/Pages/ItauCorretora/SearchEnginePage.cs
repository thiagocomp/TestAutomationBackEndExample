using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationExample.Services.Pages.ItauCorretora
{
    public sealed class SearchEnginePage
    {
        private readonly AndroidDriver<AndroidElement> _androidDriver;
        public SearchEnginePage(AndroidDriver<AndroidElement> androidDriver)
        {
            _androidDriver = androidDriver;
        }
        private AndroidElement SearchFieldEditText => _androidDriver.FindElement(By.Id("com.itau.broker:id/search_field"));
        private AndroidElement CleatTextImageView => _androidDriver.FindElement(By.Id("com.itau.broker:id/clear_text"));
        private AndroidElement EmptyLabelTextView => _androidDriver.FindElement(By.Id("com.itau.broker:id/label_empty_title"));

        public void FillSearchField(string ticker)
        {
            SearchFieldEditText.SendKeys(ticker);
            _androidDriver.ExecuteScript("mobile: performEditorAction", new Dictionary<string, object> { { "action", "search" }, { "elementId", SearchFieldEditText.Id } });
        }

        public void ClickClearTextImage()
        {
            CleatTextImageView.Click();
        }

        public string GetSearchFieldText()
        {
            return SearchFieldEditText.Text;
        }

        public string GetEmptyLabelText()
        {
            return EmptyLabelTextView.Text;
        }
    }
}
