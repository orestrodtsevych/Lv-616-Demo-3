using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OpenCartSelenium
{
    public abstract class AHeadComponent
    {
        public class DropdownOptions
        {
            private readonly IWebDriver driver;
            public IList<IWebElement> ListOptions { get; private set; }
            public DropdownOptions(By searchLocator, IWebDriver driver)
            {
                this.driver = driver;
                InitListOptions(searchLocator);
            }
            private void InitListOptions(By searchLocator)
            {
                ListOptions = driver.FindElements(searchLocator);
            }
            public IWebElement GetDropdownOptionByPartialName(string optionName)
            {
                IWebElement result = null;
                foreach (var item in ListOptions)
                {
                    if (item.Text.ToLower().Contains(optionName.ToLower()))
                    {
                        result = item;
                        break;
                    }
                }
                return result;
            }
            public List<string> GetListOptionsText()
            {
                List<string> result = new List<string>();
                foreach (var item in ListOptions)
                {
                    result.Add(item.Text);
                }
                return result;
            }
            public void ClickDropdownOptionByPartialName(string optionName)
            {
                GetDropdownOptionByPartialName(optionName).Click();
            }
        }
       
        private readonly string TAG_ATTRIBUTE_VALUE = "value";
        private readonly string OPTION_NOT_FOUND_MESSAGE = "Cannot foud the option";
        private readonly string TAG_ATTRIBUTE_TITLE = "title";
        private readonly string LOGOUT_ERROR = "LOGOUT_ERROR";
        private readonly string LOGIN_ERROR = "LOGIN_ERROR";
        private DropdownOptions dropdownOptions;
        protected IWebDriver driver;
        public IWebElement Currency { get; private set; }
        public IWebElement MyAccount { get; private set; }
        public IWebElement WishList { get; private set; }
        public IWebElement ShoppingCart { get; private set; }
        public IWebElement Checkout { get; private set; }
        public IWebElement Logo { get; private set; }
        public IWebElement SearchProductField { get; private set; }
        public IWebElement SearchProductButton { get; private set; }
        public IWebElement CartButton { get; private set; }
        public IList<IWebElement> MenuTop { get; private set; }
        public static bool LoggedUser { get; protected set; } = false;
        public IWebElement DesktopCategory { get; private set; }
        public IWebElement LaptopsAndNotebooksCategory { get; private set; }
        public IWebElement ComponentsCategory { get; private set; }
        public IWebElement TabletsCategory { get; private set; }
        public IWebElement SoftwareCategory { get; private set; }
        public IWebElement PhonesAndPdasCategory { get; private set; }
        public IWebElement CamerasCategory { get; private set; }
        public IWebElement MP3PlayersCategory { get; private set; }
        public AHeadComponent(IWebDriver driver)
        {
            this.driver = driver;
            Currency = driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle"));
            MyAccount = driver.FindElement(By.CssSelector("a[title='My Account']"));
            WishList = driver.FindElement(By.Id("wishlist-total"));    // to do
            ShoppingCart = driver.FindElement(By.CssSelector("a[title='Shopping Cart']"));
            Checkout = driver.FindElement(By.CssSelector("a[title='Checkout']"));
            Logo = driver.FindElement(By.Id("logo"));
            SearchProductField = driver.FindElement(By.Name("search"));
            SearchProductButton = driver.FindElement(By.Id("cart"));
            CartButton = driver.FindElement(By.CssSelector("#cart > button"));
            MenuTop = driver.FindElements(By.CssSelector("ul.nav.navbar-nav > li"));
            DesktopCategory = driver.FindElement(By.LinkText("Desktops"));
            LaptopsAndNotebooksCategory = driver.FindElement(By.LinkText("Laptops & Notebooks"));
            ComponentsCategory = driver.FindElement(By.LinkText("Components"));
            TabletsCategory = driver.FindElement(By.LinkText("Tablets"));
            SoftwareCategory = driver.FindElement(By.LinkText("Software"));
            PhonesAndPdasCategory = driver.FindElement(By.LinkText("Phones & PDAs"));
            CamerasCategory = driver.FindElement(By.LinkText("Cameras"));
            MP3PlayersCategory = driver.FindElement(By.LinkText("MP3 Players"));
        }
        public void ClickCurrency() => Currency.Click();
        public void ClickCurrencyByPartialName(string optionName)
        {
            ClickSearchProductField();
            ClickCurrency();
            CreateDropdownOptions(By.CssSelector("div.btn-group.open ul.dropdown-menu li"));
            ClickDropdownOptionByPartialName(optionName);
        }
        public void ClickMyAccount() => MyAccount.Click();
        public void ClickMyAccountOptionByPartialName(string optionName)
        {
            ClickSearchProductField();
            ClickMyAccount();
            CreateDropdownOptions(By.CssSelector("ul.dropdown-menu.dropdown-menu-right li"));
            ClickDropdownOptionByPartialName(optionName);
        }
        
        public void ClickWishList() => WishList.Click();
        public void ClickShoppingCart() => ShoppingCart.Click();
        public void ClickCheckout() => Checkout.Click();
        public void ClickLogo() => Logo.Click();
        public void ClickSearchProductField() => SearchProductField.Click();
        public void ClickCartButton() => CartButton.Click();
        public void ClickDesktopCategory() => DesktopCategory.Click();
        public void ClickLaptopsAndNotebooksCategory() => LaptopsAndNotebooksCategory.Click();
        public void ClickComponentsCategory() => ComponentsCategory.Click();
        public void ClickTabletsCategory() => TabletsCategory.Click();
        public void ClickSoftwareCategory() => SoftwareCategory.Click();
        public void ClickPhonesAndPdasCategory() => PhonesAndPdasCategory.Click();
        public void ClickCamerasCategory() => CamerasCategory.Click();
        public void ClickMP3PlayersCategory() => MP3PlayersCategory.Click();

        public void ClickDesktopCategoryOptionByPartialName(string optionName)
        {
            ClickSearchProductField();
            ClickDesktopCategory();
            CreateDropdownOptions(By.CssSelector("ul.list-unstyled li"));
            ClickDropdownOptionByPartialName(optionName);
        }
        private void ClickOnShowAll()
        {
            driver.FindElement(By.PartialLinkText("Show All")).Click();
        }
        public ProductPage ClickShowAllFromCategoryByPartialCategoryName(string Category)
        {
            ClickCategoryByPartialLinkText(Category);
            ClickOnShowAll();
            return new ProductPage(driver);

        }
      
        public void ClickCategoryByPartialLinkText(string Category)
        {
            ClickSearchProductField();
            driver.FindElement(By.PartialLinkText(Category)).Click();
        }

<<<<<<< HEAD

       
=======
>>>>>>> deef80cb16824a1f7c3a85704e8e7b50152e4b61
        public IWebElement GetMenuTopByCategoryPartianName(string categoryName)
        {
            IWebElement result = null;
            foreach (IWebElement current in MenuTop)
            {
                if (current.FindElement(By.CssSelector("a.dropdown-toggle")).Text.ToLower().Contains(categoryName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            return result;
        }
        public char GetCurrencyText() => Convert.ToChar(Currency.Text.Substring(0, 1));
        public string GetWishListText() => WishList.GetAttribute(TAG_ATTRIBUTE_TITLE);
        public int GetWishListNumber()
        {
            int value = 0;
            string result = string.Empty;
            for (int i = 0; i < GetWishListText().Length; i++)
            {
                if (Char.IsDigit(GetWishListText()[i]))
                    result += GetWishListText()[i];
            }
            if (result.Length > 0)
                value = int.Parse(result);
            return value;
        }
        public string GetShoppingCartText() => ShoppingCart.GetAttribute(TAG_ATTRIBUTE_TITLE);
        public string GetCheckoutText() => Checkout.GetAttribute(TAG_ATTRIBUTE_TITLE);
        public string GetShoppingCartButtonText() => CartButton.Text;
        public string GetSearchProductFieldText() => SearchProductField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        public int GetCartAmount() => int.Parse(GetShoppingCartButtonText().TakeWhile(Char.IsDigit).ToArray());
        public double GetCartSum()
        {
            int i;
            string str = null;
            if (GetCurrencyText() != '???')
            {
                for (i = 0; i < GetShoppingCartButtonText().Length; i++)
                {
                    if (GetShoppingCartButtonText()[i] == GetCurrencyText())
                    {
                        break;
                    }
                }
                for (int j = i + 1; j < GetShoppingCartButtonText().Length; j++)
                {
                    str += GetShoppingCartButtonText()[j];
                }
            }
            else
            {
                for (i = 0; i < GetShoppingCartButtonText().Length; i++)
                {
                    if (GetShoppingCartButtonText()[i] == '-')
                    {
                        break;
                    }
                }
                for (int j = i + 2; j < GetShoppingCartButtonText().Length - 1; j++)
                {
                    str += GetShoppingCartButtonText()[j];
                }
            }
            return Convert.ToDouble(str.Replace(".", ","));
        }
        public List<string> GetMenuTopText()
        {
            List<string> result = new List<string>();
            foreach (var item in MenuTop)
            {
                result.Add(item.Text);
            }
            return result;
        }
        public void SetSearchProductField(string text)
        {
            SearchProductField.SendKeys(text);
        }
        public void ClearSearchProductField()
        {
            SearchProductField.Clear();
        }

        // Dropdown Methods
        private void CreateDropdownOptions(By searchLocator)
        {
            dropdownOptions = new DropdownOptions(searchLocator, driver);
        }
        private void ClickDropdownOptionByPartialName(string optionName)
        {
            if (!FindDropdownOptionByPartialName(optionName))
            {
                throw new FormatException(OPTION_NOT_FOUND_MESSAGE);
            }
            dropdownOptions.ClickDropdownOptionByPartialName(optionName);
            dropdownOptions = null;
        }
        private bool FindDropdownOptionByPartialName(string optionName)
        {
            bool isFound = false;
            if (dropdownOptions == null)
            {
                throw new FormatException("DropdownOptions is Null");
            }
            foreach (var item in dropdownOptions.GetListOptionsText())
            {
                if (item.ToLower().Contains(optionName.ToLower()))
                {
                    isFound = true;
                }
            }
            return isFound;
        }

        public LoginPage GoToLoginPage()
        {
            if (LoggedUser)
            {
                throw new Exception(LOGIN_ERROR);
            }
            ClickMyAccountOptionByPartialName("Login");
            return new LoginPage(driver);
        }
        public AccountLogoutPage Logout()
        {
            if (!LoggedUser)
            {
                throw new Exception(LOGOUT_ERROR);
            }
            ClickMyAccountOptionByPartialName("Logout");
            LoggedUser = false;
            return new AccountLogoutPage(driver);
        }
        public MyAccountPage Login(User user)
        {
             return GoToLoginPage().SuccessfullLogin(user);
        }
        public MyAccountPage GoToMyAccountPage()
        {
            if (!LoggedUser)
            {
                throw new Exception(LOGIN_ERROR);
            }
            ClickMyAccountOptionByPartialName("My");
            return new MyAccountPage(driver);
        }
    }
}