using AutomationTests.PageObjects.PartnerPortal;
using AutomationTests.PageObjects.staging.juiceplus.com.ie.en;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.PageActions.PartnerPortal
{
    class TeamActions
    {
        public static void NavigateToTeams()
        {
            Login lpo = new Login();
            lpo.TeamNavTab.Click();
        }

        public static void ClickFilterButton()
        {
            Team tpo = new Team();
            tpo.FilterControl.Click();
        }

        public static void AddAndApplyFilters()
        {
            Team tpo = new Team();
            tpo.FilterControlP.Click();
            Thread.Sleep(1000);
            tpo.FilterControlSC.Click();
            Thread.Sleep(1000);
            tpo.FilterControlSP.Click();
            Thread.Sleep(1000);
            tpo.ApplyFilterButton.Click();
        }

        public static void ValidateNameFilter()
        {
            Team tpo = new Team();
            tpo.FirstNameFilter.Click();
            tpo.LastNameFilterSelection.Click();
            tpo.LastNameFilter.Click();
            tpo.FirstNameFilterSelection.Click();
        }

        public static void ClickDownloadAndSelectCSV()
        {
            Team tpo = new Team();
            tpo.DownloadFilter.Click();
            Thread.Sleep(1000);
            tpo.DownloadCSVSelection.Click();
            Thread.Sleep(2000);
        }

        public static void ClickOnAddMemberAndCopyLink()
        {
            Team tpo = new Team();
            tpo.AddMemberButton.Click();
            tpo.CopyNewPartnerRegistrationLink.Click();
        }
    }




}
