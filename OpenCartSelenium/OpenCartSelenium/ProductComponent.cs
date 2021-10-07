using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Text;

namespace OpenCartSelenium
{
    class ProductComponent
    {
        public IWebElement productLayout;
        public IWebElement Name { get; private set; }
        public IWebElement Price { get; private set; }
        public IWebElement AddToCartButton { get; private set; }
        public IWebElement AddToWishButton { get; private set; }
        public IWebElement AddToCompareButton { get; private set; }
        public ProductComponent(IWebElement productLayout)
        {
            this.productLayout = productLayout;
            InitProductComponent();
        }
        private void InitProductComponent()
        {
            Name = productLayout.FindElement(By.CssSelector("h4 a"));
            Price = productLayout.FindElement(By.XPath("//p[@class='price']"));
            AddToCartButton = productLayout.FindElement(By.CssSelector(".button-group>button:nth-child(1)"));
            AddToWishButton = productLayout.FindElement(By.XPath("//button[@data-original-title='Add to Wish List']//i[@class='fa fa-heart']"));
            AddToCompareButton = productLayout.FindElement(By.XPath("//button[@data-original-title='Compare this Product']"));
        }
        public IWebElement GetProductLayout()
        {
            return productLayout;
        }
        public string GetNameText()
        {
            return Name.Text;
        }
        public void ClickName()
        {
            Name.Click();
        }
        public IWebElement GetPrice()
        {
            return Price;
        }

        public string GetPriceText()
        {
            return GetPrice().Text;
        }
        //???
        public double GetPriceAmount()
        {
            return Convert.ToDouble(GetPriceText());
        }
        //??
        public IWebElement GetAddToCartButton()
        {
            return AddToCartButton;
        }
        public void ClickAddToCartButton()
        {
            GetAddToCartButton().Click();
        }
        public IWebElement GetAddToWishButton()
        {
            return AddToWishButton;
        }
        public void ClickAddToWishButton()
        {
            GetAddToWishButton().Click();
        }
        public IWebElement GetAddToCompareButton()
        {
            return AddToCompareButton;
        }
        public void ClickAddToCompareButton()
        {
            GetAddToCompareButton().Click();
        }

    }
}