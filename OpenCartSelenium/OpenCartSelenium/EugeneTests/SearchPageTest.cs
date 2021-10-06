using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.IO;

namespace OpenCartSelenium.EugeneTests
{
    [TestFixture]
    class SearchPageTest
    {
        private IWebDriver driver;
        private readonly string OpenCartURL = "http://192.168.1.13/opencart/upload/";
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        [Test]
        public void SearchEmptyResultPageTest()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            HomePage homePage = new HomePage(driver);
            //Arrange
            string expectedResult = "Your shopping cart is empty!";
            //Act
            homePage.ClickSearchProductField();
            homePage.SetSearchProductField("");
            homePage.SetSearchProductField(Keys.Enter);
            SearchEmptyResultPage emptyResultPage = new SearchEmptyResultPage(driver);
            //Assert
            Assert.AreEqual(expectedResult, emptyResultPage.EmptyResultPageLabel.Text);
        }
    }
}
