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
        private readonly string OpenCartURL = "http://192.168.1.104/opencart/upload/index.php?route=account/register";
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
        public void RegisterxNewUser()
        {
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = User.CreateBuilder().SetFirstName("roman").SetLastName("romaniv").SetEMail("romannn@gmal.com")
                .SetTelephone("380676767235").SetPassword("passwrd").Build();
            
            registerPage.FillRegisterForm(newUser);
            registerPage.ClickAgreeCheckBox();

            AccountSuccessPage successPage = registerPage.ClickContinueButtonSuccess();
            string expected = "Congratulations! Your new account has been successfully created!";
            string actual = successPage.GetMessageText();
            successPage.ClickEditAccountInformation();
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

            RegisterMessagePage messagePage = registerPage.ClickContinueButtonMessagePage();
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

            RegisterMessagePage messagePage = registerPage.ClickContinueButtonMessagePage();
            string expected = messagePage.EXPECTED_WARNING_AGREE;
            string actual = messagePage.GetAlertMessageText();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RegisterValidFirstNameMessage()
        {
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = new UserBuilder().SetFirstName(string.Empty).SetLastName("pasternak").SetEMail("pasternak@gmail.com")
                .SetTelephone("380981234562").SetPassword("password").Build();

            registerPage.FillRegisterForm(newUser);
            registerPage.ClickAgreeCheckBox();

            RegisterTextDanger registerTextDanger = registerPage.ClickContinueButtonTextDanger(); 
            string expectedFirstNameTextDanger = registerTextDanger.EXPECTED_VALID_FIRSTNAME_MESSAGE;
            string actualFirstNameTextDanger = registerTextDanger.GetFirstNameTextDanger();
            Assert.AreEqual(expectedFirstNameTextDanger, actualFirstNameTextDanger);
        }
        [Test]
        public void RegisterValidLastNameMessage()
        {
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = new UserBuilder().SetFirstName("oleksii").SetLastName(string.Empty).SetEMail("pasternak@gmail.com")
                .SetTelephone("380981234562").SetPassword("password").Build();

            registerPage.FillRegisterForm(newUser);
            registerPage.ClickAgreeCheckBox();

            RegisterTextDanger registerTextDanger = registerPage.ClickContinueButtonTextDanger();
            string expectedLastNameTextDanger = registerTextDanger.EXPECTED_VALID_LASTNAME_MESSAGE;
            string actualLastNameTextDanger = registerTextDanger.GetLastNameTextDanger();
            Assert.AreEqual(expectedLastNameTextDanger, actualLastNameTextDanger);
        }
        [Test]
        public void RegisterValidEMailMessage()
        {
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = new UserBuilder().SetFirstName("oleksii").SetLastName("pasternak").SetEMail(string.Empty)
                .SetTelephone("380981234562").SetPassword("password").Build();

            registerPage.FillRegisterForm(newUser);
            registerPage.ClickAgreeCheckBox();

            RegisterTextDanger registerTextDanger = registerPage.ClickContinueButtonTextDanger();
            string expectedEMailTextDanger = registerTextDanger.EXPECTED_VALID_EMAIL_MESSAGE;
            string actualEMailTextDanger = registerTextDanger.GetEMailTextDanger();
            Assert.AreEqual(expectedEMailTextDanger, actualEMailTextDanger);
        }
        [Test]
        public void RegisterValidTelephoneMessage()
        {
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = new UserBuilder().SetFirstName("oleksii").SetLastName("pasternak").SetEMail("pasternak@gmail.com")
                .SetTelephone(string.Empty).SetPassword("password").Build();

            registerPage.FillRegisterForm(newUser);
            registerPage.ClickAgreeCheckBox();

            RegisterTextDanger registerTextDanger = registerPage.ClickContinueButtonTextDanger();
            string expectedTelephoneTextDanger = registerTextDanger.EXPECTED_VALID_TELEPHONE_MESSAGE;
            string actualTelephoneTextDanger = registerTextDanger.GetTelephoneTextDanger();
            Assert.AreEqual(expectedTelephoneTextDanger, actualTelephoneTextDanger);
        }
        [Test]
        public void RegisterValidPasswordMessage()
        {
            RegisterPage registerPage = new RegisterPage(driver);
            User newUser = new UserBuilder().SetFirstName("oleksii").SetLastName("pasternak").SetEMail("pasternak@gmail.com")
                .SetTelephone("380981234562").SetPassword(string.Empty).Build();

            registerPage.FillRegisterForm(newUser);
            registerPage.ClickAgreeCheckBox();

            RegisterTextDanger registerTextDanger = registerPage.ClickContinueButtonTextDanger();
            string expectedPasswordTextDanger = registerTextDanger.EXPECTED_VALID_PASSWORD_MESSAGE;
            string actualPasswordTextDanger = registerTextDanger.GetPasswordTextDanger();
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

            RegisterTextDanger registerTextDanger = registerPage.ClickContinueButtonTextDanger();
            string expectedConfirmTextDanger = registerTextDanger.EXPECTED_VALID_CONFIRMPASSWORD_MESSAGE;
            string actualConfirmTextDanger = registerTextDanger.GetConfirmPasswordTextDanger();
            Assert.AreEqual(expectedConfirmTextDanger, actualConfirmTextDanger);
        }
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}
