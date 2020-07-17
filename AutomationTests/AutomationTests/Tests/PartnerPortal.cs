using AutomationTests.ConfigElements;
using AutomationTests.PageActions.PartnerPortal;
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
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests
{
    [TestFixture]
    class PartnerPortal
    {

        [Test]
        public void ValidateDashboardCards()
        {
            LoginActions.LoginAsPartner();
            DashboardActions.ValidatePerformanceBonusCard();
            Thread.Sleep(2000);
            DashboardActions.ValidatePromoteOutBonusCard();
            Thread.Sleep(2000);
            DashboardActions.ValidateComissionCard();
        }

        [Test]
        public void TeamFilter()
        {
            LoginActions.LoginAsPartner();
            TeamActions.NavigateToTeams();
            TeamActions.ClickFilterButton();
            TeamActions.AddAndApplyFilters();
        }

        [Test]
        public void ValidatingFirstAndLastNameFilters()
        {
            LoginActions.LoginAsPartner();
            TeamActions.NavigateToTeams();
            TeamActions.ValidateNameFilter();
        }

        [Test]
        public void ValidateDownloadCSV()
        {
            LoginActions.LoginAsPartner();
            TeamActions.NavigateToTeams();
            TeamActions.ClickDownloadAndSelectCSV();
        }

        [Test]
        public void CustomerFilterValidation()
        {
            LoginActions.LoginAsPartner();
            CustomerActions.NavigateToCustomers();
            CustomerActions.ClickFilterButton();
            CustomerActions.AddAndApplyFilters();
        }

        [Test]
        public void AddAMemberPartnerPortal()
        {
            LoginActions.LoginAsPartner();
            TeamActions.NavigateToTeams();
            TeamActions.ClickOnAddMemberAndFillOutPersonalForm();
            TeamActions.FillOutContactFormAndSubmitApplication();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Teardown();
        }

    }
}
