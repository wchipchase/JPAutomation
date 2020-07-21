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
        public LoginPage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "txtUsername")]
        public IWebElement username { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "txtPassword")]
        public IWebElement password { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "button[type = 'submit']")]
        public IWebElement signInButton { get; set; }

        public static void Login(String username, String password)
        {
            LoginPage loginPage = new LoginPage();

            loginPage.username.SendKeys(username);
            loginPage.password.SendKeys(password);
            loginPage.signInButton.Click();
        }
    }
}
