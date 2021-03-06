using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    public abstract class ARightMenuComponent : AStatusBarComponent
    {
        public IWebElement EditAccountInformation { get; private set; }
        public IWebElement ChangeYourPassword { get; private set; }
        public ARightMenuComponent(IWebDriver driver) : base(driver)
        {
            //ChangeYourPassword = driver.FindElement(By.PartialLinkText("password"));
            EditAccountInformation = driver.FindElement(By.XPath("//*[text()='Edit Account']"));
        }
        public string GetEditAccountInformationText() => EditAccountInformation.Text;
        public void ClickEditAccountInformation() => EditAccountInformation.Click();
        public string GetChangeYourPasswordText() => ChangeYourPassword.Text;
        public void ClickhangeYourPassword() => ChangeYourPassword.Click();
    }
}
