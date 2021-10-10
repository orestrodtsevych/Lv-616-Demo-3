using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartSelenium
{
    class MyAccountMessagePage: MyAccountPage
    {
        public readonly string EXPECTED_SUCCESS_MESSAGE = "Success: Your account has been successfully updated.";

        public IWebElement AlertMessage { get; private set; }

        public MyAccountMessagePage(IWebDriver driver): base(driver)
        {
            InitAlertMessage();
        }

        public void InitAlertMessage()
        {
            AlertMessage = driver.FindElement(By.CssSelector(".alert.alert-success"));
        }

        public string GetAlertMessageText() => AlertMessage.Text;
    }
}
