using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.IO;

namespace OpenCartSelenium.MyTests
{
    [TestFixture]
    class LoginPageTest
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        [Test]
        public void LoginWithValidData()
        {
            const string pathOfVailidUserTxt = @"C:\Users\vital\OneDrive\Рабочий стол\Testing\C# projects\Lv-616-Demo-3\OpenCartSelenium\OpenCartSelenium\MyTests\TxtFiles\VailidUsers.txt";
            driver.Navigate().GoToUrl("http://192.168.1.16/opencart/upload/"); // const set up
            List<User> listOfVaildUsers = new List<User>();

            //Filling from files
            using (StreamReader sr = new StreamReader(pathOfVailidUserTxt, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listOfVaildUsers.Add(new UserBuilder().SetEMail(line).SetPassword(sr.ReadLine()).Build());
                    sr.ReadLine();
                }
            }

            LoginPage loginPage;
            foreach (var item in listOfVaildUsers)
            {
                loginPage = new HomePage(driver).GoToLoginPage();
                MyAccountPage myAccountPage = loginPage.SuccessfullLogin(item);
                // ask about assert
                myAccountPage.Logout();
            }
        }

        [Test]
        public void LoginWithInvalidData()
        {
            driver.Navigate().GoToUrl("http://192.168.1.16/opencart/upload/");
            const string pathOfInvailidUserTxt = @"C:\Users\vital\OneDrive\Рабочий стол\Testing\C# projects\Lv-616-Demo-3\OpenCartSelenium\OpenCartSelenium\MyTests\TxtFiles\InvailidUsers.txt";
            List<User> listOfInaildUsers = new List<User>();

            //Filling from files
            using (StreamReader sr = new StreamReader(pathOfInvailidUserTxt, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listOfInaildUsers.Add(new UserBuilder().SetEMail(line).SetPassword(sr.ReadLine()).Build());
                    sr.ReadLine();
                }
            }

            foreach (var item in listOfInaildUsers)
            {
                LoginMessagePage loginMessagePage = new HomePage(driver).GoToLoginPage().UnSuccessfullLogin(item);
            }
        }


        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
    }
}
