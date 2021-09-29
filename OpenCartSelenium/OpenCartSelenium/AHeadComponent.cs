using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OpenCartSelenium
{
    public class AHeadComponent
    {
        protected IWebDriver driver = new ChromeDriver();
        public IWebElement currency { get; private set; }
        public IWebElement myAccount { get; private set; }
        public IWebElement wishList { get; private set; }
        public IWebElement shoppingCart { get; private set; }
        public IWebElement checkout { get; private set; }
        public IWebElement logo { get; private set; }
        public IWebElement searchProductField { get; private set; }
        public IWebElement searchProductButton { get; private set; }
        public IWebElement cartButton { get; private set; }
        public IList<IWebElement> menuTop { get; private set; }

        public AHeadComponent(IWebDriver driver)
        {
            this.driver = driver;
            currency = driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle"));
            myAccount = driver.FindElement(By.CssSelector("a[title='My Account']"));
            wishList = driver.FindElement(By.Id("wishlist-total"));    // to do
            shoppingCart = driver.FindElement(By.CssSelector("a[title='Shopping Cart']"));
            checkout = driver.FindElement(By.CssSelector("a[title='Checkout']"));
            logo = driver.FindElement(By.Id("logo"));
            searchProductField = driver.FindElement(By.Name("search"));
            searchProductButton = driver.FindElement(By.Id("cart"));
            cartButton = driver.FindElement(By.CssSelector("#cart > button"));
            menuTop = driver.FindElements(By.CssSelector("ul.nav.navbar-nav > li"));
        }
        public IWebElement getCartTotal() => cartButton.FindElement(By.Id("cart-total"));
        public IWebElement getMenuTopByCategoryPartianName(string categoryName)
        {
            IWebElement result = null;
            foreach (IWebElement current in menuTop)
            {
                if (current.FindElement(By.CssSelector("a.dropdown-toggle")).Text.ToLower().Contains(categoryName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            return result;
        }
        public string getCurrencyText() => currency.Text.Substring(0, 1);
        public string getWishListText() => wishList.GetAttribute("title");
        public int getWishListNumber()
        {
            int value = 0;
            string result = string.Empty;
            for (int i = 0; i < getWishListText().Length; i++)
            {
                if (Char.IsDigit(getWishListText()[i]))
                    result += getWishListText()[i];
            }
            if (result.Length > 0)
                value = int.Parse(result);
            return value;
        }
        public string getShoppingCartText() => shoppingCart.GetAttribute("title");
        public string getCheckoutText() => checkout.GetAttribute("title");
        public string getShoppingCartButtonText() => cartButton.Text;
    }

    public class Test
    {
        [Test]
        public void Test1()  //hardcoded Test for testing methods
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://192.168.1.13/opencart/upload/index.php?route=common/home");
            AHeadComponent aHead = new AHeadComponent(driver);
            string a = aHead.getCurrencyText();
            string b = aHead.getShoppingCartText();
            string c = aHead.getCheckoutText();
            string d = aHead.getShoppingCartButtonText();
            aHead.getWishListNumber();
        }
    }

}