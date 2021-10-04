using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    public abstract class ARightMenuComponent : AStatusBarComponent
    {
        public ARightMenuComponent(IWebDriver driver) : base(driver)
        { }
    }
}
