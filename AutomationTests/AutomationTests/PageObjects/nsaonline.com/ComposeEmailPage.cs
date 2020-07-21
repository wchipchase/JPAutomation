﻿using AutomationTests.ConfigElements;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.nsaonline.com
{
    class ComposeEmailPage
    {
        public ComposeEmailPage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "textarea[id='txtToList']")]
        public IWebElement Receiver { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "textarea[name='txtSubject']")]
        public IWebElement Subject { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "button[onclick='validateBeforeSendEmail(document.composeForm);']")]
        public IWebElement SendEmail { get; set; }

        public void ComposeEmail(String receiver, String subject)
        {
            ComposeEmailPage ComposeEmailPage = new ComposeEmailPage();

            ComposeEmailPage.Receiver.SendKeys(receiver);
            ComposeEmailPage.Subject.SendKeys(subject);
            ComposeEmailPage.SendEmail.Click();
        }

    }
}