using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace OpenCartSelenium
{
    class ProductListComponent
    {
        private IWebDriver driver;
        private List<ProductComponent> productComponents;
        public ProductListComponent(IWebDriver driver)
        {
            this.driver = driver;
            //
        }

        //private void InitProductsListComponent()
        //{
        //    productComponents = new List<>();
        //    foreach (item in productComponents) { 
        //    } (IWebElement current, )
        //        driver.FindElement(By.CssSelector(".product-layout"));
        //}


    }
}
