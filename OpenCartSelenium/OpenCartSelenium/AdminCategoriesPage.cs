using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using static OpenCartSelenium.AHeadComponent;

namespace OpenCartSelenium
{
    public class AdminCategoriesPage:AAdminNavigationComponent
    {
       

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
        
    }
}
