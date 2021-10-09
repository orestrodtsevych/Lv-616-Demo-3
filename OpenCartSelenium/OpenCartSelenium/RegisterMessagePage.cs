using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartSelenium
{
    class RegisterMessagePage: RegisterPage
    {
        public readonly string EXPECTED_WARNING_AGREE = "Warning: You must agree to the Privacy Policy!";
        public readonly string EXPECTED_WARNING_EMAIL = "Warning: E-Mail Address is already registered!";
        
        public IWebElement AlertMessage { get; private set; }
        public RegisterMessagePage(IWebDriver driver) : base(driver)
        {
            InitAlertMessage();
        }
        public void InitAlertMessage()
        {
            AlertMessage = driver.FindElement(By.CssSelector(".alert.alert-danger"));
        }

        public string GetAlertMessageText() => AlertMessage.Text;
    }
}
