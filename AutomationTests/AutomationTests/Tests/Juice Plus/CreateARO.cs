using AutomationTests.ConfigElements;
using AutomationTests.PageActions.juiceplus.com;
using AutomationTests.PageActions.juiceplus.com.BuyActions;
using AutomationTests.PageActions.juiceplus.com.CartActions;
using AutomationTests.PageActions.juiceplus.com.CheckoutActions;
using AutomationTests.PageActions.juiceplus.com.NavigationsActions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.juceplus.com
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
            Driver.WebDriver.Navigate().GoToUrl("https://rccq.juiceplus.com/content/JuicePlus/en.html");
            Thread.Sleep(1000);
            NavigationActions.NavigateBuyPage();
            Thread.Sleep(1000);
            BuyActions.ViewProduct("FruitVegetableBerryBlendCapsules");
            Thread.Sleep(1000);
            BuyActions.SelectPaymentType("FullPayment");
            Thread.Sleep(1000);
            BuyActions.AddToCart(1);
            Thread.Sleep(1000);
            NavigationActions.NavigateCartPage();
            Thread.Sleep(1000);
            CartActions.CheckOut();
            Thread.Sleep(1000);
            CheckoutActions.InputShippingAndBillingInfo("Test", "Tester", "9018503000", "test@testing.com", "140 Crescent DR", "38017", "0.COLLIERVILLE", "TENNESSEE", "US", true, false);
            Thread.Sleep(1000);
            CheckoutActions.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");
            Thread.Sleep(1000);
            // CheckoutActions.CompletePurchase();
            // Thread.Sleep(1000);
            // Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately."));
        }

        [Test, Category("Regression")]
        public void CreateAROCA()
        {
            Driver.WebDriver.Navigate().GoToUrl("https://canada.rccq.juiceplus.com/jp");
            Thread.Sleep(1000);
            NavigationActions.NavigateBuyPage();
            Thread.Sleep(1000);
            BuyActions.ViewProduct("FruitVegetableBerryBlendCapsules");
            Thread.Sleep(1000);
            BuyActions.SelectPaymentType("FullPayment");
            Thread.Sleep(1000);
            BuyActions.AddToCart(1);
            Thread.Sleep(1000);
            NavigationActions.NavigateCartPage();
            Thread.Sleep(1000);
            CartActions.CheckOut();
            Thread.Sleep(1000);
            CheckoutActions.InputShippingAndBillingInfo("Test", "Tester", "9018503000", "test@testing.com", "2785 Skymark Ave", "L4W 4Y3", "Ontario", "Ontario", "CA", true, false);
            Thread.Sleep(1000);
            CheckoutActions.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");
            Thread.Sleep(1000);
            // CheckoutActions.CompletePurchase();
            // Thread.Sleep(1000);
            // Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately."));
        }

        [Test, Category("Regression")]
        public void CreateAROAU()
        {
            Driver.WebDriver.Navigate().GoToUrl("https://au.rccq.juiceplus.com/jp");
            Thread.Sleep(1000);
            NavigationActions.NavigateBuyPage();
            Thread.Sleep(1000);
            BuyActions.ViewProduct("PremiumPackCapsules");
            Thread.Sleep(1000);
            BuyActions.SelectPaymentType("FullPayment");
            Thread.Sleep(1000);
            BuyActions.AddToCart(1);
            Thread.Sleep(1000);
            NavigationActions.NavigateCartPage();
            Thread.Sleep(1000);
            CartActions.CheckOut();
            Thread.Sleep(1000);
            CheckoutActions.InputShippingAndBillingInfo("Test", "Tester", "9018503000", "test@testing.com", "14 Merewether St", "2291", "Merewether", "Queensland", "AU", true, false);
            Thread.Sleep(1000);
            CheckoutActions.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");
            Thread.Sleep(1000);
            // CheckoutActions.CompletePurchase();
            // Thread.Sleep(1000);
            // Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately."));
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
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            // Driver.WebDriver.Navigate().GoToUrl(Config.Config.BaseURL);
        }
    }

}
