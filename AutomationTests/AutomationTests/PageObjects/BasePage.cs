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

namespace AutomationTests.PageObjects
{
    class BasePage
    {
        Driver Driver;

        public BasePage(Driver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        public void Click(IWebElement webElement)
        {
            // WebDriverWait wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(5));
            // wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    webElement.Click();
                    Thread.Sleep(1000);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void SendKeys(IWebElement webElement, String text)
        {
            WebDriverWait wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    webElement.SendKeys(text);
                    Thread.Sleep(1000);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void SendKeysSlowly(IWebElement webElement, String stringValue)
        {
            Char[] stringArray = stringValue.ToCharArray();
            for (int i = 0; i < stringValue.Length; i++)
            {
                webElement.SendKeys(stringArray[i].ToString());
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
        public Boolean IsElementDisplayed(IWebElement webElement, int timeout)
        {
            while (timeout>0)
            {
                if (webElement.Displayed)
                {
                    return true;
                }
                timeout--;
            }
            return false;
        }


        public IWebElement WaitUntilElementVisible(By elementLocator, int timeout)
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

        public IWebElement WaitUntilElementVisible(IWebElement webElement, int timeout)
        {
            for (int i=0; i<timeout; i++)
            {
                if (webElement.Displayed)
                {
                    return webElement;
                }
            }
            return null;
        }
    }
}
