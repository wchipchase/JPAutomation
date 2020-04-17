using AutomationTests.ConfigElements;
using AutomationTests.PageActions.staging.juiceplus.com.ie.en.NavigationsActions;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.CapsulesPage;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.ChewablesPage;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.OurProductsMenuItems.ChewablesPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageActions.staging.juiceplus.com.ie.en.OurProductsMenuItemsActions.ChewablesActions
{
    class ChewableActions
    {
        public static void AddPremiumChewablesToCart()
        {
            try
            {
                WebDriverWait waitForElement = new WebDriverWait(Driver.WebDriver, TimeSpan.FromSeconds(5));
                NavigationActions.NavigateOurProductsChewablesClick();
                ChewablesPageObjects cpo = new ChewablesPageObjects();
                try
                {
                    Assert.IsFalse(Driver.WebDriver.PageSource.Contains("£"));
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("€"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

                LandingPageObjects lan = new LandingPageObjects();
                lan.CookieAlertAcceptButton.Click();
                Task.Delay(500).Wait(1500);
                cpo.ScrollViewport();
                cpo.ShopNowPremiumChewables.Click();
                ChewablesOrderPageObjects copo = new ChewablesOrderPageObjects();
                try
                {
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Premium Chewables"));
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

                    Console.WriteLine(e);
                }
                
                copo.AddToCartOrder.Click();
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                Thread.Sleep(3000);
                var NumInCart = nav.CartIconCounter.Text;
                Console.WriteLine(NumInCart);
                try
                {
                    Assert.That(NumInCart, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
                
                nav.CartIconCounter.Click();

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

        }

        public static void AddFruitsAndVegetablesChewablesToCart()
        {
            try
            {
                NavigationActions.NavigateOurProductsChewablesClick();
                try
                {
                    Assert.IsFalse(Driver.WebDriver.PageSource.Contains("£"));
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("€"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e); ;
                }
                ChewablesPageObjects cpo = new ChewablesPageObjects();

                LandingPageObjects lan = new LandingPageObjects();
                lan.CookieAlertAcceptButton.Click();
                Task.Delay(500).Wait(1500);
                cpo.ScrollViewport();
                cpo.ShopNowFruitVegetableChewables.Click();
                ChewablesOrderPageObjects copo = new ChewablesOrderPageObjects();
                try
                {
                    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Fruit & Vegetable Chewables"));
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

                    Console.WriteLine(e); ;
                }
                
                copo.DecrementArrowOrder.Click();
                var decrProductCount = copo.NumOfProductOrder.GetAttribute("value");

                try
                {
                    Assert.That(decrProductCount, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    throw;
                }
                
                copo.AddToCartOrder.Click();
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                Thread.Sleep(1000);
                var NumInCart = nav.CartIconCounter.Text;
                Console.WriteLine(NumInCart);
                try
                {
                    Assert.That(NumInCart, Is.EqualTo("1"));
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
                
                nav.CartIconCounter.Click();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

        }

        public static void AddBerryChewablesToCart()
        {
            try
            {
                NavigationActions.NavigateOurProductsChewablesClick();
                ChewablesPageObjects cpo = new ChewablesPageObjects();
                Assert.IsFalse(Driver.WebDriver.PageSource.Contains("£"));
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("€"));
                LandingPageObjects lan = new LandingPageObjects();
                lan.CookieAlertAcceptButton.Click();
                Task.Delay(500).Wait(1500);
                cpo.ScrollViewport();
                cpo.ShopNowBerryChewables.Click();
                ChewablesOrderPageObjects copo = new ChewablesOrderPageObjects();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Berry Chewables"));
                cpo.ScrollViewport();
                var NumOfProducts = copo.NumOfProductOrder.GetAttribute("value");
                Assert.That(NumOfProducts, Is.EqualTo("1"));
                copo.IncrementArrowOrder.Click();
                var incrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                Thread.Sleep(500);
                Assert.That(incrProductCount, Is.EqualTo("2"));
                copo.DecrementArrowOrder.Click();
                var decrProductCount = copo.NumOfProductOrder.GetAttribute("value");
                Assert.That(decrProductCount, Is.EqualTo("1"));
                copo.AddToCartOrder.Click();
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                Thread.Sleep(1000);
                var NumInCart = nav.CartIconCounter.Text;
                Console.WriteLine(NumInCart);
                Thread.Sleep(3000);
                Assert.That(NumInCart, Is.EqualTo("1"));
                nav.CartIconCounter.Click();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
        }

        public static void ClickViewRangeButtonOmegaBlend()
        {
            try
            {
                CapsulesPageObjects caps = new CapsulesPageObjects();
                caps.OmegaViewRangeCapsules.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Omega Blend"));
                Assert.IsFalse(Driver.WebDriver.PageSource.Contains("£"));
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("€"));
            }

            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
        }

        public static void ClickLearnMoreHealthyLifestyle()
        {
            try
            {
                CapsulesPageObjects caps = new CapsulesPageObjects();
                caps.HealthyLifestyleCapsules.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Feel Good, Look Your Best"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

        }

        public static void ClickLearnMoreLookYourBest()
        {
            try
            {
                CapsulesPageObjects caps = new CapsulesPageObjects();
                caps.LookingYourBestCapsules.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("One Simple Change"));
            }

            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
        }

        public static void ClickLearnMoreHealthyFamily()
        {
            try
            {
                CapsulesPageObjects caps = new CapsulesPageObjects();
                caps.HealthyFamilyCapsules.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Healthy Family"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
        }

        public static void ClickLearnMoreActiveLifestyle()
        {
            try
            {
                CapsulesPageObjects caps = new CapsulesPageObjects();
                caps.ActiveLifestyleCapsules.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Active Lifestyle"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
