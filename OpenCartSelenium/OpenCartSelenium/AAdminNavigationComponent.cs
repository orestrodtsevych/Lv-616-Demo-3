using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using static OpenCartSelenium.AHeadComponent;

namespace OpenCartSelenium
{
    public abstract class AAdminNavigationComponent
    {
        
        protected IWebDriver driver;
        private readonly string OPTION_NOT_FOUND_MESSAGE = "Cannot foud the option";
        
        private DropdownOptions dropdownOptions;
        public IWebElement AdminDashBoard { get; private set; }
        public IWebElement AdminCatalog { get; private set; }
        public IWebElement AdminExtensions { get; private set; }
        public IWebElement AdminSales { get; private set; }
        public IWebElement AdminCustomers { get; private set; }
        public IWebElement AdminMarketing{ get; private set; }
        public IWebElement AdminSystem { get; private set; }
        public IWebElement AdminReports { get; private set; }
        public AAdminNavigationComponent(IWebDriver driver) 
        {
            this.driver = driver;
            AdminDashBoard = driver.FindElement(By.CssSelector("li#menu-dashboard"));
            AdminCatalog = driver.FindElement(By.CssSelector("li#menu-catalog"));
            AdminExtensions = driver.FindElement(By.CssSelector("li#menu-extension"));
            AdminSales = driver.FindElement(By.CssSelector("li#menu-sale"));
            AdminCustomers = driver.FindElement(By.CssSelector("li#menu-customer"));
            AdminMarketing = driver.FindElement(By.CssSelector("li#menu-marketing"));
            AdminSystem = driver.FindElement(By.CssSelector("li#menu-system"));
            AdminReports = driver.FindElement(By.CssSelector("li#menu-report"));
        }
        public void ClickOnAdminDashBoard() => AdminDashBoard.Click();
        public void ClickAdminCatalog() => AdminCatalog.Click();

        public void ClickAdminExtensions() => AdminExtensions.Click();
        public void ClickAdminSales() => AdminSales.Click();
        public void ClickAdminCustomers() => AdminCustomers.Click();
        public void ClickAdminMarketing() => AdminMarketing.Click();
        public void ClickAdminSystem() => AdminSystem.Click();
        public void ClickAdminReports() => AdminReports.Click();

        private void CreateDropdownOptions(By searchLocator)
        {
            dropdownOptions = new DropdownOptions(searchLocator, driver);
        }
        private void ClickDropdownOptionByPartialName(string optionName)
        {
            if (!FindDropdownOptionByPartialName(optionName))
            {
                throw new FormatException(OPTION_NOT_FOUND_MESSAGE);
            }
            dropdownOptions.ClickDropdownOptionByPartialName(optionName);
            dropdownOptions = null;
        }

        private bool FindDropdownOptionByPartialName(string optionName)
        {
            bool isFound = false;
            if (dropdownOptions == null)
            {
                throw new FormatException("DropdownOptions is Null");
            }
            foreach (var item in dropdownOptions.GetListOptionsText())
            {
                if (item.ToLower().Contains(optionName.ToLower()))
                {
                    isFound = true;
                }
            }
            return isFound;
        }


        public AdminCategoriesPage ClickAdminCatalogCategoryOptionByPartialName(string optionName)
        {
            ClickAdminCatalog();
            CreateDropdownOptions(By.CssSelector("li#menu-catalog li"));
            ClickDropdownOptionByPartialName(optionName);
            return new AdminCategoriesPage(driver);
        }
       



    }
}
