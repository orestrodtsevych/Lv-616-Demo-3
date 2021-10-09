using System;
using OpenQA.Selenium;

namespace OpenCartSelenium
{
    class CategoryPage : AStatusBarComponent
    {
        private IWebElement _productCompare;
        private IWebElement _currentCategori;
        public CategoryPage(IWebDriver driver) : base(driver) 
        {
            _productCompare = driver.FindElement(By.Id("compare-total"));
            //_currentCategori = driver.FindElement(By.XPath($"//*[@id='product - category']/ul/li[2]/a"));
        }
        ////*[@id="product-category"]/ul/li[2]/a
        public string ProductCompareText => _productCompare.Text;
        public string CurrentCategoriText => _currentCategori.Text;

        public void ClickOnProductCompare()
            => _productCompare.Click();
    }
}
