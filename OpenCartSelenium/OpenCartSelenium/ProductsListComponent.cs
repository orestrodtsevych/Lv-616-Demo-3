using System;
using System.Linq;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace OpenCartSelenium
{
    class ProductsListComponent
    {
        private IWebDriver _driver;
        private List<ProductComponent> _productComponents;

        public ProductsListComponent(IWebDriver driver)
        {
            _driver = driver;
            initProductsListComponents();
        }

        public List<ProductComponent> ProductComponents => _productComponents;

        private void initProductsListComponents()
        {
            _productComponents = new List<ProductComponent>();
            foreach (var item in _driver.FindElements(By.CssSelector(".product-layout")))
                _productComponents.Add(new ProductComponent(item));
        }
    }
}
