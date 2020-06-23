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

namespace AutomationTests.PageActions.rc.nsaonline.ComposeEmailActions
{
    class ComposeEmailActions
    {
        
        public static void ComposeEmail(String receiver, String subject)
        {
            ComposeEmailPage ComposeEmailPage = new ComposeEmailPage();

            ComposeEmailPage.Receiver.SendKeys(receiver);
            ComposeEmailPage.Subject.SendKeys(subject);
            ComposeEmailPage.SendEmail.Click();

            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your e-mail has been sent to the following:"));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains(receiver));
        }
    }
}
