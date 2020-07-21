using AutomationTests.ConfigElements;
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
    class OrderEntryPage : BasePage
    {
        public OrderEntryPage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "dist_num")]
        public IWebElement DistributorNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[name='add_order_button']")]
        public IWebElement AddOrderButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//td[@class='menuhdr' and contains(.,'Distributor')]/parent::*/parent::*//td[@class='menusubhdr' and contains(.,'Jump')]/parent::*/parent::*//select[@name='order_country']")]
        public IWebElement DistributorJumpOrderCountrySelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "del_name")]
        public IWebElement DeliveryNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "del_addr1")]
        public IWebElement DeliveryAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[name='del_zip']")]
        public IWebElement DeliveryZipCodeField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "del_city")]
        public IWebElement DeliveryCityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "del_phone")]
        public IWebElement DeliveryPhoneNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "del_mobile")]
        public IWebElement DeliveryMobileNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "del_email")]
        public IWebElement DeliveryEmailAddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "carrier_method")]
        public IWebElement CarrierMethodSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "prod_sku_0")]
        public IWebElement SkuField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "price_type_0")]
        public IWebElement PriceTypeField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity_0")]
        public IWebElement QuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "pay_type")]
        public IWebElement PaymentTypeSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "card_num")]
        public IWebElement CreditCardNumberFieldField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "exp_date_month")]
        public IWebElement ExpirationMonthSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "exp_date_year")]
        public IWebElement ExpirationYearSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[name='update_button']")]
        public IWebElement UpdateButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[name='payment_screen_update_button']")]
        public IWebElement PaymentUpdateButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[name='payment_screen_next_button']")]
        public IWebElement PaymentNextButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[value='Finish']")]
        public IWebElement FinishOrderButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[value='Finish with Packslip Option']")]
        public IWebElement FinishOrderWithPackslipButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[value='Next']")]
        public IWebElement NextButton { get; set; }

        public void InitiateNewOrder(String countryPrefix, String distributorNumber)
        {
            SelectElement DistributorJumpOrderCountrySelectDropdown = new SelectElement(DistributorJumpOrderCountrySelect);
            DistributorJumpOrderCountrySelectDropdown.SelectByText(countryPrefix);
            DistributorNumberField.SendKeys(distributorNumber);
            AddOrderButton.Click();
        }

        public void InputDeliveryAddressInformation(String name, String address, String zip, String city, String phoneNumber, String mobileNumber, String emailAddress, String carrierMethod)
        {
            DeliveryNameField.SendKeys(name);
            DeliveryAddressField.SendKeys(address);
            DeliveryZipCodeField.SendKeys(zip);
            DeliveryCityField.SendKeys(city);
            DeliveryPhoneNumberField.SendKeys(phoneNumber);
            DeliveryMobileNumberField.SendKeys(mobileNumber);
            DeliveryEmailAddressField.SendKeys(emailAddress);
            new SelectElement(CarrierMethodSelect).SelectByText(carrierMethod);
            UpdateButton.Click();
            NextButton.Click();
        }

        public void InputProductIformation(String sku, String priceType, String quantity)
        {
            SkuField.SendKeys(sku);
            Thread.Sleep(500);
            PriceTypeField.Clear();
            PriceTypeField.SendKeys(priceType);
            QuantityField.Clear();
            QuantityField.SendKeys(quantity);
            UpdateButton.Click();
            NextButton.Click();
        }

        public void InputPaymentType(String paymentType, String creditCardNumber, String expirationMonth, String expirationYear)
        {
            if (Driver.WebDriver.PageSource.Contains("Multiple tax codes match the supplied address. Please select a tax code"))
            {
                Driver.WebDriver.FindElement(By.XPath("//a[contains(@href,'set_tax_code')]")).Click();
                UpdateButton.Click();
                NextButton.Click();
            }
            new SelectElement(PaymentTypeSelect).SelectByText(paymentType);
            CreditCardNumberFieldField.SendKeys(creditCardNumber);
            new SelectElement(ExpirationMonthSelect).SelectByText(expirationMonth);
            new SelectElement(ExpirationYearSelect).SelectByText(expirationYear);
            Thread.Sleep(999999);
            PaymentUpdateButton.Click();
            PaymentNextButton.Click();
        }

        public void FinishOrderEntry()
        {
            if (IsElementDisplayed(FinishOrderWithPackslipButton))
            {
                FinishOrderWithPackslipButton.Click();
            } else
            {
                FinishOrderButton.Click();
            }
            try
            {
                Driver.WebDriver.SwitchTo().Alert().Accept();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
