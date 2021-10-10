using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartSelenium
{
    class EditAccountPage: ARightMenuComponent
    {
        public IWebElement FirstNameField { get; private set; }
        public IWebElement LastNameField { get; private set; }
        public IWebElement EMailField { get; private set; }
        public IWebElement TelephoneField { get; private set; }
        public IWebElement ContinueButton { get; private set; }
        
        public EditAccountPage(IWebDriver driver):base(driver)
        {
            FirstNameField = driver.FindElement(By.Id("input-firstname"));
            LastNameField = driver.FindElement(By.Id("input-lastname"));
            EMailField = driver.FindElement(By.Id("input-email"));
            TelephoneField = driver.FindElement(By.Id("input-telephone"));
            ContinueButton = driver.FindElement(By.CssSelector(".btn-primary"));
        }
        public void ClearAll()
        {
            ClearFirstNameField();
            ClearLastNameField();
            ClearEMailField();
            ClearTelephoneField();
        }
        public void FillForm(User user)
        {
            SetFirstNameField(user.FirstName);
            SetLastNameField(user.LastName);
            SetEMailField(user.EMail);
            SetTelephoneField(user.Telephone);
        }
        public void ClickFirstNameField() => FirstNameField.Click();
        public void ClearFirstNameField() => FirstNameField.Clear();
        public void SetFirstNameField(string firstName) => FirstNameField.SendKeys(firstName);
        public void ClickLastNameField() => LastNameField.Click();
        public void ClearLastNameField() => LastNameField.Clear();
        public void SetLastNameField(string lastName) => LastNameField.SendKeys(lastName);
        public void ClickEMailField() => EMailField.Click();
        public void ClearEMailField() => EMailField.Clear();
        public void SetEMailField(string eMail) => EMailField.SendKeys(eMail);
        public void ClickTelephoneField() => TelephoneField.Click();
        public void ClearTelephoneField() => TelephoneField.Clear();
        public void SetTelephoneField(string telephone) => TelephoneField.SendKeys(telephone);
        public MyAccountMessagePage ClickContinueToMyAccountButton()
        {
            ContinueButton.Click();
            return new MyAccountMessagePage(driver);
        }
        public EditAccountDangerText ClickContinueButton()
        {
            ContinueButton.Click();
            return new EditAccountDangerText(driver);
        }
    }
}
