using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace OpenCartSelenium
{
   
    class LogInAsAdminPage
    {
        protected IWebDriver driver;
        public IWebElement AdminUserName { get; private set; }
        public IWebElement AdminPassword { get; private set; }
        public IWebElement LogInButton { get; private set; }
        public LogInAsAdminPage(IWebDriver driver) 
        {
            this.driver = driver;
            AdminUserName = driver.FindElement(By.CssSelector("#input-username"));
            AdminPassword = driver.FindElement(By.CssSelector("#input-password"));
            LogInButton = driver.FindElement(By.CssSelector("div.text-right button"));
        }
        private void ClickOnAdminUserName() => AdminUserName.Click();
        private void ClickOnAdminPassword() => AdminPassword.Click();
        public AdminDashboardPage ClickOnLogInButton()
        {
            LogInButton.Click();
            return new AdminDashboardPage(driver);
        }
        private void SendKeysToAdminUserName(string UserName) => AdminUserName.SendKeys(UserName);
        private void SendKeysToAdminPassword(string Password) => AdminPassword.SendKeys(Password);
        public void LogInAsAdminWithCredites(string UserName, string Password)
        {
            ClickOnAdminUserName();
            SendKeysToAdminUserName(UserName);
            ClickOnAdminPassword();
            SendKeysToAdminPassword(Password);
        }
       
       
    }
}
