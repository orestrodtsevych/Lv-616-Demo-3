using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace OpenCartSelenium.RostyslavTests
{
    class CurrencyTests
    {
        private readonly string URL = "http://localhost/OpenCart/upload/";
        private readonly By CurrencyList = By.XPath("/html/body/nav/div/div[1]/form/div/button");
        private readonly By CurrencyEuro = By.XPath("/html/body/nav/div/div[1]/form/div/ul/li[1]/button");
        private readonly By CurrencyPound = By.XPath("/html/body/nav/div/div[1]/form/div/ul/li[2]/button");
        private readonly By CurrencyDollar = By.XPath("/html/body/nav/div/div[1]/form/div/ul/li[3]/button");
        private readonly By CurrencyPriceTax = By.XPath("//*[@id='content']/div[2]/div[1]/div/div[2]/p[2]/span");

        private IWebDriver driver;
        [OneTimeSetUp]
        public void StartingChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [SetUp]
        public void BeforeEveryMethods()
        {
            driver.Navigate().GoToUrl(URL); // const set up
        }
        public string GetSpecSymbol(string price)
        {          
            string GetSpecSymbol = "ERROR";
            string v1 = "$";string v2 = "€";string v3 = "£";
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
        [Test]
        public void EuroCurrencyTest()
        {
            HomePage homePage = new HomePage(driver);
            driver.FindElement(CurrencyList).Click();
            Thread.Sleep(2000);//Only for presentation
            string Currency = driver.FindElement(CurrencyEuro).Text;
            Thread.Sleep(2000);//Only for presentation
            driver.FindElement(CurrencyEuro).Click();
            Thread.Sleep(2000);//Only for presentation
            string price = driver.FindElement(CurrencyPriceTax).Text;
            Console.WriteLine("Currency " + Currency + "( " + GetSpecSymbol(Currency) + " ) Price " + price + "( " + GetSpecSymbol(price) + " )");
            Thread.Sleep(2000);//Only for presentation
            CurrencyTest(Currency, price);
        }
        [Test]
        public void PoundCurrencyTest()
        {
            HomePage homePage = new HomePage(driver);
            driver.FindElement(CurrencyList).Click();
            Thread.Sleep(2000);//Only for presentation
            string Currency = driver.FindElement(CurrencyPound).Text;
            Thread.Sleep(2000);//Only for presentation
            driver.FindElement(CurrencyPound).Click();
            Thread.Sleep(2000);//Only for presentation
            string price = driver.FindElement(CurrencyPriceTax).Text;
            Console.WriteLine("Currency " + Currency + "( " + GetSpecSymbol(Currency) + " ) Price " + price + "( " + GetSpecSymbol(price) + " )");
            Thread.Sleep(2000);//Only for presentation
            CurrencyTest(Currency, price);
        }
        [Test]
        public void DollarCurrencyTest()
        {
            HomePage homePage = new HomePage(driver);
            driver.FindElement(CurrencyList).Click();
            Thread.Sleep(2000);//Only for presentation
            string Currency = driver.FindElement(CurrencyDollar).Text;
            Thread.Sleep(2000);//Only for presentation
            driver.FindElement(CurrencyDollar).Click();
            Thread.Sleep(2000);//Only for presentation
            string price = driver.FindElement(CurrencyPriceTax).Text;
            Console.WriteLine("Currency " + Currency + "( " + GetSpecSymbol(Currency) + " ) Price " + price + "( " + GetSpecSymbol(price) + " )");
            Thread.Sleep(2000);//Only for presentation
            CurrencyTest(Currency, price);
        }
    }
}
