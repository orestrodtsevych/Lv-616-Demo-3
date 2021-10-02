using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    public abstract class AHeadComponent
    { 
        private class DropdownOptions
        {
            private IWebDriver driver;
            public IList<IWebElement> listOptions { get; private set; }
            public DropdownOptions(By searchLocator, IWebDriver driver)
            {
                this.driver = driver;
                initListOptions(searchLocator);
            }
            private void initListOptions(By searchLocator)
            {
                listOptions = driver.FindElements(searchLocator);
            }
            public IWebElement getDropdownOptionByPartialName(string optionName)
            {
                IWebElement result = null;
                foreach (var item in listOptions)
                {
                    if (item.Text.ToLower().Contains(optionName.ToLower()))
                    {
                        result = item;
                        break;
                    }
                }
                return result;
            }
            public List<string> getListOptionsText()
            {
                List<string> result = new List<string>();
                foreach (var item in listOptions)
                {
                    result.Add(item.Text);
                }
                return result;
            }
            public void clickDropdownOptionByPartialName(string optionName)
            {
                getDropdownOptionByPartialName(optionName).Click();
            }
        }

        //-------------------------------------------------------------

        private readonly string TAG_ATTRIBUTE_VALUE = "value";
        private readonly string OPTION_NOT_FOUND_MESSAGE = "Cannot foud the option";
        private readonly string TAG_ATTRIBUTE_TITLE = "title";
        protected IWebDriver driver;
        private DropdownOptions dropdownOptions;
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
        public void clickCurrency() => currency.Click();
        public void clickCurrencyByPartialName(string optionName)
        {
            clickSearchProductField();
            clickCurrency();
            createDropdownOptions(By.CssSelector("div.btn-group.open ul.dropdown-menu li"));
            clickDropdownOptionByPartialName(optionName);
        }
        public void clickMyAccount() => myAccount.Click();
        public void clickMyAccountOptionByPartialName(string optionName)
        {
            clickSearchProductField();
            clickMyAccount();
            createDropdownOptions(By.CssSelector("ul.dropdown-menu.dropdown-menu-right li"));
            clickDropdownOptionByPartialName(optionName);
        }
        public void clickWishList() => wishList.Click();
        public void clickShoppingCart() => shoppingCart.Click();
        public void clickCheckout() => checkout.Click();
        public void clickLogo() => logo.Click();
        public void clickSearchProductField() => searchProductField.Click();
        public void clickCartButton() => cartButton.Click();
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
            if (getCurrencyText() != '€')
            {
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
            }
            else
            {
                for (i = 0; i < getShoppingCartButtonText().Length; i++)
                {
                    if (getShoppingCartButtonText()[i] == '-')
                    {
                        break;
                    }
                }
                for (int j = i + 2; j < getShoppingCartButtonText().Length - 1; j++)
                {
                    str += getShoppingCartButtonText()[j];
                }
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
        public void clearSearchProductField()
        {
            searchProductField.Clear();
        }

        // Dropdown Methods

        private void createDropdownOptions(By searchLocator)
        {
            dropdownOptions = new DropdownOptions(searchLocator, driver);
        }
        private void clickDropdownOptionByPartialName(string optionName)
        {
            if (!findDropdownOptionByPartialName(optionName))
            {
                throw new FormatException(OPTION_NOT_FOUND_MESSAGE);
            }
            dropdownOptions.clickDropdownOptionByPartialName(optionName);
            dropdownOptions = null;
        }
        private bool findDropdownOptionByPartialName(string optionName)
        {
            bool isFound = false;
            if (dropdownOptions == null) 
            {
                throw new FormatException("DropdownOptions is Null");
            }
            foreach (var item in dropdownOptions.getListOptionsText())
            {
                if (item.ToLower().Contains(optionName.ToLower()))
                {
                    isFound = true;
                }
            }
            return isFound;
        }
    }
}