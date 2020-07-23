﻿using AutomationTests.ConfigElements;
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
        public IWebElement JuicePlusCapsules2000QuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity3000")]
        public IWebElement JuicePlusCapsules3000QuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity2000CA")]
        public IWebElement JuicePlusCapsules2000CAQuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity3000CA")]
        public IWebElement JuicePlusCapsules3000CAQuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity2000AS")]
        public IWebElement JuicePlusCapsules2000ASQuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity2012AS")]
        public IWebElement JuicePlusCapsules2012ASQuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity480105050")]
        public IWebElement JuicePlusCapsules480105050QuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity490105050")]
        public IWebElement JuicePlusCapsules490105050QuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity2000']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules2000AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity3000']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules3000AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity2000CA']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules2000CAAddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity3000CA']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules3000CAAddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity2000AS']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules2000ASAddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity2012AS']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules2012ASAddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity480105050']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules480105050AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity490105050']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules490105050AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = ".btn.btn-success.shareCart")]
        public IWebElement ShareCartWithCustomerButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//button[contains(text(),'CheckOut')]")]
        public IWebElement CheckoutButton { get; set; }

        public void AddToCart(String sku, int quantity)
        {
            if (sku.Equals("2000"))
            {
                JuicePlusCapsules2000QuantityField.Clear();
                JuicePlusCapsules2000QuantityField.SendKeys(""+quantity);
                Click(JuicePlusCapsules2000AddToCartButton);
            }
            else if (sku.Equals("3000"))
            {
                JuicePlusCapsules3000QuantityField.Clear();
                JuicePlusCapsules3000QuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules3000AddToCartButton);
            }
            else if (sku.Equals("2000CA"))
            {
                JuicePlusCapsules2000CAQuantityField.Clear();
                JuicePlusCapsules2000CAQuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules2000CAAddToCartButton);
            }
            else if (sku.Equals("3000CA"))
            {
                JuicePlusCapsules3000CAQuantityField.Clear();
                JuicePlusCapsules3000CAQuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules3000CAAddToCartButton);
            }
            else if (sku.Equals("2000AS"))
            {
                JuicePlusCapsules2000ASQuantityField.Clear();
                JuicePlusCapsules2000ASQuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules2000ASAddToCartButton);
            }
            else if (sku.Equals("2012AS"))
            {
                JuicePlusCapsules2012ASQuantityField.Clear();
                JuicePlusCapsules2012ASQuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules2012ASAddToCartButton);
            }
            else if (sku.Equals("480105050"))
            {
                JuicePlusCapsules480105050QuantityField.Clear();
                JuicePlusCapsules480105050QuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules480105050AddToCartButton);
            }
            else if (sku.Equals("490105050"))
            {
                JuicePlusCapsules490105050QuantityField.Clear();
                JuicePlusCapsules490105050QuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules490105050AddToCartButton);
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

        public void Checkout()
        {
            CheckoutButton.Click();
        }
    }
}