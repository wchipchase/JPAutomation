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
        public CreateCustomerCartPageJP()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingFirstName")]
        public IWebElement FirstNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingLastName")]
        public IWebElement LastNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "shippingAddr1")]
        public IWebElement ShippingAddressField { get; set; }

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

        public void InputShippingInformation(String firstName, String lastName, String phoneNumber, String emailAddress)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            PhoneNumberField.SendKeys(phoneNumber);
            EmailAddressField.SendKeys(emailAddress);
        }

        public void InputShippingInformation(String firstName, String lastName, String phoneNumber, String mobileNumber, String emailAddress)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
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

        public void ShareCart()
        {
            ShareCartButton.Click();
        }
    }
}