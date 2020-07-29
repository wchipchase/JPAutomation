﻿using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.PartnerPortal
{
    class Login
    {
        public Login()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='Sign In']")]
        public IWebElement LoginButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "[for='input-toggle-option1--145546684']")]
        public IWebElement LoginSlider { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "[for='input-toggle-option2--145546684']")]
        public IWebElement PartnerLoginSlider { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Name, Using = "username")]
        public IWebElement UsernameTextBox { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Name, Using = "password")]
        public IWebElement PasswordTextBox { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "[for='rememberMe']")]
        public IWebElement PRememberMeCheckbox { get; set; }


        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//button[@class='a-button a-button--full-width a-button--primary js-form__submit a-button--large']/span[@class='a-button__inner']")]
        public IWebElement SignInBtn { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[contains(.,'Create an account')]")]
        public IWebElement CreateAccountBtn { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='Dashboard']")]
        public IWebElement DashboardNavTab { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'Team')]")]
        public IWebElement TeamNavTab { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='Customers']")]
        public IWebElement CustomersNavTab { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='Shop']")]
        public IWebElement ShopNavTab { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "[alt='/content/ie/juiceplus/en/portal/dashboard']")]
        public IWebElement JuicePlusSiteLink { get; set; }
    }
}
