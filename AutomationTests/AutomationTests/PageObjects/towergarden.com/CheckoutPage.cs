using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.towergarden.com
{
    class CheckoutPage
    {
        Driver Driver;

        public CheckoutPage(Driver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingPerson.firstName")]
        public IWebElement FirstName { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingPerson.lastName")]
        public IWebElement LastName { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingPhone.dialNumber")]
        public IWebElement PhoneNumber { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingEmail.addrLine")]
        public IWebElement EmailAddress { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingAddress.line1")]
        public IWebElement AddressLine1 { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingAddress.postalCode")]
        public IWebElement Zip { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "chkSameAsShipping")]
        public IWebElement BillingInformationYesRadio { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "chkNotSameAsShipping")]
        public IWebElement BillingInformationNoRadio { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "rdoReferredYes")]
        public IWebElement RefferingRepInfoYesRadio { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Web Advertisement')]")]
        public IWebElement RefferingWebAdYesRadio { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "btnShippingZipLookup")]
        public IWebElement ZipLookupButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Name, Using = "city")]
        public IWebElement CitySelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[class='proceedButton']")]
        public IWebElement CitySelectProceedButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingAddress.city")]
        public IWebElement City { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderShipment.shippingAddress.state")]
        public IWebElement StateSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "selPaymentType")]
        public IWebElement CreditCardType { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderPayment.creditcardPayment.cardNumber")]
        public IWebElement CreditCardNumber { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "selExpMonth")]
        public IWebElement CreditCardExpMonth { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "selExpYear")]
        public IWebElement CreditCardExpYear { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customerOrder.orderPayment.creditcardPayment.cvv")]
        public IWebElement CreditCardCVV { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[onclick='nextStep();']")]
        public IWebElement PaymentMethodContinueButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "next-button")]
        public IWebElement PurchaseButton { get; set; }

        public void InputShippingAndBillingInfo(String firstName, String lastName, String phoneNumber, String emailAddress, String address, String zip, String city, String state, String country, Boolean sameBillingInformation, String repType)
        {
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            PhoneNumber.SendKeys(phoneNumber);
            EmailAddress.SendKeys(emailAddress);
            AddressLine1.SendKeys(address);

            if (country.Equals("US"))
            {
                ZipLookup(zip, city);
            }
            else
            {
                SelectElement StateSelectDropdown = new SelectElement(StateSelect);
                City.SendKeys(city);
                StateSelectDropdown.SelectByText(state);
                Zip.SendKeys(zip);
            }

            if (sameBillingInformation)
            {
                BillingInformationYesRadio.Click();
            }
            else
            {
                BillingInformationNoRadio.Click();
            }

            if (repType.Equals("WebAd"))
            {
                Thread.Sleep(1000);
                RefferingWebAdYesRadio.Click();
            }
        }
        public void InputPaymentMethod(String creditCardType, String creditCardNumber, String expMonth, String expYear, String cvv)
        {
            SelectElement CreditCardTypeDropdown = new SelectElement(CreditCardType);
            SelectElement CreditCardExpMonthDropdown = new SelectElement(CreditCardExpMonth);
            SelectElement CreditCardExpYearDropdown = new SelectElement(CreditCardExpYear);

            CreditCardTypeDropdown.SelectByText(creditCardType);
            CreditCardNumber.SendKeys(creditCardNumber);
            CreditCardExpMonthDropdown.SelectByValue(expMonth);
            CreditCardExpYearDropdown.SelectByValue(expYear);

            double initialImplicitWaitTime = Driver.WebDriver.Manage().Timeouts().ImplicitWait.TotalSeconds;
            try
            {
                Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                CreditCardCVV.SendKeys(cvv);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(initialImplicitWaitTime);
            }

            PaymentMethodContinueButton.Click();
        }

        public void CompletePurchase()
        {
            PurchaseButton.Click();
        }
        public void ZipLookup(String zip, String city)
        {
            Zip.Clear();
            Zip.SendKeys(zip);
            ZipLookupButton.Click();

            Thread.Sleep(1000);
            Driver.WebDriver.SwitchTo().Frame(0);

            SelectElement CitySelectDropdown = new SelectElement(CitySelect);
            CitySelectDropdown.SelectByValue(city);
            CitySelectProceedButton.Click();
            Driver.WebDriver.SwitchTo().ParentFrame();
        }
    }
}
