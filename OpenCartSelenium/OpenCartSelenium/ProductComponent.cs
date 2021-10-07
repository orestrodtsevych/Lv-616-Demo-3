using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace OpenCartSelenium
{
    class ProductComponent
    {
        private IWebElement _productLayout;

        private IWebElement _name;
        private IWebElement _price;
        private IWebElement _description;
        private IWebElement _addToCartButton;
        private IWebElement _addToWishButton;
        private IWebElement _addToCompareButton;

        public ProductComponent (IWebElement productLayout)
        {
            _productLayout = productLayout;
            _name = _productLayout.FindElement(By.CssSelector("h4 a"));
            _price = _productLayout.FindElement(By.CssSelector(".price"));
            _description = _productLayout.FindElement(By.CssSelector("p"));
            _addToCartButton = _productLayout.FindElement(By.CssSelector(".fa fa-shopping-cart"));
            _addToWishButton = _productLayout.FindElement(By.CssSelector(".fa fa-heart"));
            _addToCompareButton = _productLayout.FindElement(By.CssSelector(".fa fa-exchange"));
            /*_name = _productLayout.FindElement(By.XPath(@"//*[@class='caption']/h4/a"));
            _price = _productLayout.FindElement(By.XPath(@"//*[@class='price']"));
            _description = _productLayout.FindElement(By.XPath(@"//*[@class='caption']/p[1]"));
            _addToCartButton = _productLayout.FindElement(By.XPath(@"//*[@class='button-group']/button[1]"));
            _addToWishButton = _productLayout.FindElement(By.XPath(@"//*[@class='button-group']/button[2]"));
            _addToCompareButton = _productLayout.FindElement(By.XPath(@"//*[@class='button-group']/button[3]"));*/
        }

        public IWebElement ProductLayout => _productLayout;
        public IWebElement Name => _name;
        public IWebElement Price => _price;
        public IWebElement Description => _description;
        public IWebElement AddToCartButton => _addToCartButton;
        public IWebElement AddToWishButton => _addToWishButton;
        public IWebElement AddToCompareButton => _addToCompareButton;

        public string GetNameText() => Name.Text;
        public string GetPriceText() => Price.Text;
        public string GetDescriptionText() => Description.Text;
        public void ClickName() => Name.Click();
        public void ClickAddToCartButton() => AddToCartButton.Click();
        public void ClickAddToWishButton() => AddToWishButton.Click();
        public void ClickAddToCompareButton() => AddToCompareButton.Click();
    }
}
