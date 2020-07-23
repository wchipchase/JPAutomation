using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.juiceplusvirtualfranchise.com;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationTests.juice.plus.virtualfranchise
{
    class Enrollment
    {
        MainPage MainPage;
        EnrollmentPageUS EnrollmentPageUS;
        EnrollmentPageCA EnrollmentPageCA;
        EnrollmentPageAU EnrollmentPageAU;

        [SetUp]
        public void Setup()
        {
            
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.Warning);
            options.AddArguments("--ignore-certificate-errors");
            Driver.InitializeDriver(options);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            MainPage = new MainPage();
            EnrollmentPageUS = new EnrollmentPageUS();
            EnrollmentPageCA = new EnrollmentPageCA();
            EnrollmentPageAU = new EnrollmentPageAU();
        }

        [Test, Category("LegacyRegression"), Category("VFEnrollment"), Description("Test US Virtual Franchise Enrollment using Corporate Url"), Repeat(1)]
        public void TestEnrollment_CorporateUrl_VF_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualFranchise", "US"));

            String emailAddress = "jason.moore" + new Random().Next(100000, 999999) + "@juiceplus.com";
            String ssn = "" + new Random().Next(100000000, 999999999);
            Console.WriteLine("Email Address: " + emailAddress);

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "us.devcq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "us.stagecq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "us.rccq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            MainPage.NavigateToEnrollmentPage();
            EnrollmentPageUS.InputPersonalInformation(ssn, "Test", "T", "Tester", "Male", "JAN", "6", "1974");
            EnrollmentPageUS.InputContactInformation("140 Crescent Dr", "Collierville", "TN", "38017", "9018502982", emailAddress);
            EnrollmentPageUS.InputSponsorInformation(true, "Todd White", "9018502982");
            EnrollmentPageUS.InputPaymentInformation("Visa", "4242424242424242", "12", "2021");
            
            EnrollmentPageUS.SubmitEnrollment();
            Assert.IsTrue(new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(EnrollmentPageUS.EnrollmentSuccessMessage)).Displayed);
            Thread.Sleep(5000);
        }

        [Test, Category("LegacyRegression"), Category("VFEnrollment"), Category("TestEnrollment_PartnerUrl_VF_US"), Description("Test US Virtual Franchise Enrollment using Partner Url"), Repeat(1)]
        public void TestEnrollment_PartnerUrl_VF_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualFranchisePartner", "US"));

            String emailAddress = "jason.moore" + new Random().Next(100000, 999999) + "@juiceplus.com";
            String ssn = "" + new Random().Next(100000000, 999999999);
            Console.WriteLine("Email Address: " + emailAddress);

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "us.devcq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "us.stagecq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "us.rccq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            MainPage.NavigateToEnrollmentPage();
            EnrollmentPageUS.InputPersonalInformation(ssn, "Test", "T", "Tester", "Male", "JAN", "6", "1974");
            EnrollmentPageUS.InputContactInformation("140 Crescent Dr", "Collierville", "TN", "38017", "9018502982", emailAddress);
            EnrollmentPageUS.InputSponsorInformation(true, "Todd White", "9018502982");
            EnrollmentPageUS.InputPaymentInformation("Visa", "4242424242424242", "12", "2021");

            EnrollmentPageUS.SubmitEnrollment();
            Assert.IsTrue(new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(EnrollmentPageUS.EnrollmentSuccessMessage)).Displayed);
            Thread.Sleep(5000);
        }

        [Test, Category("LegacyRegression"), Category("VFEnrollment"), Description("Test CAN Virtual Franchise Enrollment using Partner Url"), Repeat(1)]
        public void TestEnrollment_PartnerUrl_VF_CA()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualFranchisePartner", "CA"));

            String emailAddress = "jason.moore" + new Random().Next(100000, 999999) + "@juiceplus.com";
            String ssn = "" + new Random().Next(100, 999) + "-" + new Random().Next(100, 999) + "-" + new Random().Next(100, 999);
            Console.WriteLine("Email Address: " + emailAddress);

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "can.devcq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "can.stagecq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "can.rccq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "juiceplusvirtualfranchise.ca", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            MainPage.NavigateToEnrollmentPage();
            EnrollmentPageCA.InputPersonalInformation(ssn, "Test", "T", "Tester", "Male", "JAN", "6", "1974");
            EnrollmentPageCA.InputContactInformation("2785 Skymark Ave", "Mississauga", "ON", "L4W4Y3", "9056246368", emailAddress);
            EnrollmentPageCA.InputBusinessInformation();
            EnrollmentPageCA.InputSponsorInformation(true, "Todd White", "9018502982");
            EnrollmentPageCA.InputPaymentInformation("Visa", "4242424242424242", "12", "2021");

            EnrollmentPageCA.SubmitEnrollment();
            Assert.IsTrue(new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(EnrollmentPageCA.EnrollmentSuccessMessage)).Displayed);
            Thread.Sleep(5000);
        }

        [Test, Category("LegacyRegression"), Category("VFEnrollment"), Category("TestEnrollment_PartnerUrl_VF_AU"), Description("Test AU Virtual Franchise Enrollment using Partner Url"), Repeat(1)]
        public void TestEnrollment_PartnerUrl_VF_AU()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualFranchisePartner", "AU"));

            String emailAddress = "jason.moore" + new Random().Next(100000, 999999) + "@juiceplus.com";
            String ssn = "" + new Random().Next(100000000, 999999999);
            Console.WriteLine("Email Address: " + emailAddress);

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "au.devcq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "au.stagecq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "au.rccq.juiceplusvirtualfranchise.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("_hjDonePolls", "520447", "juiceplusvirtualfranchise.com.au", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            MainPage.NavigateToEnrollmentPage();
            EnrollmentPageAU.InputPersonalInformation(ssn, "Test", "T", "Tester", "Male", "JAN", "6", "1974");
            EnrollmentPageAU.InputContactInformation("14 Merewether St", "Merewether", "QLD", "2291", "0294963000", emailAddress);
            EnrollmentPageAU.InputBusinessInformation();
            EnrollmentPageAU.InputSponsorInformation(true, "Todd White", "9018502982");
            EnrollmentPageAU.InputPaymentInformation("Visa", "4242424242424242", "12", "2021");
            EnrollmentPageAU.InputAccountInformation("1234", "123-456", "TestBank", "AccountName");
            EnrollmentPageAU.AcceptTermsAndConditions();
            
            EnrollmentPageAU.SubmitEnrollment();
            Assert.IsTrue(new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(EnrollmentPageAU.EnrollmentSuccessMessage)).Displayed);
            Thread.Sleep(5000);
        }

        [Test, Category("Misc"), Description("Wait Test")]
        public void WaitTest()
        {
            DateTime startTime = DateTime.Now;
            try { Console.WriteLine(EnrollmentPageUS.EnrollmentSuccessMessage.Displayed); } catch (Exception) { }
            DateTime stopTime = DateTime.Now;
            Console.WriteLine(stopTime - startTime);

            startTime = DateTime.Now;
            try { Assert.IsTrue(EnrollmentPageUS.EnrollmentSuccessMessage.Displayed); } catch (Exception) { }
            stopTime = DateTime.Now;
            Console.WriteLine(stopTime - startTime);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
