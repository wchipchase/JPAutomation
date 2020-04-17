using AutomationTests.ConfigElements;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.CartCheckoutActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.ChewablesActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.IndividualCapsuleActions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests
{
    [TestFixture]
    class ProductCheckout
    {

        [Test]
        public void CheckoutPremiumCapsulesVisa()
        {
            CapsuleActions.AddPremiumCapsuleToCart();
            CartActions.CheckoutWithCartItemsVisa();
            
            
        }

        [Test]
        public void CheckoutFruitsAndVegetablesCapsulesVisa()
        {
            CapsuleActions.AddFruitsAndVegetablesCapsuleToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutBerryCapsules()
        {
            CapsuleActions.AddBerryCapsuleToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutPremiumChewablesVisa()
        {
            ChewableActions.AddPremiumChewablesToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutFruitsAndVegetableChewablesVisa()
        {
            ChewableActions.AddFruitsAndVegetablesChewablesToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutBerryChewablesVisa()
        {
            ChewableActions.AddBerryChewablesToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutPremiumCapsulesMC()
        {
            CapsuleActions.AddPremiumCapsuleToCart();
            CartActions.CheckoutWithCartItemsMC();


        }

        [Test]
        public void CheckoutFruitsAndVegetablesCapsulesMC()
        {
            CapsuleActions.AddFruitsAndVegetablesCapsuleToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        [Test]
        public void CheckoutBerryCapsulesMC()
        {
            CapsuleActions.AddBerryCapsuleToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        [Test]
        public void CheckoutPremiumChewablesMC()
        {
            ChewableActions.AddPremiumChewablesToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutFruitsAndVegetableChewablesMC()
        {
            ChewableActions.AddFruitsAndVegetablesChewablesToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        [Test]
        public void CheckoutBerryChewablesMC()
        {
            ChewableActions.AddBerryChewablesToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }

    }
}
