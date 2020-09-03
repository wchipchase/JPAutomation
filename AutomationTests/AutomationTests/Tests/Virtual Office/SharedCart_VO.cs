using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.nsaonline.com;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Concurrent;
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
        ExtentHelper ExtentHelper;
        static ConcurrentDictionary<string, Driver> drivers = new ConcurrentDictionary<string, Driver>();

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ExtentHelper = new ExtentHelper();
            ExtentHelper.Setup(TestContext.CurrentContext);
        }

        [SetUp]
        public void Setup()
        {
            Driver Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Driver.WebDriver.Manage().Window.Maximize();

            drivers.TryAdd(TestContext.CurrentContext.Test.Name, Driver);

            ExtentHelper.AddTest(TestContext.CurrentContext);
        }

        [Test, Description("Shared Cart United States")]
        [Category("LegacyRegression"),Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_UnitedStates()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));
            LoginPage.Login("wddot", "wddot");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("2000", 1);
            Thread.Sleep(1000);
            SubmitCustomerJPOrderPage.AddToCart("3000", 1);
            Thread.Sleep(1000);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "140 Crescent Dr.", "38017", "9018502938", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            Assert.AreEqual(EditCartPage.GetQuanity("2000"), "1");
            Assert.AreEqual(EditCartPage.GetQuanity("3000"), "1");
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart United Kingdom")]
        [Category("LegacyRegression"),Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_UnitedKingdom()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

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
            Thread.Sleep(1000);
            SubmitCustomerJPOrderPage.AddToCart("490105050", 1);
            Thread.Sleep(1000);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "40 Heyes St.", "L5 6SG", "Liverpool", "Liverpool", "Liverpool", "07720750898", "07720750898", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            Assert.AreEqual(EditCartPage.GetQuanity("480105050"), "1");
            Assert.AreEqual(EditCartPage.GetQuanity("490105050"), "1");
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart France")]
        [Category("LegacyRegression"),Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_France()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

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
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "2 Boulevard du Levant", "93167", "Noisy-le-Grand", "N/A", "Île-de-France", "+33 1 45924747", "+33 1 45924747", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Austria")]
        [Category("LegacyRegression"),Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Austria()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

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
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Savoyenstraße 2", "1160", "Vienna", "N/A", "Vienna", "+43 1 4858503555", "+43 1 4858503555", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Belgium")]
        [Category("LegacyRegression"),Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Belgium()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

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
            // Warwick Brussels
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Rue Duquesnoy 5", "1000", "Bruxelles", "N/A", "N/A", "+32 2 505 55 55", "+32 2 505 55 55", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Denmark")]
        [Category("LegacyRegression"),Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Denmark()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

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
            // Hotel Randers
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Torvegade 11", "8900", "Randers", "N/A", "Randers", "+45 86 42 34 22", "+45 86 42 34 22", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Din ordre bliver behandlet inden for kort tid. En email blev sendt til denne adresse:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Finland")]
        [Category("LegacyRegression"),Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Finland()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Finland");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105084", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Hotel Lilla Roberts
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Pieni Roobertinkatu 1", "00130", "Helsinki", "N/A", "Helsinki", "+358 9 6899880", "+358 9 6899880", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Germany")]
        [Category("LegacyRegression"),Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Germany()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Germany");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105001", 1);
            SubmitCustomerJPOrderPage.AcceptAgreement();
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Grand Hotel Downtown
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Taunusstraße 48-50", "60329", "Frankfurt am Main", "N/A", "Frankfurt am Main", "+49 69 96869890", "+49 69 96869890", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Ireland")]
        [Category("LegacyRegression"),Category("Virtual Office"), Category("Shared Cart")]
        [Ignore("Ignore")]
        [Repeat(1)]
        public void SharedCart_VO_Ireland()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Ireland");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105050", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Hodson Bay Hotel
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Athlone Rd", "N/A", "Athlone", "Roscommon", "Roscommon", "+49 69 96869890", "+49 69 96869890", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Italy")]
        [Category("LegacyRegression"), Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Italy()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));
            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Italy");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105040", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // The Liberty Boutique Hotel
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Via Palestro, 64", "00185", "Roma", "N/A", "RM", "+39 06 495 9261", "+39 06 495 9261", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.InputCodiceFiscalInformation("TSTTST80A01A001N", "01-01-1980", "Abano Terme", "Male");
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Luxembourg")]
        [Category("LegacyRegression"), Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Luxembourg()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));
            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Luxembourg");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105036", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // ibis Styles Luxembourg Centre Gare
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "30 Rue Joseph Junck", "1839", "Luxembourg", "N/A", "N/A", "+352 49 24 96", "+352 49 24 96", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Netherlands")]
        [Category("LegacyRegression"), Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Netherlands()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Netherlands");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("480110034", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Fletcher Hotel Amsterdam
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Schepenbergweg 50", "1105 AT", "Amsterdam", "N/A", "N/A", "+31 20 311 3670", "+31 20 311 3670", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Norway")]
        [Category("LegacyRegression"), Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Norway()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Norway");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105081", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Grand Hotel Oslo
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Karl Johans gate 31", "0159", "Oslo", "N/A", "Oslo", "", "+47 23 21 20 00", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Poland")]
        [Category("LegacyRegression"), Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Poland()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Poland");
            MainPage.ChangeLanguage("en_IE");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105005", 1);
            SubmitCustomerJPOrderPage.AcceptAgreement();
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Rezydencja Luxury Hotel
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Stara 1", "41-940", "Piekary Śląskie", "N/A", "N/A", "458623422", "458623422", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Romania")]
        [Category("LegacyRegression"), Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Romania()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Romania");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490110023", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Grand Hotel Continental
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Calea Victoriei 56", "010083", "București", "N/A", "N/A", "+40 372 010 300", "+40 372 010 300", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Spain")]
        [Category("LegacyRegression"), Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Spain()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Spain");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105003", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Hotel RIU Plaza España
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "C/ Gran Vía, 84", "28013", "Madrid", "Madrid", "N/A", "+31 20 311 3670", "+31 20 311 3670", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.InputState("Madrid");
            CheckoutPage.InputNif("12345678A");
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [Test, Description("Shared Cart Sweden")]
        [Category("LegacyRegression"), Category("Virtual Office"), Category("Shared Cart")]
        [Repeat(1)]
        public void SharedCart_VO_Sweden()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

            LoginPage LoginPage = new LoginPage(Driver);
            MainPage MainPage = new MainPage(Driver);
            SubmitCustomerJPOrderPage SubmitCustomerJPOrderPage = new SubmitCustomerJPOrderPage(Driver);
            CreateCustomerCartPageJP CreateCustomerCartPageJP = new CreateCustomerCartPageJP(Driver);
            ShareModal ShareModal = new ShareModal(Driver);
            ConfirmEmailPage ConfirmEmailPage = new ConfirmEmailPage(Driver);
            EditCartPage EditCartPage = new EditCartPage(Driver);
            PageObjects.juiceplus.com.CheckoutPage CheckoutPage = new PageObjects.juiceplus.com.CheckoutPage(Driver);

            Driver.WebDriver.Navigate().GoToUrl(Driver.GetUrl("VirtualOffice"));

            String dateString = "5/1/2030 8:30:52 AM";
            DateTime date = DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);
            Cookie cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.stagecq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);
            cfCookie = new OpenQA.Selenium.Cookie("cookiesAccepted", "true", "toddwhite.us.rccq.juiceplus.com", "/", date);
            Driver.WebDriver.Manage().Cookies.AddCookie(cfCookie);

            LoginPage.Login("wddot", "wddot");
            MainPage.ChangeCountry("Sweden");
            MainPage.InitiateOrderJuicePlus();
            SubmitCustomerJPOrderPage.AddToCart("490105084", 1);
            SubmitCustomerJPOrderPage.ShareCartWithCustomer();
            // Grand Hôtel
            CreateCustomerCartPageJP.InputShippingInformation("Test", "Tester", "Södra Blasieholmshamnen 8", "103 27", "Stockholm", "N/A", "Stockholm", "+46 8 679 35 00", "+46 8 679 35 00", "test@testing.com");
            CreateCustomerCartPageJP.ShareCart();
            ShareModal.CopySharedCartLink();

            Driver.WebDriver.Navigate().GoToUrl(ShareModal.CopySharedCartLink());
            ConfirmEmailPage.VerifyEmailAddress("test@testing.com");
            Thread.Sleep(5000);
            EditCartPage.AcceptCookies();
            EditCartPage.CheckOut();
            CheckoutPage.SelectSameAddressForBilling();
            CheckoutPage.InputPaymentMethod("Visa", "4242424242424242", "02", "2022", "189");

            CheckoutPage.CompletePurchase();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your order has been received. You will receive a confirmation email shortly. Orders may ship separately.") || Driver.WebDriver.PageSource.Contains("Your order will be processed shortly. An email was sent to this address:"));
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            Driver Driver = drivers[TestContext.CurrentContext.Test.Name];

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
