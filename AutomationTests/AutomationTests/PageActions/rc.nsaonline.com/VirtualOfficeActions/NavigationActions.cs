using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.rc.nsaonline.com;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutomationTests.PageActions.rc.nsaonline.NavigationActions
{
    class NavigationActions
    {
        
        public static void NavigateComposeEmail()
        {
            MainPage mainPage = new MainPage();

            if (mainPage.remindMeLaterLink.Displayed)
            {
                mainPage.remindMeLaterLink.Click();
            }

            if (mainPage.remindMeLaterConfirmationLink.Displayed)
            {
                mainPage.remindMeLaterConfirmationLink.Click();
            }

            mainPage.customerResourcesPanel.Click();

            Thread.Sleep(1000);

            mainPage.composeEmailLink.Click();

            Thread.Sleep(1000);

            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Compose E-Mail"));
        }
    }
}
