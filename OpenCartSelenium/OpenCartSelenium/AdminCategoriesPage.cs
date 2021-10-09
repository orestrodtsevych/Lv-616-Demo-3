using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace OpenCartSelenium
{
    public class AdminCategoriesPage:AAdminNavigationComponent
    {
        
        public IWebElement AddNewCategoryButton { get; private set; }
        public AdminCategoriesPage(IWebDriver driver) : base(driver)
        {
            AddNewCategoryButton = driver.FindElement(By.CssSelector("a.btn.btn-primary"));
        }
        public AddCategoryGeneral ClickAddNewCategoryButton()
        {
            AddNewCategoryButton.Click();
            return new AddCategoryGeneral(driver);
        }
    }
}
