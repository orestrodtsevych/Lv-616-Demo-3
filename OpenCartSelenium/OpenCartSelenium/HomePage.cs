using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace OpenCartSelenium
{
    class HomePage : AHeadComponent
    {
        public HomePage(IWebDriver driver) : base(driver) { }







    }




    //public class Test
    //{
    //    [Test]
    //    public void Test1()  //hardcoded Test for testing methods
    //    {
    //        IWebDriver driver = new ChromeDriver();
    //        driver.Navigate().GoToUrl("http://192.168.1.16/opencart/upload/index.php?route=common/home");
    //        HomePage page = new HomePage(driver);
    //        double dvgsd = page.getCartSum();

    //    }
    //}

}
