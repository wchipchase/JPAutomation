using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.nsanet.com;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.nsanet.com
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    class OrderEntryTest
    {
        [ThreadStatic]
        static Driver Driver;

        [ThreadStatic]
        static LoginPage LoginPage;
        [ThreadStatic]
        static MainPage MainPage;
        [ThreadStatic]
        static OrderEntryPage OrderEntryPage;

        ExtentHelper ExtentHelper;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ExtentHelper = new ExtentHelper();
            ExtentHelper.Setup(TestContext.CurrentContext);
        }

        [SetUp]
        public void Setup()
        {
            Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.WebDriver.Manage().Window.Maximize();

            LoginPage = new LoginPage(Driver);
            MainPage = new MainPage(Driver);
            OrderEntryPage = new OrderEntryPage(Driver);

            ExtentHelper.AddTest(TestContext.CurrentContext);
        }

        [Test, Description("Create US Order on NSA Net Order Entry")]
        [Category("LegacyRegression"), Category("OrderEntry")]
        [Repeat(1)]
         public void OrderEntry_NSANet_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("autodevsvcacct", "Juiceplus123");
            MainPage.NavigateToOrderEntry();
            OrderEntryPage.InitiateNewOrder("USA", "USM0025620");
            OrderEntryPage.InputDeliveryAddressInformation("Test Tester", "140 Crescent Dr.", "38017", "Collierville", "9018503000", "9018503000", "test@testing.com", "UPS - Ground");
            OrderEntryPage.InputProductIformation("2000", "RO", "1");
            OrderEntryPage.InputPaymentType("Visa", "4242424242424242", "12", "2025");
            OrderEntryPage.FinishOrderEntry();

            var SuccessMessageRegex = new Regex(@"USO\d{5,9}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("Sales Order ID: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value);
            }
            Thread.Sleep(5000);
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Transaction Completed Successfully") || Driver.WebDriver.PageSource.Contains("Order Added"));
            Thread.Sleep(5000);
            Driver.Pause();
        }

        [Test, Description("Create CA Order on NSA Net Order Entry")]
        [Category("LegacyRegression"), Category("OrderEntry")]
        [Repeat(1)]
        public void OrderEntry_NSANet_CA()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("autodevsvcacct", "Juiceplus123");
            MainPage.NavigateToOrderEntry();
            OrderEntryPage.InitiateNewOrder("CAN", "USM0025620");
            OrderEntryPage.InputDeliveryAddressInformation("Test Tester", "2785 Skymark Ave.", "L4W 4Y3", "Mississauga", "9018503000", "9018503000", "test@testing.com", "Economy");
            OrderEntryPage.InputProductIformation("2000CA", "RO", "1");
            OrderEntryPage.InputPaymentType("Visa", "4242424242424242", "12", "2025");
            OrderEntryPage.FinishOrderEntry();

            var SuccessMessageRegex = new Regex(@"CNO\d{5,9}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("Sales Order ID: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value);
            }
            Thread.Sleep(5000);
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Transaction Completed Successfully") || Driver.WebDriver.PageSource.Contains("Order Added"));
            Thread.Sleep(5000);
        }

        [Test, Description("Create UK Order on NSA Net Order Entry")]
        [Category("LegacyRegression"), Category("OrderEntry")]
        [Repeat(1)]
        public void OrderEntry_NSANet_UK()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("autodevsvcacct", "Juiceplus123");
            MainPage.NavigateToOrderEntry();
            OrderEntryPage.InitiateNewOrder("UK", "USM0025620");
            OrderEntryPage.InputDeliveryAddressInformation("Test Tester", "40 Heyes St.", "L5 6SG", "Liverpool", "07720750898", "07720750898", "test@testing.com", "FMNET");
            OrderEntryPage.InputProductIformation("480105050", "RO", "1");
            OrderEntryPage.InputPaymentType("Visa", "4242424242424242", "12", "2025");
            OrderEntryPage.FinishOrderEntry();

            var SuccessMessageRegex = new Regex(@"UKO\d{5,9}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("Sales Order ID: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value);
            }
            Thread.Sleep(5000);
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Transaction Completed Successfully") || Driver.WebDriver.PageSource.Contains("Order Added"));
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            ExtentHelper.LogTest(TestContext.CurrentContext, Driver);
            Driver.Teardown();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentHelper.Flush();
        }
    }
}
