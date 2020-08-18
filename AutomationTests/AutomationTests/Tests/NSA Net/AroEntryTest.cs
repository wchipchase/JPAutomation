﻿using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.nsanet.com;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.nsanet.com
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    class AroEntryTest
    {
        [ThreadStatic]
        static Driver Driver;

        [ThreadStatic] 
        static LoginPage LoginPage;
        [ThreadStatic] 
        static MainPage MainPage;
        [ThreadStatic]
        static AroEntryPage AroEntryPage;

        ExtentHelper ExtentHelper;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ExtentHelper = new ExtentHelper();
            ExtentHelper.Setup(TestContext.CurrentContext);
        }

        [SetUp]
        public void Setup()
        {
            Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.WebDriver.Manage().Window.Maximize();

            LoginPage = new LoginPage(Driver);
            MainPage = new MainPage(Driver);
            AroEntryPage = new AroEntryPage(Driver);

            ExtentHelper.AddTest(TestContext.CurrentContext);
        }

        [Test, Description("Create US ARO on NSANet Aro Entry")]
        [Category("LegacyRegression"), Category("NSANet"), Category("AROEntry")]
        [Repeat(1)]
        public void AROEntry_NSANet_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            Thread.Sleep(5000);
            LoginPage.Login("jcrocker", "Juiceplus123");
            MainPage.NavigateToAroEntry();
            AroEntryPage.InitiateNewAro("USA");
            AroEntryPage.InputBasicInformation("USM0025620");
            AroEntryPage.InputAdrressInformation("test", "tester", "140 Crescent Dr.", "38017", "COLLIERVILLE", "9018503000", "9018503000", "test@testing.com");
            AroEntryPage.InputPaymentInformation("Visa", "4242424242424242", "12", "25");
            AroEntryPage.InputProductInformation("2000", 1);

            AroEntryPage.SubmitAro();
            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("ARO Number: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", ""));
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);
        }

        [Test, Description("Create CAN ARO on NSANet Aro Entry")]
        [Category("LegacyRegression"), Category("NSANet"), Category("AROEntry")]
        [Repeat(1)]
        public void AROEntry_NSANet_CA()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            Thread.Sleep(5000);
            LoginPage.Login("jcrocker", "Juiceplus123");
            MainPage.NavigateToAroEntry();
            AroEntryPage.InitiateNewAro("CAN");
            AroEntryPage.InputBasicInformation("USM0025620");
            AroEntryPage.InputAdrressInformation("test", "tester", "2785 Skymark Ave", "L4W 4Y3", "Mississauga", "ON", "9056246368", "9056246368", "test@testing.com", "121290");
            AroEntryPage.InputPaymentInformation("American Express", "374500262001008", "01", "25");
            AroEntryPage.InputProductInformation("2000CA", 1);

            AroEntryPage.SubmitAro();
            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("ARO Number: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", ""));
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);
        }

        [Test, Description("Create AU ARO on NSANet Aro Entry")]
        [Category("LegacyRegression"), Category("NSANet"), Category("AROEntry")]
        [Repeat(1)]

        public void AROEntry_NSANet_AU()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
            Thread.Sleep(15000);
            LoginPage.Login("jcrocker", "Juiceplus123");
            MainPage.NavigateToAroEntry();
            AroEntryPage.InitiateNewAro("AU");
            AroEntryPage.InputBasicInformation("USM0025620");
            AroEntryPage.InputAdrressInformation("test", "tester", "14 Merewether St.", "2291", "Merewether", "QLD", "0294963000", "0412345678", "test@testing.com", "121290");
            AroEntryPage.InputPaymentInformation("Visa", "4242424242424242", "01", "25");
            AroEntryPage.InputProductInformation("2000AS", 1);
            
            AroEntryPage.SubmitAro();
            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("ARO Number: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", ""));
            }
            Assert.IsTrue(SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0);
        }

        [TearDown]
        public void TearDown()
        {
            ExtentHelper.LogTest(TestContext.CurrentContext, Driver);
            Driver.Teardown();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentHelper.Flush();
        }
    }
}
