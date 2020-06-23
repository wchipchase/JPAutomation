using AutomationTests.ConfigElements;
using AutomationTests.PageActions.rc.nsaonline;
using AutomationTests.PageActions.rc.nsaonline.LoginActions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.rc.nsaonline
{
    class LoginTest
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;
        LoginActions LoginActions = new LoginActions();

        [Test, Category("Regression")]
        public void Login()
        {
        LoginActions.Login("wddot", "wddot");
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("USM0025620"));
            Assert.IsFalse(Driver.WebDriver.PageSource.Contains("USM0025620"));
        }

        [OneTimeSetUp]
        protected void OneTimeSetup()
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
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [SetUp]
        public void Setup()
        {
            Driver.InitializeDriver();
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.WebDriver.Navigate().GoToUrl("https://rc.nsaonline.com/esuite/control/main/");
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            _extent.Flush();
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)? "": string.Format("0", TestContext.CurrentContext.Result.StackTrace); 
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
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);

            Driver.Teardown();
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
