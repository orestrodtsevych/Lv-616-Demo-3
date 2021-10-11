using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

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
        public SearchCriteriaComponent FindProduct(string searchText)
        {
            ClearSearchProductField();
            SetSearchProductField(searchText);
            SetSearchProductField(Keys.Enter);
            if(searchText == "")
            {
                return new SearchEmptyResultPage(driver);
            }
            else
            {
                return new SearchResultPage(driver);
            }
        }
    }
}
