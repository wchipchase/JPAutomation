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
    class MainPage
    {
        Driver Driver;

        public MainPage(Driver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "a[id='buy-page-nav-item']")]
        public IWebElement BuyLink { get; set; }

        public void NavigateBuyPage()
        {
            Header Header = new Header(Driver);

            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(BuyLink, BuyLink.Size.Width / 2, (BuyLink.Size.Height * 75) / 100).Click().Build();
            action.Perform();

            // Header.BuyLink.Click();
        }
    }
}
