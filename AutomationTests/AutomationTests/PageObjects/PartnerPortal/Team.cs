using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.PartnerPortal
{
    class Team
    {
        public Team()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='Filter']")]
        public IWebElement FilterControl { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='SC']")]
        public IWebElement FilterControlSC { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='SP']")]
        public IWebElement FilterControlSP { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='P']")]
        public IWebElement FilterControlP { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='SDD']")]
        public IWebElement FilterControlSDD { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='QSSC']")]
        public IWebElement FilterControlQSSC { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='SSC']")]
        public IWebElement FilterControlSSC { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='QNMD']")]
        public IWebElement FilterControlQNMD { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='NMD']")]
        public IWebElement FilterControlNMD { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='NULL']")]
        public IWebElement FilterControlNULL { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='First Name']")]
        public IWebElement FirstNameFilter { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='Last Name']")]
        public IWebElement LastNameFilter { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--select m-flyout__content--dropdown']//a[contains(.,'Last Name')]")]
        public IWebElement LastNameFilterSelection { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--select m-flyout__content--dropdown']//a[contains(.,'First Name')]")]
        public IWebElement FirstNameFilterSelection { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--select m-flyout__content--dropdown']//a[contains(.,'Last name')]")]
        public IWebElement LastNameSelectFilter { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='Download']")]
        public IWebElement DownloadFilter { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='Apply Filter']")]
        public IWebElement ApplyFilterButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'CSV')]")]
        public IWebElement DownloadCSVSelection { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='Add member']")]
        public IWebElement AddMemberButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='Copy Link']")]
        public IWebElement CopyNewPartnerRegistrationLink { get; set; }
    }
}
