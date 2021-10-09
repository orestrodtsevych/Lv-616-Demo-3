using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OpenCartSelenium.OrestTests
{
    [TestFixture]
    class CartTests
    {
        IWebDriver driver;
        private readonly string OpenCartURL = "http://localhost/index.php?route=common/home";
        private readonly string cartURL = "http://localhost/index.php?route=checkout/cart";
        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }
        [Test]
        public void addToCart()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            driver.FindElement(By.CssSelector("div[class='product-layout col-lg-3 col-md-3 col-sm-6 col-xs-12']")).Click();
            driver.FindElement(By.Id("button-cart")).Click();
            driver.Navigate().GoToUrl(cartURL);
            string actual1 = driver.FindElement(By.XPath("//*[@id='content']/div[2]/div/table/tbody/tr[4]/td[2]")).Text;
            actual1 = actual1.Remove(0, 1);
            actual1.Substring(actual1.Length - 3);
            Console.WriteLine(actual1);
            bool actual = false;
            if (actual1.Length > 4)
            {
                actual = true;
            }
            Assert.IsTrue(actual);
            driver.Close();
        }
        [Test]
        public void viewCart()
        {
            bool addToCartCheck = false;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            driver.FindElement(By.CssSelector("div[class='product-layout col-lg-3 col-md-3 col-sm-6 col-xs-12']")).Click();
            driver.FindElement(By.Id("button-cart")).Click();
            //driver.FindElement(By.XPath("//*[@id='cart']/button")).Click();
            //driver.FindElement(By.PartialLinkText("View Cart")).Click();
            //DELETE
            driver.Navigate().GoToUrl(cartURL);
            //
            if (driver.FindElement(By.XPath("//*[@id='content']/p")).Text.Contains("Your shopping cart is empty!"))
            {
                addToCartCheck = false;
            }
            else
            {
                addToCartCheck = true;
            }
            Console.WriteLine("addToCartCheck " + addToCartCheck);
            string price = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div/table/tbody/tr/td[6]")).Text;
            price = price.Remove(0, 1);
            price = price.Replace('.', ',');
            double doublePrice = Convert.ToDouble(price);
            driver.FindElement(By.XPath("//*[@id='content']/form/div/table/tbody/tr/td[4]/div/input")).SendKeys(Keys.Backspace + "2");
            driver.FindElement(By.CssSelector("#content > form > div > table > tbody > tr > td:nth-child(4) > div > span > button.btn.btn-primary")).Click();
            string price2 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div/table/tbody/tr/td[6]")).Text;
            price2 = price2.Remove(0, 1);
            price2 = price2.Remove(price.Length - 5, 1);
            price2 = price2.Replace('.', ',');
            double doublePrice2 = Convert.ToDouble(price2);
            bool sumIsRight = false;
            if (doublePrice * 2 == doublePrice2)
            {
                sumIsRight = true;
            }
            Console.WriteLine("sumIsRight " + sumIsRight);
            bool deletecart = false;
            driver.FindElement(By.XPath("//*[@id='content']/form/div/table/tbody/tr/td[4]/div/span/button[2]")).Click();
            driver.Navigate().GoToUrl(cartURL);
            if (driver.FindElement(By.CssSelector("#content > p")).Text.Contains("Your shopping cart is empty!"))
            {
                deletecart = true;
            };
            Console.WriteLine("deletecart " + deletecart);
            driver.Close();
        }
        [Test]
        public void viewCartLoged()
        {

        }
    }
}
