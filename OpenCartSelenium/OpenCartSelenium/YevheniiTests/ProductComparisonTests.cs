using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace OpenCartSelenium.YevheniiTests
{
    //[TestFixture("Windows 10")]
    public class ProductComparisonTests
    {
        private IWebDriver driver;
        private readonly string ChromeDriverURL = @"C:\Users\Admin\source\repos";
        private readonly string OpenCartURL = "http://192.168.1.9/opencart/";

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver(ChromeDriverURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
        }
        //[SetUp]
        public void Setup()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
        }

        [Test]
        public void Test1()
        {
            // Arrange
            // Act
            HomePage homePage = new HomePage(driver);
            homePage.ClickPhonesAndPdasCategory();
            //ClickOnCompareButtons();
            ProductsListComponent productsList = new ProductsListComponent(driver);

            ClickOnCompareButtons();
            // Assert
            //Assert.;
        }
        [Test]
        public void Test2()
        {
            // Arrange
            // Act
            HomePage homePage = new HomePage(driver);
            homePage.ClickDesktopCategory();
            CategoryPage page = new CategoryPage(driver);
            page.ClickOnProductCompare();
            ProductComparison comparePage = new ProductComparison(driver);
            comparePage.ClickRemoveButtonByID(0);
            // Assert
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            //driver.Quit();
        }

        private void ClickOnCompareButtons()
        {

            ProductsListComponent productsList = new ProductsListComponent(driver);
            foreach (var item in productsList.ProductComponents)
                item.ClickAddToCompareButton();
            //productsList.ProductComponents[1].ClickAddToCompareButton();
            //productsList = new ProductsListComponent(driver);
            //productsList.ProductComponents[2].ClickAddToCompareButton();
        }
    }
}