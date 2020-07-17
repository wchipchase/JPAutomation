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

namespace AutomationTests.PageObjects.juiceplusvirtualfranchise.com
{
    class Header
    {
        public Header()
        {
            PageFactory.InitElements(Driver.WebDriver, this);
        }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'The Juice Plus+ Product')]")]
        public IWebElement JuicePlusProductNavLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'The Juice Plus+ Company')]")]
        public IWebElement JuicePlusCompanyNavLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'The Juice Plus+ Business')]")]
        public IWebElement JuicePlusBusinessNavLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'Juice Plus+ LIVE!')]")]
        public IWebElement JuicePlusLiveNavLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//li/a[contains(.,'Contact Us')]")]
        public IWebElement ContactUsNavLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'Our Products')]")]
        public IWebElement OurProductsNavLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='o-header__logo']//img[@alt='/content/ie/juiceplus/en/home']")]
        public IWebElement JuicePlusHeaderLogo { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'Live Better')]")]
        public IWebElement LiveBetterNavigationLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'Our Products')]")]
        public IWebElement OurProductsNavigationLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'Our Community')]")]
        public IWebElement OurCommunityNavigationLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'Join Us')]")]
        public IWebElement JoinUsNavigationLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.ClassName, Using = "//div[@class='o-header__search']//span[@class='h-icon h-icon--search']")]
        public IWebElement SearchIcon { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.CssSelector, Using = ".m-icon-badge__counter")]
        public IWebElement CartIconCounter { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//span[.='Sign In']")]
        public IWebElement LoginButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[.='Newsletter']")]
        public IWebElement NewsletterLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Overview')]")]
        public IWebElement LiveBetterOverviewLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Healthy Starts for Families')]")]
        public IWebElement LiveBetterHealthyFamilyLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Active Lifestyle')]")]
        public IWebElement LiveBetterActiveLifestyleLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Feel Good, Look Your Best')]")]
        public IWebElement LiveBetterFeelGoodLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'One Simple Change')]")]
        public IWebElement LiveBetterOneSimpleChangeLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = " //div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--tooltip']//a[contains(.,'Overview')]")]
        public IWebElement OurProductsOverviewLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Capsules')]")]
        public IWebElement OurProductsCapsulesLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Chewables')]")]
        public IWebElement OurProductsChewablesLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Omega Blend')]")]
        public IWebElement OurProdutcsOmegaLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Complete by Juice Plus+')]")]
        public IWebElement OurProductsCompleteLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Uplift by Juice Plus+')]")]
        public IWebElement OurProductsUpliftLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'What is Juice Plus+?')]")]
        public IWebElement OurProductsWhatIsJuicePlusLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Clinical Research')]")]
        public IWebElement OurProductsClinicalResearch { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Overview')]")]
        public IWebElement OurCommunityOverviewLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Blog')]")]
        public IWebElement OurCommunityBlogLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Giving Back')]")]
        public IWebElement OurCommunityGivingBackLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//a[contains(.,'Let's Go Beyond')]")]
        public IWebElement OurCommunityGoBeyondLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'Live Better')]")]
        public IWebElement LiveBetterNavLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//a[contains(.,'Our Community')]")]
        public IWebElement OurCommunityNavLink { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//div[@class='m-product-count-container__flyout-content m-flyout__content js-m-flyout__content m-flyout__content--attached m-flyout__content--dropdown']//span[@class='a-button__inner']")]
        public IWebElement CheckoutButton { get; set; }

        public void NavigateJuicePlusProductClick()
        {
            Console.WriteLine("JuicePlusProductNavLink.Location.X: " + JuicePlusProductNavLink.Location.X);
            Console.WriteLine("JuicePlusProductNavLink.Location.Y: " + JuicePlusProductNavLink.Location.Y);
            Console.WriteLine("JuicePlusProductNavLink.Size.Width: " + JuicePlusProductNavLink.Size.Width);
            Console.WriteLine("JuicePlusProductNavLink.Size.Height: " + JuicePlusProductNavLink.Size.Height);

            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(JuicePlusProductNavLink, JuicePlusProductNavLink.Size.Width / 2, (JuicePlusProductNavLink.Size.Height * 75) / 100).Click().Build();
            action.Perform();
            Thread.Sleep(2000);
        }

        public void NavigateJuicePlusCompanyClick()
        {
            Console.WriteLine("JuicePlusCompanyNavLink.Location.X: " + JuicePlusCompanyNavLink.Location.X);
            Console.WriteLine("JuicePlusCompanyNavLink.Location.Y: " + JuicePlusCompanyNavLink.Location.Y);
            Console.WriteLine("JuicePlusCompanyNavLink.Size.Width: " + JuicePlusCompanyNavLink.Size.Width);
            Console.WriteLine("JuicePlusCompanyNavLink.Size.Height: " + JuicePlusCompanyNavLink.Size.Height);

            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(JuicePlusCompanyNavLink, JuicePlusCompanyNavLink.Size.Width / 2, (JuicePlusCompanyNavLink.Size.Height * 75) / 100).Click().Build();
            action.Perform();
            Thread.Sleep(2000);
        }

        public void NavigateJuicePlusBusinessClick()
        {
            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(JuicePlusBusinessNavLink, JuicePlusBusinessNavLink.Size.Width / 2, (JuicePlusBusinessNavLink.Size.Height * 75) / 100).Click().Build();
            action.Perform();
            Thread.Sleep(2000);
        }

        public void NavigateJuicePlusLiveClick()
        {
            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(JuicePlusLiveNavLink, JuicePlusLiveNavLink.Size.Width / 2, (JuicePlusLiveNavLink.Size.Height * 75) / 100).Click().Build();
            action.Perform();
            Thread.Sleep(2000);
        }

        public void NavigateContactUsClick()
        {
            Console.WriteLine("ContactUsNavLink.Location.X: " + ContactUsNavLink.Location.X);
            Console.WriteLine("ContactUsNavLink.Location.Y: " + ContactUsNavLink.Location.Y);
            Console.WriteLine("ContactUsNavLink.Size.Width: " + ContactUsNavLink.Size.Width);
            Console.WriteLine("ContactUsNavLink.Size.Height: " + ContactUsNavLink.Size.Height);

            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(ContactUsNavLink, ContactUsNavLink.Size.Width / 2, (ContactUsNavLink.Size.Height * 75) / 100).Click().Build();
            action.Perform();
            Thread.Sleep(2000);
        }
    }
}
