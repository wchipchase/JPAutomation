using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.nsaonline.com;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.nsaonline
{
    [TestFixture]
    class ComposeEmailTest
    {
        Driver Driver;

        MainPage MainPage;
        ComposeEmailPage ComposeEmailPage;
        LoginPage LoginPage;

        [SetUp]
        public void Setup()
        {
            Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.WebDriver.Manage().Window.Maximize();

            MainPage = new MainPage(Driver);
            ComposeEmailPage = new ComposeEmailPage(Driver);
            LoginPage = new LoginPage(Driver);
        }

        [Test, Category("LegacyRegression"), Category("Virtual Office"), Description("Test Compose Email on Virtual Office.")]
        public void ComposeEmail_VO_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice", "US"));
            LoginPage.Login("wddot", "wddot");
            MainPage.NavigateComposeEmail();
            ComposeEmailPage.ComposeEmail("test@testtesttest.com", "test");

            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your e-mail has been sent to the following:"));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("test@testtesttest.com"));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
