using NUnit.Framework;
using User = FrameworkCore.DataFiles.User;
using DbConnectionString = FrameworkCore.DataFiles.DbConnectionString;
using FrameworkCore.Utilities;
using PimsSupport.PAGES;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using System.Configuration;
using static PimsSupport.PAGES.RelationshipsPage;
using OpenQA.Selenium.Support.UI;
using FrameworkCore.DataFiles;
using System.Data.SqlClient;
using PimsSupport.PAGES;
using System.Timers;
using FrameworkCore.PageObject;
using OpenQA.Selenium.Support;


namespace PimsSupport.TESTS
{
    [TestFixture("chrome")]
    //[TestFixture("ie")]
    //[TestFixture("firefox")]
    //[Parallelizable]
    public class RelationshipsTest : BaseTest
    {
        LoginPage loginPage;
        HeadbarMainMenu headbarMainMenu;
        LandingPage landingPage;
        ClientAliasesPage clientAliasesPage;
        RelationshipsPage relationshipsPage;

        public RelationshipsTest(string browser) : base(browser) { }

        [SetUp]
        public void SetUp()
        {
            loginPage = new LoginPage(driver);
            loginPage.Load();
            landingPage = new LandingPage(driver, loginPage);
            headbarMainMenu = new HeadbarMainMenu(driver, landingPage);
            relationshipsPage = new RelationshipsPage(driver, landingPage);
        }


        [Test, Description("TC708A : Pims > Relationships: Validate that url, page title, page footer, web table columns are enabled")]
        [Category("Regression")]
        [Order(1)]
        public void Relationships_708A()
        {
            loginPage.Login(User.USER2);
            headbarMainMenu.ClickPIMSMenu();
            headbarMainMenu.ClickRelationships();
            relationshipsPage.FilterRelationships(FiltersFilterBy.Blank, "");
            relationshipsPage.orderByMethod(OrderByOrderOrSortBy.Blank, OrderByDirection.Blank);
            Assert.Multiple(() =>
            {
                Assert.True(relationshipsPage.ValidatePageURL(), "Page URL does not include " + relationshipsPage.ExpectedPageURL);
                Assert.True(relationshipsPage.ValidatePageTitleEnabled(), "Page title \"Client Aliases\" is not enabled");
                Assert.True(relationshipsPage.ValidateFooterEnabled(), "Page footer is not enabled");
                Assert.True(relationshipsPage.ValidateColumnDescriptionEnabled(), "Column name: " + relationshipsPage.columnNameDescription + " is not enabled");
                Assert.True(relationshipsPage.ValidateColumnStateEnabled(), "Column name: " + relationshipsPage.columnNameState + " is not enabled");
                Assert.True(relationshipsPage.ValidateColumnRelationshipIdNumberEnabled(), "Column name: " + relationshipsPage.columnNameRelationshipIdNumber + " is not enabled");
                Assert.True(relationshipsPage.ValidateColumnCoverageTypeEnabled(), "Column name: " + relationshipsPage.columnNameCoverageType + " is not enabled");
                Assert.True(relationshipsPage.ValidateColumnEffectiveDateEnabled(), "Column name: " + relationshipsPage.columnNameEffectiveDate + " is not enabled");
                Assert.True(relationshipsPage.ValidateColumnTerminationDateEnabled(), "Column name: " + relationshipsPage.columnNameTerminationDate + " is not enabled");
                Assert.True(relationshipsPage.ValidateColumnCancelledDateEnabled(), "Column name: " + relationshipsPage.columnNameCancelledDate + " is not enabled");
                Assert.True(relationshipsPage.ValidateColumnStatusEnabled(), "Column name: " + relationshipsPage.columnNameStatus + " is not enabled");
                Assert.True(relationshipsPage.ValidateHelpButtonEnabled(), "Column name: " + relationshipsPage.columnNameStatus + " is not enabled");

            });
        }
        



        [Test, Description("TC742 : Pims > Relationships > View > Rates: Details")]
        [Category("Regression")]
        [Order(10)]
        public void Relationships_742()
        {
            loginPage.Login(User.USER2);
            headbarMainMenu.ClickPIMSMenu();
            headbarMainMenu.ClickRelationships();
            relationshipsPage.FilterRelationships(FiltersFilterBy.RelationshipIdNumber, "51093");    // "31466");       //"2326");
            relationshipsPage.ClickViewOption();
            relationshipsPage.ClickViewRates();
            relationshipsPage.ClickRatesCreateNew();
            relationshipsPage.CreateNewRates(Utilities.getRandomPastDate(5));
            string NewCreatedRate_ClassCode = relationshipsPage.getTextOfgetCreateRates_ClassCode1(); Console.WriteLine(NewCreatedRate_ClassCode);
            relationshipsPage.ClickRatesDetails();
            Assert.Multiple(() =>
            {
                Assert.True(relationshipsPage.ValidatePageURL_RatesDetails(), "Page url not contains 'PimsSupport/RateRevision/Details'");
                Assert.True(relationshipsPage.ValidateRatesDetailsTitleEnabled(), "Rates-Details Title is not enabled");
                Assert.True(relationshipsPage.ValidateRatesDetailsEditEnabled(), "Rates-Details Edit is not enabled");
                Assert.True(relationshipsPage.ValidateRatesDetailsDeleteEnabled(), "Rates-Details Delete is not enabled");
                Assert.True(relationshipsPage.ValidateRatesDetailsBackToListEnabled(), "Rates-Details BackToList is not enabled");
                Assert.True(relationshipsPage.ValidateRatesDetailsBackToListEnabled(), "Rates-Details BackToList is not enabled");
            });

            String query = "Select * FROM [PremAcc3].[dbo].[Rates] Where Relationship_ID_Number =51093 and Class_Code = '"+ NewCreatedRate_ClassCode + "';";
            Assert.Multiple(() =>
            {
                Assert.True(relationshipsPage.ValidateRelationshipRetesDetailsEffectiveDateOnDatabase(query), "Effective Date on Databese and UI are not maching");
                Assert.True(relationshipsPage.ValidateRelationshipRetesDetailsMaximumCoverageTermOnDatabase(query), "Maximum Coverage Term on Databese and UI are not maching");
                Assert.True(relationshipsPage.ValidateRelationshipRetesDetailsCreatedOnDatabase(query), "Created date on Databese and UI are not maching");
                Assert.True(relationshipsPage.ValidateRelationshipRetesDetailsModifiedOnDatabase(query), "Modified date on Databese and UI are not maching");
                Assert.True(relationshipsPage.ValidateRelationshipRetesDetailsUserIDOnDatabase(query), "User_ID on Databese and UI are not maching");

            });
            relationshipsPage.ClickRatesDetailsBackToList();
            relationshipsPage.DeleteNewRates();
        }


        [TearDown]
        public void LogoutCenterPoint()
        {
            landingPage.EvaluateScreenshotSourcePageSaving();
            headbarMainMenu.GoToLogout();
        }

    }
}




