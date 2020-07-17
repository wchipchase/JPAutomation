using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.rc.nsaonline.com;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.rc.nsaonline
{
    class SharedCartVOTest
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

        [Test, Category("LegacyRegression"), Description("Shared Cart."), Repeat(1)]
        public void SharedCart_VO_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Config.Config.VirtualOfficeUrl_US_STG);
            LoginPage.Login("wddot", "wddot");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("2000", 1);
            SubmitCustomerJPOrderPage.AddToCart("3000", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "9018502938", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEMailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            Assert.AreEqual(EditCartPage.GetQuanity("2000"), "1");
            Assert.AreEqual(EditCartPage.GetQuanity("3000"), "1");
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
