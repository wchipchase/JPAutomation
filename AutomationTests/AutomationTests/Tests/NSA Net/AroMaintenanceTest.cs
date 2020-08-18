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
    class AroMaintenanceTest
    {
        [ThreadStatic]
        static Driver Driver;

        [ThreadStatic]
        static LoginPage LoginPage;
        [ThreadStatic]
        static MainPage MainPage;
        [ThreadStatic]
        static AroEntryPage AroEntryPage;
        [ThreadStatic]
        static AroMaintenancePage AroMaintenancePage;

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
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.WebDriver.Manage().Window.Maximize();

            LoginPage = new LoginPage(Driver);
            MainPage = new MainPage(Driver);
            AroEntryPage = new AroEntryPage(Driver);
            AroMaintenancePage = new AroMaintenancePage(Driver);

            ExtentHelper.AddTest(TestContext.CurrentContext);
        }

        [Test, Description("Create and Edit US ARO on NSA Net Aro Maintenance")]
        [Category("LegacyRegression")]
        [Repeat(1)]
        public void AROMaintenance_NSANet_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("jcrocker", "Juiceplus123");
            MainPage.NavigateToAroEntry();
            AroEntryPage.CreateUSAro();

            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            String AroNumber = "";
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                AroNumber = SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", "");
                Console.WriteLine("ARO Number: " + AroNumber);
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);

            AroEntryPage.NavigateToWebPortal();
            MainPage.NavigateToAroMaintenance();
            AroMaintenancePage.ViewAro(AroNumber);

            AroMaintenancePage.EditNextDelivery("DDCI WISMO TRKD PK", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditNameAddress("TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "DDCI CXL ORD", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditCreditCardInfo("MasterCard", "5454545454545454", "N/A", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditPaymentPlan("2- Installments", "DDCI WISMO TRKD PK", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditProductInformation("2", "DDCI WISMO TRKD PK", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.CancelAro("Cancel - Return Product", "DB - Double Billed", "DDCI WISMO TRKD PK", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
        }

        [Test, Description("Create and Edit CA ARO on NSA Net Aro Maintenance")]
        [Category("LegacyRegression")]
        [Repeat(1)]
        public void AROMaintenance_NSANet_CA()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("jcrocker", "Juiceplus123");
            MainPage.NavigateToAroEntry();
            AroEntryPage.CreateCAAro();

            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            String AroNumber = "";
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                AroNumber = SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", "");
                Console.WriteLine("ARO Number: " + AroNumber);
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);

            AroEntryPage.NavigateToWebPortal();
            MainPage.NavigateToAroMaintenance();
            AroMaintenancePage.SelectCountry("CAN");
            AroMaintenancePage.ViewAro(AroNumber);

            AroMaintenancePage.EditNextDelivery("forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditNameAddress("TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditCreditCardInfo("Check", "5454545454545454", "123", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditPaymentPlan("2- Installments", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditProductInformation("2", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
            
            AroMaintenancePage.CancelAro("Cancel - Return Product", "DB - Double Billed", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
        }

        [Test, Description("Create and Edit AU ARO on NSA Net Aro Maintenance")]
        [Category("LegacyRegression")]
        [Repeat(1)]
        public void AROMaintenance_NSANet_AU()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("jcrocker", "Juiceplus123");
            MainPage.NavigateToAroEntry();
            AroEntryPage.CreateAUAro();

            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            String AroNumber = "";
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                AroNumber = SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", "");
                Console.WriteLine("ARO Number: " + AroNumber);
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);

            AroEntryPage.NavigateToWebPortal();
            MainPage.NavigateToAroMaintenance();
            AroMaintenancePage.SelectCountry("AU");
            AroMaintenancePage.ViewAro(AroNumber);

            AroMaintenancePage.EditNextDelivery("forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditNameAddress("TESTING", "14 MEREWETHER ST.", "901-958-3015", "901-058-3021", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditCreditCardInfo("MasterCard", "5454545454545454", "N/A", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditPaymentPlan("2 - Installments", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditProductInformation("2", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.CancelAro("Cancel - Return Product", "DB - Double Billed", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
        }

        [Test, Description("Cancel All AROs")]
        [Category("Misc")]
        [Repeat(1)]
        public void CancelAROs_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("jcrocker", "Juiceplus123");
            String[] AroArray = { "6533085", "6533086", "6533087", "6533088", "6533089", "6533090", "6533091", "6533094", "6533095", "6533096", "6533097", "6533104", "6533105" };
            for (int i = 0; i < AroArray.Length; i++)
            {
                MainPage.NavigateToAroMaintenance();
                AroMaintenancePage.ViewAro(AroArray[i]);
                AroMaintenancePage.ProcessAro();
                AroMaintenancePage.CancelAro("Cancel - Return Product", "DB - Double Billed", "DDCI WISMO TRKD PK", "Test");
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
                AroEntryPage.NavigateToWebPortal();
            }

            Thread.Sleep(999999);
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
