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
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.rc.nsaonline
{
    class AROEntryVOTest
    {
        LoginPage LoginPage;
        MainPage MainPage;
        SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage;
        CheckoutPage CheckoutPage;
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
            CheckoutPage = new CheckoutPage();
            ShareModal = new ShareModal();
            ConfirmEMailPage = new ConfirmEmailPage();
            EditCartPage = new EditCartPage();
        }

        [Test, Category("LegacyRegression"), Category("Virtual Office"), Description("Create US ARO on VO."), Repeat(1)]
        public void AROEntry_VO_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice", "US"));
            LoginPage.Login("wddot", "wddot");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("2000", 1);
            SubmitCustomerJPOrderPage.AddToCart("3000", 1);
            SubmitCustomerJPOrderPage.Checkout();
            CheckoutPage.InputShippingInformation("Test", "Tester", "140 Crescent Dr.", "38017", "9018502938", "test@testing.com");
            CheckoutPage.UseShippingAddressForBilling();
            CheckoutPage.InputPaymentInformation("Visa", "4242424242424242", "12 - Dec", "2030");
            CheckoutPage.ContinueOrder();
            CheckoutPage.ProcessOrder();

            Thread.Sleep(5000);
        }

        [Test, Category("LegacyRegression"), Category("Virtual Office"), Description("Create CA ARO on VO."), Repeat(1)]
        public void AROEntry_VO_CA()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));
            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Canada");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("2000CA", 1);
            SubmitCustomerJPOrderPage.AddToCart("3000CA", 1);
            SubmitCustomerJPOrderPage.Checkout();
            CheckoutPage.InputShippingInformation("Test", "Tester", "2785 Skymark Ave", "L4W 4Y3", "Mississauga", "Ontario", "905-624-6368", "test@testing.com");
            CheckoutPage.UseShippingAddressForBilling();
            CheckoutPage.InputPaymentInformation("Visa", "4242424242424242", "12 - Dec", "2030");
            CheckoutPage.ContinueOrder();
            CheckoutPage.ProcessOrder();

            Thread.Sleep(5000);
        }

        [Test, Category("LegacyRegression"), Category("Virtual Office"), Description("Create AU ARO on VO."), Repeat(1)]
        public void AROEntry_VO_AU()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));
            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Australia");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("2000AS", 1);
            SubmitCustomerJPOrderPage.AddToCart("2012AS", 1);
            SubmitCustomerJPOrderPage.Checkout();
            CheckoutPage.InputShippingInformation("Test", "Tester", "14 Merewether St.", "2291", "Merewether", "Queensland", "0412345678", "test@testing.com");
            CheckoutPage.UseShippingAddressForBilling();
            CheckoutPage.InputPaymentInformation("Visa", "4242424242424242", "12 - Dec", "2030");
            CheckoutPage.ContinueOrder();
            CheckoutPage.ProcessOrder();

            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
