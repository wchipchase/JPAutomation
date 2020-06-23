using AutomationTests.ConfigElements;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.CartCheckoutActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.MixedProductActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.ChewablesActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.CompleteActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.IndividualCapsuleActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.OmegaActions;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.UpliftActions;
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
        public void CheckoutBerryCapsulesVisa()
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
        public void CheckoutOmegaBlendVisa()
        {
            OmegaActions.AddOmegaBlendToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutUpliftVisa()
        {
            UpliftActions.AddUpliftToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutCompleteShakesVisa()
        {
            CompleteActions.AddCompleteJuicePlusShakesToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutCompleteJuiceBarsVisa()
        {
            CompleteActions.AddCompleteJuicePlusBarsToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutCompleteVegetableSoupVisa()
        {
            CompleteActions.AddCompleteVegetableSoupToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutCompleteCombiBoxVisa()
        {
            CompleteActions.AddCompleteCombiBoxToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }

        [Test]
        public void CheckoutCompleteBoosterVisa()
        {
            CompleteActions.AddCompleteBoosterToCart();
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

        [Test]
        public void CheckoutOmegaBlendMC()
        {
            OmegaActions.AddOmegaBlendToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        [Test]
        public void CheckoutUpliftMC()
        {
            UpliftActions.AddUpliftToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        [Test]
        public void CheckoutCompleteShakesMC()
        {
            CompleteActions.AddCompleteJuicePlusShakesToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        [Test]
        public void CheckoutCompleteJuiceBarsMC()
        {
            CompleteActions.AddCompleteJuicePlusBarsToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        [Test]
        public void CheckoutCompleteVegetableSoupMC()
        {
            CompleteActions.AddCompleteVegetableSoupToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        [Test]
        public void CheckoutCompleteCombiBoxMC()
        {
            CompleteActions.AddCompleteCombiBoxToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        [Test]
        public void CheckoutCompleteBoosterMC()
        {
            CompleteActions.AddCompleteBoosterToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        [Test]
        public void CheckoutMixedProductUplifSinglePayRecurringOrderCapsulesSingleOrderInstallmentsVisa()
        {
            MixedProductActions.AddUpliftInstallmentPayCapsulePayInFullRecurringToCart();
            CartActions.CheckoutWithCartItemsVisa();
        }


        [Test]
        public void CheckoutMixedProductUplifSinglePayRecurringOrderCapsulesSingleOrderInstallmentsMC()
        {
            MixedProductActions.AddUpliftInstallmentPayCapsulePayInFullRecurringToCart();
            CartActions.CheckoutWithCartItemsMC();
        }

        /*[SetUp]
        public void Setup()
        {
            Console.WriteLine("Setup");
            Driver.InitializeDriver();
        }*/

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
            Driver.Teardown();
        }

    }
}
