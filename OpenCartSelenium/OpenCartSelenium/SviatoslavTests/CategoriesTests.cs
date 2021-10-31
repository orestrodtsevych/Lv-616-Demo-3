using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace OpenCartSelenium.SviatoslavTests
{
    [TestFixture]
    class CategoriesTests
    {
        private readonly string URL = "http://34.135.92.238/opencart/upload/";
        private readonly string AdminURL = "http://34.135.92.238/opencart/upload/admin";
        private IWebDriver driver;

        [OneTimeSetUp]
        public void StartChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
        }
        
        public void CategoryPreTest(string CategoryExpected)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            Thread.Sleep(1000);
            HomePage homePage = new HomePage(driver);
            Thread.Sleep(1000);
            ProductPage productPage =homePage.ClickShowAllFromCategoryByPartialCategoryName(CategoryExpected);

            string actualInLeftMenu = productPage.GetCurrentItemFromLeftMenuText();
            string actualInContent = productPage.GetCategoryNameFromContent();
            StringAssert.Contains(CategoryExpected, actualInLeftMenu);
            Console.WriteLine("Expected: "+CategoryExpected+" Actual in Left: "+ actualInLeftMenu+ " Actual in Content: " + actualInContent);
            Assert.AreEqual(CategoryExpected, actualInContent);
        }
        [Test]
        public void DesktopCategoryTest()
        {
            string CategoryExpected = "Desktops";
            CategoryPreTest(CategoryExpected);
        }
        [Test]
        public void ComponentsCategoryTest()
        {
            string CategoryExpected = "Components";
            CategoryPreTest(CategoryExpected);
        }
        [Test]
        public void TabletsCategoryTest()
        {
            string CategoryExpected = "Tablets";
            CategoryPreTest(CategoryExpected);
        }

        [Test]
        public void CamerasCategoryTest()
        {
            string CategoryExpected = "Cameras";
            CategoryPreTest(CategoryExpected);
        }
        [Test]
        public void SoftwareCategoryTest()
        {
            string CategoryExpected = "Software";
            CategoryPreTest(CategoryExpected);
        }
        [Test]
        public void AddNewCategoryTest()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(AdminURL);
            Thread.Sleep(1000);//Only for presentation
            LogInAsAdminPage logInAsAdminPage = new LogInAsAdminPage(driver);
            string UserName = "admin";
            string Password = "AdminU-P784_2-77_LV";
            logInAsAdminPage.LogInAsAdminWithCredites(UserName, Password);
            AdminDashboardPage adminDashboardPage = logInAsAdminPage.ClickOnLogInButton();

            Thread.Sleep(1000);//Only for presentation
            string OptionName = "Categories";
            AdminCategoriesPage adminCategoriesPage = adminDashboardPage.ClickAdminCatalogCategoryOptionByPartialName(OptionName);
            Thread.Sleep(1000);//Only for presentation

            AddCategoryGeneral addCategoryGeneral= adminCategoriesPage.ClickAddNewCategoryButton();
            string NewCategoryName = "Test Category";
            AddCategoryData addCategory = addCategoryGeneral.InputDataCategoryGeneral(NewCategoryName);
            AdminCategoriesPage adminCategoriesPage2 = addCategory.InputDataInAddCategoryDataWhithoutParent();

            AddCategoryGeneral addCategoryGeneral2 = adminCategoriesPage2.ClickAddNewCategoryButton();
            string NewCategoryName2 = "Cleaner";
            AddCategoryData addCategory2 = addCategoryGeneral2.InputDataCategoryGeneral(NewCategoryName2);
            string Parent2 = NewCategoryName;
            AdminCategoriesPage adminCategoriesPage3 = addCategory2.InputDataInAddCategoryData(Parent2);
            Thread.Sleep(1000);//Only for presentation
            CategoryPreTest(NewCategoryName);
        }
 
    
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}
