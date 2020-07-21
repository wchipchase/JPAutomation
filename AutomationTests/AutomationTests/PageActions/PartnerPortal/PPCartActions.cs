using AutomationTests.ConfigElements;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.NavigationsActions;
using AutomationTests.PageObjects.PartnerPortal;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.CapsulesPage;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.CartPage;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.ChewablesPage;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.OurProductsMenuItems.ChewablesPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageActions.PartnerPortal
{
    class PPCartActions
    {
        WebDriverWait waitForElement = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30));
        NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
        CapsulesPageObjects caps = new CapsulesPageObjects();
        LandingPageObjects lan = new LandingPageObjects();
        ChewablesPageObjects cpo = new ChewablesPageObjects();
        ChewablesOrderPageObjects copo = new ChewablesOrderPageObjects();
        CartPageObjects carp = new CartPageObjects();
        public static void NavigateToJuicePlusWebsite()
        {
            Driver.WebDriver.Navigate().GoToUrl("https://sculpt.staging.juiceplus.com/ie/en");
            //WebDriverWait waitForElement = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30));
            //Login lpo = new Login();
            //waitForElement.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[alt='/content/ie/juiceplus/en/portal/dashboard']")));
            //lpo.JuicePlusSiteLink.Click();
        }

        public static void AddProductsToCart()
        {
            ChewablesPageObjects cpo = new ChewablesPageObjects();
            LandingPageObjects lan = new LandingPageObjects();
            ChewablesOrderPageObjects copo = new ChewablesOrderPageObjects();
            NavigationActions.NavigateOurProductsChewablesClick();
            Task.Delay(500).Wait(1500);
            lan.CookieAlertAcceptButton.Click();
            cpo.ScrollViewport();
            cpo.ShopNowPremiumChewables.Click();
            cpo.ScrollViewport();
            copo.AddToCartOrder.Click();
            Thread.Sleep(1000);
        }

        public static void CheckoutWithItems()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            CartPageObjects carp = new CartPageObjects();
            WebDriverWait waitForElement = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30));
            waitForElement.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".m-icon-badge__counter")));
            nav.CartIconCounter.Click();
            nav.CheckoutButton.Click();
            carp.NavigateToProceedToCheckoutAndClick();
        }
    }
}
