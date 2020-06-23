using AutomationTests.ConfigElements;
using AutomationTests.PageObjects.towergarden.com;
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

namespace AutomationTests.PageActions.towergarden.com.BuyActions
{
    class BuyActions
    {
        public static void AddToCart(String sku)
        {
            BuyPage BuyPage = new BuyPage();

            if (sku.Equals("GT360L"))
            {
                BuyPage.TowerGardenHomeAddToCart.Click();
            }
            else if (sku.Equals("TG350CA"))
            {
                BuyPage.TowerGardenGrowingSystemAddToCart.Click();
            }
            
        }
    }
}
