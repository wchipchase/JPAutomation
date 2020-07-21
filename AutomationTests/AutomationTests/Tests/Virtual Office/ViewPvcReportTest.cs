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
    class ViewPvcReportTest
    {
        LoginPage LoginPage;
        MainPage MainPage;
        SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage;
        CreateCustomerCartPageJP CreateCustomerCartPageJP;
        ShareModal ShareModal;
        ConfirmEmailPage ConfirmEMailPage;
        EditCartPage EditCartPage;

        [SetUp]
        public void Setup()
        {
            Driver.InitializeDriver();
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            LoginPage = new LoginPage();
            MainPage = new MainPage();
            SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage();
            CreateCustomerCartPageJP = new CreateCustomerCartPageJP();
            ShareModal = new ShareModal();
            ConfirmEMailPage = new ConfirmEmailPage();
            EditCartPage = new EditCartPage();
        }

        [Test, Category("LegacyRegression"), Description("View Pvc Report in Virtual Office."), Repeat(1)]
        public void ViewPvcReport_VO_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Config.Config.VirtualOfficeUrl_US_STG);
            LoginPage.Login("wddot", "wddot");
            MainPage.NavigateManageMyTeam();
            MainPage.ViewPvcReport();

            Driver.WebDriver.SwitchTo().Frame(2);
            Assert.IsTrue(MainPage.PvcReportEmbed.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
