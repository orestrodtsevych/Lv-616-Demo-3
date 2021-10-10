using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace OpenCartSelenium.RostyslavTests
{
    class CurrencyWishListTests
    {
        private readonly string URL = "http://localhost/OpenCart/upload/";
        private readonly string URLWishList = "http://localhost/OpenCart/upload/index.php?route=account/wishlist";
        private readonly string URLLoginPage = "http://localhost/OpenCart/upload/index.php?route=account/login";
        private readonly By CurrencyList = By.XPath("/html/body/nav/div/div[1]/form/div/button");
        private readonly By CurrencyEuro = By.XPath("/html/body/nav/div/div[1]/form/div/ul/li[1]/button");
        private readonly By CurrencyPound = By.XPath("/html/body/nav/div/div[1]/form/div/ul/li[2]/button");
        private readonly By CurrencyDollar = By.XPath("/html/body/nav/div/div[1]/form/div/ul/li[3]/button");
        private readonly By CurrencyPriceTax = By.XPath("//*[@id='content']/div[1]/table/tbody/tr[1]/td[5]/div");
        private readonly By AddToWishList = By.XPath("//*[@id='content']/div[2]/div[2]/div/div[3]/button[2]");
        User SomeUser = User.CreateBuilder().SetEMail("levitsky.ross@gmail.com").SetPassword("123qwe").Build();
        private IWebDriver driver;
        [OneTimeSetUp]
        public void StartingChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SuccessfullLogin(SomeUser);
            driver.Navigate().GoToUrl(URL);
            driver.FindElements(AddToWishList);
        }
        [SetUp]
        public void BeforeEveryMethods()
        {
            driver.Navigate().GoToUrl(URLWishList); // const set up
        }
        public string ChooseCurrency(By CurrencyXPath)
        {
            driver.FindElement(CurrencyList).Click();
            Thread.Sleep(2000);//Only for presentation
            string Currency = driver.FindElement(CurrencyXPath).Text;
            Thread.Sleep(2000);//Only for presentation
            driver.FindElement(CurrencyXPath).Click();
            Thread.Sleep(2000);//Only for presentation
            return Currency;
        }
        public string GetPrice()
        {
            string price = driver.FindElement(CurrencyPriceTax).Text;
            Thread.Sleep(2000);//Only for presentation
            return price;
        }
        public string GetSpecSymbol(string price)
        {
            string GetSpecSymbol = "ERROR";
            string v1 = "$"; string v2 = "€"; string v3 = "£";
            for (int i = 0; i < price.Length; i++)
            {
                if (price.Contains(v1))
                {
                    GetSpecSymbol = v1;
                }
                if (price.Contains(v2))
                {
                    GetSpecSymbol = v2;
                }
                if (price.Contains(v3))
                {
                    GetSpecSymbol = v3;
                }
            }
            return GetSpecSymbol;
        }
        public void CurrencyTest(string Currency, string price)
        {
            HomePage homePage = new HomePage(driver);
            homePage.ChooseCurrency(Currency);
            Assert.AreEqual(GetSpecSymbol(Currency), GetSpecSymbol(price));
        }
        public void OutResult(string Currency, string price)
        {
            Console.WriteLine("Currency " + Currency + "( " + GetSpecSymbol(Currency) + " ) Price " + price + "( " + GetSpecSymbol(price) + " )");
        }
        [Test]
        public void EuroCurrencyTest()
        {
            string Currency = ChooseCurrency(CurrencyEuro);
            string price = GetPrice();
            OutResult(Currency, price);
            CurrencyTest(Currency, price);
        }
        [Test]
        public void PoundCurrencyTest()
        {
            string Currency = ChooseCurrency(CurrencyPound);
            string price = GetPrice();
            OutResult(Currency, price);
            CurrencyTest(Currency, price);
        }
        [Test]
        public void DollarCurrencyTest()
        {
            string Currency = ChooseCurrency(CurrencyDollar);
            string price = GetPrice();
            OutResult(Currency, price);
            CurrencyTest(Currency, price);
        }
    }
}
