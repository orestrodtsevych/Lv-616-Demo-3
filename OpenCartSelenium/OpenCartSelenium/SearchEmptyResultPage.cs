using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartSelenium
{
    class SearchEmptyResultPage : SearchCriteriaComponent
    {
        public IWebElement EmptyResultPageLabel { get; private set; }       
        public SearchEmptyResultPage(IWebDriver driver) : base(driver)
        {
            EmptyResultPageLabel = driver.FindElement(By.XPath("//*[@id='content']/p[2]"));            
        }
    }
}
