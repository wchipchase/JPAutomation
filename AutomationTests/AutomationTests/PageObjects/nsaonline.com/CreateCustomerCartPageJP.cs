using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.nsaonline.com
{
    class CreateCustomerCartPageJP : BasePage
    {
        Driver Driver;

        public CreateCustomerCartPageJP(Driver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingFirstName")]
        public IWebElement FirstNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingLastName")]
        public IWebElement LastNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingAddr1")]
        public IWebElement ShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingZip")]
        public IWebElement ShippingZipField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "btnShippingZipLookup")]
        public IWebElement ZipLookupButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "btnSelectCity")]
        public IWebElement ZipLookupModalSelectButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingCity")]
        public IWebElement ShippingCityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingCounty")]
        public IWebElement ShippingCountyField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingState")]
        public IWebElement ShippingStateField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingPhoneNum")]
        public IWebElement PhoneNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingPhone2Num")]
        public IWebElement MobileNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingEmail")]
        public IWebElement EmailAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shareCartBtn")]
        public IWebElement ShareCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shareCarAndSaveAddresstBtn")]
        public IWebElement ShareCartAndSaveAddressButton { get; set; }

        public void InputShippingInformation(String firstName, String lastName, String address, String zip, String phoneNumber, String emailAddress)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            ShippingAddressField.SendKeys(address);
            ZipLookup(zip);
            PhoneNumberField.SendKeys(phoneNumber);
            EmailAddressField.SendKeys(emailAddress);
        }

        public void InputShippingInformation(String firstName, String lastName, String address, String zip, String city, String county, String state, String phoneNumber, String mobileNumber, String emailAddress)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            ShippingAddressField.SendKeys(address);
            ShippingZipField.SendKeys(zip);
            ShippingCityField.SendKeys(city);
            ShippingCountyField.SendKeys(county);
            ShippingStateField.SendKeys(state);
            PhoneNumberField.SendKeys(phoneNumber);
            MobileNumberField.SendKeys(mobileNumber);
            EmailAddressField.SendKeys(emailAddress);
        }

        public void InputPaymentInformation(String firstName, String lastName, String phoneNumber, String emailAddress)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            PhoneNumberField.SendKeys(phoneNumber);
            EmailAddressField.SendKeys(emailAddress);
        }

        public void ZipLookup(String zip)
        {
            ShippingZipField.SendKeys(zip);
            ZipLookupButton.Click();
            ZipLookupModalSelectButton.Click();
        }

        public void ShareCart()
        {
            ShareCartButton.Click();
        }
    }
}