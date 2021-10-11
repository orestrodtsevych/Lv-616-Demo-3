using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using static OpenCartSelenium.AHeadComponent;


namespace OpenCartSelenium
{
    public class AddCategoryData: AAdminNavigationComponent
    {
        
        private readonly string OPTION_NOT_FOUND_MESSAGE = "Cannot foud the option";  
        private DropdownOptions dropdownOptions;
 
        public void ClickParentCategoryOptionByPartialName(string optionName)
        {
            ClickAddCategoryDataParent();
            SendKeysDataParent(optionName);
            Thread.Sleep(1000);//Only for presentation
            CreateDropdownOptions(By.CssSelector("ul.dropdown-menu li"));
            ClickDropdownOptionByPartialName(optionName);
        }
        public IWebElement AddCategoryDataParent { get; private set; }
        public IWebElement TopCheckbox { get; private set; }
        public IWebElement SaveChanges { get; private set; }
        public AddCategoryData(IWebDriver driver) : base(driver)
        {
            AddCategoryDataParent = driver.FindElement(By.Id("input-parent"));
            TopCheckbox = driver.FindElement(By.CssSelector("#input-top"));
            SaveChanges = driver.FindElement(By.CssSelector("button.btn.btn-primary"));  
        }
        public void ClickAddCategoryDataParent() => AddCategoryDataParent.Click();
        public void SendKeysDataParent(string ParentName) => AddCategoryDataParent.SendKeys(ParentName);
        public void ClickTopCheckbox() => TopCheckbox.Click();
        public void ClickSaveChanges() => SaveChanges.Click();
        public AdminCategoriesPage InputDataInAddCategoryData(string ParentName)
        {
            ClickParentCategoryOptionByPartialName(ParentName);
            return InputDataInAddCategoryDataWhithoutParent();
        }
        public AdminCategoriesPage InputDataInAddCategoryDataWhithoutParent()
        {
            ClickTopCheckbox();
            ClickSaveChanges();
            return new AdminCategoriesPage(driver);
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
