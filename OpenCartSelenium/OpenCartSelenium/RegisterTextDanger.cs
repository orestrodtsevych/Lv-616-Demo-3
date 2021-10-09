using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCartSelenium
{
    class RegisterTextDanger: RegisterPage
    {
        public readonly string EXPECTED_VALID_FIRSTNAME_MESSAGE = "First Name must be between 1 and 32 characters!";
        public readonly string EXPECTED_VALID_LASTNAME_MESSAGE = "Last Name must be between 1 and 32 characters!";
        public readonly string EXPECTED_VALID_EMAIL_MESSAGE = "E-Mail Address does not appear to be valid!";
        public readonly string EXPECTED_VALID_TELEPHONE_MESSAGE = "Telephone must be between 3 and 32 characters!";
        public readonly string EXPECTED_VALID_PASSWORD_MESSAGE = "Password must be between 4 and 20 characters!";
        public readonly string EXPECTED_VALID_CONFIRMPASSWORD_MESSAGE = "Password confirmation does not match password!";

        public IList<IWebElement> TextDangerMessages { get; private set; }
        public RegisterTextDanger(IWebDriver driver): base(driver)
        {
            TextDangerMessages = driver.FindElements(By.CssSelector(".text-danger"));
        }
        public string GetFirstNameTextDanger() => TextDangerMessages.Select(x => x.FindElement(By.XPath("//*[@id='input-firstname']/following-sibling::div"))).FirstOrDefault().Text;
        public string GetLastNameTextDanger() => TextDangerMessages.Select(x => x.FindElement(By.XPath("//*[@id='input-lastname']/following-sibling::div"))).FirstOrDefault().Text;
        public string GetEMailTextDanger() => TextDangerMessages.Select(x => x.FindElement(By.XPath("//*[@id='input-email']/following-sibling::div"))).FirstOrDefault().Text;
        public string GetTelephoneTextDanger() => TextDangerMessages.Select(x => x.FindElement(By.XPath("//*[@id='input-telephone']/following-sibling::div"))).FirstOrDefault().Text;
        public string GetPasswordTextDanger() => TextDangerMessages.Select(x => x.FindElement(By.XPath("//*[@id='input-password']/following-sibling::div"))).FirstOrDefault().Text;
        public string GetConfirmPasswordTextDanger() => TextDangerMessages.Select(x => x.FindElement(By.XPath("//*[@id='input-confirm']/following-sibling::div"))).FirstOrDefault().Text;

    }
}
