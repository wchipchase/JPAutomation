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
    class SubmitCustomerJPOrderPage : BasePage
    {
        public SubmitCustomerJPOrderPage()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity2000")]
        public IWebElement JuicePlusCapsulesQuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity3000")]
        public IWebElement JuicePlusCapsules3000QuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity2000']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsulesAddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity3000']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules3000AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = ".btn.btn-success.shareCart")]
        public IWebElement ShareCartWithCustomerButton { get; set; }

        public void AddToCart(String sku, int quantity)
        {
            if (sku.Equals("2000"))
            {
                JuicePlusCapsulesQuantityField.Clear();
                JuicePlusCapsulesQuantityField.SendKeys(""+quantity);
                Click(JuicePlusCapsulesAddToCartButton);
            } else if (sku.Equals("3000"))
            {
                JuicePlusCapsules3000QuantityField.Clear();
                JuicePlusCapsules3000QuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules3000AddToCartButton);
            }
            else
            {
                throw new Exception("Invalid sku!");
            }
        }

        public void ShareCartWithCustomer()
        {
            ShareCartWithCustomerButton.Click();
        }
    }
}