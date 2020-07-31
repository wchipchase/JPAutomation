using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.nsaonline.com
{
    class CheckoutPage : BasePage
    {
        Driver Driver;

        public CheckoutPage(Driver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingFirstName")]
        public IWebElement FirstNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingLastName")]
        public IWebElement LastNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingAddr1")]
        public IWebElement ShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingZip")]
        public IWebElement ShippingZipField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingCity")]
        public IWebElement ShippingCityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingState")]
        public IWebElement ShippingStateSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "btnShippingZipLookup")]
        public IWebElement ShippingZipLookupButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "selCityLookup")]
        public IWebElement ZipLookupModalCitySelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "btnSelectCity")]
        public IWebElement ZipLookupModalSelectButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingPhoneNum")]
        public IWebElement PhoneNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingEmail")]
        public IWebElement EmailAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shareCartBtn")]
        public IWebElement ShareCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shareCarAndSaveAddresstBtn")]
        public IWebElement ShareCartAndSaveAddressButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "sameBilling")]
        public IWebElement UseSameAddressCheckbox { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "selPaymentType")]
        public IWebElement PaymentMethodSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "cardNumber")]
        public IWebElement CardNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "expMonth")]
        public IWebElement ExpirationMonthSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "expYear")]
        public IWebElement ExpirationYearSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "btnSubmit")]
        public IWebElement ContinueButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "btnProcess")]
        public IWebElement ProcessOrderButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "orderNumber")]
        public IWebElement OrderNumberText { get; set; }

        public void InputShippingInformation(String firstName, String lastName, String address, String zip, String phoneNumber, String emailAddress)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            ShippingAddressField.SendKeys(address);
            ZipLookup(zip);
            PhoneNumberField.SendKeys(phoneNumber);
            EmailAddressField.SendKeys(emailAddress);
        }

        public void InputShippingInformation(String firstName, String lastName, String address, String zip, String city, String state, String phoneNumber, String emailAddress)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            ShippingAddressField.SendKeys(address);
            ShippingZipField.SendKeys(zip);
            ShippingCityField.SendKeys(city);
            new SelectElement(ShippingStateSelect).SelectByText(state);
            PhoneNumberField.SendKeys(phoneNumber);
            EmailAddressField.SendKeys(emailAddress);
        }

        public void InputPaymentInformation(String paymentType, String cardNumber, String expirationMonth, String expirationYear)
        {
            new SelectElement(PaymentMethodSelect).SelectByText(paymentType);
            CardNumberField.SendKeys(cardNumber);
            new SelectElement(ExpirationMonthSelect).SelectByText(expirationMonth);
            new SelectElement(ExpirationYearSelect).SelectByText(expirationYear);
        }

        public void ShareCart()
        {
            ShareCartButton.Click();
        }

        public void UseShippingAddressForBilling()
        {
            UseSameAddressCheckbox.Click();
        }

        public void ContinueOrder()
        {
            ContinueButton.Click();
        }

        public void ProcessOrder()
        {
            ProcessOrderButton.Click();
        }

        public void ZipLookup(String zip)
        {
            ShippingZipField.SendKeys(zip);
            ShippingZipLookupButton.Click();
            ZipLookupModalSelectButton.Click();
        }

        public String GetOrderNumber()
        {
            return OrderNumberText.Text;
        }
    }
}