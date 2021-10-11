using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using static OpenCartSelenium.AHeadComponent;

namespace OpenCartSelenium
{
    public class AdminCategoriesPage:AAdminNavigationComponent
    {
        private DropdownOptions dropdownOptions;
        private readonly string OPTION_NOT_FOUND_MESSAGE = "Cannot foud the option";

        public IWebElement AddNewCategoryButton { get; private set; }
        public IWebElement MyAdminAccountButton { get; private set; }

        public AdminCategoriesPage(IWebDriver driver) : base(driver)
        {
            AddNewCategoryButton = driver.FindElement(By.CssSelector("a.btn.btn-primary"));
            MyAdminAccountButton = driver.FindElement(By.CssSelector("#header > div > ul > li.dropdown"));
        }
        public void ClickMyAdminAccountButton() => MyAdminAccountButton.Click();
        public AddCategoryGeneral ClickAddNewCategoryButton()
        {
            AddNewCategoryButton.Click();
            return new AddCategoryGeneral(driver);
        }
        public void ClickMyAdminAccountOptionByPartialName(string optionName)
        {
            ClickMyAdminAccountButton();
            CreateDropdownOptions(By.CssSelector("ul.dropdown-menu.dropdown-menu-right li"));
            ClickDropdownOptionByPartialName(optionName);
        }
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
    }
}
