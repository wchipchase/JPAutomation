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
using AutomationTests.nsanet.com;

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
        
        [TestCase("AU", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "2 - Installments", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("BEL", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("CAN", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "Check", "5454545454545454", "123", "2- Installments", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("DK", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("FI", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("FR", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("GER", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("EIR", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("IT", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("LU", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("NL", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("NO", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("PL", "TESTING", "145 CRESCENT DR.", "901859015", "901850021", "MC", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("RO", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("ES", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("SUI", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("SE", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "N- Full Payment", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("UK", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "2- Installments", "2", "Cancel - Return Product", "DB - Double Billed")]
        [TestCase("USA", "TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021", "MasterCard", "5454545454545454", "N/A", "2- Installments", "2", "Cancel - Return Product", "DB - Double Billed")]
        [Test, Description("Create and Edit US ARO on NSA Net Aro Maintenance")]
        [Category("LegacyRegression"), Category("AROMaintenance")]
        [Repeat(1)]
        public void AROMaintenance_NSANet(String countryCode, String lastName, String address, String phoneNumber, String mobileNumber, String paymentType, String accountNumber, String routingNumber, String paymentPlanType, String quantity, String cancelType, String statusReasonCode)
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("autodevsvcacct", "Juiceplus123");
            MainPage.NavigateToAroEntry();
            String aroNumber = AroEntryPage.CreateAro(countryCode);

            AroEntryPage.NavigateToWebPortal();
            MainPage.NavigateToAroMaintenance();
            AroMaintenancePage.SelectCountry(countryCode);
            AroMaintenancePage.ViewAro(aroNumber);

            AroMaintenancePage.EditNextDelivery();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditNameAddress(lastName, address, phoneNumber, mobileNumber);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditCreditCardInfo(paymentType, accountNumber, routingNumber);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditPaymentPlan(paymentPlanType);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditProductInformation(quantity);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.CancelAro(cancelType, statusReasonCode);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
        }

        [Test, Description("Create and Edit CA ARO on NSA Net Aro Maintenance")]
        [Category("LegacyRegression"), Category("AROMaintenance")]
        [Repeat(1)]
        public void AROMaintenance_NSANet_CA()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("autodevsvcacct", "Juiceplus123");
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

            AroMaintenancePage.EditNextDelivery();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditNameAddress("TESTING", "145 CRESCENT DR.", "901-859-3015", "901-850-3021");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditCreditCardInfo("Check", "5454545454545454", "123");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditPaymentPlan("2- Installments");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditProductInformation("2");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
            
            AroMaintenancePage.CancelAro("Cancel - Return Product", "DB - Double Billed");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
        }

        [Test, Description("Create and Edit AU ARO on NSA Net Aro Maintenance")]
        [Category("LegacyRegression"), Category("AROMaintenance")]
        [Repeat(1)]
        public void AROMaintenance_NSANet_AU()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("autodevsvcacct", "Juiceplus123");
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

            AroMaintenancePage.EditNextDelivery();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditNameAddress("TESTING", "14 MEREWETHER ST.", "901-958-3015", "901-058-3021");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditCreditCardInfo("MasterCard", "5454545454545454", "N/A");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditPaymentPlan("2 - Installments");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.EditProductInformation("2");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));

            AroMaintenancePage.CancelAro("Cancel - Return Product", "DB - Double Billed");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("SUCCESS - Changed values are highlighted below in green"));
        }

        [Test, Description("Cancel All AROs"), Category("AROMaintenance")]
        [Category("AROMaintenance")]
        [Repeat(1)]
        public void CancelAROs_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("autodevsvcacct", "Juiceplus123");
            String[] AroArray = { "6533085", "6533086", "6533087", "6533088", "6533089", "6533090", "6533091", "6533094", "6533095", "6533096", "6533097", "6533104", "6533105" };
            for (int i = 0; i < AroArray.Length; i++)
            {
                MainPage.NavigateToAroMaintenance();
                AroMaintenancePage.ViewAro(AroArray[i]);
                AroMaintenancePage.ProcessAro();
                AroMaintenancePage.CancelAro("Cancel - Return Product", "DB - Double Billed");
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
