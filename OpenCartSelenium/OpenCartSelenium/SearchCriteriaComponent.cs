using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartSelenium
{
    class SearchCriteriaComponent : AStatusBarComponent
    {
        public IWebElement SearchCriteria { get; private set; }
        public IWebElement Description { get; private set; }
        public IWebElement SubCategory { get; private set; }
        public IWebElement SearchCriteriaButton { get; private set; }

        public SearchCriteriaComponent(IWebDriver driver) : base(driver)
        {
            SearchCriteria = driver.FindElement(By.Name("search"));
            Description = driver.FindElement(By.Name("description"));
            SubCategory = driver.FindElement(By.Name("sub_category"));
            SearchCriteriaButton = driver.FindElement(By.Id("button-search"));
        }
        public void ClickSearchCriteria() => SearchCriteria.Click();
        public void ClickDescription() => Description.Click();
        public void ClickSubCategory() => SubCategory.Click();
        public void ClickSearchCriteriaButton() => SearchCriteriaButton.Click();
        public void SetSearchCriteria(string text)
        {
            ClickSearchCriteria();
            SearchCriteria.SendKeys(text);
        }

    }
}
