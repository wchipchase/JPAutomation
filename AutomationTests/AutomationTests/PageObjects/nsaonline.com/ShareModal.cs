using AutomationTests.ConfigElements;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageObjects.nsaonline.com
{
    class ShareModal : BasePage
    {
        Driver Driver;

        public ShareModal(Driver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "share-btn-copy")]
        public IWebElement CopyShareButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "share-btn-email")]
        public IWebElement EmailShareButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "share-btn-whatsapp")]
        public IWebElement WhatsappShareButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "share-btn-facebook")]
        public IWebElement FacebookShareButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "share-btn-twitter")]
        public IWebElement TwitterShareButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.Id, Using = "copyCart")]
        public IWebElement CopyCartInput { get; set; }

        public String CopySharedCartLink()
        {
            Click(CopyShareButton);
            return CopyCartInput.GetAttribute("value");
        }

    }
}
