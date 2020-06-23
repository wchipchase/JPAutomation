using AutomationTests.ConfigElements;
using AutomationTests.PageActions.juiceplusvirtualfranchise.com;
using AutomationTests.PageActions.juiceplusvirtualfranchise.com.NavigationsActions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.juice.plus.virtualfranchise
{
    class TestHeaderNavigationItems
    {
        NavigationActions nav = new NavigationActions();

        [Test, Category("Regression")]
        public void TestAllHeaderNavigation()
        {
            NavigationActions.NavigateJuicePlusProductClick();
            NavigationActions.NavigateJuicePlusCompanyClick();
            NavigationActions.NavigateJuicePlusBusinessClick();
            NavigationActions.NavigateJuicePlusLiveClick();
            NavigationActions.NavigateContactUsClick();
        }

        [SetUp]
        public void Setup()
        {
            Driver.InitializeDriver();
            Driver.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.WebDriver.Navigate().GoToUrl("http://us.rccq.juiceplusvirtualfranchise.com/");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }
    }

}
