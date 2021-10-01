using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    public abstract class AStatusBarComponent : AHeadComponent
    {
        private readonly string STATUS_BAR_ERROR = "STATUS_BAR_ERROR";
        public IList<IWebElement> breadcrumps { get; private set; }
        public AStatusBarComponent(IWebDriver driver) : base(driver) 
        {
            breadcrumps = driver.FindElements(By.CssSelector(".beradrump li"));
        }
        public int getCountBreadcrumps() => breadcrumps.Count;
        public IWebElement getBreadcrumb(int breadcrumbIndex)
        {
            if (breadcrumbIndex >= getCountBreadcrumps())
            {
                throw new Exception(STATUS_BAR_ERROR);
            }
            return breadcrumps[breadcrumbIndex];
        }
        public IWebElement getLastBreadcrumb() => breadcrumps[getCountBreadcrumps() - 1];
        public string getBreadcrumbText(int breadcrumbIndex)
        {
            return getBreadcrumb(breadcrumbIndex).Text;
        }
        public string getLastBreadcrumbText() => getLastBreadcrumb().Text;

    }
}
