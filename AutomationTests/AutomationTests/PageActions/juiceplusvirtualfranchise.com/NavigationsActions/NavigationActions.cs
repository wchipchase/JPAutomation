using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.juiceplusvirtualfranchise.com;
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

namespace AutomationTests.PageActions.juiceplusvirtualfranchise.com.NavigationsActions
{
    class NavigationActions
    {
        
        public static void NavigateJuicePlusProductClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();

            Console.WriteLine("nav.JuicePlusProductNavLink.Location.X: " + nav.JuicePlusProductNavLink.Location.X);
            Console.WriteLine("nav.JuicePlusProductNavLink.Location.Y: " + nav.JuicePlusProductNavLink.Location.Y);
            Console.WriteLine("nav.JuicePlusProductNavLink.Size.Width: " + nav.JuicePlusProductNavLink.Size.Width);
            Console.WriteLine("nav.JuicePlusProductNavLink.Size.Height: " + nav.JuicePlusProductNavLink.Size.Height);

            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(nav.JuicePlusProductNavLink, nav.JuicePlusProductNavLink.Size.Width/2, (nav.JuicePlusProductNavLink.Size.Height*75)/100).Click().Build();
            action.Perform();

            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ is whole food based nutrition in a capsule and chewable form"));
        }

        public static void NavigateJuicePlusCompanyClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();

            Console.WriteLine("nav.JuicePlusCompanyNavLink.Location.X: " + nav.JuicePlusCompanyNavLink.Location.X);
            Console.WriteLine("nav.JuicePlusCompanyNavLink.Location.Y: " + nav.JuicePlusCompanyNavLink.Location.Y);
            Console.WriteLine("nav.JuicePlusCompanyNavLink.Size.Width: " + nav.JuicePlusCompanyNavLink.Size.Width);
            Console.WriteLine("nav.JuicePlusCompanyNavLink.Size.Height: " + nav.JuicePlusCompanyNavLink.Size.Height);

            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(nav.JuicePlusCompanyNavLink, nav.JuicePlusCompanyNavLink.Size.Width/2, (nav.JuicePlusCompanyNavLink.Size.Height * 75) / 100).Click().Build();
            action.Perform();

            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Juice Plus+ is made by The Juice Plus+ Company, located in Collierville, Tennessee, a suburb of Memphis"));
        }

        public static void NavigateJuicePlusBusinessClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();

            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(nav.JuicePlusBusinessNavLink, nav.JuicePlusBusinessNavLink.Size.Width/2, (nav.JuicePlusBusinessNavLink.Size.Height * 75) / 100).Click().Build();
            action.Perform();

            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Our Business Model"));
        }

        public static void NavigateJuicePlusLiveClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();

            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(nav.JuicePlusLiveNavLink, nav.JuicePlusLiveNavLink.Size.Width/2, (nav.JuicePlusLiveNavLink.Size.Height * 75) / 100).Click().Build();
            action.Perform();

            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("What is Juice Plus+ LIVE?"));
        }

        public static void NavigateContactUsClick()
        {
            NavigationHeaderPageObjects nav = new NavigationHeaderPageObjects();

            Console.WriteLine("nav.ContactUsNavLink.Location.X: " + nav.ContactUsNavLink.Location.X);
            Console.WriteLine("nav.ContactUsNavLink.Location.Y: " + nav.ContactUsNavLink.Location.Y);
            Console.WriteLine("nav.ContactUsNavLink.Size.Width: " + nav.ContactUsNavLink.Size.Width);
            Console.WriteLine("nav.ContactUsNavLink.Size.Height: " + nav.ContactUsNavLink.Size.Height);

            Actions builder = new Actions(Driver.WebDriver);
            IAction action = builder.MoveToElement(nav.ContactUsNavLink, nav.ContactUsNavLink.Size.Width/2, (nav.ContactUsNavLink.Size.Height * 75) / 100).Click().Build();
            action.Perform();

            Assert.IsTrue(Driver.WebDriver.PageSource.Contains("Contact Juice Plus+"));
        }
    }
}
