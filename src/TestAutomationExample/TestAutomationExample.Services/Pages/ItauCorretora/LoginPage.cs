using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace TestAutomationExample.Services.Pages.ItauCorretora
{
    public sealed class LoginPage

    {
        private readonly AndroidDriver<AndroidElement> _androidDriver;
        public LoginPage(AndroidDriver<AndroidElement> androidDriver)
        {
            _androidDriver = androidDriver;
        }

        private AndroidElement PermissionContinueButton => _androidDriver.FindElement(By.Id("com.android.permissioncontroller:id/continue_button"));
        private AndroidElement OkButton => _androidDriver.FindElement(By.Id("android:id/button1"));

        private AndroidElement ClientAgencyEditText => _androidDriver.FindElement(By.Id("com.itau.broker:id/client_agency"));
        private AndroidElement ClientAccountEditText => _androidDriver.FindElement(By.Id("com.itau.broker:id/client_account"));
        private AndroidElement PasswordEditText => _androidDriver.FindElement(By.Id("com.itau.broker:id/password"));
        private AndroidElement LoginButton => _androidDriver.FindElement(By.Id("com.itau.broker:id/button_login"));
        private AndroidElement MessageTextView => _androidDriver.FindElement(By.Id("android:id/message"));
        private AndroidElement FooterTextView => _androidDriver.FindElement(By.Id("com.itau.broker:id/footer_view"));

        public void LoadLogin()
        {
            PermissionContinueButton.Click();
            OkButton.Click();
        }

        public void Login(string clientAgency, string clientAccount, string password) 
        {
            ClientAgencyEditText.SendKeys(clientAgency);
            ClientAccountEditText.SendKeys(clientAccount);
            PasswordEditText.SendKeys(password);
            LoginButton.Click();
        }

        public string GetMessageBox()
        {
            return MessageTextView.Text;
        }

        public string GetTextButton1()
        {
            return OkButton.Text;
        }
    }
}
