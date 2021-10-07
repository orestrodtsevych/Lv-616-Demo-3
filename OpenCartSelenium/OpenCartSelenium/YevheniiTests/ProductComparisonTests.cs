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
    [TestFixture("Windows 10")]
    public class ProductComparisonTests
    {
        private IWebDriver driver;
        private readonly string ChromeDriverURL = @"C:\Users\Жека\source\repos";
        private readonly string OpenCartURL = "http://192.168.1.13/opencart/upload/";

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver(ChromeDriverURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        [SetUp]
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
            // Assert
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}