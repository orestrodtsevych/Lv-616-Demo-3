using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    public class AccountLogoutPage : AUnloggedRightMenuComponent
    {
        public readonly string EXPECTED_TEXT_LOGOUT = "Account Logout";
        public IWebElement AccountLogoutLable { get; private set; }
        public AccountLogoutPage(IWebDriver driver) : base(driver)
        {
            AccountLogoutLable = driver.FindElement(By.CssSelector("#content h1"));
        }
        public string GetAccountLogoutLabletext() => AccountLogoutLable.Text;
    }
}
