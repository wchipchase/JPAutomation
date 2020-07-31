using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.nsaonline.com;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.rc.nsaonline
{
    [TestFixture]
    class ViewPvcReportTest
    {
        [ThreadStatic]
        static Driver Driver;

        static LoginPage LoginPage;
        [ThreadStatic]
        static MainPage MainPage;
        [ThreadStatic]
        static SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage;
        [ThreadStatic]
        static CreateCustomerCartPageJP CreateCustomerCartPageJP;
        [ThreadStatic]
        static ShareModal ShareModal;
        [ThreadStatic]
        static ConfirmEmailPage ConfirmEMailPage;
        [ThreadStatic]
        static EditCartPage EditCartPage;

        [SetUp]
        public void Setup()
        {
            Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.WebDriver.Manage().Window.Maximize();

            LoginPage = new LoginPage(Driver);
            MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal = new ShareModal(Driver);
            ConfirmEMailPage = new ConfirmEmailPage(Driver);
            EditCartPage = new EditCartPage(Driver);
        }

        [Test, Category("LegacyRegression"), Category("Virtual Office"), Description("View Pvc Report in Virtual Office."), Repeat(1)]
        public void ViewPvcReport_VO_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice", "US"));
            LoginPage.Login("wddot", "wddot");
            MainPage.NavigateManageMyTeam();
            MainPage.ViewPvcReport();

            Driver.WebDriver.SwitchTo().Frame(1);
            Assert.IsTrue(MainPage.PvcReportEmbed.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
