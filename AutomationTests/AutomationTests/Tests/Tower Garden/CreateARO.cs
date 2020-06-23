using AutomationTests.ConfigElements;
using AutomationTests.PageActions.towergarden.com.BuyActions;
using AutomationTests.PageActions.towergarden.com.CartActions;
using AutomationTests.PageActions.towergarden.com.CheckoutActions;
using AutomationTests.PageActions.towergarden.com.NavigationsActions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.towergarden.com
{
    class CreateAROTest
    {
        NavigationActions NavigationActions = new NavigationActions();
        BuyActions BuyActions = new BuyActions();
        CartActions CartActions = new CartActions();
        CheckoutActions CheckoutActions = new CheckoutActions();

        [Test, Category("Regression")]
        public void CreateAROUS()
        {
            Driver.WebDriver.Navigate().GoToUrl("https://us.rccq.towergarden.com/tg");
            Thread.Sleep(1000);
            NavigationActions.NavigateBuyPage();
            Thread.Sleep(1000);
            BuyActions.AddToCart("GT360L");
            Thread.Sleep(1000);
            NavigationActions.NavigateCartPage();
            Thread.Sleep(1000);
            CartActions.ZipLookup("38017");
            Thread.Sleep(1000);
            CartActions.CitySelect("0.COLLIERVILLE");
            Thread.Sleep(1000);
            CartActions.Next();
            Thread.Sleep(1000);
            CheckoutActions.InputShippingAndBillingInfo("Test", "Tester", "9018503000", "test@testing.com", "140 Crescent DR", "38017", "0.COLLIERVILLE", "TENNESSEE", "US", true, "WebAd");
            Thread.Sleep(1000);
            CheckoutActions.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");
            Thread.Sleep(5000);
            // CheckoutActions.CompletePurchase();
            //Thread.Sleep(1000);
            //Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately."));
        }

        [Test, Category("Regression")]
        public void CreateAROCA()
        {
            Driver.WebDriver.Navigate().GoToUrl("https://can.rccq.towergarden.ca/tg");
            Thread.Sleep(1000);
            NavigationActions.NavigateBuyPage();
            Thread.Sleep(1000);
            BuyActions.AddToCart("TG350CA");
            Thread.Sleep(1000);
            NavigationActions.NavigateCartPage();
            Thread.Sleep(1000);
            CartActions.StateSelect("ON");
            Thread.Sleep(1000);
            CartActions.Next();
            Thread.Sleep(1000);
            CheckoutActions.InputShippingAndBillingInfo("Test", "Tester", "9018503000", "test@testing.com", "2785 Skymark Ave", "L4W 4Y3", "Ontario", "ON", "CA", true, "WebAd");
            Thread.Sleep(1000);
            CheckoutActions.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");
            Thread.Sleep(5000);
            // CheckoutActions.CompletePurchase();
            //Thread.Sleep(1000);
            //Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately."));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }

        [SetUp]
        public void Setup()
        {
            Driver.InitializeDriver();
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            // Driver.WebDriver.Navigate().GoToUrl(Config.Config.BaseURL);
        }
    }

}
