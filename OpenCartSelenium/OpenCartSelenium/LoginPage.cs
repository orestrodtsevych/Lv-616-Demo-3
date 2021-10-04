using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    class LoginPage : AUnloggedRightMenuComponent
    {
        public IWebElement EmailField { get; private set; }
        public IWebElement PasswordField { get; private set; }
        public LoginPage(IWebDriver driver) : base(driver)
        {
            InitLoginComponent();
        }
        private void InitLoginComponent()
        {
            EmailField = driver.FindElement(By.Id("input-email"));
            PasswordField = driver.FindElement(By.Id("input-password"));
        }
        public void ClickEmailField() => EmailField.Click();
        public void ClickPasswordField() => PasswordField.Click();

    }
}
