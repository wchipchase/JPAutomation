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

namespace AutomationTests.PageObjects.nsaonline.com
{
    class ConfirmEmailPage : BasePage
    {
        public ConfirmEmailPage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[placeholder='Email']")]
        public IWebElement EmailAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//button[@type='submit' and contains(.,'Verify email')]")]
        public IWebElement VerifyEmailAddressButton { get; set; }

        public void VerifyEmailAddress(String emailaddress)
        {
            SendKeys(EmailAddressField, emailaddress);
            VerifyEmailAddressButton.Click();
        }

    }
}
