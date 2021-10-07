using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace OpenCartSelenium
{
    public  class ALeftMenuComponent : AStatusBarComponent
    {
        public IList<IWebElement> listOFLeftMenuItems { get; private set; }

        public ALeftMenuComponent(IWebDriver driver) : base(driver)
        {
            listOFLeftMenuItems = driver.FindElements(By.CssSelector("#column-left > div.list-group > a.list-group-item"));
        }
        public IWebElement GetCurrentItemFromLeftMenu()
        {
            return driver.FindElement(By.CssSelector("#column-left > div.list-group > a.list-group-item.active"));
        }
    }
}
