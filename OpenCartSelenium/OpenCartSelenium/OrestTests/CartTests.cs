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
        private readonly string loginPage = "http://localhost/index.php?route=account/login";
        private readonly By firstProductOnMainPage = By.CssSelector("div[class='product-layout col-lg-3 col-md-3 col-sm-6 col-xs-12']");
        private readonly By clickAddToCart = By.Id("button-cart");
        private readonly By GetPrice = By.XPath("//*[@id='content']/div[2]/div/table/tbody/tr[4]/td[2]");
        private readonly By GetPriceTotal = By.XPath("/html/body/div[2]/div/div/form/div/table/tbody/tr/td[6]");
        private readonly By emtyCartText = By.XPath("//*[@id='content']/p");
        private readonly By productCountInputField = By.XPath("//*[@id='content']/form/div/table/tbody/tr/td[4]/div/input");
        private readonly By refreshButton = By.CssSelector("#content > form > div > table > tbody > tr > td:nth-child(4) > div > span > button.btn.btn-primary");
        private readonly By deleteProductFromCart = By.XPath("//*[@id='content']/form/div/table/tbody/tr/td[4]/div/span/button[2]");
        public bool CheckEmptyCart()
        {
            bool addToCartCheck = false;
            if (driver.FindElement(emtyCartText).Text.Contains("Your shopping cart is empty!"))
            {
                addToCartCheck = false;
            }
            else
            {
                addToCartCheck = true;
            }
            return addToCartCheck;
        }

        public double getPrice()
        {
            string price = driver.FindElement(GetPriceTotal).Text;
            price = price.Remove(0, 1);
            price = price.Replace('.', ',');
            double doublePrice = Convert.ToDouble(price);
            return doublePrice;
        }

        public bool CheckRightCountTotal(double doublePrice1, double doublePrice2)
        {
            bool sumIsRight = false;
            if (doublePrice1 * 2 == doublePrice2)
            {
                sumIsRight = true;
            }
            return sumIsRight;
        }
        //private readonly By 
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
            driver.FindElement(firstProductOnMainPage).Click();
            driver.FindElement(clickAddToCart).Click();
            driver.Navigate().GoToUrl(cartURL);
            string actual1 = driver.FindElement(GetPrice).Text;
            Console.WriteLine(actual1);
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
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            driver.FindElement(firstProductOnMainPage).Click();
            driver.FindElement(clickAddToCart).Click();
            driver.Navigate().GoToUrl(cartURL);
            CheckEmptyCart();
            double doublePrice1 = getPrice();
            driver.FindElement(productCountInputField).SendKeys(Keys.Backspace + "2");
            driver.FindElement(refreshButton).Click();
            double doublePrice2 = getPrice();
            CheckRightCountTotal(doublePrice1, doublePrice2);
            driver.FindElement(deleteProductFromCart).Click();
            driver.Navigate().GoToUrl(cartURL);
            CheckEmptyCart();
            driver.Close();
        }
        [Test]
        public void viewCartLogged()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(loginPage);
            LoginPage page1 = new LoginPage(driver);
            User user1 = User.CreateBuilder().SetEMail("admin@gmail.com").SetPassword("admin").Build();
            page1.SuccessfullLogin(user1);
        }
    }
}
