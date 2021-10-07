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
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        [SetUp]
        public void SetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(OpenCartURL);
        }

        [Test]
        public void RegisterNewUser()
        {
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = User.CreateBuilder().SetFirstName("roman").SetLastName("romaniv").SetEMail("rom123334an@gmal.com")
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
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = User.CreateBuilder().SetFirstName("roman").SetLastName("romaniv").SetEMail("roman@gmal.com")
                .SetTelephone("380676767235").SetPassword("passwrd").Build();

            registerPage.FillRegisterForm(newUser);
            registerPage.ClickContinueButton();

            RegisterMessagePage messagePage = new RegisterMessagePage(driver);
            string expected = messagePage.EXPECTED_WARNING_AGREE;
            string actual = messagePage.GetAlertMessageText();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RegisterValidMessage()
        {
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = new UserBuilder().SetFirstName(string.Empty).SetLastName(string.Empty).SetEMail(string.Empty)
                .SetTelephone(string.Empty).SetPassword(string.Empty).Build();

            registerPage.FillRegisterForm(newUser);
            registerPage.ClickAgreeCheckBox();
            registerPage.ClickContinueButton();

            RegisterTextDanger registerTextDanger = new RegisterTextDanger(driver);
            string expectedFirstNameTextDanger = registerTextDanger.EXPECTED_VALID_FIRSTNAME_MESSAGE;
            string actualFirstNameTextDanger = registerTextDanger.GetFirstNameTextDanger();

            string expectedLastNameTextDanger = registerTextDanger.EXPECTED_VALID_LASTNAME_MESSAGE;
            string actualLastNameTextDanger = registerTextDanger.GetLastNameTextDanger();

            string expectedEMailTextDanger = registerTextDanger.EXPECTED_VALID_EMAIL_MESSAGE;
            string actualEMailTextDanger = registerTextDanger.GetEMailTextDanger();

            string expectedTelephoneTextDanger = registerTextDanger.EXPECTED_VALID_TELEPHONE_MESSAGE;
            string actualTelephoneTextDanger = registerTextDanger.GetTelephoneTextDanger();

            string expectedPasswordTextDanger = registerTextDanger.EXPECTED_VALID_PASSWORD_MESSAGE;
            string actualPasswordTextDanger = registerTextDanger.GetPasswordTextDanger();

            Assert.AreEqual(expectedFirstNameTextDanger, actualFirstNameTextDanger);
            Assert.AreEqual(expectedLastNameTextDanger, actualLastNameTextDanger);
            Assert.AreEqual(expectedEMailTextDanger, actualEMailTextDanger);
            Assert.AreEqual(expectedTelephoneTextDanger, actualTelephoneTextDanger);
            Assert.AreEqual(expectedPasswordTextDanger, actualPasswordTextDanger);
        }
        [Test]
        public void ConfirmPasswordTest()
        {
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = User.CreateBuilder().SetFirstName("roman").SetLastName("romaniv").SetEMail("roman34@gmal.com")
                .SetTelephone("380676767235").SetPassword("passwrd").Build();

            registerPage.FillRegisterForm(newUser);
            registerPage.SetConfirmPasswordField("notconfirm");
            registerPage.ClickAgreeCheckBox();
            registerPage.ClickContinueButton();

            RegisterTextDanger registerTextDanger = new RegisterTextDanger(driver);
            string expectedConfirmTextDanger = registerTextDanger.EXPECTED_VALID_CONFIRMPASSWORD_MESSAGE;
            string actualConfirmTextDanger = registerTextDanger.GetConfirmPasswordTextDanger();
            Assert.AreEqual(expectedConfirmTextDanger, actualConfirmTextDanger);

        }
    }
}
