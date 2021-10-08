using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartSelenium
{
    public abstract class AUnloggedRightMenuComponent : AStatusBarComponent
    {
        public IWebElement LoginPageButton { get; private set; }
        public IWebElement RegisterButton { get; private set; }
        public IWebElement ForgottenPasswordButton { get; private set; }
        public IWebElement MyAccountButton { get; private set; }
        public IWebElement AddressBookButton { get; private set; }
        public IWebElement WishListButton { get; private set; }
        public IWebElement OrderHistoryButton { get; private set; }
        public IWebElement DownloadsButton { get; private set; }
        public IWebElement RecurringPaymentsButton { get; private set; }
        public IWebElement RewardPointsButton { get; private set; }
        public IWebElement ReturnsButton { get; private set; }
        public IWebElement TransactionsButton { get; private set; }
        public IWebElement NewsletterButton { get; private set; }
        public AUnloggedRightMenuComponent(IWebDriver driver) : base(driver)
        {
            LoginPageButton = driver.FindElement(By.XPath("//a[contains(@href, 'login')]"));
            RegisterButton = driver.FindElement(By.XPath("//a[contains(@href, 'register')]"));
            ForgottenPasswordButton = driver.FindElement(By.XPath("//a[contains(@href, 'forgotten')]"));
            MyAccountButton = driver.FindElement(By.XPath("//a[contains(@href, 'account')]"));
            AddressBookButton = driver.FindElement(By.XPath("//a[contains(@href, 'address')]"));
            WishListButton = driver.FindElement(By.XPath("//a[contains(@href, 'wishlist')]"));
            OrderHistoryButton = driver.FindElement(By.XPath("//a[contains(@href, 'order')]"));
            DownloadsButton = driver.FindElement(By.XPath("//a[contains(@href, 'download')]"));
            RecurringPaymentsButton = driver.FindElement(By.XPath("//a[contains(@href, 'recurring')]"));
            RewardPointsButton = driver.FindElement(By.XPath("//a[contains(@href, 'reward')]"));
            ReturnsButton = driver.FindElement(By.XPath("//a[contains(@href, 'return')]"));
            TransactionsButton = driver.FindElement(By.XPath("//a[contains(@href, 'transaction')]"));
            NewsletterButton = driver.FindElement(By.XPath("//a[contains(@href, 'newsletter')]"));
        }
    }
}
