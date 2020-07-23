using AutomationTests.ConfigElements;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.nsaonline.com
{
    class MainPage : BasePage
    {
        public MainPage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(),'Country Language')]")]
        public IWebElement CountryLanguageIcon { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "selChangeCountry")]
        public IWebElement ChangeCountrySelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[contains(text(),'Remind me later!')]")]
        public IWebElement RemindMeLaterLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[href = '/esuite/control/clickHere']")]
        public IWebElement RemindMeLaterConfirmationLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//b[contains(.,'Customer Resources')]")]
        public IWebElement CustomerResourcesPanel { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[href='/esuite/control/emailCompose?Mode=new']")]
        public IWebElement ComposeEmailLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[href='/esuite/control/paymentTypeAndProducts']")]
        public IWebElement SubmitOrderJuicePlus { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = ".myTeamDataContainer")]
        public IWebElement TeamDataPanel { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'Manage My Team')]")]
        public IWebElement ManageMyTeamLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(),'Previous Month End PVC report')]")]
        public IWebElement PvcReportLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.TagName, Using = "embed")]
        public IWebElement PvcReportEmbed { get; set; }

        public void ChangeCountry(String countryName)
        {
            CountryLanguageIcon.Click();
            new SelectElement(ChangeCountrySelect).SelectByText(countryName);
            Thread.Sleep(1000);
        }

        public void NavigateComposeEmail()
        {
            /*if (RemindMeLaterLink.Displayed)
            {
                RemindMeLaterLink.Click();
            }

            if (RemindMeLaterConfirmationLink.Displayed)
            {
                RemindMeLaterConfirmationLink.Click();
            }*/

            CustomerResourcesPanel.Click();
            Thread.Sleep(1000);
            ComposeEmailLink.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Compose E-Mail"));
        }

        public void InitiateOrderJuicePlus ()
        {
            SubmitOrderJuicePlus.Click();
        }

        public void NavigateManageMyTeam()
        {
            TeamDataPanel.Click();
            Click(ManageMyTeamLink);
        }

        public void ViewPvcReport()
        {
            PvcReportLink.Click();
        }
    }
}
