using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    public class MyAccountPage : ARightMenuComponent
    {
        public IWebElement MyAccountLabel { get; private set; }
        public IWebElement EditAccountInformation { get; private set; }
        public IWebElement ChangeYourPassword { get; private set; }
        public MyAccountPage(IWebDriver driver) : base(driver)
        {
            MyAccountLabel = driver.FindElement(By.XPath("//*[@id='content']/h2[1]"));
        }
        public string GetMyAccountLabelText() => MyAccountLabel.Text;
        public string GetEditAccountInformationText() => EditAccountInformation.Text;
        public void ClickEditAccountInformation() => EditAccountInformation.Click();
        public string GetChangeYourPasswordText() => ChangeYourPassword.Text;
        public void ClickhangeYourPassword() => ChangeYourPassword.Click();

    }
}
