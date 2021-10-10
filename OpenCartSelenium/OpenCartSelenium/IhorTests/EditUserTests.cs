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
    class EditUserTests
    {
        IWebDriver driver;
        private readonly string OpenCartURL = "http://192.168.1.104/opencart/upload/index.php?route=account/login";
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
            LoginPage loginPage = new LoginPage(driver);
            loginPage.SetEmailField("tolik@gmail.com");
            loginPage.SetPasswordField("tolik");
            loginPage.ClickLoginButton();
        }
        [Test]
        public void EditDataTest()
        {
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.ClickEditAccountInformation();
            EditAccountPage editAccountPage = new EditAccountPage(driver);
            editAccountPage.ClearAll();
            User user = User.CreateBuilder().SetFirstName("Anatolii").SetLastName("Lembryk")
                .SetEMail("tolik@gmail.com").SetTelephone("380976543430").Build();
            editAccountPage.FillForm(user);
            MyAccountMessagePage messagePage = editAccountPage.ClickContinueToMyAccountButton();
            string expectedMessage = messagePage.EXPECTED_SUCCESS_MESSAGE;
            string actualMessage = messagePage.GetAlertMessageText();
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [Test]
        public void ValidFirstNameDangerText()
        {
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.ClickEditAccountInformation();
            EditAccountPage editAccountPage = new EditAccountPage(driver);
            editAccountPage.ClearAll();
            User user = User.CreateBuilder().SetFirstName(string.Empty).SetLastName("Lembryk")
                .SetEMail("tolik@gmail.com").SetTelephone("380976543430").Build();
            editAccountPage.FillForm(user);
            EditAccountDangerText editAccountDanger = editAccountPage.ClickContinueButton();
            string expectedDangerText = editAccountDanger.EXPECTED_VALID_FIRSTNAME_MESSAGE;
            string actualDangerText = editAccountDanger.GetFirstNameTextDanger();
            Assert.AreEqual(expectedDangerText, actualDangerText);
        }
        [Test]
        public void ValidLastNameDangerText()
        {
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.ClickEditAccountInformation();
            EditAccountPage editAccountPage = new EditAccountPage(driver);
            editAccountPage.ClearAll();
            User user = User.CreateBuilder().SetFirstName("Anatolii").SetLastName(string.Empty)
                .SetEMail("tolik@gmail.com").SetTelephone("380976543430").Build();
            editAccountPage.FillForm(user);
            EditAccountDangerText editAccountDanger = editAccountPage.ClickContinueButton();
            string expectedDangerText = editAccountDanger.EXPECTED_VALID_LASTNAME_MESSAGE;
            string actualDangerText = editAccountDanger.GetLastNameTextDanger();
            Assert.AreEqual(expectedDangerText, actualDangerText);
        }
        [Test]
        public void ValidEmailDangerText()
        {
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.ClickEditAccountInformation();
            EditAccountPage editAccountPage = new EditAccountPage(driver);
            editAccountPage.ClearAll();
            User user = User.CreateBuilder().SetFirstName("Anatolii").SetLastName("Lembryk")
                .SetEMail(string.Empty).SetTelephone("380976543430").Build();
            editAccountPage.FillForm(user);
            EditAccountDangerText editAccountDanger = editAccountPage.ClickContinueButton();
            string expectedDangerText = editAccountDanger.EXPECTED_VALID_EMAIL_MESSAGE;
            string actualDangerText = editAccountDanger.GetEMailTextDanger();
            Assert.AreEqual(expectedDangerText, actualDangerText);
        }
        [Test]
        public void ValidTelephoneDangerText()
        {
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.ClickEditAccountInformation();
            EditAccountPage editAccountPage = new EditAccountPage(driver);
            editAccountPage.ClearAll();
            User user = User.CreateBuilder().SetFirstName("Anatolii").SetLastName("Lembryk")
                .SetEMail("tolik@gmail.com").SetTelephone(string.Empty).Build();
            editAccountPage.FillForm(user);
            EditAccountDangerText editAccountDanger = editAccountPage.ClickContinueButton();
            string expectedDangerText = editAccountDanger.EXPECTED_VALID_TELEPHONE_MESSAGE;
            string actualDangerText = editAccountDanger.GetTelephoneTextDanger();
            Assert.AreEqual(expectedDangerText, actualDangerText);
        }
        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}
