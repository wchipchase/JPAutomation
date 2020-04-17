﻿using AutomationTests.ConfigElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.staging.juiceplus.com.ie.en.CapsulesPage
{
    class CapsulesPageObjects
    {
        public CapsulesPageObjects()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        public void ClickPremiumCapsuleShopNow()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.WebDriver;
            js.ExecuteScript("window.scrollBy(0,600)");
            Thread.Sleep(500);
            ShopNowPremiumCapsules.Click();
        }

        public void ClickVegetablesAndFruitCapsuleShopNow()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.WebDriver;
            js.ExecuteScript("window.scrollBy(0,600)");
            Thread.Sleep(500);
            ShopNowFruitVegetableCapsules.Click();
        }

        public void ClickBerryCapsuleShopNow()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.WebDriver;
            js.ExecuteScript("window.scrollBy(0,1000)");
            Thread.Sleep(500);
            ShopNowBerryCapsules.Click();
        }
        public void ScrollViewport()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.WebDriver;
            js.ExecuteScript("window.scrollBy(0,400)");
            Thread.Sleep(500);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = ".m-product-category-header__title")]
        public IWebElement JuicePlusCapsulesLogo { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='£61.75']")]
        public IWebElement PremiumCapsulePriceCapsules { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//p[contains(.,'From £41.00')]")]
        public IWebElement FruitVegetableCapsulePriceCapsules { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='£22.25']")]
        public IWebElement BerryCapsulePriceCapsules { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[@href='/ie/en/products/capsules/premium-capsules']//span[@class='a-button__inner']")]
        public IWebElement ShopNowPremiumCapsules { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[@href='/ie/en/products/capsules/fruit-and-vegetable-capsules']//span[@class='a-button__inner']")]
        public IWebElement ShopNowFruitVegetableCapsules { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[@href='/ie/en/products/capsules/berry-capsules']//span[@class='a-button__inner']")]
        public IWebElement ShopNowBerryCapsules { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[contains(.,'View Range')]")]
        public IWebElement OmegaViewRangeCapsules { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='aem-Grid aem-Grid--default--4 aem-Grid--tablet-landscape--2 aem-Grid--tablet-portrait--2 aem-Grid--phone--1   tns-slider tns-carousel tns-subpixel tns-calc tns-horizontal']//a[@href='https://www.staging.juiceplus.com/ie/en/live-better/look-and-feel-your-best']//span[@class='a-button__inner']")]
        public IWebElement HealthyLifestyleCapsules { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='aem-Grid aem-Grid--default--4 aem-Grid--tablet-landscape--2 aem-Grid--tablet-portrait--2 aem-Grid--phone--1   tns-slider tns-carousel tns-subpixel tns-calc tns-horizontal']//a[@href='https://www.staging.juiceplus.com/ie/en/live-better/healthy-family']//span[@class='a-button__inner']")]
        public IWebElement HealthyFamilyCapsules { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='aem-Grid aem-Grid--default--4 aem-Grid--tablet-landscape--2 aem-Grid--tablet-portrait--2 aem-Grid--phone--1   tns-slider tns-carousel tns-subpixel tns-calc tns-horizontal']//a[@href='https://www.staging.juiceplus.com/ie/en/live-better/active-lifestyle']//span[@class='a-button__inner']")]
        public IWebElement ActiveLifestyleCapsules { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='aem-Grid aem-Grid--default--4 aem-Grid--tablet-landscape--2 aem-Grid--tablet-portrait--2 aem-Grid--phone--1   tns-slider tns-carousel tns-subpixel tns-calc tns-horizontal']//a[@href='https://www.staging.juiceplus.com/ie/en/live-better/one-simple-change']//span[@class='a-button__inner']")]
        public IWebElement LookingYourBestCapsules { get; set; }
    }
}
