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
    [TestFixture, Parallelizable(ParallelScope.All)]
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

        ExtentHelper ExtentHelper;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ExtentHelper = new ExtentHelper();
            ExtentHelper.Setup(TestContext.CurrentContext);
        }

        [SetUp]
        public void Setup()
        {
            Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.WebDriver.Manage().Window.Maximize();

            LoginPage = new LoginPage(Driver);
            MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal = new ShareModal(Driver);
            ConfirmEMailPage = new ConfirmEmailPage(Driver);
            EditCartPage = new EditCartPage(Driver);
            CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            ExtentHelper.AddTest(TestContext.CurrentContext);
        }

        [Test, Description("Shared Cart US.")]
        [Category("LegacyRegression"), Category("Virtual Office")]
        [Repeat(1)]
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
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
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

        [Test, Description("Shared Cart UK")]
        [Category("LegacyRegression"), Category("Virtual Office")]
        [Repeat(1)]
        public void SharedCart_VO_UK()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
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
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
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

        [Test, Description("Shared Cart France")]
        [Category("LegacyRegression"), Category("Virtual Office")]
        [Repeat(1)]
        public void SharedCart_VO_France()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("France");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105030", 1);
            SubmitCustomerJPOrderPage.AcceptAgreement();
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Holiday Inn Paris - Marne la Vallee
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "2 Boulevard du Levant", "93167", "Noisy-le-Grand", "Île-de-France", "+33 1 45924747", "+33 1 45924747", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEMailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='jp-acct-block1']")));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Austria")]
        [Category("LegacyRegression"), Category("Virtual Office")]
        [Repeat(1)]
        public void SharedCart_VO_Austria()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Austria");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105001", 1);
            SubmitCustomerJPOrderPage.AcceptAgreement();
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Austria Trend Hotel Schloss Wilhelminenberg
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Savoyenstraße 2", "1160", "Vienna", "Vienna", "+43 1 4858503555", "+43 1 4858503555", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEMailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='jp-acct-block1']")));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Belgium")]
        [Category("LegacyRegression"), Category("Virtual Office")]
        [Repeat(1)]
        public void SharedCart_VO_Belgium()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Belgium");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("480110034", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Austria Trend Hotel Schloss Wilhelminenberg
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Rue Duquesnoy 5", "1000", "Bruxelles", "+32 2 505 55 55", "+32 2 505 55 55", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEMailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='jp-acct-block1']")));
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Denmark")]
        [Category("LegacyRegression"), Category("Virtual Office")]
        [Repeat(1)]
        public void SharedCart_VO_Denmark()
        {
            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Denmark");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105080", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Austria Trend Hotel Schloss Wilhelminenberg
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Torvegade 11", "8900", "Randers", "Randers", "+45 86 42 34 22", "+45 86 42 34 22", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEMailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.SelectLanguage("English");
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
            ExtentHelper.LogTest(TestContext.CurrentContext, Driver);
            Driver.Teardown();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentHelper.Flush();
        }
    }

}
