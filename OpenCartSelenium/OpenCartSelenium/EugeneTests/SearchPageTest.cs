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
        }
        [Test]
        public void SearchEmptyResultPageTest()
        {
            string expectedResult = "Your shopping cart is empty!";

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);

            HomePage homePage = new HomePage(driver);
            homePage.ClickSearchProductField();
            homePage.SetSearchProductField("");
            homePage.SetSearchProductField(Keys.Enter);

            SearchEmptyResultPage emptyResultPage = new SearchEmptyResultPage(driver);
            Assert.AreEqual(expectedResult, emptyResultPage.EmptyResultPageLabel.Text);    //check if search page is empty
        }
        [Test]
        public void SearchResultPageTest()
        {
            string expectedResult = "Search - Mac";

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);

            HomePage homePage = new HomePage(driver);
            homePage.ClickSearchProductField();
            homePage.SetSearchProductField("Mac");
            homePage.SetSearchProductField(Keys.Enter);

            SearchResultPage resultPage = new SearchResultPage(driver);
            Assert.AreEqual(expectedResult, resultPage.ResultPageHeader.Text);   //check if page header equals expected result
        }
        [Test]
        public void SearchResultPageListGridViewTests()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            HomePage homePage = new HomePage(driver);
            homePage.ClearSearchProductField();
            homePage.SetSearchProductField("Mac");
            homePage.SetSearchProductField(Keys.Enter);

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

            Assert.AreEqual(expectedCategory.SelectedOption.Text, "Desktops");         //check if selected option as same as expected
            Assert.AreEqual(expectedTitle, resultPage.FirstProductTitle.Text);        //check if title of first product in the list as same as expected
        }
        [Test]
        public void SubCategoryTest()
        {
            string expectedTitle = "Apple Cinema 30\"";

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            HomePage homePage = new HomePage(driver);
            homePage.ClearSearchProductField();
            homePage.SetSearchProductField("C");
            homePage.SetSearchProductField(Keys.Enter);

            SearchCriteriaComponent searchCriteria = new SearchCriteriaComponent(driver);
            searchCriteria.ClickCategory();
            searchCriteria.SelectCategory("Components");
            searchCriteria.ClickSubCategory();
            Assert.IsTrue(searchCriteria.SubCategory.Selected);        //assert a check box is checked
            searchCriteria.ClickSearchCriteriaButton();

            SearchResultPage resultPage = new SearchResultPage(driver);
            Assert.AreEqual(expectedTitle, resultPage.FirstProductTitle.Text);   //check if title of first product in the list as same as expected
        }
        [Test]
        public void SearchProductDescriptionTest()
        {
            string expectedTitle = "Samsung SyncMaster 941BW";

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            HomePage homePage = new HomePage(driver);
            homePage.ClearSearchProductField();
            homePage.SetSearchProductField("Imagine the advantages");
            homePage.SetSearchProductField(Keys.Enter);

            SearchCriteriaComponent searchCriteria = new SearchCriteriaComponent(driver);
            searchCriteria.ClickDescription();
            Assert.IsTrue(searchCriteria.Description.Selected);        //assert a check box is checked
            searchCriteria.ClickSearchCriteriaButton();

            SearchResultPage resultPage = new SearchResultPage(driver);
            Assert.AreEqual(expectedTitle, resultPage.FirstProductTitle.Text);   //check if title of first product in the list as same as expected
        }
        [Test]
        public void SortByTest()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            HomePage homePage = new HomePage(driver);
            homePage.ClearSearchProductField();
            homePage.SetSearchProductField("M");
            homePage.SetSearchProductField(Keys.Enter)
                ;
            SearchResultPage resultPage = new SearchResultPage(driver);
            resultPage.ClickSortBy();
            resultPage.SelectSortByType("Model (Z - A)");

            SearchResultPage newResultPage = new SearchResultPage(driver);
            SelectElement expectedResult = new SelectElement(newResultPage.SortBy);
            Assert.AreEqual("Model (Z - A)", expectedResult.SelectedOption.Text);
        }
        [Test]
        public void ShowTest()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            HomePage homePage = new HomePage(driver);
            homePage.ClearSearchProductField();
            homePage.SetSearchProductField("A");
            homePage.SetSearchProductField(Keys.Enter);

            SearchResultPage resultPage = new SearchResultPage(driver);
            resultPage.SelectShowType("100");

            SearchResultPage newResultPage = new SearchResultPage(driver);
            SelectElement expectedResult = new SelectElement(newResultPage.Show);
            Assert.AreEqual("100", expectedResult.SelectedOption.Text);
        }
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}
