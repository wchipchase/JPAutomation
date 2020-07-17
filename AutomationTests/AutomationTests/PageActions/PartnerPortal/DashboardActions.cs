﻿using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.PartnerPortal;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageActions.PartnerPortal
{
    class DashboardActions
    {
        public static IWebElement WaitUntilElementVisible(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }

        public static void ValidateComissionCard()
        {
            Dashboard dbo = new Dashboard();
            dbo.ComissionsCard.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Personal Volume"));
        }

        public static void ValidatePerformanceBonusCard()
        {
            Dashboard dbo = new Dashboard();
            dbo.PerformanceBonusCard.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Performance Bonus Qualification"));
        }

        public static void ValidatePromoteOutBonusCard()
        {
            Dashboard dbo = new Dashboard();
            dbo.PromoteOutBonusCard.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Promote Out Bonus Qualification"));
        }

        public static void ClickPendingRenewal()
        {
            Dashboard dbo = new Dashboard();
            WebDriverWait waitForElement = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".m-portal-section-header__title")));
            dbo.ScrollViewport();
            dbo.TeamCardArrow.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Team"));
        }

        public static void ClickPaymentIssues()
        {
            Dashboard dbo = new Dashboard();
            WebDriverWait waitForElement = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".m-portal-section-header__title")));
            dbo.ScrollViewport();
            dbo.CustomerCardAll.Click();
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[.='See all']")));
            dbo.ArrowToPaymentIssues.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Customer"));
        }

        public static void ClickAnniversaries()
        {
            Dashboard dbo = new Dashboard();
            WebDriverWait waitForElement = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".m-portal-section-header__title")));
            dbo.ScrollViewport();
            dbo.CustomerCardAll.Click();
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[.='See all']")));
            dbo.ArrowToAnniversaries.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Customer"));
        }
    }
}
