using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    class ChangePasswordPage : ARightMenuComponent
    {
        public IWebElement PasswordField { get; private set; }
        public IWebElement PasswordConfirm { get; private set; }
        public IWebElement ContinueButton { get; private set; }
        public ChangePasswordPage(IWebDriver driver) : base(driver)
        {
            PasswordField = driver.FindElement(By.Id("input-password"));
            PasswordConfirm = driver.FindElement(By.Id("input-confirm"));
            ContinueButton = driver.FindElement(By.CssSelector("input.btn.btn-primary"));
        }
        public void ClickPasswordField() => PasswordField.Click();
        public void ClearPasswordField() => PasswordField.Clear();
        public void SetPasswordField(string text) => PasswordField.SendKeys(text);
        public void ClickPasswordConfirmField() => PasswordConfirm.Click();
        public void ClearPasswordConfirmField() => PasswordConfirm.Clear();
        public void SetPasswordConfirmField(string text) => PasswordConfirm.SendKeys(text);
        public void ClickContinueButton() => ContinueButton.Click();
        public MyAccountPage ChangePassword(string NewPassword)
        {
            FillLoginForm(NewPassword);
            return new MyAccountPage(driver);
        }
        private void FillLoginForm(string NewPassword)
        {
            ClickPasswordField();
            ClearPasswordField();
            SetPasswordField(NewPassword);
            ClickPasswordConfirmField();
            ClearPasswordConfirmField();
            SetPasswordConfirmField(NewPassword);
            ClickContinueButton();
        }
    }
}
