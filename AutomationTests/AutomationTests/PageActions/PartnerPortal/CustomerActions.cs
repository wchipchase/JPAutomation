using AutomationTests.PageObjects.PartnerPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageActions.PartnerPortal
{
    class CustomerActions
    {
        public static void NavigateToTeams()
        {
            Login lpo = new Login();
            lpo.CustomersNavTab.Click();
        }

        public static void ClickFilterButton()
        {
            Customers cpo = new Customers();
            cpo.FilterCustomers.Click();
        }

        public static void AddAndApplyFilters()
        {
            Customers cpo = new Customers();
            cpo.FilterSelectCountryUSA.Click();
            Thread.Sleep(1000);
            cpo.FilterSelectCountryCanada.Click();
            Thread.Sleep(1000);
            cpo.FilterSelectCountryUK.Click();
            Thread.Sleep(1000);
            cpo.FilterSelectCountryEIR.Click();
            Thread.Sleep(1000);
            cpo.FilterSelectApply.Click();
        }

        public static void ValidateNameFilter()
        {
            Team tpo = new Team();
            tpo.FirstNameFilter.Click();
            tpo.LastNameFilterSelection.Click();
            tpo.LastNameFilter.Click();
            tpo.FirstNameFilterSelection.Click();
        }
    }
}
