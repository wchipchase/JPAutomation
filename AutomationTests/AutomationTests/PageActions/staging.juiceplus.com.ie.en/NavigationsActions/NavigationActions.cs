using AutomationTests.ConfigElements;
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

namespace AutomationTests.PageActions.staging.juiceplus.com.ie.en.NavigationsActions
{
    class NavigationActions
    {
        
        public static void NavigateOurProductsCapsulesClick()
        {

            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.OurProductsNavLink).Perform();
            nav.OurProductsCapsulesLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Capsules"));
            
        }

        public static void NavigateOurProductsOverViewClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.OurProductsNavLink).Perform();
            nav.OurProductsOverviewLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Products"));
        }


        public static void NavigateOurProductsChewablesClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.OurProductsNavLink).Perform();
            nav.OurProductsChewablesLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Chewables"));
        }

        public static void NavigateOurProductsOmegaClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.OurProductsNavLink).Perform();
            nav.OurProdutcsOmegaLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Omega Blend"));
        }

        public static void NavigateOurProductsCompleteClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.OurProductsNavLink).Perform();
            nav.OurProductsCompleteLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Complete"));
        }

        public static void NavigateOurProductsUpliftClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.OurProductsNavLink).Perform();
            nav.OurProductsUpliftLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Uplift"));
        }

        public static void NavigateOurProductsWhatIsJuicePlusClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.OurProductsNavLink).Perform();
            nav.OurProductsWhatIsJuicePlusLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("What is Juice Plus+"));

        }


        public static void NavigateLiveBetterOverviewClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.LiveBetterNavigationLink).Perform();
            nav.LiveBetterOverviewLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Live Better"));
        }

        public static void NavigateLiveBetterHealthyFamilyClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.LiveBetterNavLink).Perform();
            nav.LiveBetterHealthyFamilyLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Healthy Family"));
        }

        

        public static void NavigateLiveBetterActiveLifestyleClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.LiveBetterNavLink).Perform();
            nav.LiveBetterActiveLifestyleLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Active Lifestyle"));
        }

        public static void NavigateLiveBetterFeelGoodLookGoodClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.LiveBetterNavLink).Perform();
            nav.LiveBetterFeelGoodLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Feel Good, Look Your Best"));
        }

        public static void NavigateLiveBetterOneSimpleChangeClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.LiveBetterNavLink).Perform();
            nav.LiveBetterOneSimpleChangeLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("One Simple Change"));
        }

        public static void NavigateOurCommunityOverviewClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.OurCommunityNavLink).Perform();
            nav.OurCommunityOverviewLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Our Community"));
        }

        public static void NavigateOurCommunityBlogClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.OurCommunityNavLink).Perform();
            nav.OurCommunityBlogLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Blog"));
        }

        public static void NavigateOurCommunityGivingBackClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            Actions action = new Actions(Driver.WebDriver);
            action.MoveToElement(nav.OurCommunityNavLink).Perform();
            nav.OurCommunityGivingBackLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Giving Back"));
        }

        //public static void NavigateOurCommunityGoBeyondClick()
        //{
        //    NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
        //    Actions action = new Actions(Driver.WebDriver);
        //    action.MoveToElement(nav.OurCommunityNavLink).Perform();
        //    nav.OurCommunityGoBeyondLink.Click();
        //    Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Let's Go Beyond"));
        //}

        public static void NavigateJoinUsClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            nav.JoinUsNavigationLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Join Us"));
        }

        public static void NavSearchIconClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            nav.SearchIcon.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Capsules"));
        }

        public static void NavLoginButtonClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            nav.LoginButton.Click();
            //Assert.IsTrue(Driver.WebDriver.PageSource.Contains(""));
        }

        public static void NavNewsletterClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            nav.NewsletterLink.Click();
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Login"));
        }

        public static void NavCartIconClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();
            nav.CartIconCounter.Click();
            //Assert.IsTrue(Driver.WebDriver.PageSource.Contains("You have no itmes in your cart."));
        }

        public static void NavigateFacebookClick()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.FacebookIcon);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("facebook"));
        }

        public static void NavigateInstagramClick()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.InstagramIcon);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("juiceplus_uk"));
        }

        public static void NavigateYoutubeClick()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.YoutubeIcon);
            //Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice PLUS+"));
        }

        public static void NavigateCompany_AboutUs()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.AboutUsFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("About the Juice Plus+ Company"));
        }

        public static void NavigateCompany_GivingBack()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.GivingBackFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Giving Back"));
        }

        public static void NavigateCompany_ContactUs()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.ContactUsFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Contact Us"));
        }

        public static void NavigateJuicePlus_HowCapsAreMade()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.HowCapsulesAreMadeFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("How are Juice Plus+ capsules made?"));
        }

        public static void NavigateJuicePlus_ClinicalResearch()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.ClinicalResearchFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ Clinical Research"));
        }

        public static void NavigateJuicePlus_InformedChoice()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.InformedChoiceFooter);
            Driver.WebDriver.Close();
            //Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Informed-Choice Certification"));
        }

        public static void NavigateResources_OneSimpleChange()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.OneSimpleChangeFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("One Simple Change"));
        }

        public static void NavigateResources_HealthyStartforFamilies()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.HealthyStartsLink);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Healthy Starts for Families"));
        }

        public static void NavigateResources_LetsGoBeyond()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.GoBeyondFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Let's Go Beyond"));
        }

        public static void NavigateMore_TowerGarden()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.TowerGardenFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Grow Your Own Food with Tower Garden"));
        }

        public static void NavigateCountrySelect()
        {
            NavigationFooterPageObjects nav = new NavigationFooterPageObjects();
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver.WebDriver);
            js.ExecuteScript("arguments[0].click();", nav.CountryLocationFooter);
            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Choose your country and language"));
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
