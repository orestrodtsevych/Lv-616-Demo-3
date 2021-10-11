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
        [Test, Order(1)]
        public void SearchEmptyResultPageTest()
        {
            string expectedResult = "Your shopping cart is empty!";

            HomePage homePage = new HomePage(driver);
            SearchEmptyResultPage emptyResultPage = (SearchEmptyResultPage)homePage.FindProduct(""); 
            string actualResult = emptyResultPage.EmptyResultPageLabel.Text;
            Assert.AreEqual(expectedResult, actualResult);    //check if search page is empty
        }
        [Test, Order(2)]
        public void SearchResultPageTest()
        {
            string expectedResult = "Search - Mac";

            HomePage homePage = new HomePage(driver);
            SearchResultPage resultPage = (SearchResultPage)homePage.FindProduct("Mac");

            string actualResult = resultPage.ResultPageHeader.Text;
            Assert.AreEqual(expectedResult, actualResult);   //check if page header equals expected result
        }
        [Test, Order(3)]
        public void SearchResultPageListGridViewTests()
        {
            HomePage homePage = new HomePage(driver);

            SearchResultPage resultPage = (SearchResultPage)homePage.FindProduct("Mac");
            resultPage.ClickButtonListView();
            Assert.IsTrue(resultPage.ButtonListView.GetAttribute(TAG_ATTRIBUTE_CLASS).Contains(OPTION_ACTIVE));   //check if list view active

            resultPage.ClickButtonGridView();
            Assert.IsTrue(resultPage.ButtonGridView.GetAttribute(TAG_ATTRIBUTE_CLASS).Contains(OPTION_ACTIVE));  //check if grid view active
        }
        [Test, Order(4)]
        public void CategoriesTest()
        {
            string expectedTitle = "MacBook";
            string expectedCategory = "Desktops";

            HomePage homePage = new HomePage(driver);

            SearchResultPage searchResult = (SearchResultPage)homePage.FindProduct("Mac");
            searchResult.SelectCategory("Desktops");

            SearchResultPage resultPage = searchResult.ClickSearchCriteriaButton();
            SelectElement actualCategory = new SelectElement(resultPage.Categories);
            string actualTitle = resultPage.FirstProductTitle.Text;

            Assert.AreEqual(actualCategory.SelectedOption.Text, expectedCategory);         //check if selected option as same as expected
            Assert.AreEqual(expectedTitle, actualTitle);        //check if title of first product in the list as same as expected
        }
        [Test, Order(5)]
        public void SubCategoryTest()
        {
            string expectedTitle = "Apple Cinema 30\"";

            HomePage homePage = new HomePage(driver);

            SearchResultPage searchResult = (SearchResultPage)homePage.FindProduct("C");
            searchResult.SelectCategory("Components");
            searchResult.ClickSubCategory();
            Assert.IsTrue(searchResult.SubCategory.Selected);        //assert a check box is checked
            
            SearchResultPage resultPage = searchResult.ClickSearchCriteriaButton();
            string actualTitle = resultPage.FirstProductTitle.Text;

            Assert.AreEqual(expectedTitle, actualTitle);   //check if title of first product in the list as same as expected
        }
        [Test, Order(6)]
        public void SearchProductDescriptionTest()
        {
            string expectedTitle = "Apple Cinema 30\"";

            HomePage homePage = new HomePage(driver);

            SearchResultPage searchResult = (SearchResultPage)homePage.FindProduct("1");

            searchResult.ClickDescription();
            Assert.IsTrue(searchResult.Description.Selected);        //assert a check box is checked
           
            SearchResultPage newResultPage = searchResult.ClickSearchCriteriaButton();
            string actualTitle = newResultPage.FirstProductTitle.Text;
            Assert.AreEqual(expectedTitle, actualTitle);   //check if title of first product in the list as same as expected
        }
        [Test, Order(7)]
        public void SortByTest()
        {
            string expectedResult = "Model (Z - A)";
            HomePage homePage = new HomePage(driver);
            
            SearchResultPage resultPage = (SearchResultPage)homePage.FindProduct("M");
            resultPage.ClickSortBy();

            SearchResultPage newResultPage = resultPage.SelectSortByType("Model (Z - A)");
            SelectElement actualResult = new SelectElement(newResultPage.SortBy);
            Assert.AreEqual(expectedResult, actualResult.SelectedOption.Text);
        }
        [Test, Order(8)]
        public void ShowTest()
        {
            string expectedResult = "100";
            HomePage homePage = new HomePage(driver);
            
            SearchResultPage resultPage = (SearchResultPage)homePage.FindProduct("A");
            
            SearchResultPage newResultPage = resultPage.SelectShowType("100");
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
