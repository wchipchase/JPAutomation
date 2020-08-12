using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.nsanet.com
{
    class MainPage
    {
        Driver Driver;

        public MainPage(Driver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[href='/aro_entry/']")]
        public IWebElement AroEntryLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[href='/aro_maint/']")]
        public IWebElement AroMaintenanceLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[href='/order_entry/']")]
        public IWebElement OrderEntryLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[href='/dea/']")]
        public IWebElement DistributorEntryLink { get; set; }

        public void NavigateToAroEntry()
        {
            Thread.Sleep(1000);
            AroEntryLink.Click();
            Thread.Sleep(1000);
            if (Driver.WebDriver.WindowHandles.Count > 1)
            {
                Driver.WebDriver.SwitchTo().Window(Driver.WebDriver.WindowHandles[0]);
                Thread.Sleep(1000);
                Driver.WebDriver.Close();
                Thread.Sleep(1000);
                Driver.WebDriver.SwitchTo().Window(Driver.WebDriver.WindowHandles[0]);
            }
        }

        public void NavigateToAroMaintenance()
        {
            Thread.Sleep(1000);
            AroMaintenanceLink.Click();
            Thread.Sleep(1000);
            if (Driver.WebDriver.WindowHandles.Count > 1)
            {
                Driver.WebDriver.SwitchTo().Window(Driver.WebDriver.WindowHandles[0]);
                Thread.Sleep(1000);
                Driver.WebDriver.Close();
                Thread.Sleep(1000);
                Driver.WebDriver.SwitchTo().Window(Driver.WebDriver.WindowHandles[0]);
            }
        }

        public void NavigateToOrderEntry()
        {            
            Thread.Sleep(1000);
            OrderEntryLink.Click();
            Thread.Sleep(1000);
            if (Driver.WebDriver.WindowHandles.Count > 1)
            {
                Driver.WebDriver.SwitchTo().Window(Driver.WebDriver.WindowHandles[0]);
                Thread.Sleep(1000);
                Driver.WebDriver.Close();
                Thread.Sleep(1000);
                Driver.WebDriver.SwitchTo().Window(Driver.WebDriver.WindowHandles[0]);
            }
        }

    }
}
