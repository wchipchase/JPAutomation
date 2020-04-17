using AutomationTests.Config;
using AutomationTests.ConfigElements;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.CartCheckoutActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.NavigationsActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.ChewablesActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.IndividualCapsuleActions;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.CartPage;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.CheckoutPage;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.Navigation;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AutomationTests.Tests
{
    class Scratch
    {
        [Test]
        public void CheckoutPremiumChewables()
        {
            ChewableActions.AddPremiumChewablesToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        public void TearDown()
        {
            Driver.Teardown();
        }

    }

}

