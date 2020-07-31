using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.towergarden.com
{
    class Header
    {
        Driver Driver;

        public Header(Driver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='topnav']//a[@class='cart_link']")]
        public IWebElement CartLink { get; set; }

        public void NavigateCartPage()
        {
            CartLink.Click();
            Thread.Sleep(1000);
        }
    }
}
