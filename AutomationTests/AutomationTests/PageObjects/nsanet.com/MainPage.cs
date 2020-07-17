using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.nsanet.com
{
    class MainPage
    {
        public MainPage()
        {
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
            AroEntryLink.Click();
        }

        public void NavigateToAroMaintenance()
        {
            AroMaintenanceLink.Click();
        }

        public void NavigateToOrderEntry()
        {
            OrderEntryLink.Click();
        }

    }
}
