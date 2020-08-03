using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.nsaonline.com;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.rc.nsaonline
{
    [TestFixture]
    class AROEntryVOTest
    {
        [ThreadStatic]
        static Driver Driver;

        [ThreadStatic]
        static LoginPage LoginPage;
        [ThreadStatic]
        static MainPage MainPage;
        [ThreadStatic]
        static SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage;
        [ThreadStatic]
        static CheckoutPage CheckoutPage;
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
            CheckoutPage = new CheckoutPage(Driver);
            ShareModal = new ShareModal(Driver);
            ConfirmEMailPage = new ConfirmEmailPage(Driver);
            EditCartPage = new EditCartPage(Driver);
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

            var SuccessMessageRegex = new Regex(@"USWA\d{5,8}");
            if (SuccessMessageRegex.Matches(CheckoutPage.GetOrderNumber()).Count > 0)
            {
                Console.Write("USW Confirmation Number: " + SuccessMessageRegex.Matches(CheckoutPage.GetOrderNumber())[0].Value);
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(CheckoutPage.GetOrderNumber()).Count > 0);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Thank You for submitting your customer's order!"));
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

            var SuccessMessageRegex = new Regex(@"CNWA\d{5,8}");
            if (SuccessMessageRegex.Matches(CheckoutPage.GetOrderNumber()).Count > 0)
            {
                Console.Write("CNW Confirmation Number: " + SuccessMessageRegex.Matches(CheckoutPage.GetOrderNumber())[0].Value);
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(CheckoutPage.GetOrderNumber()).Count > 0);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Thank You for submitting your customer's order!"));
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

            var SuccessMessageRegex = new Regex(@"AUWA\d{5,8}");
            if (SuccessMessageRegex.Matches(CheckoutPage.GetOrderNumber()).Count > 0)
            {
                Console.Write("AUW Confirmation Number: " + SuccessMessageRegex.Matches(CheckoutPage.GetOrderNumber())[0].Value);
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(CheckoutPage.GetOrderNumber()).Count > 0);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Thank You for submitting your customer's order!"));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
