using System;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTests.ConfigElements
{
    public static class Driver {
        // Privatize the _webDriver member; use the WebDriver as the only external exposure to the driver
        private static IWebDriver _webDriver;
        public static IWebDriver WebDriver {
            get {
                // _webDriver = _webDriver == null ? GetWebDriver : _webDriver
                _webDriver = _webDriver ?? GetWebDriver();
                return _webDriver;
            }
        }

        private static IWebDriver GetWebDriver() {
            var webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(Config.Config.BaseURL);
            WaitForElementUpTo(webDriver, Config.Config.ElementsWaitingTimeout);

            return webDriver;
        }

        private static void WaitForElementUpTo(IWebDriver webDriver, int seconds = 10) {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void Teardown() {
            _webDriver.Quit();
            _webDriver = null;
        }
    }
}
