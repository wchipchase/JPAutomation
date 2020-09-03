using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.nsanet.com;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.nsanet.com
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    class AroEntryTest
    {
        [ThreadStatic]
        static Driver Driver;

        [ThreadStatic] 
        static LoginPage LoginPage;
        [ThreadStatic] 
        static MainPage MainPage;
        [ThreadStatic]
        static AroEntryPage AroEntryPage;

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

            ExtentHelper.AddTest(TestContext.CurrentContext);
        }

        [TestCase("AU", "14 Merewether St", "2291", "Merewether", "QLD", "N/A", "9018503000", "9018503000", "121290", "2000AS", "Visa", "4242424242424242", "01", "25")]
        [TestCase("BEL", "Rue Duquesnoy 5", "1000", "Bruxelles", "N/A", "N/A", "0294963000", "0412345678", "121290", "490105034", "Visa", "4242424242424242", "01", "25")]
        [TestCase("CAN", "2785 Skymark Ave", "L4W 4Y3", "Mississauga", "ON", "N/A", "9018503000", "9018503000", "121290", "2000CA", "American Express", "374500262001008", "01", "25")]
        [TestCase("DK", "Torvegade 11", "8900", "Randers", "N/A", "N/A", "45 86 42 34 22", "45 86 42 34 22", "N/A", "490105080", "Visa", "4242424242424242", "01", "25")]
        [TestCase("FI", "Pieni Roobertinkatu 1", "001 30", "Helsinki", "N/A", "N/A", "358 9 6899880", "358 9 6899880", "N/A", "490105084", "Visa", "4242424242424242", "01", "25")]
        [TestCase("FR", "2 Boulevard du Levant", "93167", "Noisy-le-Grand", "N/A", "N/A", "33 1 45924747", "33 1 45924747", "N/A", "490105030", "Visa", "4242424242424242", "01", "25")] // ARO number is required
        [TestCase("GER", "Taunusstrasse 48-50", "60329", "Frankfurt am Main", "N/A", "N/A", "49 69-96869890", "49 69-96869890", "N/A", "490105001", "Visa", "4242424242424242", "01", "25")] // ARO number is required
        [TestCase("EIR", "Athlone Rd", "60329", "Athlone", "N/A", "Roscommon", "49 69 96869890", "49 69 96869890", "N/A", "490105030", "Visa", "4242424242424242", "01", "25")]// Need County. Wrong label.
        [TestCase("IT", "Via Torri Bianche 7", "20871", "Vimercate", "MB", "N/A", "39 06 495 9261", "39 06 495 9261", "121290", "490105040", "Visa", "4242424242424242", "01", "25")] // Extra stuff
        [TestCase("LU", "30 Rue Joseph Junck", "1839", "Luxembourg", "N/A", "N/A", "352 49 24 96", "352 49 24 96", "N/A", "490105036", "Visa", "4242424242424242", "01", "25")]
        [TestCase("NL", "Schepenbergweg 50", "1105 AT", "Amsterdam", "N/A", "N/A", "31 20 311 3670", "31 20 311 3670", "N/A", "490105034", "Visa", "4242424242424242", "01", "25")]
        [TestCase("NO", "Karl Johans gate 31", "0159", "Oslo", "N/A", "N/A", "47 23 21 20 00", "47 23 21 20 00", "N/A", "490105081", "Visa", "4242424242424242", "01", "25")]
        [TestCase("PL", "Stara 1", "41-940", "Piekary Śląskie", "N/A", "N/A", "458623422", "458623422", "N/A", "490105005", "Visa", "4242424242424242", "01", "25")]
        [TestCase("RO", "Calea Victoriei 56", "010083", "București", "București", "N/A", "40 372 010 300", "40 372 010 300", "N/A", "490110023", "Visa", "4242424242424242", "01", "25")] // wrong label state, but shows county.
        [TestCase("ES", "C/ Gran Vía, 84", "28013", "Madrid", "N/A", "N/A", "31 20 311 3670", "31 20 311 3670", "N/A", "490105003", "Visa", "4242424242424242", "01", "25")]
        [TestCase("SUI", "Bürgenstock 17", "6363", "Obbürgen", "N/A", "N/A", "41 41-612 60 00", "41 41-612 60 00", "N/A", "490105015", "Visa", "4242424242424242", "01", "25")] // ARO number is required
        [TestCase("SE", "Södra Blasieholmshamnen 8", "103 27", "Stockholm", "N/A", "N/A", "46 8 679 35 00", "46 8 679 35 00", "N/A", "490105084", "Visa", "4242424242424242", "01", "25")]
        [TestCase("UK", "40 Heyes St.", "L5 6SG", "Liverpool", "N/A", "Liverpool", "07720750898", "07720750898", "N/A", "490105084", "Visa", "4242424242424242", "01", "25")] // Need County. Wrong label.
        [TestCase("USA", "140 Crescent Dr.", "38017", "Collierville", "Tennessee", "N/A", "9018502938", "9018502938", "N/A", "2000", "Visa", "4242424242424242", "01", "25")]
        [Test, Description("Create Generic ARO on NSANet Aro Entry")]
        [Category("LegacyRegression"), Category("NSANet")]
        [Repeat(1)]
        public void AROEntry_NSANet_Generic(String countryCode, String address, String zip, String city, String state, String county, String mobile, String phone, String dob, String sku, String paymentType, String accountNumber, String expMonth, String expYear)
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("jcrocker", "Vivalabam123");
            MainPage.NavigateToAroEntry();
            AroEntryPage.InitiateNewAro(countryCode);
            AroEntryPage.InputBasicInformation("USM0025620", "4 Month Installment");
            AroEntryPage.InputAdrressInformation("test", "tester", address, zip, city, state, county, mobile, phone, "test@testing.com", dob);
            AroEntryPage.InputPaymentInformation(paymentType, accountNumber, expMonth, expYear);
            AroEntryPage.InputProductInformation(sku, 1);

            AroEntryPage.SubmitAro();
            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("ARO Number: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", ""));
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);
        }

        [Test, Description("Create United States ARO on NSANet Aro Entry")]
        [Category("LegacyRegression"), Category("NSANet"), Category("AROEntry")]
        [Repeat(1)]
        public void AROEntry_NSANet_UnitedStates()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            Thread.Sleep(5000);
            LoginPage.Login("autodevsvcacct", "Juiceplus123");
            MainPage.NavigateToAroEntry();
            AroEntryPage.InitiateNewAro("USA");
            AroEntryPage.InputBasicInformation("USM0025620");
            AroEntryPage.InputAdrressInformation("test", "tester", "140 Crescent Dr.", "38017", "COLLIERVILLE", "9018503000", "9018503000", "test@testing.com");
            AroEntryPage.InputPaymentInformation("Visa", "4242424242424242", "12", "25");
            AroEntryPage.InputProductInformation("2000", 1);

            AroEntryPage.SubmitAro();
            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("ARO Number: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", ""));
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);
        }

        [Test, Description("Create Canada ARO on NSANet Aro Entry")]
        [Category("LegacyRegression"), Category("NSANet"), Category("AROEntry")]
        [Repeat(1)]
        public void AROEntry_NSANet_Canada()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            Thread.Sleep(5000);
            LoginPage.Login("autodevsvcacct", "Juiceplus123");
            MainPage.NavigateToAroEntry();
            AroEntryPage.InitiateNewAro("CAN");
            AroEntryPage.InputBasicInformation("USM0025620");
            AroEntryPage.InputAdrressInformation("test", "tester", "2785 Skymark Ave", "L4W 4Y3", "Mississauga", "ON", "N/A", "9056246368", "9056246368", "test@testing.com", "121290");
            AroEntryPage.InputPaymentInformation("American Express", "374500262001008", "01", "25");
            AroEntryPage.InputProductInformation("2000CA", 1);

            AroEntryPage.SubmitAro();
            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("ARO Number: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", ""));
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);
        }

        [Test, Description("Create Australia ARO on NSANet Aro Entry")]
        [Category("LegacyRegression"), Category("NSANet"), Category("AROEntry")]
        [Repeat(1)]

        public void AROEntry_NSANet_Australia()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            Thread.Sleep(15000);
            LoginPage.Login("autodevsvcacct", "Juiceplus123");
            MainPage.NavigateToAroEntry();
            AroEntryPage.InitiateNewAro("AU");
            AroEntryPage.InputBasicInformation("USM0025620");
            AroEntryPage.InputAdrressInformation("test", "tester", "14 Merewether St.", "2291", "Merewether", "QLD", "N/A", "0294963000", "0412345678", "test@testing.com", "121290");
            AroEntryPage.InputPaymentInformation("Visa", "4242424242424242", "01", "25");
            AroEntryPage.InputProductInformation("2000AS", 1);
            
            AroEntryPage.SubmitAro();
            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("ARO Number: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", ""));
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);
        }

        [Test, Description("Create Belgium ARO on NSANet Aro Entry")]
        [Category("LegacyRegression"), Category("NSANet"), Category("AROEntry")]
        [Repeat(1)]
        public void AROEntry_NSANet_Belgium()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            LoginPage.Login("autodevsvcacct", "Juiceplus123");
            MainPage.NavigateToAroEntry();
            AroEntryPage.InitiateNewAro("BEL");
            AroEntryPage.InputBasicInformation("USM0025620", "4 Month Installment");
            AroEntryPage.InputAdrressInformation("test", "tester", "Rue Duquesnoy 5", "1000", "Bruxelles", "N/A", "N/A", "0294963000", "0412345678", "test@testing.com", "121290");
            AroEntryPage.InputPaymentInformation("Visa", "4242424242424242", "01", "25");
            AroEntryPage.InputProductInformation("490105034", 1);

            AroEntryPage.SubmitAro();
            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("ARO Number: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", ""));
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);
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
