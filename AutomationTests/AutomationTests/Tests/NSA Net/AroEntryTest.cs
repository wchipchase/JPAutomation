using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.nsanet.com;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.nsanet.com
{
    class AroEntryTest
    {
        LoginPage LoginPage;
        MainPage MainPage;
        AroEntryPage AroEntryPage;


        [SetUp]
        public void Setup()
        {
            Driver.InitializeDriver();
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            LoginPage = new LoginPage();
            MainPage = new MainPage();
            AroEntryPage = new AroEntryPage();
        }

        [Test, Category("LegacyRegression"), Category("AROEntry"), Description("Create US ARO on NSANet Aro Entry"), Repeat(1)]
        public void AROEntry_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
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

        [Test, Category("LegacyRegression"), Category("AROEntry"), Description("Create CAN ARO on NSANet Aro Entry"), Repeat(1)]
        public void AROEntry_CA()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
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

        [Test, Category("LegacyRegression"), Category("AROEntry"), Description("Create AU ARO on NSANet Aro Entry"), Repeat(1)]
        public void AROEntry_AU()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("NSANet"));
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
            Driver.Teardown();
        }
    }
}
