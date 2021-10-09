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
    //[Parallelizable(ParallelScope.Self)]
    class CategoriesTests
    {
        private readonly string URL = "http://192.168.1.105/opencart/upload/";
        private readonly string AdminURL = "http://192.168.1.105/opencart/upload/admin";
        private IWebDriver driver;

        [OneTimeSetUp]
        public void StartChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        //[TestCaseSource(nameof(HomePage.MenuTop))]
        [Test]
        public void DesktopsCategoryTest()
        {
            
            string CategoryExpected = "Desktops";
            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            Thread.Sleep(2000);
            HomePage homePage = new HomePage(driver);
            
            Thread.Sleep(2000);

            ProductPage productPage =homePage.ClickShowAllFromCategoryByPartialCategoryName(CategoryExpected);

            string actualInLeftMenu = productPage.GetCurrentItemFromLeftMenuText();
            string actualInContent = productPage.GetCategoryNameFromContent();
            StringAssert.Contains(CategoryExpected, actualInLeftMenu);
            Console.WriteLine(CategoryExpected+":-"+ actualInLeftMenu+"||"+ actualInContent);
            Assert.AreEqual(CategoryExpected, actualInContent);

        }
        [Test]
        public void AddNewCategoryTest()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(AdminURL);
            Thread.Sleep(2000);
            LogInAsAdminPage logInAsAdminPage = new LogInAsAdminPage(driver);
            string UserName = "admin";
            string Password = "AdminU-P784_2-77_LV";
            logInAsAdminPage.LogInAsAdminWithCredites(UserName, Password);
            AdminDashboardPage adminDashboardPage = logInAsAdminPage.ClickOnLogInButton();
            //logInAsAdminPage.
            Thread.Sleep(2000);
            string OptionName = "Categories";
            AdminCategoriesPage adminCategoriesPage = adminDashboardPage.ClickAdminCatalogCategoryOptionByPartialName(OptionName);

            Thread.Sleep(2000);
            AddCategoryGeneral addCategoryGeneral= adminCategoriesPage.ClickAddNewCategoryButton();
            string NewCategoryName = "TestCategory";
            
            AddCategoryData addCategory = addCategoryGeneral.InputDataCategoryGeneral(NewCategoryName);

            
            AdminCategoriesPage adminCategoriesPage2 = addCategory.InputDataInAddCategoryDataWhithoutParent();

            //
            AddCategoryGeneral addCategoryGeneral2 = adminCategoriesPage2.ClickAddNewCategoryButton();
            string NewCategoryName2 = "Cleaner";

            AddCategoryData addCategory2 = addCategoryGeneral2.InputDataCategoryGeneral(NewCategoryName2);

            string Parent2 = NewCategoryName;
            AdminCategoriesPage adminCategoriesPage3 = addCategory2.InputDataInAddCategoryData(Parent2);
        }
 
    
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            //driver.Quit();
        }
    }
}
