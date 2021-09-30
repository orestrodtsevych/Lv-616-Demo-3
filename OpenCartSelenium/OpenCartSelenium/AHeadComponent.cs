using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace OpenCartSelenium
{
    public class AHeadComponent
    {
        private readonly string TAG_ATTRIBUTE_VALUE = "value";
        private readonly string TAG_ATTRIBUTE_TITLE = "title";
        protected IWebDriver driver;
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
        //useless
        //public IWebElement getCartTotal() => cartButton.FindElement(By.Id("cart-total")); 
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
        public char getCurrencyText() => Convert.ToChar(currency.Text.Substring(0, 1));
        public string getWishListText() => wishList.GetAttribute(TAG_ATTRIBUTE_TITLE);
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
        public string getShoppingCartText() => shoppingCart.GetAttribute(TAG_ATTRIBUTE_TITLE);
        public string getCheckoutText() => checkout.GetAttribute(TAG_ATTRIBUTE_TITLE);
        public string getShoppingCartButtonText() => cartButton.Text;
        public string getSearchProductFieldText() => searchProductField.GetAttribute(TAG_ATTRIBUTE_VALUE);

        public int getCartAmount() => int.Parse(getShoppingCartButtonText().TakeWhile(Char.IsDigit).ToArray());
        public double getCartSum()
        {
            int i;
            string str = null;
            for (i = 0; i < getShoppingCartButtonText().Length; i++)
            {
                if (getShoppingCartButtonText()[i] == getCurrencyText())
                {
                    break;
                }
            }
            for (int j = i + 1; j < getShoppingCartButtonText().Length; j++)
            {
                str += getShoppingCartButtonText()[j];
            }
            return Convert.ToDouble(str.Replace(".", ","));
        }
        public List<string> getMenuTopText()
        {
            List<string> result = new List<string>();
            foreach (var item in menuTop)
            {
                result.Add(item.Text);
            }
            return result;
        }
        public void setSearchProductField(string text)
        {
            searchProductField.SendKeys(text);
        }
    }

    public class Test
    {
        [Test]
        public void Test1()  //hardcoded Test for testing methods
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://192.168.1.16/opencart/upload/index.php?route=common/home");
            AHeadComponent aHead = new AHeadComponent(driver);
            char a = aHead.getCurrencyText();
            string b = aHead.getShoppingCartText();
            string c = aHead.getCheckoutText();
            string d = aHead.getShoppingCartButtonText();
            int cartAmount = aHead.getCartAmount();
            double safa = aHead.getCartSum();
            List<string> qdcw = aHead.getMenuTopText();
            aHead.setSearchProductField("wdaad");

            aHead.getWishListNumber();
        }
    }

}