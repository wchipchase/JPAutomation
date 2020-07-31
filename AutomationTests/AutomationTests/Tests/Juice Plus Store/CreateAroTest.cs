using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.juiceplus.com;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.juiceplus.com
{
    [TestFixture]
    class CreateAroTest
    {
        Driver Driver;

        BuyPage BuyPage;
        CartPage CartPage;
        CheckoutPage CheckoutPage;
        Header Header;

        [SetUp]
        public void Setup()
        {
            Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.WebDriver.Manage().Window.Maximize();

            BuyPage = new BuyPage(Driver);
            CartPage = new CartPage(Driver);
            CheckoutPage = new CheckoutPage(Driver);
            Header = new Header(Driver);
        }

        [Test, Category("LegacyRegression"), Description("Create ARO on US Juice Plus Store"), Repeat(1)]
        public void CreateARO_JP_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("JuicePlusStore", "US"));
            Header.NavigateBuyPage();
            BuyPage.ViewProduct("FruitVegetableBerryBlendCapsules");
            BuyPage.SelectPaymentType("FullPayment");
            BuyPage.AddToCart(1);
            Header.NavigateCartPage();
            CartPage.CheckOut();
            CheckoutPage.InputShippingAndBillingInfo("Test", "Tester", "9018503000", "test@juiceplus.com", "140 Crescent DR", "38017", "0.COLLIERVILLE", "TENNESSEE", "US", true, false);
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");
            
            CheckoutPage.CompletePurchase();
            new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='jp-acct-block1']")));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Category("LegacyRegression"), Description("Create ARO on CA Juice Plus Store"), Repeat(1)]
        public void CreateARO_JP_CA()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("JuicePlusStore", "CA"));
            Header.NavigateBuyPage();
            BuyPage.ViewProduct("FruitVegetableBerryBlendCapsules");
            BuyPage.SelectPaymentType("FullPayment");
            BuyPage.AddToCart(1);
            Header.NavigateCartPage();
            CartPage.CheckOut();
            CheckoutPage.InputShippingAndBillingInfo("Test", "Tester", "9018503000", "test@testing.com", "2785 Skymark Ave", "L4W 4Y3", "Ontario", "Ontario", "CA", true, false);
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='jp-acct-block1']")));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately."));
            Thread.Sleep(5000);
        }

        [Test, Category("LegacyRegression"), Description("Create ARO on AU Juice Plus Store"), Repeat(1)]
        public void CreateARO_JP_AU()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("JuicePlusStore", "AU"));
            Header.NavigateBuyPage();
            BuyPage.ViewProduct("PremiumPackCapsules");
            BuyPage.SelectPaymentType("FullPayment");
            BuyPage.AddToCart(1);
            Header.NavigateCartPage();
            CartPage.CheckOut();
            CheckoutPage.InputShippingAndBillingInfo("Test", "Tester", "9018503000", "test@testing.com", "14 Merewether St", "2291", "Merewether", "Queensland", "AU", true, false);
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='jp-acct-block1']")));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately."));
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
