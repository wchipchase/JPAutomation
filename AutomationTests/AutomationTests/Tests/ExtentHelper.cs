using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.juiceplusvirtualfranchise.com;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MongoDB.Bson;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests
{
    class ExtentHelper
    {
        protected ExtentReports _extent;
        protected static ConcurrentDictionary<string, ExtentTest> _tests = new ConcurrentDictionary<string, ExtentTest>();

        protected String projectPath;

        public ExtentHelper() { }

        public void Setup(TestContext testContext)
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\" + testContext.Test.Name + "\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
        }

        public void AddTest(TestContext testContext)
        {
            // Console.WriteLine("AddTest: " + testContext.Test.Name);
            // Console.WriteLine("_tests: " + _tests.Count);
            // Console.WriteLine("_extent: " + _extent.Stats);
            _tests.TryAdd(testContext.Test.Name, _extent.CreateTest(testContext.Test.Name));
        }

        public void LogTest(TestContext testContext, Driver driver) 
        {
            // Console.WriteLine("LogTest: " + testContext.Test.Name);
            var status = testContext.Result.Outcome.Status;
            var message = testContext.Result.Message;
            var stacktrace = testContext.Result.StackTrace;
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    // Console.WriteLine("Here: 1:");
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    String screenShotPath = Capture(driver.WebDriver, fileName);
                    try
                    {
                        _tests[testContext.Test.Name].Log(Status.Fail, "Snapshot below: " + _tests[testContext.Test.Name].AddScreenCaptureFromPath(screenShotPath));
                    } catch (KeyNotFoundException e)
                    {
                        Console.Write(e.Message);
                        Console.Write("_tests.ToJson(): " + _tests.ToJson());
                    }                    
                    break;
                case TestStatus.Inconclusive:
                    // Console.WriteLine("Here: 2:");
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    // Console.WriteLine("Here: 3:");
                    logstatus = Status.Skip;
                    break;
                default:
                    // Console.WriteLine("Here: 4:");
                    logstatus = Status.Pass;
                    break;
            }
            _tests[testContext.Test.Name].Log(logstatus, "Logstatus: " + logstatus);
            if (logstatus == Status.Fail)
            {
                _tests[testContext.Test.Name].Log(logstatus, "Message: " + message);
                _tests[testContext.Test.Name].Log(logstatus, "Stacktrace: " + stacktrace);
            }
        }

        public void Flush()
        {
            _extent.Flush();
        }

        public string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot;
            try
            {
                driver.SwitchTo().Alert().Dismiss();
            } catch (Exception)
            {
            }
            screenshot = ts.GetScreenshot();
            Thread.Sleep(1000);
            // Screenshot screenshot = ts.GetScreenshot();
            Directory.CreateDirectory(projectPath + "Reports\\" + "Screenshots");
            var finalpth = projectPath + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            for (int i=0; i<5; i++)
            {
                try
                {
                    screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(1000);
                }
            }
            return finalpth;
        }
    }
}
