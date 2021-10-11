using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

namespace OpenCartSelenium
{
    class HomePage : AHeadComponent
    {
        public HomePage(IWebDriver driver) : base(driver) { }
        public HomePage ChooseCurrency(string currency)
        {
            ClickCurrencyByPartialName(currency);
            return new HomePage(driver);
        }
        public void FindProduct(string searchText)
        {
            ClearSearchProductField();
            SetSearchProductField(searchText);
            SetSearchProductField(Keys.Enter);
        }
    }
}
