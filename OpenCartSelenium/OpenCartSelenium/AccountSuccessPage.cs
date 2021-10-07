using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartSelenium
{
    class AccountSuccessPage: ARightMenuComponent
    {
        public IWebElement MessageText { get; private set; }
        public IWebElement ContinueButton { get; private set; }
        public AccountSuccessPage(IWebDriver driver) : base(driver)
        {
            MessageText = driver.FindElement(By.CssSelector("#content > p"));
            ContinueButton = driver.FindElement(By.CssSelector(".btn-primary"));
        }
        public string GetMessageText() => MessageText.Text;
        public void ClickContinueButton() => ContinueButton.Click();
    }
}
