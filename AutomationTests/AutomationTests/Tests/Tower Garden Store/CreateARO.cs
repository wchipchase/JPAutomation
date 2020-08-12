using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.towergarden.com;
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

namespace AutomationTests.towergarden.com
{
    [TestFixture]
    class CreateAROTest
    {
        [ThreadStatic]
        Driver Driver;

        [ThreadStatic]
        MainPage MainPage;
        [ThreadStatic]
        BuyPage BuyPage;
        [ThreadStatic]
        CartPage CartPage;
        [ThreadStatic]
        CheckoutPage CheckoutPage;
        [ThreadStatic]
        Header Header;

        [SetUp]
        public void Setup()
        {
            Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.WebDriver.Manage().Window.Maximize();

            MainPage = new MainPage(Driver);
            BuyPage = new BuyPage(Driver);
            CartPage = new CartPage(Driver);
            CheckoutPage = new CheckoutPage(Driver);
            Header = new Header(Driver);
        }

        [Test, Description("Create ARO on US Tower Garden Store")]
        [Category("LegacyRegression")]
        [Repeat(1)]
        public void CreateARO_TG_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("TowerGardenStore", "US"));
            MainPage.NavigateBuyPage();
            BuyPage.AddToCart("GT360");
            Header.NavigateCartPage();
            CartPage.ZipLookup("38017");
            CartPage.CitySelect("0.COLLIERVILLE");
            CartPage.Next();
            CheckoutPage.InputShippingAndBillingInfo("Test", "Tester", "9018503000", "test@testing.com", "140 Crescent DR", "38017", "0.COLLIERVILLE", "TENNESSEE", "US", true, "WebAd");
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='jp-acct-block1']")));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been placed. You should receive a confirmation email shortly.") || Driver.WebDriver.PageSource.Contains("You will receive an additional e-mail when your order is shipped."));
            Thread.Sleep(5000);
        }

        [Test, Description("Create ARO on CA Tower Garden Store")]
        [Category("LegacyRegression")]
        public void CreateARO_TG_CA()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("TowerGardenStore", "CA"));
            Thread.Sleep(2000);
            MainPage.NavigateBuyPage();
            BuyPage.AddToCart("TG350CA");
            Header.NavigateCartPage();
            CartPage.StateSelect("ON");
            CartPage.Next();
            CheckoutPage.InputShippingAndBillingInfo("Test", "Tester", "9018503000", "test@testing.com", "2785 Skymark Ave", "L4W 4Y3", "Ontario", "ON", "CA", true, "WebAd");
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='jp-acct-block1']")));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been placed. You should receive a confirmation email shortly."));
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
