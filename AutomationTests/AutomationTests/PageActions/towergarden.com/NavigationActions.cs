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

namespace AutomationTests.PageActions.towergarden.com.NavigationsActions
{
    class NavigationActions
    {
        public static void NavigateBuyPage()
        {
            MainPage MainPage = new MainPage();
            MainPage.BuyTowerGardenNowButton.Click();
        }

        public static void NavigateCartPage()
        {
            Header Header = new Header();
            Header.CartLink.Click();
        }

    }
}
