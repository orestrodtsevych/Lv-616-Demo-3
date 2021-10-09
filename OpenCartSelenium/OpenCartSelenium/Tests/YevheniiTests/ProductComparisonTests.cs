using System;
using System.Linq;
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
        }
        //[SetUp]
        public void Setup()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);


            //ClickOnCompareButtons();
            //ProductsListComponent productsList = new ProductsListComponent(driver);
            //page.ClickOnProductCompare();

            //ClickOnCompareButtons();
        }

        [Test]
        [TestCase('$')]
        public void CurrencyCheckTest(char expected)
        {
            // Arrange
            HomePage homePage = new HomePage(driver);
            // Act          
            char actual = homePage.GetCurrencyText();
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase("Phones & PDAs")]
        public void CategoryCheckTest(string expected)
        {
            // Arrange
            HomePage homePage = new HomePage(driver);
            // Act
            homePage.ClickPhonesAndPdasCategory();
            CategoryPage page = new CategoryPage(driver);
            string actual = page.GetLastBreadcrumbText();
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase(arg:new string[]{ "HTC Touch HD", "iPhone", "Palm Treo Pro" })]
        public void ProductsListTest(string [] productNames)//string first, string second, string third)
        {
            // Arrange
            ProductsListComponent productsList = new ProductsListComponent(driver);
            // Act
            string[] actualNames = productsList.GetProductsNameList().ToArray();
            // Assert
            Assert.AreEqual(productNames, actualNames);
        }
        [Test]
        [TestCase(3)]
        public void CountOfSelectedProductTest(int countOfProducts)
        {
            // Arrange
            CategoryPage page = new CategoryPage(driver);
            ProductsListComponent productsList = new ProductsListComponent(driver);
            // Act
            foreach (var item in productsList.ProductComponents)
                item.ClickAddToCompareButton();
            delay();
            // Assert
            Assert.AreEqual($"Product Compare ({ countOfProducts})", page.ProductCompareText);
        }
        [Test]
        [TestCase(arg: new double[] { 122, 123.2, 337.99})]
        public void ProductCompareTest(double[] prices)
        {
            // Arrange
            CategoryPage page = new CategoryPage(driver);
            ProductComparison comPage;
            // Act
            page.ClickOnProductCompare();
            comPage = new ProductComparison(driver);
            // Assert
            Assert.AreEqual(prices, comPage.Prices);
        }

            //ProductComparison comparePage = new ProductComparison(driver);
            //comparePage.ClickRemoveButtonByID(0);
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        private void delay()
            => Thread.Sleep(1000);

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