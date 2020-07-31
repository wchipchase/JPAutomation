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

namespace AutomationTests.PageObjects.towergarden.com
{
    class CartPage
    {
        Driver Driver;

        public CartPage(Driver driver)
        {
            Driver = driver;
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

        public void ZipLookup(String zip)
        {
            ZipCodeInput.SendKeys(zip);
            ZipCodeEnterButton.Click();
        }

        public void CitySelect(String cityName)
        {
            Driver.WebDriver.SwitchTo().Frame(0);
            new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(CityNameSelect));
            SelectElement CityNameSelectDropdown = new SelectElement(CityNameSelect);
            CityNameSelectDropdown.SelectByValue(cityName);
            ProceedButton.Click();
        }

        public void Next()
        {
            NextButton.Click();
        }

        public void StateSelect(String stateName)
        {
            SelectElement StateNameSelectDropdown = new SelectElement(StateNameSelect);
            StateNameSelectDropdown.SelectByValue(stateName);
        }
    }
}
