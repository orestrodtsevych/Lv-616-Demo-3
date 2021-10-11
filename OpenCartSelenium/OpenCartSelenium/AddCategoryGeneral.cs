using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace OpenCartSelenium
{
    public class AddCategoryGeneral: AAdminNavigationComponent
    {
        public IWebElement CategoryName { get; private set; }
        public IWebElement MetaTagTitle { get; private set; }
        public IWebElement AddCategoryDataButton { get; private set; }
        public AddCategoryGeneral(IWebDriver driver) : base(driver)
        {
            CategoryName = driver.FindElement(By.Id("input-name1"));
            MetaTagTitle = driver.FindElement(By.Id("input-meta-title1"));
            AddCategoryDataButton = driver.FindElement(By.XPath("//a[text()='Data']"));
        }
        public void ClickCategoryName() => CategoryName.Click();
        public void ClickMetaTagTitle() => MetaTagTitle.Click();
        public void SendKeysCategoryName(string Keys) => CategoryName.SendKeys(Keys);
        public void SendKeysMetaTagTitle(string Keys) => MetaTagTitle.SendKeys(Keys);
        public void ClickAddCategoryDataButton() => AddCategoryDataButton.Click();
        public AddCategoryData InputDataCategoryGeneral(string Keys)
        {
            ClickCategoryName();
            SendKeysCategoryName(Keys);
            ClickMetaTagTitle();
            SendKeysMetaTagTitle(Keys);
            ClickAddCategoryDataButton();
            return new AddCategoryData(driver);
        }
    }
}
