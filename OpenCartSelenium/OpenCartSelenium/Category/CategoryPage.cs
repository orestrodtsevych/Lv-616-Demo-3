using System;
using OpenQA.Selenium;

namespace OpenCartSelenium
{
    class CategoryPage : AStatusBarComponent
    {
        private IWebElement _productCompare;
        public CategoryPage(IWebDriver driver) : base(driver) 
        {
            _productCompare = driver.FindElement(By.Id("compare-total"));
        }

        public string ProductCompareText => _productCompare.Text;

        public void ClickOnProductCompare()
            => _productCompare.Click();
    }
}
