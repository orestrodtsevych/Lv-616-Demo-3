using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartSelenium
{
    class SearchResultPage : SearchCriteriaComponent
    {
        public IWebElement ButtonListView { get; private set; }
        public IWebElement ButtonGridView { get; private set; }
        public IWebElement ProductCompare { get; private set; }
        public IWebElement ResultPageHeader { get; private set; }
        public IWebElement ProductTable { get; private set; }
        public SearchResultPage(IWebDriver driver) : base(driver)
        {
            ButtonListView = driver.FindElement(By.Id("list-view"));
            ButtonGridView = driver.FindElement(By.Id("grid-view"));
            ProductCompare = driver.FindElement(By.Id("compare-total"));
            ResultPageHeader = driver.FindElement(By.XPath("//*[@id='content']/h1"));
            ProductTable = driver.FindElement(By.CssSelector("#content > div:nth-child(8)"));
        }
        public void ClickButtonListView() => ButtonListView.Click();
        public void ClickButtonGridView() => ButtonGridView.Click();
        public void ClickProductCompare() => ProductCompare.Click();
    }
}
