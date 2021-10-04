using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    public abstract class AUnloggedRightMenuComponent : AStatusBarComponent
    {
        public AUnloggedRightMenuComponent(IWebDriver driver) : base(driver)
        { }
    }
}
