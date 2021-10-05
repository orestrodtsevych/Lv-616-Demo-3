using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartSelenium
{
    class RegisterPage: AUnloggedRightMenuComponent
    {
        public IWebElement FirstNameField;
        public IWebElement LastNameField;
        public IWebElement EMailField;
        public IWebElement TelephoneField;
        public IWebElement PasswordField;
        public IWebElement ConfirmPasswordField;
        public IWebElement SubscribeRadio;
        public IWebElement AgreeCheckBox;
        public IWebElement ContinueButton;

        public RegisterPage(IWebDriver driver): base(driver)
        {
            InitialRegisterPage();
        }

        public void InitialRegisterPage()
        {
            FirstNameField = driver.FindElement(By.Id("input-firstname"));
            LastNameField = driver.FindElement(By.Id("input-lastname"));
            EMailField = driver.FindElement(By.Id("input-email"));
            TelephoneField = driver.FindElement(By.Id("input-telephone"));
            PasswordField = driver.FindElement(By.Id("input-password"));
            ConfirmPasswordField = driver.FindElement(By.Id("input-confirm"));
            AgreeCheckBox = driver.FindElement(By.Name("agree"));
            ContinueButton = driver.FindElement(By.CssSelector(".btn-primary"));
        }

        public void ClickFirstNameField() => FirstNameField.Click();
        public void ClickLastNameField() => LastNameField.Click();
        public void ClickEMailField() => EMailField.Click();
        public void ClickTelephoneField() => TelephoneField.Click();
        public void ClickPasswordField() => PasswordField.Click();
        public void ClickConfirmPasswordField() => ConfirmPasswordField.Click();





    }
}
