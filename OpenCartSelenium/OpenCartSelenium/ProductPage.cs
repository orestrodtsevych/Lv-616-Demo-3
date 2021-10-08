using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace OpenCartSelenium
{
    public class ProductPage: ALeftMenuComponent
    {
        public IWebElement CategoryNameText { get; private set; }
        public ProductPage(IWebDriver driver) : base(driver)
        {
            CategoryNameText = driver.FindElement(By.CssSelector("#content > h2"));
        }
        public string GetCategoryNameFromContent() => CategoryNameText.Text;
    }
}
