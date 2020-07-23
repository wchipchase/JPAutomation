using System;
using AutomationTests.Config;
using NUnit.Framework;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace AutomationTests.Tests
{
    public class Misc
    {
        [ThreadStatic]
        static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
           // driver = new ChromeDriver();
        }

        [Test, Parallelizable, Category("MiscTest")]
        public void Test1()
        {
            Thread.Sleep(10000);
            driver.Navigate().GoToUrl("https://google.com");
        }

        [Test, Parallelizable, Category("MiscTest")]
        public void Test2()
        {
            Thread.Sleep(10000);
            driver.Navigate().GoToUrl("https://yahoo.com");
        }

        [Test, Parallelizable, Category("MiscTest")]
        public void Test3()
        {
            Thread.Sleep(10000);
            driver.Navigate().GoToUrl("https://bing.com");
        }

        [Test, Parallelizable, Category("BSTest")]
        [Obsolete]
        public void BSTest()
        {
            string USERNAME = "diannkelley1";
            string AUTOMATE_KEY = "Cegxz8p89wZFzY7N5VYW";

            DesiredCapabilities caps = new DesiredCapabilities();

            caps.SetCapability("os", "Windows");
            caps.SetCapability("os_version", "10");
            caps.SetCapability("browser", "Chrome");
            caps.SetCapability("browser_version", "80");
            caps.SetCapability("browserstack.user", USERNAME);
            caps.SetCapability("browserstack.key", AUTOMATE_KEY);
            caps.SetCapability("name", "diannkelley1's First Test");

            IWebDriver driver;
            driver = new RemoteWebDriver(
              new Uri("https://hub-cloud.browserstack.com/wd/hub/"), caps
            );
            driver.Navigate().GoToUrl("http://www.google.com");
            Console.WriteLine(driver.Title);

            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Browserstack");
            query.Submit();
            Console.WriteLine(driver.Title);

            driver.Quit();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}