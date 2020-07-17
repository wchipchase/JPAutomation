using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.canada.rccq.juiceplus.com.jp
{
    class BillingAndShipping
    {
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingPerson.firstName")]
        public IWebElement BuyNavItem { get; set; }

        /*[OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingPerson.firstName")]
        public IWebElement BuyNavItem { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingPerson.firstName")]
        public IWebElement BuyNavItem { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingPerson.firstName")]
        public IWebElement BuyNavItem { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingPerson.firstName")]
        public IWebElement BuyNavItem { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingPerson.firstName")]
        public IWebElement BuyNavItem { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingPerson.firstName")]
        public IWebElement BuyNavItem { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingPerson.firstName")]
        public IWebElement BuyNavItem { get; set; }*/
    }
}
