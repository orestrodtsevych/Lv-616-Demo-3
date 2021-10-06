using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace OpenCartSelenium.EugeneTests
{
    [TestFixture]
    class SearchPageTest
    {
        private IWebDriver driver;
        private readonly string OpenCartURL = "http://192.168.1.13/opencart/upload/";
        private readonly string TAG_ATTRIBUTE_CLASS = "class";
        private readonly string OPTION_ACTIVE = "active";
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        [Test]
        public void SearchEmptyResultPageTest()
        {
            //Arrange
            string expectedResult = "Your shopping cart is empty!";
            //Act
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);

            HomePage homePage = new HomePage(driver);
            homePage.ClickSearchProductField();
            homePage.SetSearchProductField("");
            homePage.SetSearchProductField(Keys.Enter);
            SearchEmptyResultPage emptyResultPage = new SearchEmptyResultPage(driver);
            //Assert
            Assert.AreEqual(expectedResult, emptyResultPage.EmptyResultPageLabel.Text);
        }
        [Test]
        public void SearchResultPageTest()
        {
            //Arrange
            string expectedResult = "Search - Mac";
            //Act
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);

            HomePage homePage = new HomePage(driver);
            homePage.ClickSearchProductField();
            homePage.SetSearchProductField("Mac");
            homePage.SetSearchProductField(Keys.Enter);
            SearchResultPage resultPage = new SearchResultPage(driver);
            //Assert
            Assert.AreEqual(expectedResult, resultPage.ResultPageHeader.Text);
        }
        [Test]
        public void SearchResultPageListGridViewTests()
        {    
            //Act
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            HomePage homePage = new HomePage(driver);
            homePage.ClearSearchProductField();
            homePage.SetSearchProductField("Mac");
            homePage.SetSearchProductField(Keys.Enter);
            SearchResultPage resultPage = new SearchResultPage(driver);
            resultPage.ClickButtonListView();
            //Assert
            Assert.IsTrue(resultPage.ButtonListView.GetAttribute(TAG_ATTRIBUTE_CLASS).Contains(OPTION_ACTIVE));
            //Act
            resultPage.ClickButtonGridView();
            //Assert
            Assert.IsTrue(resultPage.ButtonGridView.GetAttribute(TAG_ATTRIBUTE_CLASS).Contains(OPTION_ACTIVE));
        }
        [Test]
        public void CategoriesTest()
        {
            //Arrange
            string expectedTitle = "MacBook";

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            HomePage homePage = new HomePage(driver);
            homePage.ClearSearchProductField();
            homePage.SetSearchProductField("Mac");
            homePage.SetSearchProductField(Keys.Enter);

            SearchCriteriaComponent searchCriteria = new SearchCriteriaComponent(driver);
            searchCriteria.ClickCategory();
            searchCriteria.SelectCategory("Desktops");
            searchCriteria.ClickSearchCriteriaButton();

            SearchResultPage resultPage = new SearchResultPage(driver);
            SelectElement expectedCategory = new SelectElement(resultPage.Categories);
            expectedCategory.SelectByValue("20");

            Assert.AreEqual(expectedCategory.SelectedOption.Text, "Desktops");
            Assert.AreEqual(expectedTitle, resultPage.FirstProductTitle.Text);
        }
    }
}
