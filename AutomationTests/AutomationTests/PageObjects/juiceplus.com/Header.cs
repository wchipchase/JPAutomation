using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.juiceplus.com
{
    class Header
    {
        public Header()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.ClassName, Using = "cart")]
        public IWebElement CartLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "buy-page-nav-item")]
        public IWebElement BuyLink { get; set; }

        public void NavigateBuyPage()
        {
            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(BuyLink, BuyLink.Size.Width / 2, (BuyLink.Size.Height * 75) / 100).Click().Build();
            action.Perform();

            // Header.BuyLink.Click();
        }

        public void NavigateCartPage()
        {
            CartLink.Click();
        }
    }
}
