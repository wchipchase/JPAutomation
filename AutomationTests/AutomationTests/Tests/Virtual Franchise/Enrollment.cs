using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.juiceplusvirtualfranchise.com;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace AutomationTests.juice.plus.virtualfranchise
{
    [TestFixture]
    class Enrollment
    {
        [ThreadStatic]
        static Driver Driver;

        [ThreadStatic]
        static MainPage MainPage;
        [ThreadStatic]
        static EnrollmentPageUS EnrollmentPageUS;
        [ThreadStatic]
        static EnrollmentPageCA EnrollmentPageCA;
        [ThreadStatic]
        static EnrollmentPageAU EnrollmentPageAU;

        [SetUp]
        public void Setup()
        {
            Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.WebDriver.Manage().Window.Maximize();

            MainPage = new MainPage(Driver);
            EnrollmentPageUS = new EnrollmentPageUS(Driver);
            EnrollmentPageCA = new EnrollmentPageCA(Driver);
            EnrollmentPageAU = new EnrollmentPageAU(Driver);
        }

        [Test, Description("Test US Virtual Franchise Enrollment using Corporate Url")]
        [Category("LegacyRegression"), Category("VFEnrollment")]
        [Retry(1)]
        public void TestEnrollmentCorporateUrl_VF_US()
        {
            Driver.Navigate(Driver.GetUrl("VirtualFranchise", "US"));

            String emailAddress = "jason.moore" + new Random().Next(100000, 999999) + "@juiceplus.com";
            String ssn = "" + new Random().Next(100000000, 999999999);
            Console.WriteLine("Email Address: " + emailAddress);

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447");
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            // MainPage.NavigateToEnrollmentPage();
            EnrollmentPageUS.InputPersonalInformation(ssn, "Test", "T", "Tester", "Male", "JAN", "6", "1974");
            EnrollmentPageUS.InputContactInformation("140 Crescent Dr", "Collierville", "TN", "38017", "9018502982", emailAddress);
            EnrollmentPageUS.InputSponsorInformation(true, "Todd White", "9018502982");
            EnrollmentPageUS.InputPaymentInformation("Visa", "4242424242424242", "12", "2021");
            
            EnrollmentPageUS.SubmitEnrollment();
            Assert.IsTrue(new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(EnrollmentPageUS.EnrollmentSuccessMessage)).Displayed);
            Thread.Sleep(5000);
        }

        [Test, Description("Test US Virtual Franchise Enrollment using Partner Url")]
        [Category("LegacyRegression"), Category("VFEnrollment")]
        [Retry(1)]
        public void TestEnrollmentPartnerUrl_VF_US()
        {
            Driver.Navigate(Driver.GetUrl("VirtualFranchisePartner", "US"));

            String emailAddress = "jason.moore" + new Random().Next(100000, 999999) + "@juiceplus.com";
            String ssn = "" + new Random().Next(100000000, 999999999);
            Console.WriteLine("Email Address: " + emailAddress);

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447");
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            // MainPage.NavigateToEnrollmentPage();
            EnrollmentPageUS.InputPersonalInformation(ssn, "Test", "T", "Tester", "Male", "JAN", "6", "1974");
            EnrollmentPageUS.InputContactInformation("140 Crescent Dr", "Collierville", "TN", "38017", "9018502982", emailAddress);
            EnrollmentPageUS.InputSponsorInformation(true, "Todd White", "9018502982");
            EnrollmentPageUS.InputPaymentInformation("Visa", "4242424242424242", "12", "2021");

            EnrollmentPageUS.SubmitEnrollment();
            Assert.IsTrue(new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(EnrollmentPageUS.EnrollmentSuccessMessage)).Displayed);
            var SuccessMessageRegex = new Regex(@"USM\d{5,8}");
            if (SuccessMessageRegex.Matches(EnrollmentPageUS.GetFinNumber()).Count > 0)
            {
                Console.Write("New Parter FIN: " + SuccessMessageRegex.Matches(EnrollmentPageUS.GetFinNumber())[0].Value);
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(EnrollmentPageUS.GetFinNumber()).Count > 0);
            Thread.Sleep(5000);
        }

        [Test, Description("Test CAN Virtual Franchise Enrollment using Partner Url")]
        [Category("LegacyRegression"), Category("VFEnrollment")]
        [Retry(1)]
        public void TestEnrollmentPartnerUrl_VF_CA()
        {
            Driver.Navigate(Driver.GetUrl("VirtualFranchisePartner", "CA"));

            String emailAddress = "jason.moore" + new Random().Next(100000, 999999) + "@juiceplus.com";
            String ssn = "" + new Random().Next(100, 999) + "-" + new Random().Next(100, 999) + "-" + new Random().Next(100, 999);
            Console.WriteLine("Email Address: " + emailAddress);

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447");
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            // MainPage.NavigateToEnrollmentPage();
            EnrollmentPageCA.InputPersonalInformation(ssn, "Test", "T", "Tester", "Male", "JAN", "6", "1974");
            EnrollmentPageCA.InputContactInformation("2785 Skymark Ave", "Mississauga", "ON", "L4W4Y3", "9056246368", emailAddress);
            EnrollmentPageCA.InputBusinessInformation();
            EnrollmentPageCA.InputSponsorInformation(true, "Todd White", "9018502982");
            EnrollmentPageCA.InputPaymentInformation("Visa", "4242424242424242", "12", "2021");

            EnrollmentPageCA.SubmitEnrollment();
            Assert.IsTrue(new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(EnrollmentPageCA.EnrollmentSuccessMessage)).Displayed);
            var SuccessMessageRegex = new Regex(@"CAN\d{5,8}");
            if (SuccessMessageRegex.Matches(EnrollmentPageCA.GetFinNumber()).Count > 0)
            {
                Console.Write("New Parter FIN: " + SuccessMessageRegex.Matches(EnrollmentPageCA.GetFinNumber())[0].Value);
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(EnrollmentPageCA.GetFinNumber()).Count > 0);
            Thread.Sleep(5000);
        }

        [Test, Description("Test AU Virtual Franchise Enrollment using Partner Url")]
        [Category("LegacyRegression"), Category("VFEnrollment")]
        [Retry(1)]
        public void TestEnrollmentPartnerUrl_VF_AU()
        {
            Driver.Navigate(Driver.GetUrl("VirtualFranchisePartner", "AU"));

            String emailAddress = "jason.moore" + new Random().Next(100000, 999999) + "@juiceplus.com";
            String ssn = "" + new Random().Next(100000000, 999999999);
            Console.WriteLine("Email Address: " + emailAddress);

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447");
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            // MainPage.NavigateToEnrollmentPage();
            EnrollmentPageAU.InputPersonalInformation(ssn, "Test", "T", "Tester", "Male", "JAN", "6", "1974");
            EnrollmentPageAU.InputContactInformation("14 Merewether St", "Merewether", "QLD", "2291", "0294963000", emailAddress);
            EnrollmentPageAU.InputBusinessInformation();
            EnrollmentPageAU.InputSponsorInformation(true, "Todd White", "9018502982");
            EnrollmentPageAU.InputPaymentInformation("Visa", "4242424242424242", "12", "2021");
            EnrollmentPageAU.InputAccountInformation("1234", "123-456", "TestBank", "AccountName");
            EnrollmentPageAU.AcceptTermsAndConditions();
            
            EnrollmentPageAU.SubmitEnrollment();
            Assert.IsTrue(new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(EnrollmentPageAU.EnrollmentSuccessMessage)).Displayed);
            var SuccessMessageRegex = new Regex(@"AU\d{5,8}");
            if (SuccessMessageRegex.Matches(EnrollmentPageAU.GetFinNumber()).Count > 0)
            {
                Console.Write("New Parter FIN: " + SuccessMessageRegex.Matches(EnrollmentPageAU.GetFinNumber())[0].Value);
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(EnrollmentPageAU.GetFinNumber()).Count > 0);
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
