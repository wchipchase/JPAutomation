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
    class AroMaintenancePage
    {
        public AroMaintenancePage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quickJump1")]
        public IWebElement AroNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "select[name = 'form_country']")]
        public IWebElement CountrySelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(),'Next Delivery')]")]
        public IWebElement NextDeliveryLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(),'Name / Address')]")]
        public IWebElement NameAddressLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(),'Credit Card')]")]
        public IWebElement CreditCardLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(),'Payment Plan')]")]
        public IWebElement PaymentPlanLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(),'Product')]")]
        public IWebElement ProductLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(),'Cancel ARO')]")]
        public IWebElement CancelAroLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(text(),'Process ARO')]")]
        public IWebElement ProcessAroLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[value='Next Ship ASAP']")]
        public IWebElement NextShipAsapButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_comment")]
        public IWebElement CommentCodeSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_comment_text")]
        public IWebElement CommentCodeTextField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "input[value='Update']")]
        public IWebElement UpdateButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_cust_last_name")]
        public IWebElement LastNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_cust_addr_1")]
        public IWebElement AddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_cust_phone")]
        public IWebElement PhoneNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_cust_mobile")]
        public IWebElement MobileNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_payment_type")]
        public IWebElement PaymentTypeSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_credit_card_num")]
        public IWebElement AccountNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_routing_num")]
        public IWebElement RoutingNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_credit_card_exp_date_month")]
        public IWebElement ExpirationMonthSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_credit_card_exp_date_year")]
        public IWebElement ExpirationYearSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_cvc_number")]
        public IWebElement CvvNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_payment_plan")]
        public IWebElement PaymentPlanSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "existing_quantity_0")]
        public IWebElement ExistingQuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_cancel_type")]
        public IWebElement CancelTypeSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "new_status_reason_code")]
        public IWebElement StatusReasonCodeSelect { get; set; }

        public void ViewAro(String aroNumber)
        {
            AroNumberField.SendKeys(aroNumber);
            AroNumberField.SendKeys(Keys.Enter);
        }

        public void SelectCountry(String countryCode)
        {
            SelectElement SelectCountry = new SelectElement(CountrySelect);
            SelectCountry.SelectByText(countryCode);
        }

        public void ProcessAro()
        {
            ProcessAroLink.Click();
            Driver.WebDriver.SwitchTo().Alert().Accept();
        }

        public void EditNextDelivery(String commentCode, String commentText)
        {
            NextDeliveryLink.Click();;
            NextShipAsapButton.Click();
            InputComments(commentCode, commentText);
            UpdateButton.Click();
        }

        public void EditNameAddress(String newLastName, String newAddress, String newPhoneNumber, String newMobileNumber, String commentCode, String commentText)
        {
            NameAddressLink.Click();
            LastNameField.Clear();
            LastNameField.SendKeys(newLastName);
            AddressField.Clear();
            AddressField.SendKeys(newAddress);
            PhoneNumberField.Clear();
            PhoneNumberField.SendKeys(newPhoneNumber);
            MobileNumberField.Clear();
            MobileNumberField.SendKeys(newMobileNumber);
            InputComments(commentCode, commentText);
            UpdateButton.Click();
        }

        public void EditCreditCardInfo(String paymentType, String accountNumber, String cvvNumber, String routingNumber, String commentCode, String commentText)
        {
            CreditCardLink.Click();
            new SelectElement(PaymentTypeSelect).SelectByText(paymentType);
            AccountNumberField.Clear();
            AccountNumberField.SendKeys(accountNumber);
            if (!cvvNumber.Equals("N/A"))
            {
                CvvNumberField.Clear();
                CvvNumberField.SendKeys(cvvNumber);
            }
            if (!routingNumber.Equals("N/A"))
            {
                RoutingNumberField.Clear();
                RoutingNumberField.SendKeys(routingNumber);
            }
            InputComments(commentCode, commentText);
            UpdateButton.Click();
        }

        public void EditPaymentPlan(String PaymentPlanType, String commentCode, String commentText)
        {
            PaymentPlanLink.Click();
            new SelectElement(PaymentPlanSelect).SelectByText(PaymentPlanType);
            InputComments(commentCode, commentText);
            UpdateButton.Click();
        }

        public void EditProductInformation(String newQuantity, String commentCode, String commentText)
        {
            ProductLink.Click();
            ExistingQuantityField.Clear();
            ExistingQuantityField.SendKeys(newQuantity);
            InputComments(commentCode, commentText);
            UpdateButton.Click();
        }

        public void CancelAro(String cancelType, String statusReasonCode, String commentCode, String commentText)
        {
            CancelAroLink.Click();
            new SelectElement(CancelTypeSelect).SelectByText(cancelType);
            new SelectElement(StatusReasonCodeSelect).SelectByText(statusReasonCode);
            InputComments(commentCode, commentText);
            UpdateButton.Click();
        }

        public void InputComments(String commentCode, String commentText)
        {
            new SelectElement(CommentCodeSelect).SelectByText(commentCode);
            CommentCodeTextField.SendKeys(commentText);
        }
    }
}
