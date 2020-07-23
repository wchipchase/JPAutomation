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
    class ComposeEmailTest
    {
        MainPage MainPage;
        ComposeEmailPage ComposeEmailPage;

        [SetUp]
        public void Setup()
        {
            Driver.InitializeDriver();
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            MainPage = new MainPage();
            ComposeEmailPage = new ComposeEmailPage();
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
