using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace OpenCartSelenium
{
   
    class LogInAsAdminPage:AHeadComponent
    {
        public IWebElement AdminUsername { get; private set; }
        public IWebElement AdminPassword { get; private set; }
        public IWebElement LogInButton { get; private set; }
        public LogInAsAdminPage(IWebDriver driver) : base(driver)
        {
            AdminUsername = driver.FindElement(By.CssSelector("#input-username"));
            AdminPassword = driver.FindElement(By.CssSelector("#input-password"));
            LogInButton = driver.FindElement(By.CssSelector(""));
        }
        
        public void LogInAsAdminWithCredites(string UserName, string Password)
        {
            AdminUsername.Click();
            AdminUsername.SendKeys(UserName);
            AdminPassword.Click();
            AdminPassword.SendKeys(Password);
        }
        public void ClickLogInButton() => LogInButton.Click();
    }
}
