using AutomationTests.Config;
using AutomationTests.ConfigElements;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.NavigationsActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.IndividualCapsuleActions;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.CapsulesPage;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.CartPage;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.CheckoutPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageActions.staging.juiceplus.com.ie.en.CartCheckoutActions
{
    class CartActions
    {
        public static IWebElement WaitUntilElementVisible(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }
        public static void CheckoutWithCartItemsVisa()
        {
            try
            {
                WebDriverWait waitForElement = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30));
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                nav.CheckoutButton.Click();
                //waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[.='Proceed to checkout']")));
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your Cart"));
                CartPageObjects cpo = new CartPageObjects();
                cpo.ProceedToCheckoutButton.Click();
                waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[.='Checkout as guest']")));
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("New to Juice Plus+?"));
                CheckoutPageObjects cop = new CheckoutPageObjects();
                cop.CheckoutAsGuestButton.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Shipping Address"));
                cop.FirstNameShippingTextbox.SendKeys(AddressInfo.ShippingAddress.FirstNameShipping.FirstName);
                cop.LastNameShippingTextbox.SendKeys(AddressInfo.ShippingAddress.LastNameShipping.LastName);
                cop.DaytimePhoneNumberShippingTextbox.SendKeys(AddressInfo.ShippingAddress.PrimaryPhoneShipping.PrimaryPhone);
                cop.AlternatePhoneNumberShippingTextbox.SendKeys(AddressInfo.ShippingAddress.AlternatePhoneShipping.AlternatePhone);
                cop.EmailShippingTextbox.SendKeys(AddressInfo.ShippingAddress.EmailShipping.Email);
                cop.StreetAddressDeliveryTextbox.SendKeys(AddressInfo.ShippingAddress.StreetAddShipping.StreetAdd);
                cop.OptionalStreetAddressDeliveryTextbox.SendKeys(AddressInfo.ShippingAddress.OptionalStreetShipping.OptionalStreet);
                cop.CityDeliveryTextbox.SendKeys(AddressInfo.ShippingAddress.CityShipping.City);
//                cop.StateDeliveryTextbox.SendKeys(AddressInfo.ShippingAddress.StateShipping.State);
                cop.CountyDeliveryTextbox.SendKeys(AddressInfo.ShippingAddress.CountyShipping.County);
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", cop.ReferringRepNoRadioButton);
                cop.ProceedToCheckoutButton.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Secure Payment"));
                //               cop.VisaPaymentMethodButton.Click();
                cop.PaymentCCNumberTextbox.SendKeys(CreditCardInfo.CreditCardNumber.VisaCCNum.ccnumberValid);
                cop.PaymentCCExpirationDateTextbox.SendKeys(CreditCardInfo.CCExpDate.VisaCCExpDate.VisaCCExpDateValid);
                cop.PaymentCVVTextbox.SendKeys(CreditCardInfo.CreditCardCCV.VisaCCV.VisaCCVValid);
                js.ExecuteScript("arguments[0].click();", cop.TOSAcceptCheckbox);
                js.ExecuteScript("arguments[0].click();", cop.ConfirmOrderButton);
                
                waitForElement.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".m-checkout-confirmation__title")));
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Thank you, your order has been confirmed!"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

        }

        public static void CheckoutWithCartItemsMC()
        {
            try
            {
                WebDriverWait waitForElement = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(30));
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                nav.CheckoutButton.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Your Cart"));
                CartPageObjects cpo = new CartPageObjects();
                cpo.ProceedToCheckoutButton.Click();
                waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[.='Checkout as guest']")));
                try
                {
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("New to Juice Plus+?"));
                }

                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                CheckoutPageObjects cop = new CheckoutPageObjects();
                cop.CheckoutAsGuestButton.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Shipping Address"));
                cop.FirstNameShippingTextbox.SendKeys(AddressInfo.ShippingAddress.FirstNameShipping.FirstName);
                cop.LastNameShippingTextbox.SendKeys(AddressInfo.ShippingAddress.LastNameShipping.LastName);
                cop.DaytimePhoneNumberShippingTextbox.SendKeys(AddressInfo.ShippingAddress.PrimaryPhoneShipping.PrimaryPhone);
                cop.AlternatePhoneNumberShippingTextbox.SendKeys(AddressInfo.ShippingAddress.AlternatePhoneShipping.AlternatePhone);
                cop.EmailShippingTextbox.SendKeys(AddressInfo.ShippingAddress.EmailShipping.Email);
                cop.StreetAddressDeliveryTextbox.SendKeys(AddressInfo.ShippingAddress.StreetAddShipping.StreetAdd);
                cop.OptionalStreetAddressDeliveryTextbox.SendKeys(AddressInfo.ShippingAddress.OptionalStreetShipping.OptionalStreet);
                cop.CityDeliveryTextbox.SendKeys(AddressInfo.ShippingAddress.CityShipping.City);
                cop.CountyDeliveryTextbox.SendKeys(AddressInfo.ShippingAddress.CountyShipping.County);
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", cop.ReferringRepNoRadioButton);
                cop.ProceedToCheckoutButton.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Secure Payment"));
                js.ExecuteScript("arguments[0].click();", cop.MCPaymentMethodButton);
                cop.PaymentCCNumberTextbox.SendKeys(CreditCardInfo.CreditCardNumber.MasterCardCCNum.ccnumberValid);
                cop.PaymentCCExpirationDateTextbox.SendKeys(CreditCardInfo.CCExpDate.MasterCardCCExpDate.MasterCardCCExpDateValid);
                cop.PaymentCVVTextbox.SendKeys(CreditCardInfo.CreditCardCCV.MasterCardCCV.MasterCardCCVValid);
                js.ExecuteScript("arguments[0].click();", cop.TOSAcceptCheckbox);
                js.ExecuteScript("arguments[0].click();", cop.ConfirmOrderButton);

                waitForElement.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".m-checkout-confirmation__title")));
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Thank you, your order has been confirmed!"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

        }

    }
}