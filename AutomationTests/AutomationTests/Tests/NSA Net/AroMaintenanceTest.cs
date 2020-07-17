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
    class AroMaintenanceTest
    {
        LoginPage LoginPage;
        MainPage MainPage;
        AroEntryPage AroEntryPage;
        AroMaintenancePage AroMaintenancePage;

        [SetUp]
        public void Setup()
        {
            Driver.InitializeDriver();
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            LoginPage = new LoginPage();
            MainPage = new MainPage();
            AroEntryPage = new AroEntryPage();
            AroMaintenancePage = new AroMaintenancePage();
        }

        [Test, Category("LegacyRegression"), Description("Create and Edit US ARO on NSA Net Aro Maintenance"), Repeat(1)]
        public void AROMaintenance_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Config.Config.NSANetUrl_STG);
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

            Driver.WebDriver.Navigate().GoToUrl(Config.Config.NSANetUrl_STG);
            MainPage.NavigateToAroMaintenance();
            AroMaintenancePage.ViewAro(AroNumber);

            AroMaintenancePage.EditNextDelivery("DDCI WISMO TRKD PK", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditNameAddress("TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "DDCI CXL ORD", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditCreditCardInfo("MasterCard", "5454545454545454", "123", "N/A", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditPaymentPlan("2- Installments", "DDCI WISMO TRKD PK", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditProductInformation("2", "DDCI WISMO TRKD PK", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.ProcessAro();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("ARO Processed"));

            AroMaintenancePage.CancelAro("Cancel - Return Product", "DB - Double Billed", "DDCI WISMO TRKD PK", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
        }

        [Test, Category("LegacyRegression"), Description("Create and Edit CA ARO on NSA Net Aro Maintenance"), Repeat(1)]
        public void AROMaintenance_CA()
        {
            Driver.WebDriver.Navigate().GoToUrl(Config.Config.NSANetUrl_STG);
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

            Driver.WebDriver.Navigate().GoToUrl(Config.Config.NSANetUrl_STG);
            MainPage.NavigateToAroMaintenance();
            AroMaintenancePage.SelectCountry("CAN");
            AroMaintenancePage.ViewAro(AroNumber);

            AroMaintenancePage.EditNextDelivery("forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditNameAddress("TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditCreditCardInfo("Check", "5454545454545454", "N/A", "123", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditPaymentPlan("2- Installments", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditProductInformation("2", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.ProcessAro();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("ARO Processed"));

            AroMaintenancePage.CancelAro("Cancel - Return Product", "DB - Double Billed", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
        }

        [Test, Category("LegacyRegression"), Description("Create and Edit AU ARO on NSA Net Aro Maintenance"), Repeat(1)]
        public void AROMaintenance_AU()
        {
            Driver.WebDriver.Navigate().GoToUrl(Config.Config.NSANetUrl_STG);
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

            Driver.WebDriver.Navigate().GoToUrl(Config.Config.NSANetUrl_STG);
            MainPage.NavigateToAroMaintenance();
            AroMaintenancePage.SelectCountry("AU");
            AroMaintenancePage.ViewAro(AroNumber);

            AroMaintenancePage.EditNextDelivery("forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditNameAddress("TESTING", "14 MEREWETHER ST.", "901-958-3015", "901-058-3021", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditCreditCardInfo("MasterCard", "5454545454545454", "123", "N/A", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditPaymentPlan("2 - Installments", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditProductInformation("2", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.ProcessAro();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("ARO Processed"));

            AroMaintenancePage.CancelAro("Cancel - Return Product", "DB - Double Billed", "forwarded to", "Test");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
        }

        [Test, Category("Misc"), Description("Cancel All AROs"), Repeat(1)]
        public void CancelAROs_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Config.Config.NSANetUrl_STG);
            LoginPage.Login("jcrocker", "Juiceplus123");
            String[] AroArray = { "6533085", "6533086", "6533087", "6533088", "6533089", "6533090", "6533091", "6533094", "6533095", "6533096", "6533097", "6533104", "6533105" };
            for (int i = 0; i < AroArray.Length; i++)
            {
                MainPage.NavigateToAroMaintenance();
                AroMaintenancePage.ViewAro(AroArray[i]);
                AroMaintenancePage.ProcessAro();
                AroMaintenancePage.CancelAro("Cancel - Return Product", "DB - Double Billed", "DDCI WISMO TRKD PK", "Test");
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
                Driver.WebDriver.Navigate().GoToUrl(Config.Config.NSANetUrl_STG);
            }

            Thread.Sleep(999999);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }
}
