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
    class BuyPage
    {
        public BuyPage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "button[data-sku='GT360L']")]
        public IWebElement TowerGardenHomeAddToCart { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "button[data-sku='TG350CA']")]
        public IWebElement TowerGardenGrowingSystemAddToCart { get; set; }

    }
}
