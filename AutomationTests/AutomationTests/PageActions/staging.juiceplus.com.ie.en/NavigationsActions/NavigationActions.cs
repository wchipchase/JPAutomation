﻿using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en.Navigation;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutomationTests.PageActions.staging.juiceplus.com.ie.en.NavigationsActions
{
    class NavigationActions
    {
        
        public static void NavigateOurProductsCapsulesClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.OurProductsNavLink).Perform();
                nav.OurProductsNavLink.Click();
                nav.OurProductsCapsulesLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Capsules"));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }


            
        }

        public static void NavigateOurProductsOverViewClick()
        {

            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.OurProductsNavLink).Perform();
                nav.OurProductsNavLink.Click();
                nav.OurProductsOverviewLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Products"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public static void NavigateOurProductsChewablesClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.OurProductsNavLink).Perform();
                nav.OurProductsNavLink.Click();
                nav.OurProductsChewablesLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Chewables"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateOurProductsOmegaClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.OurProductsNavLink).Perform();
                nav.OurProductsNavLink.Click();
                nav.OurProdutcsOmegaLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Omega Blend"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateOurProductsCompleteClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.OurProductsNavLink).Perform();
                nav.OurProductsNavLink.Click();
                nav.OurProductsCompleteLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Complete"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateOurProductsUpliftClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.OurProductsNavLink).Perform();
                nav.OurProductsNavLink.Click();
                nav.OurProductsUpliftLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Uplift"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateOurProductsWhatIsJuicePlusClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.OurProductsNavLink).Perform();
                nav.OurProductsNavLink.Click();
                nav.OurProductsWhatIsJuicePlusLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("What is Juice Plus+"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }


        public static void NavigateLiveBetterOverviewClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.LiveBetterNavigationLink).Perform();
                nav.LiveBetterNavLink.Click();
                nav.LiveBetterOverviewLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Live Better"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateLiveBetterHealthyFamilyClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.LiveBetterNavLink).Perform();
                nav.LiveBetterNavLink.Click();
                nav.LiveBetterHealthyFamilyLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Healthy Family"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        

        public static void NavigateLiveBetterActiveLifestyleClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.LiveBetterNavLink).Perform();
                nav.LiveBetterNavLink.Click();
                nav.LiveBetterActiveLifestyleLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Active Lifestyle"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateLiveBetterFeelGoodLookGoodClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.LiveBetterNavLink).Perform();
                nav.LiveBetterNavLink.Click();
                nav.LiveBetterFeelGoodLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Feel Good, Look Your Best"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateLiveBetterOneSimpleChangeClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.LiveBetterNavLink).Perform();
                nav.LiveBetterNavLink.Click();
                nav.LiveBetterOneSimpleChangeLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("One Simple Change"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateOurCommunityOverviewClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.OurCommunityNavLink).Perform();
                nav.OurCommunityNavLink.Click();
                nav.OurCommunityOverviewLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Our Community"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateOurCommunityBlogClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.OurCommunityNavLink).Perform();
                nav.OurCommunityNavLink.Click();
                nav.OurCommunityBlogLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Blog"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateOurCommunityGivingBackClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.OurCommunityNavLink).Perform();
                nav.OurCommunityNavLink.Click();
                nav.OurCommunityGivingBackLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Giving Back"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateOurCommunityGoBeyondClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                //Actions action = new Actions(Driver.WebDriver);
                //action.MoveToElement(nav.OurCommunityNavLink).Perform();
                nav.OurCommunityNavLink.Click();
                nav.OurCommunityGoBeyondLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Let's Go Beyond"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateJoinUsClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                nav.JoinUsNavigationLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Join Us"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavSearchIconClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                nav.SearchIcon.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Capsules"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void NavLoginButtonClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                nav.LoginButton.Click();
                //Assert.IsTrue(Driver.WebDriver.PageSource.Contains(""));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavNewsletterClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                nav.NewsletterLink.Click();
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains(""));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavCartIconClick()
        {
            try
            {
                NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
                nav.CartIconCounter.Click();
                //Assert.IsTrue(Driver.WebDriver.PageSource.Contains("You have no itmes in your cart."));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateFacebookClick()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.FacebookIcon);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("facebook"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateCountryClick()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.IrelandFooter);
                js.ExecuteScript("arguments[0].click();", nav.CountrySelectionUnitedKingdom);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateInstagramClick()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.InstagramIcon);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("juiceplus_uk"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateYoutubeClick()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.YoutubeIcon);
                //Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice PLUS+"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateCompany_AboutUs()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.AboutUsFooter);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("About Juice Plus+"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateCompany_GivingBack()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.GivingBackFooter);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Giving Back"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateCompany_ContactUs()

        {try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.ContactUsFooter);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Contact Us"));
            }
        catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void NavigateJuicePlus_HowCapsAreMade()
        {try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.HowCapsulesAreMadeFooter);
                Thread.Sleep(5000);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("How are Juice Plus+ capsules made?"));
            }
        catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateJuicePlus_ClinicalResearch()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.ClinicalResearchFooter);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Clinical Research"));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateJuicePlus_InformedChoice()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.InformedChoiceFooter);
                Driver.WebDriver.Close();
                //Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Informed-Choice Certification"));
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void NavigateResources_OneSimpleChange()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.OneSimpleChangeFooter);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("One Simple Change"));
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void NavigateResources_HealthyStartforFamilies()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.HealthyStartsLink);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Join the Study and enjoy free product for your child!"));
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }



        public static void NavigateResources_LetsGoBeyond()
            
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.GoBeyondFooter);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Let's Go Beyond"));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateMore_TowerGarden()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.TowerGardenFooter);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Grow Your Own Food with Tower Garden"));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void NavigateCountrySelect()
        {
            try
            {
                NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
                IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
                js.ExecuteScript("arguments[0].click();", nav.CountryLocationFooter);
                Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Choose your country and language"));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void NavigateTermsOfUse()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.TermsOfUseFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Terms of Use"));
        }

        public static void NavigatePrivacyPolicy()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.PrivacyPolicyFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Privacy and Cookie Policy"));
        }

        public static void NavigateReturnPolicy()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.ReturnPolicyFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Return Policy"));
        }

        public static void NavigateTermsofService()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.TermsOfServiceFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Terms of Service Policy"));
        }
    }
}
