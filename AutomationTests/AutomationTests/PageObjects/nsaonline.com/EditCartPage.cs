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

namespace AutomationTests.PageObjects.nsaonline.com
{
    class EditCartPage : BasePage
    {
        Driver Driver;

        public EditCartPage(Driver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "qty2000")]
        public IWebElement Sku2000QuanityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "qty3000")]
        public IWebElement Sku3000QuanityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "qty480105050")]
        public IWebElement Sku480105050QuanityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "qty490105050")]
        public IWebElement Sku490105050QuanityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = "a.cart-btn.checkout-btn")]
        public IWebElement CheckoutButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "cookieAccept")]
        public IWebElement CookieAcceptButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.ClassName, Using = "lang")]
        public IWebElement LanguageSelectionIcon { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "language-select")]
        public IWebElement LanguageSelect { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "locationApply")]
        public IWebElement LanguageSelectionApplyButton { get; set; }

        public String GetQuanity(String sku)
        {
            Thread.Sleep(5000);

            String quantity;
            if (sku.Equals("2000"))
            {
                quantity = Sku2000QuanityField.GetAttribute("value");
            }
            else if (sku.Equals("3000"))
            {
                quantity = Sku3000QuanityField.GetAttribute("value");
            }
            else if (sku.Equals("480105050"))
            {
                quantity = Sku480105050QuanityField.GetAttribute("value");
            }
            else if (sku.Equals("490105050"))
            {
                quantity = Sku490105050QuanityField.GetAttribute("value");
            }
            else
            {
                throw new Exception("Invalid sku!");
            }

            return quantity;
        }

        public void CheckOut()
        {
            Click(CheckoutButton);
        }

        public void AcceptCookies()
        {
            if (IsElementDisplayed(CookieAcceptButton))
            {
                Click(CookieAcceptButton);
            }
        }

        public void SelectLanguage(String language)
        {
            LanguageSelectionIcon.Click();
            Thread.Sleep(5000);
            new SelectElement(LanguageSelect).SelectByText(language);
            LanguageSelectionApplyButton.Click();
        }
    }
}
