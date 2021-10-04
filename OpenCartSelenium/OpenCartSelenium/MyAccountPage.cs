using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    public class MyAccountPage : ARightMenuComponent
    {
        public IWebElement EditAccountInformation { get; private set; }
        public IWebElement ChangeYourPassword { get; private set; }
        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }
        public string GetEditAccountInformationText() => EditAccountInformation.Text;
        public void ClickEditAccountInformation() => EditAccountInformation.Click();
        public string GetChangeYourPasswordText() => ChangeYourPassword.Text;
        public void ClickhangeYourPassword() => ChangeYourPassword.Click();

    }
}
