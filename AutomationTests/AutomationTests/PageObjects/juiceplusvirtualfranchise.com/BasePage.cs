using AutomationTests.ConfigElements;
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

namespace AutomationTests.PageObjects.juiceplusvirtualfranchise.com
{
    class BasePage
    {
        Driver Driver;

        public BasePage(Driver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        public void Click (IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement)).Click();
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    webElement.Click();
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void ClickWhenClickable(IWebElement webElement, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(Driver.WebDriver, timeout);
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement)).Click();
        }

        public Boolean IsElementDisplayed(IWebElement webElement)
        {
            double initialImplicitWaitTime = Driver.WebDriver.Manage().Timeouts().ImplicitWait.TotalSeconds;
            try
            {
                Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                if (webElement.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(initialImplicitWaitTime);
            }
        }
    }
}
