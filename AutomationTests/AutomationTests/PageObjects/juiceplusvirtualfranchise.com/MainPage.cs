using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.juiceplusvirtualfranchise.com
{
    class MainPage
    {
        Driver Driver;

        public MainPage(Driver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'Join Our Mission')]")]
        public IWebElement JoinOurMissionLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'The Juice Plus+ Business')]")]
        public IWebElement TheJuicePlusBusinessLink { get; set; }

        public void ClickWithCondition(IWebElement webElement, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(Driver.WebDriver, timeout);
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement)).Click();
        }

        public void NavigateToEnrollmentPage()
        {
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(TheJuicePlusBusinessLink, TheJuicePlusBusinessLink.Size.Width / 2, (TheJuicePlusBusinessLink.Size.Height * 75) / 100).Build().Perform();
            ClickWithCondition(JoinOurMissionLink, TimeSpan.FromSeconds(5));
        }
    }
}
