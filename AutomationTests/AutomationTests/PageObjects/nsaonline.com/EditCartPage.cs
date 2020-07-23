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
    class EditCartPage
    {
        public EditCartPage()
        {
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

        public String GetQuanity(String sku)
        {
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
    }
}
