using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OpenCartSelenium.IhorTests
{
    [TestFixture]
    class RegisterTests
    {
        IWebDriver driver;
        private readonly string OpenCartURL = "http://192.168.1.103/opencart/upload/index.php?route=account/register";
        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();

        }
        [Test]
        public void RegisterNewUser()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = User.CreateBuilder().SetFirstName("roman").SetLastName("romaniv").SetEMail("rom12333an@gmal.com")
                .SetTelephone("380676767235").SetPassword("passwrd").Build();
            
            registerPage.FillRegisterForm(newUser);
            registerPage.ClickAgreeCheckBox();
            registerPage.ClickContinueButton();

            AccountSuccessPage successPage = new AccountSuccessPage(driver);
            string expected = "Congratulations! Your new account has been successfully created!";
            string actual = successPage.GetMessageText();

            Assert.IsTrue(actual.Contains(expected));
        }
        [Test]
        public void RegisterShowMessageAboutEMail()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = User.CreateBuilder().SetFirstName("roman").SetLastName("romaniv").SetEMail("roman@gmal.com")
                .SetTelephone("380676767235").SetPassword("passwrd").Build();

            registerPage.FillRegisterForm(newUser);
            registerPage.ClickAgreeCheckBox();
            registerPage.ClickContinueButton();

            RegisterMessagePage messagePage = new RegisterMessagePage(driver);
            string expected = messagePage.EXPECTED_WARNING_EMAIL;
            string actual = messagePage.GetAlertMessageText();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RegisterShowMessageAboutAgreePrivacyPolicy()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = User.CreateBuilder().SetFirstName("roman").SetLastName("romaniv").SetEMail("roman@gmal.com")
                .SetTelephone("380676767235").SetPassword("passwrd").Build();

            registerPage.FillRegisterForm(newUser);
            registerPage.ClickAgreeCheckBox();
            registerPage.ClickContinueButton();

            RegisterMessagePage messagePage = new RegisterMessagePage(driver);
            string expected = messagePage.EXPECTED_WARNING_AGREE;
            string actual = messagePage.GetAlertMessageText();
            Assert.AreEqual(expected, actual);
        }
    }
}
