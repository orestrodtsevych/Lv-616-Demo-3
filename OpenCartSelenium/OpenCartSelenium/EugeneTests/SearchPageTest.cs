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
        private readonly string OpenCartURL = "http://192.168.1.13/opencart/upload/";   //url to navigate to opencart
        private readonly string TAG_ATTRIBUTE_CLASS = "class";
        private readonly string OPTION_ACTIVE = "active";
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
        }
        [Test]
        public void SearchEmptyResultPageTest()
        {
            string expectedResult = "Your shopping cart is empty!";

            HomePage homePage = new HomePage(driver);
            homePage.FindProduct("");

            SearchEmptyResultPage emptyResultPage = new SearchEmptyResultPage(driver);
            string actualResult = emptyResultPage.EmptyResultPageLabel.Text;
            Assert.AreEqual(expectedResult, actualResult);    //check if search page is empty
        }
        [Test]
        public void SearchResultPageTest()
        {
            string expectedResult = "Search - Mac";

            HomePage homePage = new HomePage(driver);
            homePage.FindProduct("Mac");

            SearchResultPage resultPage = new SearchResultPage(driver);
            string actualResult = resultPage.ResultPageHeader.Text;
            Assert.AreEqual(expectedResult, actualResult);   //check if page header equals expected result
        }
        [Test]
        public void SearchResultPageListGridViewTests()
        {
            HomePage homePage = new HomePage(driver);
            homePage.FindProduct("Mac");

            SearchResultPage resultPage = new SearchResultPage(driver);
            resultPage.ClickButtonListView();
            Assert.IsTrue(resultPage.ButtonListView.GetAttribute(TAG_ATTRIBUTE_CLASS).Contains(OPTION_ACTIVE));   //check if list view active

            resultPage.ClickButtonGridView();
            Assert.IsTrue(resultPage.ButtonGridView.GetAttribute(TAG_ATTRIBUTE_CLASS).Contains(OPTION_ACTIVE));  //check if grid view active
        }
        [Test]
        public void CategoriesTest()
        {
            string expectedTitle = "MacBook";
            string expectedCategory = "Desktops";

            HomePage homePage = new HomePage(driver);
            homePage.FindProduct("Mac");

            SearchCriteriaComponent searchCriteria = new SearchCriteriaComponent(driver);
            searchCriteria.SelectCategory("Desktops");
            searchCriteria.ClickSearchCriteriaButton();

            SearchResultPage resultPage = new SearchResultPage(driver);
            SelectElement actualCategory = new SelectElement(resultPage.Categories);
            string actualTitle = resultPage.FirstProductTitle.Text;

            Assert.AreEqual(actualCategory.SelectedOption.Text, expectedCategory);         //check if selected option as same as expected
            Assert.AreEqual(expectedTitle, actualTitle);        //check if title of first product in the list as same as expected
        }
        [Test]
        public void SubCategoryTest()
        {
            string expectedTitle = "Apple Cinema 30\"";

            HomePage homePage = new HomePage(driver);
            homePage.FindProduct("C");

            SearchCriteriaComponent searchCriteria = new SearchCriteriaComponent(driver);
            searchCriteria.SelectCategory("Components");
            searchCriteria.ClickSubCategory();
            Assert.IsTrue(searchCriteria.SubCategory.Selected);        //assert a check box is checked
            searchCriteria.ClickSearchCriteriaButton();

            SearchResultPage resultPage = new SearchResultPage(driver);
            string actualTitle = resultPage.FirstProductTitle.Text;

            Assert.AreEqual(expectedTitle, actualTitle);   //check if title of first product in the list as same as expected
        }
        [Test]
        public void SearchProductDescriptionTest()
        {
            string expectedTitle = "Samsung SyncMaster 941BW";

            HomePage homePage = new HomePage(driver);
            homePage.FindProduct("Imagine the advantages");

            SearchCriteriaComponent searchCriteria = new SearchCriteriaComponent(driver);
            searchCriteria.ClickDescription();
            Assert.IsTrue(searchCriteria.Description.Selected);        //assert a check box is checked
            searchCriteria.ClickSearchCriteriaButton();

            SearchResultPage resultPage = new SearchResultPage(driver);
            string actualTitle = resultPage.FirstProductTitle.Text;
            Assert.AreEqual(expectedTitle, actualTitle);   //check if title of first product in the list as same as expected
        }
        [Test]
        public void SortByTest()
        {
            string expectedResult = "Model (Z - A)";
            HomePage homePage = new HomePage(driver);
            homePage.FindProduct("M");

            SearchResultPage resultPage = new SearchResultPage(driver);
            resultPage.ClickSortBy();
            resultPage.SelectSortByType("Model (Z - A)");

            SearchResultPage newResultPage = new SearchResultPage(driver);
            SelectElement actualResult = new SelectElement(newResultPage.SortBy);
            Assert.AreEqual(expectedResult, actualResult.SelectedOption.Text);
        }
        [Test]
        public void ShowTest()
        {
            string expectedResult = "100";
            HomePage homePage = new HomePage(driver);
            homePage.FindProduct("A");

            SearchResultPage resultPage = new SearchResultPage(driver);
            resultPage.SelectShowType("100");

            SearchResultPage newResultPage = new SearchResultPage(driver);
            SelectElement actualResult = new SelectElement(newResultPage.Show);
            Assert.AreEqual(expectedResult, actualResult.SelectedOption.Text); 
        }
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}
