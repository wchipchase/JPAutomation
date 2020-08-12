using AutomationTests.ConfigElements;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.nsanet.com
{
    class AroEntryPage : BasePage
    {
        Driver Driver;

        public AroEntryPage(Driver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Up to Web Portal')]")]
        public IWebElement UpToWebPortalLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "select[name='country']")]
        public IWebElement CountrySelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[value = 'New ARO']")]
        public IWebElement NewAroButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "distributorNumber")]
        public IWebElement DistributorNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[value = 'Continue']")]
        public IWebElement ContinueButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "ship_name_first")]
        public IWebElement FirstNameShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "ship_name_last")]
        public IWebElement LastNameShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "ship_addr_1")]
        public IWebElement AddressShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "ship_city")]
        public IWebElement CityShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "ship_state")]
        public IWebElement StateShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "ship_zip")]
        public IWebElement ZipShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[name='ship_button']")]
        public IWebElement ZipLookupButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "ship_phone")]
        public IWebElement PhoneNumberShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "ship_mobile")]
        public IWebElement MobileNumberShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "ship_email")]
        public IWebElement EmailAddressShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "dob")]
        public IWebElement DateOfBirthShippingAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[name='same_as_ship']")]
        public IWebElement SameBillingAndShippingAddressCheckbox { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "payment_type")]
        public IWebElement PaymentTypeSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "account_num")]
        public IWebElement AccountNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "expir_date_month")]
        public IWebElement ExpirationMonthDropdown { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "expir_date_year")]
        public IWebElement ExpirationYearDropdown { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "qt2000")]
        public IWebElement JuicePlusCapsulesQuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "qt2000CA")]
        public IWebElement JuicePlusCapsulesCAQuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "qt2000AS")]
        public IWebElement JuicePlusCapsulesASQuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "sku0")]
        public IWebElement SkuInputField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[name='update']")]
        public IWebElement UpdateButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[value = 'Finished']")]
        public IWebElement FinishedButton { get; set; }

        public void NavigateToWebPortal()
        {
            UpToWebPortalLink.Click();
        }

        public void InitiateNewAro(String countryPrefix)
        {
            SelectElement CountrySelectDropdown = new SelectElement(CountrySelect);
            CountrySelectDropdown.SelectByText(countryPrefix);
            NewAroButton.Click();
        }

        public void InputBasicInformation(String distributorNumber)
        {
            DistributorNumberField.SendKeys(distributorNumber);
            ContinueButton.Click();
        }

        public void ZipLookup(String zip, String city)
        {
            ZipShippingAddressField.SendKeys(zip);
            ZipLookupButton.Click();
            Driver.WebDriver.SwitchTo().Window(Driver.WebDriver.WindowHandles[1]);
            Thread.Sleep(1000);
            Driver.WebDriver.FindElement(By.XPath("//input[@type='checkbox' and contains(@onclick," + city + ")]")).Click();
            Driver.WebDriver.FindElement(By.XPath("//td[contains(text()," + city + ")]/..//input[@type='checkbox']")).Click();
            Driver.WebDriver.SwitchTo().Window(Driver.WebDriver.WindowHandles[0]);
        }

        public void InputAdrressInformation(String firstName, String lastName, String address, String zip, String city, String phoneNumber, String mobileNumber, String emailAddress)
        {
            SendKeysSlowly(FirstNameShippingAddressField, firstName);
            SendKeysSlowly(LastNameShippingAddressField, lastName);
            SendKeysSlowly(AddressShippingAddressField, address);
            SendKeysSlowly(PhoneNumberShippingAddressField, phoneNumber);
            SendKeysSlowly(MobileNumberShippingAddressField, mobileNumber);
            SendKeysSlowly(EmailAddressShippingAddressField, emailAddress);
            ZipLookup(zip, city);
            ContinueButton.Click();
        }

        public void InputAdrressInformation(String firstName, String lastName, String address, String zip, String city, String state, String phoneNumber, String mobileNumber, String emailAddress, String dob)
        {
            SendKeysSlowly(FirstNameShippingAddressField, firstName);
            SendKeysSlowly(LastNameShippingAddressField, lastName);
            SendKeysSlowly(AddressShippingAddressField, address);
            SendKeysSlowly(ZipShippingAddressField, zip);
            SendKeysSlowly(CityShippingAddressField, city);
            SendKeysSlowly(StateShippingAddressField, state);
            SendKeysSlowly(PhoneNumberShippingAddressField, phoneNumber);
            SendKeysSlowly(MobileNumberShippingAddressField, mobileNumber);
            SendKeysSlowly(EmailAddressShippingAddressField, emailAddress);
            SendKeysSlowly(DateOfBirthShippingAddressField, dob);
            ContinueButton.Click();
        }

        public void InputPaymentInformation(String paymentType, String accountNumber, String expirationMonth, String expirationYear)
        {
            SelectElement paymentTypeDropdown = new SelectElement(PaymentTypeSelect);
            SelectElement expirationMonthDropdown = new SelectElement(ExpirationMonthDropdown);
            SelectElement expirationYearDropdown = new SelectElement(ExpirationYearDropdown);

            SameBillingAndShippingAddressCheckbox.Click();
            paymentTypeDropdown.SelectByText(paymentType);
            Thread.Sleep(500);
            AccountNumberField.SendKeys(accountNumber);
            Thread.Sleep(500);
            expirationMonthDropdown.SelectByText(expirationMonth);
            expirationYearDropdown.SelectByText(expirationYear);
            ContinueButton.Click();
            if (Driver.WebDriver.PageSource.Contains("Please Verify this ARO is not a Duplicate"))
            {
                ContinueButton.Click();
            }
        }

        public void InputProductInformation(String sku, int quantity)
        {
            if (sku.Equals("2000"))
            {
                if (!IsElementDisplayed(JuicePlusCapsulesQuantityField))
                {
                    SkuInputField.SendKeys(sku);
                    UpdateButton.Click();
                }

                JuicePlusCapsulesQuantityField.Clear();
                JuicePlusCapsulesQuantityField.SendKeys("" + quantity);
            } else if (sku.Equals("2000CA"))
            {
                if (!IsElementDisplayed(JuicePlusCapsulesCAQuantityField))
                {
                    SkuInputField.SendKeys(sku);
                    UpdateButton.Click();
                }

                JuicePlusCapsulesCAQuantityField.Clear();
                JuicePlusCapsulesCAQuantityField.SendKeys("" + quantity);
            } else if (sku.Equals("2000AS"))
            {
                if (!IsElementDisplayed(JuicePlusCapsulesASQuantityField))
                {
                    SkuInputField.SendKeys(sku);
                    UpdateButton.Click();
                }

                JuicePlusCapsulesASQuantityField.Clear();
                JuicePlusCapsulesASQuantityField.SendKeys("" + quantity);
            }
            else
            {
                throw new Exception("Invalid Product Code.");
            }

            UpdateButton.Click();
            ContinueButton.Click();
        }

        public void SubmitAro()
        {
            FinishedButton.Click();
        }

        public void CreateUSAro()
        {
            InitiateNewAro("USA");
            InputBasicInformation("USM0025620");
            InputAdrressInformation("test", "tester", "140 Crescent Dr.", "38017", "COLLIERVILLE", "9018593000", "9018503000", "test@testing.com");
            InputPaymentInformation("Visa", "4242424242424242", "12", "25");
            InputProductInformation("2000", 1);
            SubmitAro();
        }

        public void CreateCAAro()
        {
            InitiateNewAro("CAN");
            InputBasicInformation("USM0025620");
            InputAdrressInformation("test", "tester", "2785 Skymark Ave", "L4W 4Y3", "Mississauga", "ON", "9056246368", "9056246368", "test@testing.com", "121290");
            InputPaymentInformation("American Express", "374500262001008", "01", "25");
            InputProductInformation("2000CA", 1);
            SubmitAro();
        }

        public void CreateAUAro()
        {
            InitiateNewAro("AU");
            InputBasicInformation("USM0025620");
            InputAdrressInformation("test", "tester", "14 Merewether St", "2291", "Merewether", "QLD", "0294963000", "0412345678", "test@testing.com", "121290");
            InputPaymentInformation("Visa", "4242424242424242", "01", "25");
            InputProductInformation("2000AS", 1);
            SubmitAro();
        }
    }
}
