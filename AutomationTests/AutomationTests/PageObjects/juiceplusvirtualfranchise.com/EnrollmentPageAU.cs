﻿using AutomationTests.ConfigElements;
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

namespace AutomationTests.PageObjects.juiceplusvirtualfranchise.com
{
    class EnrollmentPageAU
    {
        Driver Driver;

        public EnrollmentPageAU(Driver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "memberSSN")]
        public IWebElement SsnField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "memberFirstName")]
        public IWebElement FirstNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "memberMiddleName")]
        public IWebElement MiddleNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "memberLastName")]
        public IWebElement LastNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "memberGender")]
        public IWebElement GenderSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "memberDOBMonth")]
        public IWebElement BirthMonthSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "memberDOBDay")]
        public IWebElement BirthDaySelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "memberDOBYear")]
        public IWebElement BirthYearSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "address1")]
        public IWebElement AddressField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "city")]
        public IWebElement CityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "state")]
        public IWebElement StateField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "zipCode")]
        public IWebElement ZipField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "telHome")]
        public IWebElement ContactPhoneNumber { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "confirmEmail")]
        public IWebElement ConfirmEmailField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='rdoReferredYes']//parent::label")]
        public IWebElement ReferredYesRadioButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='rdoReferredNo']//parent::label")]
        public IWebElement ReferredNoRadioButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "sponsorName")]
        public IWebElement ReferredByNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "sponsorPhoneNum")]
        public IWebElement ReferredByPhoneField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "paymentType")]
        public IWebElement PaymentTypeSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "cardNumber")]
        public IWebElement CreditCardNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "expMonth")]
        public IWebElement CreditCardExpirationMonth { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "expYear")]
        public IWebElement CreditCardExpirationYear { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "ccAddresCheck")]
        public IWebElement BillingAddressSameButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "eftbankAccountNumber")]
        public IWebElement BankAccountNumberField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "eftbankCode")]
        public IWebElement BankStateBranchCodeField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "eftbankName")]
        public IWebElement BankNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "eftbankAccountName")]
        public IWebElement AccountNameField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//label[contains(.,'I Agree')]")]
        public IWebElement AgreeButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "button[style='background: rgb(234, 234, 234);']")]
        public IWebElement MinimizeFeedbackBoxButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[class='buttonPrevious']")]
        public IWebElement PreviousButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[class='buttonNext']")]
        public IWebElement NextButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a[class='buttonFinish']")]
        public IWebElement SubmitButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//p[contains(text(),'New Partner application has been submitted')]")]
        public IWebElement EnrollmentSuccessMessage { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "newDistFin")]
        public IWebElement NewFinNumber { get; set; }

        public void InputPersonalInformation (String ssn, String firstName, String middleName, String lastName, String gender, String birthMonth, String birthDay, String birthYear)
        {
            SsnField.SendKeys(ssn);
            FirstNameField.SendKeys(firstName);
            MiddleNameField.SendKeys(middleName);
            LastNameField.SendKeys(lastName);
            new SelectElement(GenderSelect).SelectByText(gender);
            new SelectElement(BirthMonthSelect).SelectByText(birthMonth);
            new SelectElement(BirthDaySelect).SelectByText(birthDay);
            new SelectElement(BirthYearSelect).SelectByText(birthYear);
            NextButton.Click();
        }

        public void InputContactInformation (String address, String city, String stateCode, String zip, String contactPhone, String emailAddress)
        {
            AddressField.SendKeys(address);
            CityField.SendKeys(city);
            StateField.SendKeys(stateCode);
            ZipField.SendKeys(zip);
            ContactPhoneNumber.SendKeys(contactPhone);
            EmailField.SendKeys(emailAddress);
            if (IsElementDisplayed(ConfirmEmailField))
            {
                ConfirmEmailField.SendKeys(emailAddress);
            }
            NextButton.Click();
        }

        public void InputBusinessInformation()
        {
            Thread.Sleep(1000);
            NextButton.Click();
        }

        public void InputSponsorInformation (Boolean referredByPartner, String referredByName, String referredByPhone)
        {
            Thread.Sleep(1000);
            if (referredByPartner && ReferredByNameField.Enabled)
            {
                ClickWhenClickable(ReferredYesRadioButton, TimeSpan.FromSeconds(5));
                ReferredByNameField.SendKeys(referredByName);
                ReferredByPhoneField.SendKeys(referredByPhone);
            } else if (!referredByPartner && ReferredByNameField.Enabled)
            {
                ClickWhenClickable(ReferredNoRadioButton, TimeSpan.FromSeconds(5));
            }
            NextButton.Click();
        }

        public void InputPaymentInformation(String paymentType, String creditCardNumber, String expirationMonth, String expirationYear)
        {
            new SelectElement(PaymentTypeSelect).SelectByText(paymentType);
            CreditCardNumberField.SendKeys(creditCardNumber);
            new SelectElement(CreditCardExpirationMonth).SelectByValue(expirationMonth);
            new SelectElement(CreditCardExpirationYear).SelectByText(expirationYear);
            BillingAddressSameButton.Click();
            Thread.Sleep(1000);
            NextButton.Click();
        }

        public void InputAccountInformation(String bankAccountNumber, String bankStateBranchCode, String bankNameField, String accountNameField)
        {
            BankAccountNumberField.SendKeys(bankAccountNumber);
            BankStateBranchCodeField.SendKeys(bankStateBranchCode);
            BankNameField.SendKeys(bankNameField);
            AccountNameField.SendKeys(accountNameField);
            ScrollToElement(NextButton);
            NextButton.Click();
        }

        public void AcceptTermsAndConditions()
        {
            Thread.Sleep(1000);
            AgreeButton.Click();
        }

        public void SubmitEnrollment ()
        {
            SubmitButton.Click();
        }

        public void ClickWhenClickable(IWebElement webElement, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(Driver.WebDriver, timeout);
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement)).Click();
        }

        public Boolean IsElementDisplayed(IWebElement webElement)
        {
            // Temp Fix.
            double initialImplicitWaitTime = 5;
            // double initialImplicitWaitTime = Driver.WebDriver.Manage().Timeouts().ImplicitWait.TotalSeconds;
            try
            {
                Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                if (webElement.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(initialImplicitWaitTime);
            }
        }

        public void ScrollToElement (IWebElement webElement)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.WebDriver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
            Thread.Sleep(500);
        }

        public void MinimizeFeedbackBox ()
        {
            double initialImplicitWaitTime = Driver.WebDriver.Manage().Timeouts().ImplicitWait.TotalSeconds;
            try
            {
                Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                MinimizeFeedbackBoxButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(initialImplicitWaitTime);
            }
        }

        public String GetFinNumber()
        {
            return NewFinNumber.Text;
        }
    }
}
