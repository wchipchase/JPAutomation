using AutomationTests.ConfigElements;
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
    class LoginPage
    {
        Driver Driver;
        public LoginPage(Driver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "txtUsername")]
        public IWebElement UsernameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "txtPassword")]
        public IWebElement PasswordField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "button[type = 'submit']")]
        public IWebElement SignInButton { get; set; }

        public void Login(String username, String password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            SignInButton.Click();
        }
    }
}
