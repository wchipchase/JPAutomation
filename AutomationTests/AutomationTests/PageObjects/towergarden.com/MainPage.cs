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
    class MainPage
    {
        public MainPage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(),'Buy Your Tower Garden Now')]")]
        public IWebElement BuyTowerGardenNowButton { get; set; }

        public void NavigateBuyPage()
        {
            BuyTowerGardenNowButton.Click();
            Thread.Sleep(1000);
        }
    }
}
