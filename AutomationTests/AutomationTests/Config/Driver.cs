using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationTests.ConfigElements
{
    class Driver
    {
        public static IWebDriver driver { get; set; }

        public static void WaitForElementUpTo(int seconds = 5)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
    }
}
