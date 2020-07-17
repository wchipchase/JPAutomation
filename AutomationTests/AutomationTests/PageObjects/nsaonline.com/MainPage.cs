using AutomationTests.ConfigElements;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.rc.nsaonline.com
{
    class MainPage
    {
        public MainPage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[contains(text(),'Remind me later!')]")]
        public IWebElement remindMeLaterLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[href = '/esuite/control/clickHere']")]
        public IWebElement remindMeLaterConfirmationLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//b[contains(.,'Customer Resources')]")]
        public IWebElement customerResourcesPanel { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[href='/esuite/control/emailCompose?Mode=new']")]
        public IWebElement composeEmailLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.ClassName, Using = "submitJPOrder")]
        public IWebElement SubmitOrderJuicePlus { get; set; }

        public void NavigateComposeEmail()
        {
            MainPage mainPage = new MainPage();

            /*if (mainPage.remindMeLaterLink.Displayed)
            {
                mainPage.remindMeLaterLink.Click();
            }

            if (mainPage.remindMeLaterConfirmationLink.Displayed)
            {
                mainPage.remindMeLaterConfirmationLink.Click();
            }*/

            mainPage.customerResourcesPanel.Click();
            Thread.Sleep(1000);
            mainPage.composeEmailLink.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Compose E-Mail"));
        }

        public void InitiateOrderJuicePlus ()
        {
            SubmitOrderJuicePlus.Click();
        }
    }
}
