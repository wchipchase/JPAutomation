using AutomationTests.ConfigElements;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.NavigationsActions;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.CompletePage;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.OurProductsMenuItems.CompletePage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.CompleteActions
{
    class CompleteActions
    {
        public static void AddCompleteJuicePlusShakesToCart()
        {
            try
            {
                NavigationActions.NavigateOurProductsCompleteClick();
                CompletePageObjects cpo = new CompletePageObjects();
                try
                {
                    Assert.IsFalse(Driver.WebDriver.PageSource.Contains("£"));
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("€"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                LandingPageObjects lan = new LandingPageObjects();
                lan.CookieAlertAcceptButton.Click();
                Task.Delay(500).Wait(1500);
                cpo.ClickShakesCompleteShopNow();
                CompleteOrderPageObjects copo = new CompleteOrderPageObjects();
                try
                {
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Vanilla Shake"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                cpo.ScrollViewport();
                var NumOfProducts = copo.NumOfProductOrder.GetAttribute("value");
                try
                {
                    Assert.That(NumOfProducts, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                copo.IncrementArrowOrder.Click();
                var incrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                Thread.Sleep(500);
                try
                {
                    Assert.That(incrProductCount, Is.EqualTo("2"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                copo.DecrementArrowOrder.Click();
                var decrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                try
                {
                    Assert.That(decrProductCount, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                copo.AddToCartOrder.Click();
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                Thread.Sleep(1000);
                var NumInCart = nav.CartIconCounter.Text;
                Console.WriteLine(NumInCart);
                Thread.Sleep(1000);
                try
                {
                    Assert.That(NumInCart, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                nav.CartIconCounter.Click();

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

        }

        public static void AddCompleteJuicePlusBarsToCart()
        {
            try
            {
                NavigationActions.NavigateOurProductsCompleteClick();
                CompletePageObjects cpo = new CompletePageObjects();
                try
                {
                    Assert.IsFalse(Driver.WebDriver.PageSource.Contains("£"));
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("€"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                LandingPageObjects lan = new LandingPageObjects();
                lan.CookieAlertAcceptButton.Click();
                Task.Delay(500).Wait(1500);
                cpo.ClickCompleteJuiceBarsShopNow();
                CompleteOrderPageObjects copo = new CompleteOrderPageObjects();
                try
                {
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Chocolate Bar"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                cpo.ScrollViewport();
                var NumOfProducts = copo.NumOfProductOrder.GetAttribute("value");
                try
                {
                    Assert.That(NumOfProducts, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                copo.IncrementArrowOrder.Click();
                var incrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                Thread.Sleep(500);
                try
                {
                    Assert.That(incrProductCount, Is.EqualTo("2"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                copo.DecrementArrowOrder.Click();
                var decrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                try
                {
                    Assert.That(decrProductCount, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                copo.AddToCartOrder.Click();
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                Thread.Sleep(1000);
                var NumInCart = nav.CartIconCounter.Text;
                Console.WriteLine(NumInCart);
                Thread.Sleep(1000);
                try
                {
                    Assert.That(NumInCart, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                nav.CartIconCounter.Click();

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

        }

        public static void AddCompleteVegetableSoupToCart()
        {
            try
            {
                NavigationActions.NavigateOurProductsCompleteClick();
                CompletePageObjects cpo = new CompletePageObjects();
                try
                {
                    Assert.IsFalse(Driver.WebDriver.PageSource.Contains("£"));
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("€"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                LandingPageObjects lan = new LandingPageObjects();
                lan.CookieAlertAcceptButton.Click();
                Task.Delay(500).Wait(1500);
                cpo.ClickCompleteVegetableSoupShopNow();
                CompleteOrderPageObjects copo = new CompleteOrderPageObjects();
                try
                {
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Vegetable Soup"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                cpo.ScrollViewport();
                var NumOfProducts = copo.NumOfProductOrder.GetAttribute("value");
                try
                {
                    Assert.That(NumOfProducts, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                copo.IncrementArrowOrder.Click();
                var incrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                Thread.Sleep(500);
                try
                {
                    Assert.That(incrProductCount, Is.EqualTo("2"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                copo.DecrementArrowOrder.Click();
                var decrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                try
                {
                    Assert.That(decrProductCount, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                copo.AddToCartOrder.Click();
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                Thread.Sleep(1000);
                var NumInCart = nav.CartIconCounter.Text;
                Console.WriteLine(NumInCart);
                Thread.Sleep(1000);
                try
                {
                    Assert.That(NumInCart, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                nav.CartIconCounter.Click();

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

        }

        public static void AddCompleteCombiBoxToCart()
        {
            try
            {
                NavigationActions.NavigateOurProductsCompleteClick();
                CompletePageObjects cpo = new CompletePageObjects();
                try
                {
                    Assert.IsFalse(Driver.WebDriver.PageSource.Contains("£"));
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("€"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                LandingPageObjects lan = new LandingPageObjects();
                lan.CookieAlertAcceptButton.Click();
                Task.Delay(500).Wait(1500);
                cpo.ClickCompleteCombiBoxShopNow();
                CompleteOrderPageObjects copo = new CompleteOrderPageObjects();
                try
                {
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Vanilla Shake Combi Box"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                cpo.ScrollViewport();
                var NumOfProducts = copo.NumOfProductOrder.GetAttribute("value");
                try
                {
                    Assert.That(NumOfProducts, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                copo.IncrementArrowOrder.Click();
                var incrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                Thread.Sleep(500);
                try
                {
                    Assert.That(incrProductCount, Is.EqualTo("2"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                copo.DecrementArrowOrder.Click();
                var decrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                try
                {
                    Assert.That(decrProductCount, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                copo.AddToCartOrder.Click();
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                Thread.Sleep(1000);
                var NumInCart = nav.CartIconCounter.Text;
                Console.WriteLine(NumInCart);
                Thread.Sleep(1000);
                try
                {
                    Assert.That(NumInCart, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                nav.CartIconCounter.Click();

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

        }

        public static void AddCompleteBoosterToCart()
        {
            try
            {
                NavigationActions.NavigateOurProductsCompleteClick();
                CompletePageObjects cpo = new CompletePageObjects();
                try
                {
                    Assert.IsFalse(Driver.WebDriver.PageSource.Contains("£"));
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("€"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                LandingPageObjects lan = new LandingPageObjects();
                lan.CookieAlertAcceptButton.Click();
                Task.Delay(500).Wait(1500);
                cpo.ClickCompleteJuiceBarsShopNow();
                CompleteOrderPageObjects copo = new CompleteOrderPageObjects();
                try
                {
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Chocolate Bar"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                cpo.ScrollViewport();
                var NumOfProducts = copo.NumOfProductOrder.GetAttribute("value");
                try
                {
                    Assert.That(NumOfProducts, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                copo.IncrementArrowOrder.Click();
                var incrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                Thread.Sleep(500);
                try
                {
                    Assert.That(incrProductCount, Is.EqualTo("2"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                copo.DecrementArrowOrder.Click();
                var decrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                try
                {
                    Assert.That(decrProductCount, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                copo.AddToCartOrder.Click();
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                Thread.Sleep(1000);
                var NumInCart = nav.CartIconCounter.Text;
                Console.WriteLine(NumInCart);
                Thread.Sleep(1000);
                try
                {
                    Assert.That(NumInCart, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }

                nav.CartIconCounter.Click();

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
