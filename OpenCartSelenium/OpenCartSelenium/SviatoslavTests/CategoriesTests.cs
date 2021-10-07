using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace OpenCartSelenium.SviatoslavTests
{
    [TestFixture]
    class CategoriesTests
    {
        private readonly string URL = "http://192.168.1.105/opencart/upload/index.php?route=common/home";
        
        private IWebDriver driver;

        [OneTimeSetUp]
        public void StartChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        [Test]
        public void DesktopsCategoryTest()
        {

            string Category = "Desktops";
            string ItemInCategory = "Show All";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);

            HomePage homePage = new HomePage(driver);
            Thread.Sleep(2000);
            homePage.ClickSearchProductField();
            Thread.Sleep(2000);
            homePage.ClickItemFromCategoryByPartialLinkText(Category, ItemInCategory);
            ALeftMenuComponent LeftMenuItem = new ALeftMenuComponent(driver);
            string actual1 = LeftMenuItem.GetCurrentItemFromLeftMenu().Text.Split(" ")[0];
            Console.WriteLine("Category: " + Category + " actual = " + actual1);
            Assert.AreEqual(Category, actual1);

        }
    }
}
