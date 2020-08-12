using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.juiceplusvirtualfranchise.com;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.juice.plus.virtualfranchise
{
    [TestFixture]
    class TestHeaderNavigationItems
    {
        Driver Driver;

        Header Header;

        [SetUp]
        public void Setup()
        {
            Driver = new Driver(Driver.BrowserType.Chrome);
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.WebDriver.Manage().Window.Maximize();

            Header = new Header(Driver);
        }

        [Test, Description("Test Virtual Franchise Connectivity")]
        [Category("LegacyRegression")]
        [Repeat(1)]
        public void TestAllHeaderNavigation_VF_US()
        {
            Driver.WebDriver.Navigate().GoToUrl("http://www.juiceplusvirtualfranchise.com");

            Header.NavigateJuicePlusProductClick();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ is whole food based nutrition in a capsule and chewable form"));
            
            Header.NavigateJuicePlusCompanyClick();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ is made by The Juice Plus+ Company, located in Collierville, Tennessee, a suburb of Memphis"));

            Header.NavigateJuicePlusBusinessClick();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Our Business Model"));

            Header.NavigateJuicePlusLiveClick();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("What is Juice Plus+ LIVE?"));

            Header.NavigateContactUsClick();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Contact Juice Plus+"));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
