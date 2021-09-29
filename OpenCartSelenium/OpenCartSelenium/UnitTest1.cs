using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
namespace OpenCartSelenium
{
    public class Tests
    {
        public static ChromeOptions options = new ChromeOptions();
        public IWebDriver driver = new ChromeDriver();
        
        [Test]
        public void Test1()
        {       
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
        }
        public void Test2()
        {
            Assert.Pass();
        }
    }
}