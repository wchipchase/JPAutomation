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

namespace AutomationTests.PageActions.rc.nsaonline.LoginActions
{
    class LoginActions
    {
        
        public static void Login(String username, String password)
        {
            LoginPage loginPage = new LoginPage();

            loginPage.username.SendKeys(username);
            loginPage.password.SendKeys(password);
            loginPage.signInButton.Click();
        }
    }
}
