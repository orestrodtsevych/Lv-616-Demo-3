using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    public class LoginMessagePage : LoginPage
    {
        public readonly string EXPECTED_WARNING_LOGIN = "Warning: No match for E-Mail Address and/or Password.";
        private IWebElement AlertMessage;
        public LoginMessagePage(IWebDriver driver) : base(driver)
        {
            InitAlertMessage();
        }
        private void InitAlertMessage()
        {
            AlertMessage = driver.FindElement(By.CssSelector(".alert.alert-danger"));
        }
    }
}
