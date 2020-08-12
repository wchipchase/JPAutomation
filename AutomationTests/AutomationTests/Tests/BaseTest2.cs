using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.juiceplusvirtualfranchise.com;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.nsanet.com
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    class TestHelper2
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;

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

        [OneTimeSetUp]
        public void OneTimeSetupExtent()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
        }

        [SetUp]
        public void Setup()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

            Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.WebDriver.Manage().Window.Maximize();

            MainPage = new MainPage(Driver);
            EnrollmentPageUS = new EnrollmentPageUS(Driver);
            EnrollmentPageCA = new EnrollmentPageCA(Driver);
            EnrollmentPageAU = new EnrollmentPageAU(Driver);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _extent.Flush();
        }

        [Test, Category("ReportTest"), Description("Test US Virtual Franchise Enrollment using Corporate Url"), Retry(1)]
        public void BaseTestTest3()
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
            EnrollmentPageUS.InputPaymentInformation("Visa", "", "12", "2021");

            EnrollmentPageUS.SubmitEnrollment();
            Assert.IsTrue(new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(EnrollmentPageUS.EnrollmentSuccessMessage)).Displayed);
            Thread.Sleep(5000);
        }

        [Test, Category("ReportTest"), Description("Test US Virtual Franchise Enrollment using Partner Url"), Retry(1)]
        public void BaseTestTest4()
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

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    Console.WriteLine("Here: 1:");
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    String screenShotPath = Capture(Driver.WebDriver, fileName);
                    _test.Log(Status.Fail, "Fail");
                    _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    break;
                case TestStatus.Inconclusive:
                    Console.WriteLine("Here: 2:");
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    Console.WriteLine("Here: 3:");
                    logstatus = Status.Skip;
                    break;
                default:
                    Console.WriteLine("Here: 4:");
                    logstatus = Status.Pass;
                    break;
            }
            _test.Log(logstatus, "Test ended with " + "logstatus:" + logstatus + " stacktrace:" + stacktrace);
            Driver.WebDriver.Quit();
        }

        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }
    }
}
