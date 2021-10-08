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
    [Parallelizable(ParallelScope.Self)]
    class CategoriesTests
    {
        private readonly string URL = "http://192.168.1.105/opencart/upload/";
        
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
            
            string CategoryExpected = "Desktops";
            string ItemInCategory = "Show All";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);

            HomePage homePage = new HomePage(driver);
            Thread.Sleep(2000);
            homePage.ClickSearchProductField();
            //Thread.Sleep(2000);
            homePage.ClickItemFromCategoryByPartialLinkText(CategoryExpected, ItemInCategory);
            ProductPage ProductPage = new ProductPage(driver);
            string actualInLeftMenu = ProductPage.GetCurrentItemFromLeftMenu().Text.Split(" ")[0];
            string actualInContent = ProductPage.GetCategoryNameFromContent();

            Assert.AreEqual(CategoryExpected, actualInLeftMenu);
            Assert.AreEqual(CategoryExpected, actualInContent);

        }
        

        [Test]
        public void TabletsCategoryTest()
        {

            string CategoryExpected = "Tablets";
            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);

            HomePage homePage = new HomePage(driver);
            Thread.Sleep(2000);
            homePage.ClickSearchProductField();
            Thread.Sleep(2000);
            homePage.ClickCategoryByPartialLinkText(CategoryExpected);

            ProductPage ProductPage = new ProductPage(driver);
            string actualInLeftMenu = ProductPage.GetCurrentItemFromLeftMenu().Text.Split(" ")[0];
            string actualInContent = ProductPage.GetCategoryNameFromContent();

            Assert.AreEqual(CategoryExpected, actualInLeftMenu);
            Assert.AreEqual(CategoryExpected, actualInContent);

        }
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}
