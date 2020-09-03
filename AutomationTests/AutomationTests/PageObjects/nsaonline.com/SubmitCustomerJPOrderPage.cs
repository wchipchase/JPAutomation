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
        Driver Driver;

        public SubmitCustomerJPOrderPage(Driver driver) : base(driver)
        {
            Driver = driver;
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

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity490105030")]
        public IWebElement JuicePlusCapsules490105030QuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity490105001")]
        public IWebElement JuicePlusCapsules490105001QuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity480110034")]
        public IWebElement JuicePlusCapsules480110034QuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity490105080")]
        public IWebElement JuicePlusCapsules490105080QuantityField { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "quantity490105084")]
        public IWebElement JuicePlusCapsules490105084QuantityField { get; set; }

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

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity490105030']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules490105030AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity480105030']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules480105030AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity490105050']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules490105050AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity490105001']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules490105001AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity480110034']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules480110034AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity490105080']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules490105080AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//input[@id='quantity490105084']//following-sibling::div/button")]
        public IWebElement JuicePlusCapsules490105084AddToCartButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = ".btn.btn-success.shareCart")]
        public IWebElement ShareCartWithCustomerButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//button[contains(text(),'CheckOut')]")]
        public IWebElement CheckoutButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "customer.shoppingCartAccept.yes")]
        public IWebElement AcceptAgreementRadioButton { get; set; }
        

        /*public void AddToCart(String sku, int quantity)
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
            } else if (sku.Equals("490105030"))
            {
                JuicePlusCapsules490105030QuantityField.Clear();
                JuicePlusCapsules490105030QuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules490105030AddToCartButton);
            } else if (sku.Equals("490105001"))
            {
                JuicePlusCapsules490105001QuantityField.Clear();
                JuicePlusCapsules490105001QuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules490105001AddToCartButton);
            } else if (sku.Equals("480110034"))
            {
                JuicePlusCapsules480110034QuantityField.Clear();
                JuicePlusCapsules480110034QuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules480110034AddToCartButton);
            }
            else if (sku.Equals("490105080"))
            {
                JuicePlusCapsules490105080QuantityField.Clear();
                JuicePlusCapsules490105080QuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules490105080AddToCartButton);
            } else if (sku.Equals("490105084"))
            {
                JuicePlusCapsules490105084QuantityField.Clear();
                JuicePlusCapsules490105084QuantityField.SendKeys("" + quantity);
                Click(JuicePlusCapsules490105084AddToCartButton);
            }
            else
            {
                throw new Exception("Invalid sku!");
            }
        }*/

        public void AddToCart(String sku, int quantity)
        {
            Driver.WebDriver.FindElement(By.Id("quantity" + sku)).Clear();
            Driver.WebDriver.FindElement(By.Id("quantity" + sku)).SendKeys("" + quantity);
            Driver.WebDriver.FindElement(By.XPath("//input[@id='quantity" + sku + "']//following-sibling::div/button")).Click();
        }

        public void ShareCartWithCustomer()
        {
            ShareCartWithCustomerButton.Click();
        }

        public void Checkout()
        {
            CheckoutButton.Click();
        }

        public void AcceptAgreement()
        {
            AcceptAgreementRadioButton.Click();
        }
    }
}