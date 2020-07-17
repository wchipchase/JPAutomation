using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.nsanet.com
{
    class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "username")]
        public IWebElement UsernameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[value='LOGIN']")]
        public IWebElement LoginButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[value='CLEAR']")]
        public IWebElement ClearButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(),'here')]")]
        public IWebElement CasAuthFailRedirect { get; set; }

        public void Login(String username, String password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();

            if (Driver.WebDriver.PageSource.Contains("CAS Authentication failed!"))
            {
                CasAuthFailRedirect.Click();
            }
        }
    }
}
