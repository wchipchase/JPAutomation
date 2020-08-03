using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.nsaonline.com;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.rc.nsaonline
{
    [TestFixture]
    class SharedCartVOTest
    {
        [ThreadStatic]
        static Driver Driver;

        [ThreadStatic]
        static LoginPage LoginPage;
        [ThreadStatic]
        static MainPage MainPage;
        [ThreadStatic]
        static SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage;
        [ThreadStatic]
        static CreateCustomerCartPageJP CreateCustomerCartPageJP;
        [ThreadStatic]
        static ShareModal ShareModal;
        [ThreadStatic]
        static ConfirmEmailPage ConfirmEMailPage;
        [ThreadStatic]
        static EditCartPage EditCartPage;
        [ThreadStatic]
        static PageObjects.juiceplus.com.CheckoutPage CheckoutPage;

        [SetUp]
        public void Setup()
        {
            Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.WebDriver.Manage().Window.Maximize();

            LoginPage = new LoginPage(Driver);
            MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal = new ShareModal(Driver);
            ConfirmEMailPage = new ConfirmEmailPage(Driver);
            EditCartPage = new EditCartPage(Driver);
            CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);
        }

        [Test, Category("LegacyRegression"), Category("Virtual Office"), Description("Shared Cart US."), Repeat(1)]
        public void SharedCart_VO_US()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));
            LoginPage.Login("wddot", "wddot");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("2000", 1);
            SubmitCustomerJPOrderPage.AddToCart("3000", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "140 Crescent Dr.", "38017", "9018502938", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEMailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(1000);
            Assert.AreEqual(EditCartPage.GetQuanity("2000"), "1");
            Assert.AreEqual(EditCartPage.GetQuanity("3000"), "1");
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='jp-acct-block1']")));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Category("LegacyRegression"), Category("Virtual Office"), Description("Shared Cart UK"), Repeat(1)]
        public void SharedCart_VO_UK()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "uk.devcq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "uk.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "uk.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("United kingdom");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("480105050", 1);
            SubmitCustomerJPOrderPage.AddToCart("490105050", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "40 Heyes St.", "L5 6SG", "Liverpool", "Liverpool", "Liverpool", "07720750898", "07720750898", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEMailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(1000);
            Assert.AreEqual(EditCartPage.GetQuanity("480105050"), "1");
            Assert.AreEqual(EditCartPage.GetQuanity("490105050"), "1");
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='jp-acct-block1']")));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
