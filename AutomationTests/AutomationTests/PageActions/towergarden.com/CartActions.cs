using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.towergarden.com;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutomationTests.PageActions.towergarden.com.CartActions
{
    class CartActions
    {
        public static void ZipLookup(String zip)
        {
            CartPage CartPage = new CartPage();
            CartPage.ZipCodeInput.SendKeys(zip);
            CartPage.ZipCodeEnterButton.Click();
        }

        public static void CitySelect(String cityName)
        {
            CartPage CartPage = new CartPage();
            Driver.WebDriver.SwitchTo().Frame(0);
            SelectElement CityNameSelect = new SelectElement(CartPage.CityNameSelect);
            CityNameSelect.SelectByValue(cityName);
            CartPage.ProceedButton.Click();
        }

        public static void Next()
        {
            CartPage CartPage = new CartPage();
            CartPage.NextButton.Click();
        }

        public static void StateSelect(String stateName)
        {
            CartPage CartPage = new CartPage();
            SelectElement StateNameSelect = new SelectElement(CartPage.StateNameSelect);
            StateNameSelect.SelectByValue(stateName);
        }
    }
}
