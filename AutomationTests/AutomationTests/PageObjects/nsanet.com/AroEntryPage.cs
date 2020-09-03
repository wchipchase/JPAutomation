using AutomationTests.ConfigElements;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        // Temp change. Need to Fix. NTF
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "ship_country")]
        public IWebElement CountyShippingAddressField { get; set; }

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

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "aro_type")]
        public IWebElement AroTypeDropdown { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "aroNumber")]
        public IWebElement AroNumberField { get; set; }

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

        public void InputBasicInformation(String distributorNumber, String aroType)
        {
            String[] newStringArray = {"FR", "GER", "SUI"};
            String selectedCountry = new SelectElement(CountrySelect).SelectedOption.Text;
            if (newStringArray.Contains(selectedCountry))
            {
                AroNumberField.SendKeys(""+new Random().Next(100000, 1000000));
            }
            DistributorNumberField.SendKeys(distributorNumber);
            AroTypeDropdown.SendKeys(aroType);
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

        public void InputAdrressInformation(String firstName, String lastName, String address, String zip, String city, String state, String county, String phoneNumber, String mobileNumber, String emailAddress, String dob)
        {
            SendKeysSlowly(FirstNameShippingAddressField, firstName);
            SendKeysSlowly(LastNameShippingAddressField, lastName);
            SendKeysSlowly(AddressShippingAddressField, address);
            SendKeysSlowly(PhoneNumberShippingAddressField, phoneNumber);
            SendKeysSlowly(MobileNumberShippingAddressField, mobileNumber);
            SendKeysSlowly(EmailAddressShippingAddressField, emailAddress);

            if (IsElementDisplayed(ZipLookupButton))
            {
                ZipLookup(zip, city);
            } else
            {
                SendKeysSlowly(ZipShippingAddressField, zip);
                SendKeysSlowly(CityShippingAddressField, city);
                if (!state.Equals("N/A"))
                {
                    SendKeysSlowly(StateShippingAddressField, state);
                }
                if (!county.Equals("N/A"))
                {
                    SendKeysSlowly(CountyShippingAddressField, county);
                }
            }
            if (!dob.Equals("N/A"))
            {
                SendKeysSlowly(DateOfBirthShippingAddressField, dob);
            }
            ContinueButton.Click();
        }

        public void InputAdrressInformationValidFields(String firstName, String lastName, String address, String zip, String city, String state, String county, String phoneNumber, String mobileNumber, String emailAddress, String dob)
        {
            SendKeysSlowly(FirstNameShippingAddressField, firstName);
            SendKeysSlowly(LastNameShippingAddressField, lastName);
            SendKeysSlowly(AddressShippingAddressField, address);
            SendKeysSlowly(PhoneNumberShippingAddressField, phoneNumber);
            SendKeysSlowly(MobileNumberShippingAddressField, mobileNumber);
            SendKeysSlowly(EmailAddressShippingAddressField, emailAddress);

            if (IsElementDisplayed(ZipLookupButton))
            {
                ZipLookup(zip, city);
            }
            else
            {
                SendKeysSlowly(ZipShippingAddressField, zip);
                SendKeysSlowly(CityShippingAddressField, city);
                if (!state.Equals("N/A") && IsElementDisplayed(StateShippingAddressField))
                {
                    SendKeysSlowly(StateShippingAddressField, state);
                }
                if (!county.Equals("N/A") && IsElementDisplayed(CountyShippingAddressField))
                {
                    SendKeysSlowly(CountyShippingAddressField, county);
                }
            }
            if (!dob.Equals("N/A") && IsElementDisplayed(DateOfBirthShippingAddressField))
            {
                SendKeysSlowly(DateOfBirthShippingAddressField, dob);
            }
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

        public void ClearAllProducts()
        {
            IList<IWebElement> newList = Driver.WebDriver.FindElements(By.CssSelector("input[type='checkbox']"));
            for (int i=0; i< newList.Count; i++)
            {
                newList[i].Click();
            }
            UpdateButton.Click();
        }

        public void InputProductInformation(String sku, int quantity)
        {
            ClearAllProducts();
            if (ExpectedConditions.ElementExists(By.Id("qt"+ sku)) != null)
            {
                SkuInputField.SendKeys(sku);
                UpdateButton.Click();
            }

            Driver.WebDriver.FindElement(By.Id("qt" + sku)).Clear();
            Driver.WebDriver.FindElement(By.Id("qt" + sku)).SendKeys(""+quantity);

            /*if (sku.Equals("2000"))
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
            }*/

            UpdateButton.Click();
            ContinueButton.Click();
        }

        public void SubmitAro()
        {
            FinishedButton.Click();
        }

        public String CreateAro(String countryCode, String address, String zip, String city, String state, String county, String mobile, String phone, String dob, String sku, String paymentType, String accountNumber, String expMonth, String expYear)
        {
            InitiateNewAro(countryCode);
            InputBasicInformation("USM0025620", "4 Month Installment");
            InputAdrressInformation("test", "tester", address, zip, city, state, county, mobile, phone, "test@testing.com", dob);
            InputPaymentInformation(paymentType, accountNumber, expMonth, expYear);
            InputProductInformation(sku, 1);

            SubmitAro();

            var SuccessMessageRegex = new Regex(@"ARO Entered Successfully - \d{5,8}");
            if (SuccessMessageRegex.Matches(Driver.WebDriver.PageSource).Count > 0)
            {
                Console.Write("ARO Number: " + SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", ""));
                return SuccessMessageRegex.Matches(Driver.WebDriver.PageSource)[0].Value.Replace("ARO Entered Successfully - ", "");
            } else
            {
                return null;
            }
        }

        public String CreateAro(String countryCode)
        {
            switch (countryCode)
            {
                case "AU":
                    return CreateAro("AU", "14 Merewether St", "2291", "Merewether", "QLD", "N/A", "9018503000", "9018503000", "121290", "2000AS", "Visa", "4242424242424242", "01", "25");
                case "BEL":
                    return CreateAro("BEL", "Rue Duquesnoy 5", "1000", "Bruxelles", "N/A", "N/A", "0294963000", "0412345678", "121290", "490105034", "Visa", "4242424242424242", "01", "25");
                case "CAN":
                    return CreateAro("CAN", "2785 Skymark Ave", "L4W 4Y3", "Mississauga", "ON", "N/A", "9018503000", "9018503000", "121290", "2000CA", "American Express", "374500262001008", "01", "25");
                case "DK":
                    return CreateAro("DK", "Torvegade 11", "8900", "Randers", "N/A", "N/A", "45 86 42 34 22", "45 86 42 34 22", "N/A", "490105080", "Visa", "4242424242424242", "01", "25");
                case "FI":
                    return CreateAro("FI", "Pieni Roobertinkatu 1", "001 30", "Helsinki", "N/A", "N/A", "358 9 6899880", "358 9 6899880", "N/A", "490105084", "Visa", "4242424242424242", "01", "25");
                case "FR":
                    return CreateAro("FR", "2 Boulevard du Levant", "93167", "Noisy-le-Grand", "Île-de-France", "N/A", "33 1 45924747", "33 1 45924747", "N/A", "490105030", "Visa", "4242424242424242", "01", "25"); // ARO number is required
                case "GER":
                    return CreateAro("GER", "Taunusstraße 48-50", "60329", "Frankfurt am Main", "Frankfurt am Main", "N/A", "+49 69 96869890", "+49 69 96869890", "N/A", "490105030", "Visa", "4242424242424242", "01", "25"); // ARO number is required
                case "EIR":
                    return CreateAro("EIR", "Athlone Rd", "60329", "Athlone", "N/A", "Roscommon", "49 69 96869890", "49 69 96869890", "N/A", "490105030", "Visa", "4242424242424242", "01", "25");// Need County. Wrong label.
                case "IT":
                    return CreateAro("IT", "Via Torri Bianche 7", "20871", "Vimercate", "MB", "N/A", "39 06 495 9261", "39 06 495 9261", "121290", "490105040", "Visa", "4242424242424242", "01", "25"); // Extra stuff
                case "LU":
                    return CreateAro("LU", "30 Rue Joseph Junck", "1839", "Luxembourg", "N/A", "N/A", "352 49 24 96", "352 49 24 96", "N/A", "490105036", "Visa", "4242424242424242", "01", "25");
                case "NL":
                    return CreateAro("NL", "Schepenbergweg 50", "1105 AT", "Amsterdam", "N/A", "N/A", "31 20 311 3670", "31 20 311 3670", "N/A", "490105034", "Visa", "4242424242424242", "01", "25");
                case "NO":
                    return CreateAro("NO", "Karl Johans gate 31", "0159", "Oslo", "N/A", "N/A", "47 23 21 20 00", "47 23 21 20 00", "N/A", "490105081", "Visa", "4242424242424242", "01", "25");
                case "PL":
                    return CreateAro("PL", "Stara 1", "41-940", "Piekary Śląskie", "N/A", "N/A", "458623422", "458623422", "N/A", "490105005", "Visa", "4242424242424242", "01", "25");
                case "RO":
                    return CreateAro("RO", "Calea Victoriei 56", "010083", "București", "București", "N/A", "40 372 010 300", "40 372 010 300", "N/A", "490110023", "Visa", "4242424242424242", "01", "25"); // wrong label state, but shows county.
                case "ES":
                    return CreateAro("ES", "C/ Gran Vía, 84", "28013", "Madrid", "N/A", "N/A", "31 20 311 3670", "31 20 311 3670", "N/A", "490105003", "Visa", "4242424242424242", "01", "25");
                case "SUI":
                    return CreateAro("SUI", "Bürgenstock 17", "6363", "Obbürgen", "N/A", "N/A", "41 41 612 60 00", "41 41 612 60 00", "N/A", "490110023", "Visa", "4242424242424242", "01", "25"); // ARO number is required
                case "SE":
                    return CreateAro("SE", "Södra Blasieholmshamnen 8", "103 27", "Stockholm", "N/A", "N/A", "46 8 679 35 00", "46 8 679 35 00", "N/A", "490105084", "Visa", "4242424242424242", "01", "25");
                case "UK":
                    return CreateAro("UK", "40 Heyes St.", "L5 6SG", "Liverpool", "N/A", "Liverpool", "07720750898", "07720750898", "N/A", "490105084", "Visa", "4242424242424242", "01", "25"); // Need County. Wrong label.
                case "USA":
                    return CreateAro("USA", "140 Crescent Dr.", "38017", "Collierville", "Tennessee", "N/A", "9018502938", "9018502938", "N/A", "2000", "Visa", "4242424242424242", "01", "25");
                default:
                    return null;
                 
            }
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
            InputAdrressInformation("test", "tester", "2785 Skymark Ave", "L4W 4Y3", "Mississauga", "ON", "N/A", "9056246368", "9056246368", "test@testing.com", "121290");
            InputPaymentInformation("American Express", "374500262001008", "01", "25");
            InputProductInformation("2000CA", 1);
            SubmitAro();
        }

        public void CreateAUAro()
        {
            InitiateNewAro("AU");
            InputBasicInformation("USM0025620");
            InputAdrressInformation("test", "tester", "14 Merewether St", "2291", "Merewether", "QLD", "N/A", "0294963000", "0412345678", "test@testing.com", "121290");
            InputPaymentInformation("Visa", "4242424242424242", "01", "25");
            InputProductInformation("2000AS", 1);
            SubmitAro();
        }
    }
}
