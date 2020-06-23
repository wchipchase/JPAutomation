using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.towergarden.com
{
    class CartPage
    {
        public CartPage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingAddress.postalCode")]
        public IWebElement ZipCodeInput { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "btnZipLookup")]
        public IWebElement ZipCodeEnterButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "select[name='city']")]
        public IWebElement CityNameSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingAddress.state")]
        public IWebElement StateNameSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[class='proceedButton']")]
        public IWebElement ProceedButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "next-button")]
        public IWebElement NextButton { get; set; }

    }
}
