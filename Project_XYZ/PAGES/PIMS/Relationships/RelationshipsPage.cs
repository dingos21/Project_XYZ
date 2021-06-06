using FrameworkCore.PageObject;
using FrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using FrameworkCore.Utilities;
using FrameworkCore.DataFiles;
using System.Globalization;
using System.Linq;

namespace PimsSupport.PAGES
{
    public class RelationshipsPage : BaseComponent
    {
        public LandingPage landingPage;
        public string ExpectedPageURL;
        public string ExpectedPageURL_CreateNew;
        public string ExpectedPageURL_Details;
        public string ExpectedPageURL_Edit;
        public string ExpectedPageURL_Delete;
        public string ExpectedPageURL_UDFs;
        public string ExpectedPageURL_QuickComment;
        public string ExpectedPageURL_CreateRates;
        public string ExpectedPageURL_RatesDetails;
        public string ExpectedPageURL_RatesEdit;
        public string ExpectedPageURL_RatesDelete;


        
        public string columnNameDescription;
        public string columnNameState;
        public string columnNameRelationshipIdNumber;
        public string columnNameCoverageType;
        public string columnNameEffectiveDate;
        public string columnNameTerminationDate;
        public string columnNameCancelledDate;
        public string columnNameStatus;

        private WebElementProxy pageURL;
        private WebElementProxy pageTitle;
        private WebElementProxy footer;
        private WebElementProxy createNew;

        //private IWebElement table_main;
        //private IWebElement tableHead_main;
        //private IWebElement tableBody_main;
        //private IWebElement table1;
        //private IWebElement tableHead1;
        //private IWebElement table2;
        //private IWebElement tableHead2;
        //private IWebElement table3;
        //private IWebElement tableHead3;

        private WebElementProxy table_main;
        private WebElementProxy tableHead_main;
        private WebElementProxy tableBody_main;
        private WebElementProxy tableBody_FirstRow;
        private WebElementProxy columnDescription;
        private WebElementProxy columnState;
        private WebElementProxy columnRelationshipIdNumber;
        private WebElementProxy columnCoverageType;
        private WebElementProxy columnEffectiveDate;
        private WebElementProxy columnTerminationDate;
        private WebElementProxy columnCancelledDate;
        private WebElementProxy columnStatus;
        private WebElementProxy webTableRow0;
        private WebElementProxy webTableRow1;
        private WebElementProxy firstDescription;
        
        private WebElementProxy firstRowRelationshipIDNumber;

        private WebElementProxy detailsOption;
        private WebElementProxy editOption;
        private WebElementProxy deleteOption;
        private WebElementProxy udfsOption;
        private WebElementProxy quickCommentOption;
        private WebElementProxy viewOption;
        private WebElementProxy viewOption_Comments;
        private WebElementProxy viewOption_Commissions;
        private WebElementProxy viewOption_Fees;
        private WebElementProxy viewOption_ImportExport;
        private WebElementProxy viewOption_Products;
        private WebElementProxy viewOption_Rates;

        private WebElementProxy table1;
        private WebElementProxy tableHead1;
        private WebElementProxy filters;
        private WebElementProxy filters_FilterBy;
        private WebElementProxy filters_FilterBy_PrimaryKey;
        private WebElementProxy filters_FilterBy_CoverageType;
        private WebElementProxy filters_FilterBy_Relationship;
        private WebElementProxy filters_FilterBy_RelationshipIdNumber;
        private WebElementProxy filters_FilterBy_State;
        private WebElementProxy filters_FilterBy_Status;
        private WebElementProxy filters_ContainingOrLike;
        private WebElementProxy t1r1c1;
        private WebElementProxy t1r1c2;
        private WebElementProxy t1r2c1;
        private WebElementProxy t1r2c2;
        private WebElementProxy t1r3c1;
        private WebElementProxy t1r3c2;
        private WebElementProxy t1r4c1;
        private WebElementProxy t1r4c2;
        private WebElementProxy t1r5c1;
        private WebElementProxy t1r5c2;
        private WebElementProxy t1r6c1;
        private WebElementProxy t1r6c2;

        private WebElementProxy table2;
        private WebElementProxy tableHead2;
        private WebElementProxy dateFilters;
        private WebElementProxy dateFilters_FilterBy_Created;
        private WebElementProxy dateFilters_FilterBy_Modified;
        private WebElementProxy dateFilters_NoNameBox1_Between;
        private WebElementProxy dateFilters_NoNameBox1_GreaterAndEqual;
        private WebElementProxy dateFilters_NoNameBox1_Greater;
        private WebElementProxy dateFilters_NoNameBox1_NutNULL;
        private WebElementProxy dateFilters_BeginDate;
        private WebElementProxy dateFilters_NoNameBox2_Between;
        private WebElementProxy dateFilters_NoNameBox2_GreaterAndEqual;
        private WebElementProxy dateFilters_NoNameBox2_Greater;
        private WebElementProxy dateFilters_NoNameBox2_NutNULL;
        private WebElementProxy dateFilters_EndDate;
        private WebElementProxy t2r1c1;
        private WebElementProxy t2r1c2;
        private WebElementProxy t2r1c3;
        private WebElementProxy t2r1c4;
        private WebElementProxy t2r1c5;
        private WebElementProxy t2r1c6;
        private WebElementProxy t2r2c1;
        private WebElementProxy t2r2c2;
        private WebElementProxy t2r2c3;
        private WebElementProxy t2r2c4;
        private WebElementProxy t2r2c5;
        private WebElementProxy t2r2c6;

        private WebElementProxy table3;
        private WebElementProxy tableHead3;
        private WebElementProxy orderBy;
        public string orderOrSortBy_Blank;
        public string orderOrSortBy_PrimaryKey;
        public string orderOrSortBy_CoverageType;
        public string orderOrSortBy_Relationship;
        public string orderOrSortBy_RelationshipIdNumber;
        public string orderOrSortBy_State;
        public string orderOrSortBy_Status;
        public string orderOrSortBy_Created;
        public string orderOrSortBy_Modified;
        private WebElementProxy direction;
        public string direction_Blank;
        public string direction_Ascending;
        public string direction_Descending;
        private WebElementProxy t3r1c1;
        private WebElementProxy t3r1c2;
        private WebElementProxy t3r2c1;
        private WebElementProxy t3r2c2;
        private WebElementProxy t3r3c1;
        private WebElementProxy t3r3c2;
        private WebElementProxy t3r4c1;
        private WebElementProxy t3r4c2;
        private WebElementProxy t3r5c1;
        private WebElementProxy t3r5c2;
        private WebElementProxy t3r6c1;
        private WebElementProxy t3r6c2;

        private WebElementProxy goToPageButton;
        private WebElementProxy goToPageBox;
        private WebElementProxy pageNumberBox;
        private WebElementProxy rowPerPageBox;
        private WebElementProxy goToTheNextPageArrow;
        private WebElementProxy goToThePreviousPageArrow;
        private WebElementProxy goToTheFirtPageArrow;
        private WebElementProxy goToTheLastPageArrow;
        private WebElementProxy help;
        private WebElementProxy totalRowNumber;

        //--------------create new
        private WebElementProxy client_Create;
        private WebElementProxy clientBox_Create;
        private WebElementProxy clientIDisRequired_Create;
        private WebElementProxy descExtension_Create;
        private WebElementProxy descExtensionBox_Create;
        private WebElementProxy effectiveDate_Create;
        private WebElementProxy effectiveDateBox_Create;
        private WebElementProxy effectiveDateIsRequired_Create;
        private WebElementProxy product_Create;
        private WebElementProxy productBox_Create;
        private WebElementProxy productIsRequired_Create;
        private WebElementProxy duplicateRelationshipIDnotAllowed_Create;
        private WebElementProxy createButton_Create;
        private WebElementProxy backTolist_Create;
        private WebElementProxy descExtensionWarningMessage_Create;

        //--------------edit
        public string expectedPageTitle_edit; //= "Edit Relationships";
        private WebElementProxy relationship_Edit;
        private WebElementProxy defaultClassBox_Edit;
        private WebElementProxy ezAlertImpactBox_Edit;
        private WebElementProxy commentBox_Edit;
        private WebElementProxy saveButton_Edit;
        private WebElementProxy relationshipUpdatedMesage_Edit;

        private WebElementProxy statusBox_Edit;
        private WebElementProxy cancelledDateBox_Edit;
        private WebElementProxy commissionOptionBox_Edit;
        private WebElementProxy feesOptionBox_Edit;
        private WebElementProxy ratesOptionBox_Edit;
        private WebElementProxy iQQCUIDBox_Edit;
        private WebElementProxy invoiceFormatBox_Edit;
        private WebElementProxy masterRelationshipBox_Edit;
        private WebElementProxy subjectBox_Edit;
        private WebElementProxy descExtension_Edit;


        //-------------delete
        private WebElementProxy AreYouSureYouWantToDeleteThisMwsage;
        private WebElementProxy deleteButton;
        private WebElementProxy relationshipDeletedMwsage;


        //-----------Detils
        private WebElementProxy cancelledDate;
        private WebElementProxy backTolist_Details;
        private WebElementProxy commissionsPanelCond;
        private WebElementProxy feesPanelCond;
        private WebElementProxy ratesPanelCond;
        private WebElementProxy productsPanelCond;
        private WebElementProxy commentsPanelCond;
        private WebElementProxy commissionsPanel;
        private WebElementProxy feesPanel;
        private WebElementProxy ratesPanel;
        private WebElementProxy productsPanel;
        private WebElementProxy commentsPanel;
        private WebElementProxy commissionsPanelEffectiveDate;
        private WebElementProxy feesPanelEffectiveDate;
        private WebElementProxy ratesPanelEffectiveDate;
        private WebElementProxy productsPanelEffectiveDate;
        private WebElementProxy commentsPanelSubject;
        private WebElementProxy feesPanelRepresentative;
        private WebElementProxy feesPanelAmount;
        private WebElementProxy feesPanelPercentage;
        private WebElementProxy goToBottomButtun;
        private WebElementProxy backToTopButtun;
        private WebElementProxy relationshipIdNumber_Details;
        private WebElementProxy descExtension_Details;

        //-------------- Comment

        private WebElementProxy commentsSubjectBox;
        private WebElementProxy commentsCommentBox;
        private WebElementProxy commentsCreateButton;
        private WebElementProxy commentsSaveButton;
        private WebElementProxy commentsBackToListButton;
        private WebElementProxy commentCreatedMessage;
        private WebElementProxy commentUpdatedMessage;
        private WebElementProxy commentEditOption;
        private WebElementProxy commentCreateNew;
        private WebElementProxy commentPageTitleActual;
        string commentPageTitleExpected = "Relationship Comments";

        //------------------View

        private WebElementProxy View;
        private WebElementProxy ViewComments;
        private WebElementProxy ViewCommissions;
        private WebElementProxy ViewFees;
        private WebElementProxy ViewImportExport;
        private WebElementProxy ViewProducts;
        private WebElementProxy ViewRates;

        //--------------View - Rates
        private WebElementProxy RatesTitle;
        private WebElementProxy RatesClassCode;
        private WebElementProxy RatesClass;
        private WebElementProxy RatesRate;
        private WebElementProxy RatesUnit;
        private WebElementProxy RatesCreateNew;
        private WebElementProxy RatesEffectiveDate;
        private WebElementProxy RatesBackToList;
        private WebElementProxy RatesBackToTop;
        private WebElementProxy RatesDetails;
        private WebElementProxy RatesEdit;
        private WebElementProxy RatesDelete;

        //--------------View - Rates - Create
        private WebElementProxy CreateRates_NewEffectiveDateBox;
        private WebElementProxy CreateRates_NewEffectiveDateWarningMessage;
        private WebElementProxy CreateRates_BasedOnBox;
        private WebElementProxy CreateRates_BasedOnBoxOption1;
        private WebElementProxy CreateRates_BasedOnBoxOption2;
        private WebElementProxy CreateRates_BasedOnBoxOption3;
        private WebElementProxy CreateRates_BasedOnBoxOption4;
        private WebElementProxy CreateRates_Create;
        private WebElementProxy CreateRates_SubjectBox;
        private WebElementProxy CreateRates_CommentsBox;
        private WebElementProxy CreateRates_SaveButton;
        private WebElementProxy CreateRates_AddClass;
        private WebElementProxy CreateRates_Table1;
        private WebElementProxy CreateRates_Class;
        private WebElementProxy CreateRates_Rate;
        private WebElementProxy CreateRates_MaxEligibilityTerm;
        private WebElementProxy CreateRates_MaxCoverageTerm;
        private WebElementProxy CreateRates_MaxAmt;
        private WebElementProxy CreateRates_NewClass;
        private WebElementProxy CreateRates_NewRate;
        private WebElementProxy CreateRates_NewMaxEligibilityTerm;
        private WebElementProxy CreateRates_NewMaxCoverageTerm;
        private WebElementProxy CreateRates_NewMaxAmt;
        //private static int CreateRates_NewRowNumber;
        private WebElementProxy CreateRates_ClassCode1;


        //--------------View - Rates - Details
        private WebElementProxy RatesDetailsTitle;        
        private WebElementProxy RatesDetailsEdit;
        private WebElementProxy RatesDetailsDelete;
        private WebElementProxy RatesDetailsBackToList;
        
        private WebElementProxy RatesDetailsEffectiveDate;
        private WebElementProxy RatesDetailsMaximumCoverageTerm;
        private WebElementProxy RatesDetailsCreated;
        private WebElementProxy RatesDetailsModified;
        private WebElementProxy RatesDetailsUserName;

        //--------------View - Rates - Edit
        private WebElementProxy RatesEdit_Title;
        private WebElementProxy RatesEdit_BackToList;
        private WebElementProxy RatesEdit_BackToTop;
        private WebElementProxy RatesEdit_EffectiveDate;
        private WebElementProxy RatesEdit_Rate;
        private WebElementProxy RatesEdit_MaximumEligibilityTerm;
        private WebElementProxy RatesEdit_MaximumCoverageTerm;
        private WebElementProxy RatesEdit_Unit;
        private WebElementProxy RatesEdit_MaximumAmount;
        private WebElementProxy RatesEdit_OverrideFee1;
        private WebElementProxy RatesEdit_OverrideFee2;
        private WebElementProxy RatesEdit_OverrideFee3;
        private WebElementProxy RatesEdit_Amount11;
        private WebElementProxy RatesEdit_Amount12;
        private WebElementProxy RatesEdit_Amount13;
        private WebElementProxy RatesEdit_Unit11;
        private WebElementProxy RatesEdit_Unit12;
        private WebElementProxy RatesEdit_Unit13;
        private WebElementProxy RatesEdit_Percentage11;
        private WebElementProxy RatesEdit_Percentage12;
        private WebElementProxy RatesEdit_Percentage13;
        private WebElementProxy RatesEdit_Formula11;
        private WebElementProxy RatesEdit_Formula12;
        private WebElementProxy RatesEdit_Formula13;
        private WebElementProxy RatesEdit_OverrideCommission1;
        private WebElementProxy RatesEdit_OverrideCommission2;
        private WebElementProxy RatesEdit_OverrideCommission3;
        private WebElementProxy RatesEdit_Amount21;
        private WebElementProxy RatesEdit_Amount22;
        private WebElementProxy RatesEdit_Amount23;
        private WebElementProxy RatesEdit_Unit21;
        private WebElementProxy RatesEdit_Unit22;
        private WebElementProxy RatesEdit_Unit23;
        private WebElementProxy RatesEdit_Percentage21;
        private WebElementProxy RatesEdit_Percentage22;
        private WebElementProxy RatesEdit_Percentage23;
        private WebElementProxy RatesEdit_Formula21;
        private WebElementProxy RatesEdit_Formula22;
        private WebElementProxy RatesEdit_Formula23;
        private WebElementProxy RatesEdit_Subject;
        private WebElementProxy RatesEdit_Comments;
        private WebElementProxy RatesEdit_Save;
        private WebElementProxy Rates_RatesUpdatedMessage;


        //--------------View - Rates - Delete
        private WebElementProxy RatesDelete_Title;
        private WebElementProxy RatesDelete_BackToList;
        private WebElementProxy RatesDelete_DeleteButton;
        private WebElementProxy RatesDelete_RateDeletedMessage;

        //--------------View - Fees

        private WebElementProxy Fees_PageTitle;
        private WebElementProxy Fees_RelationshipDescription;
        private WebElementProxy Fees_CreateNew;
        private WebElementProxy Fees_EffectiveDate;
        private WebElementProxy Fees_GoToRevision;
        private WebElementProxy Fees_GoToBottom;
        private WebElementProxy Fees_BackToTop;
        private WebElementProxy Fees_DataSoldRadioButton;
        private WebElementProxy Fees_DataForwardRadioButton;
        private WebElementProxy Fees_FeeType;
        private WebElementProxy Fees_Representative;
        private WebElementProxy Fees_AdjustNAC;
        private WebElementProxy Fees_AdjustAdjNAC;
        private WebElementProxy Fees_AdjustAdjAdjNAC;
        private WebElementProxy Fees_AdjustNetPremium;
        private WebElementProxy Fees_PremiumCommissionReceived;
        private WebElementProxy Fees_PartialChargeBack;
        private WebElementProxy Fees_FullChargeBack;
        private WebElementProxy Fees_Revision;
        private WebElementProxy Fees_Created;
        private WebElementProxy Fees_Modified;
        private WebElementProxy Fees_UserName;
        private WebElementProxy Fees_Edit;
        private WebElementProxy Fees_BackToList;
        private WebElementProxy Fees_FootSignature;

        //--------------View - Fees - Create
        private WebElementProxy CreateFees_NewEffectiveDate;
        private WebElementProxy CreateFees_NewEffectiveDateWarningMessage;
        private WebElementProxy CreateFees_BasedOn;
        private WebElementProxy CreateFees_BasedOnBoxOption1;
        private WebElementProxy CreateFees_BasedOnBoxOption2;
        private WebElementProxy CreateFees_BasedOnBoxOption3;
        private WebElementProxy CreateFees_BasedOnBoxOption4;
        private WebElementProxy CreateFees_Create;
        private WebElementProxy CreateFees_BackToList;
        private WebElementProxy CreateFees_FootSignature;

        private WebElementProxy CreateFees_Subject;
        private WebElementProxy CreateFees_Comments;
        private WebElementProxy CreateFees_SaveButton;
        private WebElementProxy CreateFees_AddClass;
        private WebElementProxy CreateFees_Table1;
        private WebElementProxy CreateFees_Class;
        private WebElementProxy CreateFees_Rate;
        private WebElementProxy CreateFees_MaxEligibilityTerm;
        private WebElementProxy CreateFees_MaxCoverageTerm;
        private WebElementProxy CreateFees_MaxAmt;
        private WebElementProxy CreateFees_NewClass;
        private WebElementProxy CreateFees_NewRate;
        private WebElementProxy CreateFees_NewMaxEligibilityTerm;
        private WebElementProxy CreateFees_NewMaxCoverageTerm;
        private WebElementProxy CreateFees_NewMaxAmt;
        //private static int CreateFees_NewRowNumber;
        private WebElementProxy CreateFees_ClassCode1;





        public RelationshipsPage(IWebDriver driver, LandingPage landingPage) : base(driver)
        {
            this.landingPage = landingPage;
            InitializeElements();
        }
        private void InitializeElements()
        {
            ExpectedPageURL = "PimsSupport/Relationships";
            ExpectedPageURL_CreateNew = "PimsSupport/Relationships/Create";
            ExpectedPageURL_Details = "PimsSupport/Relationships/Details";
            ExpectedPageURL_Edit = "PimsSupport/Relationships/Edit/";
            ExpectedPageURL_Delete = "PimsSupport/Relationships/Delete";
            ExpectedPageURL_UDFs = "PimsSupport/RelationshipUDF/Details";
            ExpectedPageURL_QuickComment = "PimsSupport/RelationshipComments/Create";
            ExpectedPageURL_CreateRates = "PimsSupport/RateRevision/CreateClone";
            ExpectedPageURL_RatesDetails = "PimsSupport/RateRevision/Details";
            ExpectedPageURL_RatesEdit = "PimsSupport/RateRevision/Edit";
            ExpectedPageURL_RatesDelete = "PimsSupport/RateRevision/Delete";


            pageURL = new WebElementProxy(driver);
            pageTitle = new WebElementProxy(driver, By.CssSelector(".body-content.container > h4:nth-of-type(1)"));
            footer = new WebElementProxy(driver, By.CssSelector("footer > p"));
            createNew = new WebElementProxy(driver, By.CssSelector("p > a")); 
            firstRowRelationshipIDNumber = new WebElementProxy(driver, By.CssSelector("#relationshipTable > tbody > tr:nth-child(2) > td.selectedRid"));


            // --------------------Main table
            table_main = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > table"));   // //table[@class='table']
            tableHead_main = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > table > tbody > tr:nth-child(1)"));
            tableBody_main = new WebElementProxy(driver, By.XPath("/html/body/div[2]/table/tbody"));                 // css: tbody
            tableBody_FirstRow = new WebElementProxy(driver, By.CssSelector("#relationshipTable > tbody > tr:nth-child(2)"));                 // css: tbody
            columnNameDescription = "Description";
            columnNameState = "State";
            columnNameRelationshipIdNumber = "Relationship ID #";
            columnNameCoverageType = "Coverage Type";
            columnNameEffectiveDate = "Effective Date";
            columnNameTerminationDate = "Termination Date";
            columnNameCancelledDate = "Cancelled Date";
            columnNameStatus = "Status";
            firstDescription = new WebElementProxy(driver, By.CssSelector("#relationshipTable > tbody > tr:nth-child(2) > td:nth-child(3)"));   // //table[@class='table']

            columnDescription = new WebElementProxy(driver,         By.CssSelector("#relationshipTable > tbody > tr:nth-of-type(1) > th:nth-of-type(2)"));
            columnState = new WebElementProxy(driver,               By.CssSelector("#relationshipTable > tbody > tr:nth-of-type(1) > th:nth-of-type(3)"));
            columnRelationshipIdNumber = new WebElementProxy(driver,By.CssSelector("#relationshipTable > tbody > tr:nth-of-type(1) > th:nth-of-type(4)"));
            columnCoverageType = new WebElementProxy(driver,        By.CssSelector("#relationshipTable > tbody > tr:nth-of-type(1) > th:nth-of-type(5)"));
            columnEffectiveDate = new WebElementProxy(driver,       By.CssSelector("#relationshipTable > tbody > tr:nth-of-type(1) > th:nth-of-type(6)"));
            columnTerminationDate = new WebElementProxy(driver,     By.CssSelector("#relationshipTable > tbody > tr:nth-of-type(1) > th:nth-of-type(7)"));
            columnCancelledDate = new WebElementProxy(driver,       By.CssSelector("#relationshipTable > tbody > tr:nth-of-type(1) > th:nth-of-type(8)"));
            columnStatus = new WebElementProxy(driver,              By.CssSelector("#relationshipTable > tbody > tr:nth-of-type(1) > th:nth-of-type(9)"));

            detailsOption           = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row > a:nth-of-type(1)"));
            editOption              = new WebElementProxy(driver, By.CssSelector(".link-row > a:nth-of-type(2)"));
            deleteOption            = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row > a:nth-of-type(3)"));
            udfsOption              = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row > a:nth-of-type(4)"));
            quickCommentOption      = new WebElementProxy(driver, By.CssSelector ("#relationshipTable > tbody > tr:nth-child(2) > td.link-row > a:nth-child(9)"));    //("tr:nth-of-type(2) > .link-row > a:nth-of-type(5)"));  // ("//tbody/tr[2]/td[1]/a[5]"));   
            viewOption              = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row a[role='button']")); // XPath("//tbody/tr[2]/td[1]/div[1]/li[1]/a[1]"));
            viewOption_Comments     = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(1) > a"));
            viewOption_Commissions  = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(2) > a"));
            viewOption_Fees         = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(3) > a"));
            viewOption_ImportExport = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(4) > a"));
            viewOption_Products     = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(5) > a"));
            viewOption_Rates        = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(6) > a"));
            webTableRow0            = new WebElementProxy(driver, By.CssSelector("#relationshipTable > tbody > tr:nth-child(1)"));
            webTableRow1            = new WebElementProxy(driver, By.CssSelector("#relationshipTable > tbody > tr:nth-child(2)"));
            

            // --------------------Table1 -Filters
            table1 = new WebElementProxy(driver, By.PartialLinkText("Filters"));   
            tableHead1 = new WebElementProxy(driver, By.CssSelector("#collapseOne > div > table > tbody > tr:nth-child(1)"));
            t1r1c1 = new WebElementProxy(driver, By.CssSelector("#collapseOne .panel-body table tbody > tr:nth-child(2) > td:nth-child(1) [name='ddlPageFilter']"));
            t1r1c2 = new WebElementProxy(driver, By.CssSelector("#pageNavigation_PageFilters_0__Value"));
            t1r2c1 = new WebElementProxy(driver, By.CssSelector("#collapseOne .panel-body table tbody > tr:nth-child(3) > td:nth-child(1) [name='ddlPageFilter']"));
            t1r2c2 = new WebElementProxy(driver, By.CssSelector("#pageNavigation_PageFilters_1__Value"));
            t1r3c1 = new WebElementProxy(driver, By.CssSelector("#collapseOne .panel-body table tbody > tr:nth-child(4) > td:nth-child(1) [name='ddlPageFilter']"));
            t1r3c2 = new WebElementProxy(driver, By.CssSelector("#pageNavigation_PageFilters_2__Value"));
            t1r4c1 = new WebElementProxy(driver, By.CssSelector("#collapseOne .panel-body table tbody > tr:nth-child(5) > td:nth-child(1) [name='ddlPageFilter']"));
            t1r4c2 = new WebElementProxy(driver, By.CssSelector("#pageNavigation_PageFilters_3__Value"));
            t1r5c1 = new WebElementProxy(driver, By.CssSelector("#collapseOne .panel-body table tbody > tr:nth-child(6) > td:nth-child(1) [name='ddlPageFilter']"));
            t1r5c2 = new WebElementProxy(driver, By.CssSelector("#pageNavigation_PageFilters_4__Value"));
            t1r6c1 = new WebElementProxy(driver, By.CssSelector("#collapseOne .panel-body table tbody > tr:nth-child(7) > td:nth-child(1) [name='ddlPageFilter']"));
            t1r6c2 = new WebElementProxy(driver, By.CssSelector("#pageNavigation_PageFilters_5__Value"));
            filters = new WebElementProxy(driver, By.CssSelector(".col-md-4.col-sm-4 > .panel-group > .panel.panel-default > .panel-default  .panel-title"));
            filters_ContainingOrLike = new WebElementProxy(driver, By.CssSelector(".col-md-4.col-sm-4 > .panel-group > .panel.panel-default > .panel-default  .panel-title"));


            // --------------------Table2 - Date Filters
            table2 = new WebElementProxy(driver, By.PartialLinkText("Date Filters"));    
            tableHead2 = new WebElementProxy(driver, By.CssSelector("#collapseTwo > div > table > tbody > tr:nth-child(1)"));

            t2r1c1 = new WebElementProxy(driver, By.CssSelector("#collapseTwo .panel-body table tbody > tr:nth-child(2) > td:nth-child(1) [name='ddlDateFilter']"));
            t2r1c2 = new WebElementProxy(driver, By.CssSelector("#collapseTwo .panel-body table tbody > tr:nth-child(2) > td:nth-child(2) [name='ddlBeginOperator']"));
            t2r1c3 = new WebElementProxy(driver, By.CssSelector("#pageNavigation_PageDateFilters_0__BeginDate"));                                                           //#collapseTwo .panel-body table tbody > tr:nth-child(2) > td:nth-child(3) [name='pageNavigation.PageDateFilters[0].BeginDate']"));
            t2r1c4 = new WebElementProxy(driver, By.CssSelector("#collapseTwo .panel-body table tbody > tr:nth-child(2) > td:nth-child(4) [name='ddlEndOperator']"));
            t2r1c5 = new WebElementProxy(driver, By.CssSelector("#pageNavigation_PageDateFilters_0__EndDate"));                                                             //#collapseTwo .panel-body table tbody > tr:nth-child(2) > td:nth-child(5) [name='pageNavigation.PageDateFilters[0].EndDate']"));
            t2r2c1 = new WebElementProxy(driver, By.CssSelector("#collapseTwo .panel-body table tbody > tr:nth-child(3) > td:nth-child(1) [name='ddlDateFilter']"));
            t2r2c2 = new WebElementProxy(driver, By.CssSelector("#collapseTwo .panel-body table tbody > tr:nth-child(3) > td:nth-child(2) [name='ddlBeginOperator']"));
            t2r2c3 = new WebElementProxy(driver, By.CssSelector("#pageNavigation_PageDateFilters_1__BeginDate"));
            t2r2c4 = new WebElementProxy(driver, By.CssSelector("#collapseTwo .panel-body table tbody > tr:nth-child(3) > td:nth-child(4) [name='ddlEndOperator']"));  
            t2r2c5 = new WebElementProxy(driver, By.CssSelector("#pageNavigation_PageDateFilters_1__EndDate"));
            dateFilters = new WebElementProxy(driver, By.PartialLinkText("Date Filters"));

            // --------------------Table3 - Order By
            table3 = new WebElementProxy(driver, By.PartialLinkText("Order By"));                   //CssSelector(".col-md-3.col-sm-3 > div#accordion  .collapsed.panel-default > .panel-heading > .panel-title"));   // //table[@class='table']
            tableHead3 = new WebElementProxy(driver, By.CssSelector("#collapseThree > div > table > tbody > tr:nth-child(1)"));
            t3r1c1 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(2) > td:nth-child(1) [name='ddlOrderBy']"));  
            t3r1c2 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(2) > td:nth-child(2) [name='ddlOrderDirection']"));
            t3r2c1 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(3) > td:nth-child(1) [name='ddlOrderBy']"));
            t3r2c2 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(3) > td:nth-child(2) [name='ddlOrderDirection']"));
            t3r3c1 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(4) > td:nth-child(1) [name='ddlOrderBy']"));
            t3r3c2 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(4) > td:nth-child(2) [name='ddlOrderDirection']"));
            t3r4c1 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(5) > td:nth-child(1) [name='ddlOrderBy']"));
            t3r4c2 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(5) > td:nth-child(2) [name='ddlOrderDirection']"));
            t3r5c1 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(6) > td:nth-child(1) [name='ddlOrderBy']"));
            t3r5c2 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(6) > td:nth-child(2) [name='ddlOrderDirection']"));
            t3r6c1 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(7) > td:nth-child(1) [name='ddlOrderBy']"));
            t3r6c2 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(7) > td:nth-child(2) [name='ddlOrderDirection']"));
            t3r6c1 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(8) > td:nth-child(1) [name='ddlOrderBy']"));
            t3r6c2 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(8) > td:nth-child(2) [name='ddlOrderDirection']"));
            t3r6c1 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(9) > td:nth-child(1) [name='ddlOrderBy']"));
            t3r6c2 = new WebElementProxy(driver, By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(9) > td:nth-child(2) [name='ddlOrderDirection']"));
            orderBy = new WebElementProxy(driver, By.CssSelector(".col-md-3.col-sm-3 > div#accordion  .panel-default > .panel-heading"));                                            //XPath("//h4[contains(text(),'Order By')]"));
            
            
            orderOrSortBy_Blank                 = "";                               
            orderOrSortBy_PrimaryKey            = "Primary Key";                               
            orderOrSortBy_CoverageType          = "Coverage Type";
            orderOrSortBy_Relationship          = "Relationship";
            orderOrSortBy_RelationshipIdNumber  = "Relationship ID Number";
            orderOrSortBy_State                 = "State";
            orderOrSortBy_Status                = "Status";
            orderOrSortBy_Created               = "Created";
            orderOrSortBy_Modified              = "Modified";
            direction_Blank                     = "";
            direction_Ascending                 = "Ascending";
            direction_Descending                = "Descending";



            /*

        private WebElementProxy direction;
        public string direction_Blank;
        public string direction_Ascending;
        public string direction_Descending;
             */


            rowPerPageBox = new WebElementProxy(driver, By.CssSelector("input#pageNavigation_RowsPerPage"));
            goToTheFirtPageArrow =      new WebElementProxy(driver, By.CssSelector(".col-sm-3 > button:nth-of-type(1)"));
            goToThePreviousPageArrow =  new WebElementProxy(driver, By.CssSelector(".col-sm-3 > button:nth-of-type(2)"));
            goToTheNextPageArrow =      new WebElementProxy(driver, By.CssSelector(".col-sm-3 > button:nth-of-type(3)"));
            goToTheLastPageArrow =      new WebElementProxy(driver, By.CssSelector(".col-sm-3 > button:nth-of-type(4)"));
            help = new WebElementProxy(driver, By.CssSelector("form[method='post'] > div > div:nth-of-type(1) > div:nth-of-type(1) > a"));
            goToPageButton = new WebElementProxy(driver, By.CssSelector(".col-sm-2 > button[name='bsubmit']"));       // //button[contains(text(),'Go to Page')]
            goToPageBox = new WebElementProxy(driver, By.CssSelector("input#pageNavigation_PageNumber"));
            totalRowNumber = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(1) > div:nth-of-type(6)"));  // div:nth-of-type(1) > div:nth-of-type(6)

            //--------------------------- Create New
            client_Create = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(1) > .col-md-2.control-label"));
            descExtension_Create = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(2) > .col-md-2.control-label"));
            effectiveDate_Create = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(3) > .col-md-2.control-label"));
            product_Create = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(4) > .col-md-2.control-label"));

            clientBox_Create = new WebElementProxy(driver, By.CssSelector("#Client_ID_Number"));
            descExtensionBox_Create = new WebElementProxy(driver, By.CssSelector("#Description_Extension"));
            descExtensionWarningMessage_Create = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > form > div.form-horizontal > div:nth-child(4) > div > span > span"));
            effectiveDateBox_Create = new WebElementProxy(driver, By.CssSelector("#Program_Effective_Date"));
            productBox_Create = new WebElementProxy(driver, By.CssSelector("#Product_ID_Number"));

            clientIDisRequired_Create = new WebElementProxy(driver, By.CssSelector(".field-validation-error.text-danger > span"));
            effectiveDateIsRequired_Create = new WebElementProxy(driver, By.CssSelector(".field-validation-error.text-danger > span"));
            productIsRequired_Create = new WebElementProxy(driver, By.CssSelector(".field-validation-error.text-danger > span"));
            duplicateRelationshipIDnotAllowed_Create = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(1) > .col-md-2.control-label"));

            createButton_Create = new WebElementProxy(driver, By.CssSelector("input[value='Create']"));
            backTolist_Create = new WebElementProxy(driver, By.CssSelector(".form-actions.no-color > a"));

            //--------------------------- Details
            pageTitle = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > h4"));   
            footer = new WebElementProxy(driver, By.CssSelector("footer > p"));
            descExtension_Details = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(1) > .dl-horizontal > dd:nth-of-type(3)"));

            //-------------------------- Edit
            expectedPageTitle_edit = "Edit Relationships";
            relationship_Edit = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > h2"));
            pageTitle = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > h4"));
            footer = new WebElementProxy(driver, By.CssSelector("footer > p"));
            statusBox_Edit = new WebElementProxy(driver, By.CssSelector("select#Active"));
            cancelledDateBox_Edit = new WebElementProxy(driver, By.CssSelector("input#Cancelled_Date"));
            commissionOptionBox_Edit = new WebElementProxy(driver, By.CssSelector("select#Commission_Option"));
            feesOptionBox_Edit = new WebElementProxy(driver, By.CssSelector("select#Fees_Option"));
            ratesOptionBox_Edit = new WebElementProxy(driver, By.CssSelector("select#Rates_Option"));
            iQQCUIDBox_Edit = new WebElementProxy(driver, By.CssSelector("input#Relationship_IQQ_CUID"));
            invoiceFormatBox_Edit = new WebElementProxy(driver, By.CssSelector("select#Invoice_Format"));
            masterRelationshipBox_Edit = new WebElementProxy(driver, By.CssSelector("input#Master_Relationship_ID_Number"));
            defaultClassBox_Edit = new WebElementProxy(driver, By.CssSelector("select#Default_Class"));
            ezAlertImpactBox_Edit = new WebElementProxy(driver, By.CssSelector("select#EZAlertImpact"));
            subjectBox_Edit = new WebElementProxy(driver, By.CssSelector("input#Subject"));
            commentBox_Edit = new WebElementProxy(driver, By.CssSelector("input#Comment"));
            saveButton_Edit = new WebElementProxy(driver, By.CssSelector("input[value = 'Save']"));
            relationshipUpdatedMesage_Edit = new WebElementProxy(driver, By.XPath("//h4[contains(text(),'* Relationship updated')]"));//By.CssSelector(".text-success"));
            descExtension_Edit = new WebElementProxy(driver, By.XPath("//select[@id='Active']"));//By.CssSelector("input#Description_Extension"));


            //--------------------------- Delete
            pageTitle = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > h4"));
            footer = new WebElementProxy(driver, By.CssSelector("footer > p"));
            AreYouSureYouWantToDeleteThisMwsage = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > div:nth-child(6) > h3"));
            deleteButton = new WebElementProxy(driver, By.CssSelector("input[value='Delete']"));
            relationshipDeletedMwsage = new WebElementProxy(driver, By.CssSelector(".text-success"));


            //--------------------------- UDFs
            pageTitle = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > h4"));
            footer = new WebElementProxy(driver, By.CssSelector("footer > p"));

            //--------------------------- Quick Comment
            pageTitle = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > h4"));
            footer = new WebElementProxy(driver, By.CssSelector("footer > p"));
            commentsSubjectBox = new WebElementProxy(driver, By.CssSelector("input#Subject"));
            commentsCommentBox = new WebElementProxy(driver, By.CssSelector("textarea#Comment"));
            commentsCreateButton = new WebElementProxy(driver, By.CssSelector("input[value='Create']"));
            commentsSaveButton = new WebElementProxy(driver, By.CssSelector("input[value='Save']"));
            commentsBackToListButton = new WebElementProxy(driver, By.CssSelector(".body-content.container > form[method='post'] a"));
            commentCreatedMessage = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > h4.text-success"));
            commentUpdatedMessage = new WebElementProxy(driver, By.CssSelector(".text-success"));
            commentEditOption = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > td:nth-of-type(1) > a:nth-of-type(2)"));
            commentCreateNew = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > p > a"));
            commentPageTitleActual = new WebElementProxy(driver, By.CssSelector(".body-content.container > h4:nth-of-type(1)"));


            //-----------Detils
            cancelledDate = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(1) > .dl-horizontal > dd:nth-of-type(8)"));
            backTolist_Details = new WebElementProxy(driver, By.CssSelector("div#bottom > a:nth-of-type(2)"));
            commissionsPanelCond = new WebElementProxy(driver, By.XPath("//body/div[2]/div[2]/div[1]/a[1]"));
            feesPanelCond = new WebElementProxy(driver, By.XPath("//body/div[2]/div[3]/div[1]/a[1]"));
            ratesPanelCond = new WebElementProxy(driver, By.XPath("//body/div[2]/div[4]/div[1]/a[1]"));
            productsPanelCond = new WebElementProxy(driver, By.XPath("//body/div[2]/div[5]/div[1]/a[1]"));
            commentsPanelCond = new WebElementProxy(driver, By.XPath("//body/div[2]/div[6]/div[1]/a[1]"));
            commissionsPanel = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > div:nth-child(6) > div > a > div > h4"));
            feesPanel = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(3) > div#accordion > .panel-default  .panel-title"));
            ratesPanel = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(4) > div#accordion > .panel-default  .panel-title"));
            productsPanel = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(5) > div#accordion > .panel-default  .panel-title"));
            commentsPanel = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(6) > div#accordion > .panel-default  .panel-title"));
            commissionsPanelEffectiveDate = new WebElementProxy(driver, By.CssSelector("#collapseOne > div > div > div.col-md-5 > fieldset > div > label"));
            feesPanelEffectiveDate = new WebElementProxy(driver, By.CssSelector("#collapseTwo > div > div > div.col-md-5 > fieldset > div > label"));
            ratesPanelEffectiveDate = new WebElementProxy(driver, By.CssSelector("..."));
            productsPanelEffectiveDate = new WebElementProxy(driver, By.CssSelector("#collapseFour > div > div > div > fieldset > div > label"));
            commentsPanelSubject = new WebElementProxy(driver, By.CssSelector("#collapseFive > table > tbody > tr:nth-child(1) > th:nth-child(1)"));
            feesPanelRepresentative = new WebElementProxy(driver, By.CssSelector("#collapseTwo > div > table > tbody > tr:nth-child(1) > th:nth-child(3)"));
            feesPanelAmount = new WebElementProxy(driver, By.CssSelector("#collapseTwo > div > table > tbody > tr:nth-child(1) > th:nth-child(3)"));
            feesPanelPercentage = new WebElementProxy(driver, By.CssSelector("#collapseTwo > div > table > tbody > tr:nth-child(1) > th:nth-child(5)"));
            goToBottomButtun = new WebElementProxy(driver, By.CssSelector("a[title='Go to bottom of page']"));
            backToTopButtun = new WebElementProxy(driver, By.CssSelector("#bottom > p > a"));
            relationshipIdNumber_Details = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(2) > .dl-horizontal > dd:nth-of-type(29)"));
            descExtension_Details = new WebElementProxy(driver, By.CssSelector("div:nth-of-type(1) > .dl-horizontal > dd:nth-of-type(3)"));

            //------------------View - first row type(2), second row type(3), ...
            View = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row a[role='button']"));
            ViewComments = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(1) > a"));
            ViewCommissions = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(2) > a"));
            ViewFees = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(3) > a"));
            ViewImportExport = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(4) > a"));
            ViewProducts = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(5) > a"));
            ViewRates = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > .link-row ul[role='menu'] > li:nth-of-type(6) > a"));

            //--------------View Rates
            RatesTitle = new WebElementProxy(driver, By.CssSelector(".body-content.container > h4:nth-of-type(1)"));
            RatesClassCode = new WebElementProxy(driver, By.CssSelector("tr > th:nth-of-type(2)"));
            RatesClass = new WebElementProxy(driver, By.CssSelector("tr > th:nth-of-type(3)"));
            RatesRate = new WebElementProxy(driver, By.CssSelector("tr > th:nth-of-type(4)"));
            RatesUnit = new WebElementProxy(driver, By.CssSelector("tr > th:nth-of-type(5)"));
            
            RatesCreateNew = new WebElementProxy(driver, By.CssSelector("form[method='post'] > a"));
            RatesEffectiveDate = new WebElementProxy(driver, By.CssSelector("#item_Revision"));
            RatesBackToList = new WebElementProxy(driver, By.XPath("//a[contains(text(),'Back to List')]"));
            RatesBackToTop = new WebElementProxy(driver, By.CssSelector(".pull-right > a"));
            RatesDetails = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > td:nth-of-type(1) > a:nth-of-type(1)"));
            RatesEdit = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > td:nth-of-type(1) > a:nth-of-type(2)"));
            RatesDelete = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > td:nth-of-type(1) > a:nth-of-type(3)"));

            CreateRates_NewEffectiveDateBox = new WebElementProxy(driver, By.CssSelector("#NewDateEdit"));  
            CreateRates_NewEffectiveDateWarningMessage = new WebElementProxy(driver, By.CssSelector(".field-validation-error.text-danger > span"));
            CreateRates_BasedOnBox = new WebElementProxy(driver, By.CssSelector("select#OldEffectiveDate"));
            CreateRates_BasedOnBoxOption1 = new WebElementProxy(driver, By.CssSelector("#OldEffectiveDate > option:nth-child(1)"));
            CreateRates_BasedOnBoxOption2 = new WebElementProxy(driver, By.CssSelector("#OldEffectiveDate > option:nth-child(2)"));
            CreateRates_BasedOnBoxOption3 = new WebElementProxy(driver, By.CssSelector("#OldEffectiveDate > option:nth-child(3)"));
            CreateRates_BasedOnBoxOption4 = new WebElementProxy(driver, By.CssSelector("#OldEffectiveDate > option:nth-child(4)"));
            CreateRates_Create = new WebElementProxy(driver, By.CssSelector("input[value='Create']"));    //XPath("/html/body/div[2]/form/div/div[3]/div/input"));                 //"//input[@value='Create']"));                     // "/html/body/div[2]/form/div/div[3]/div/input"
            CreateRates_SubjectBox = new WebElementProxy(driver, By.CssSelector("input#newRates_0__Subject"));
            CreateRates_CommentsBox = new WebElementProxy(driver, By.CssSelector("input#newRates_0__Comment"));
            CreateRates_SaveButton = new WebElementProxy(driver, By.CssSelector("input[name='submit']"));

            CreateRates_AddClass = new WebElementProxy(driver, By.CssSelector("input#btnAddNewRow"));
            CreateRates_Table1 = new WebElementProxy(driver, By.CssSelector("#ajaxgrid > table > tbody"));

            CreateRates_Class = new WebElementProxy(driver, By.CssSelector("select#newRates_0__Class_Code"));
            CreateRates_Rate = new WebElementProxy(driver, By.CssSelector("input#newRates_0__Rate"));
            CreateRates_MaxEligibilityTerm = new WebElementProxy(driver, By.CssSelector("input#newRates_0__Max_Term"));
            CreateRates_MaxCoverageTerm = new WebElementProxy(driver, By.CssSelector("input#newRates_0__Maximum_Coverage_Term"));
            CreateRates_MaxAmt = new WebElementProxy(driver, By.CssSelector("input#newRates_0__Max_Amount"));
            CreateRates_ClassCode1 = new WebElementProxy(driver, By.CssSelector("td:nth-of-type(2) > strong"));
            

            //--------------View - Rates - Details
            RatesDetailsTitle       = new WebElementProxy(driver, By.CssSelector(".body-content.container > h4"));
            RatesDetailsEdit        = new WebElementProxy(driver, By.CssSelector("p > a:nth-of-type(1)"));
            RatesDetailsDelete      = new WebElementProxy(driver, By.CssSelector("p > a:nth-of-type(2)"));
            RatesDetailsBackToList  = new WebElementProxy(driver, By.CssSelector("p > a:nth-of-type(3)"));
            RatesDetailsEffectiveDate = new WebElementProxy(driver, By.CssSelector(".body-content.container > div > .dl-horizontal > dd:nth-of-type(1)"));
            
            RatesDetailsMaximumCoverageTerm = new WebElementProxy(driver, By.CssSelector(".body-content.container > div > .dl-horizontal > dd:nth-of-type(8)"));
            RatesDetailsCreated     = new WebElementProxy(driver, By.CssSelector(".body-content.container > .dl-horizontal > dd:nth-of-type(1)"));
            RatesDetailsModified    = new WebElementProxy(driver, By.CssSelector(".body-content.container > .dl-horizontal > dd:nth-of-type(2)"));
            RatesDetailsUserName    = new WebElementProxy(driver, By.CssSelector(".body-content.container > .dl-horizontal > dd:nth-of-type(3)"));

            //--------------View - Rates - Edit
            RatesEdit_Title = new WebElementProxy(driver, By.CssSelector(".body-content.container > h4"));
            RatesEdit_BackToList = new WebElementProxy(driver, By.CssSelector(".form-actions.no-color > a"));
            RatesEdit_BackToTop = new WebElementProxy(driver, By.CssSelector(".pull-right > a"));
            RatesEdit_EffectiveDate = new WebElementProxy(driver, By.CssSelector("input#Effective_Date"));
            RatesEdit_Rate = new WebElementProxy(driver, By.CssSelector("input#Rate"));
            RatesEdit_MaximumEligibilityTerm = new WebElementProxy(driver, By.CssSelector("input#Max_Term"));
            RatesEdit_MaximumCoverageTerm = new WebElementProxy(driver, By.CssSelector("input#Maximum_Coverage_Term"));
            RatesEdit_Unit = new WebElementProxy(driver, By.CssSelector("select#Rate_Unit"));
            RatesEdit_MaximumAmount = new WebElementProxy(driver, By.CssSelector("input#Max_Amount"));
            RatesEdit_OverrideFee1 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Fee1']"));
            RatesEdit_OverrideFee2 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Fee2']"));
            RatesEdit_OverrideFee3 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Fee3']"));
            RatesEdit_Amount11 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Fee1_Amount']"));
            RatesEdit_Amount12 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Fee2_Amount']"));
            RatesEdit_Amount13 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Fee3_Amount']"));
            RatesEdit_Unit11 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Fee1_Unit']"));
            RatesEdit_Unit12 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Fee2_Unit']"));
            RatesEdit_Unit13 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Fee3_Unit']"));
            RatesEdit_Percentage11 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Fee1_Percent']"));
            RatesEdit_Percentage12 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Fee2_Percent']"));
            RatesEdit_Percentage13 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Fee3_Percent']"));
            RatesEdit_Formula11 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Fee1_Formula']"));
            RatesEdit_Formula12 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Fee2_Formula']"));
            RatesEdit_Formula13 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Fee3_Formula']"));
            RatesEdit_OverrideCommission1 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Commission1']"));
            RatesEdit_OverrideCommission2 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Commission2']"));
            RatesEdit_OverrideCommission3 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Commission3']"));
            RatesEdit_Amount21 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Commission1_Amount']"));
            RatesEdit_Amount22 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Commission2_Amount']"));
            RatesEdit_Amount23 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Commission3_Amount']"));
            RatesEdit_Unit21 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Commission1_Unit']"));
            RatesEdit_Unit22 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Commission2_Unit']"));
            RatesEdit_Unit23 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Commission3_Unit']"));
            RatesEdit_Percentage21 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Commission1_Percent']"));
            RatesEdit_Percentage22 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Commission2_Percent']"));
            RatesEdit_Percentage23 = new WebElementProxy(driver, By.CssSelector("input[name='Rate_Commission3_Percent']"));
            RatesEdit_Formula21 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Commission1_Formula']"));
            RatesEdit_Formula22 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Commission2_Formula']"));
            RatesEdit_Formula23 = new WebElementProxy(driver, By.CssSelector("select[name='Rate_Commission3_Formula']"));
            RatesEdit_Subject = new WebElementProxy(driver, By.CssSelector("input#Subject"));
            RatesEdit_Comments = new WebElementProxy(driver, By.CssSelector("input#Comment"));
            RatesEdit_Save = new WebElementProxy(driver, By.CssSelector("input[value='Save']"));
            Rates_RatesUpdatedMessage =  new WebElementProxy(driver, By.CssSelector(".text-success"));

            //--------------View - Rates - Delete
            RatesDelete_Title = new WebElementProxy(driver, By.CssSelector(".body-content.container > h4"));
            RatesDelete_BackToList = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > form > div > a"));
            RatesDelete_DeleteButton = new WebElementProxy(driver, By.CssSelector("input[value='Delete']"));
            RatesDelete_RateDeletedMessage = new WebElementProxy(driver, By.CssSelector(".text-success"));

            //--------------View - Fees
            Fees_PageTitle = new WebElementProxy(driver, By.CssSelector(".body-content.container > h4:nth-of-type(1)"));
            Fees_RelationshipDescription = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > h2"));
            Fees_CreateNew = new WebElementProxy(driver, By.CssSelector("form[method='post'] > a"));
            Fees_EffectiveDate = new WebElementProxy(driver, By.CssSelector("select#item_Revision"));
            Fees_GoToRevision = new WebElementProxy(driver, By.CssSelector(".row > button:nth-of-type(3)"));
            Fees_GoToBottom = new WebElementProxy(driver, By.CssSelector("a[title='Go to bottom of page']"));
            Fees_BackToTop = new WebElementProxy(driver, By.CssSelector("div#bottom > p > a"));
            Fees_DataSoldRadioButton = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > div.row > input:nth-child(1)"));
            Fees_DataForwardRadioButton = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > div.row > input:nth-child(2)"));
            Fees_FeeType            = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(1) > tbody > tr:nth-of-type(1) > th:nth-of-type(1)"));
            Fees_Representative     = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(1) > tbody > tr:nth-of-type(1) > th:nth-of-type(2)"));
            Fees_AdjustNAC          = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(1) > tbody > tr:nth-of-type(1) > th:nth-of-type(3)"));
            Fees_AdjustAdjNAC       = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(1) > tbody > tr:nth-of-type(1) > th:nth-of-type(4)"));
            Fees_AdjustAdjAdjNAC    = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(1) > tbody > tr:nth-of-type(1) > th:nth-of-type(5)"));
            Fees_AdjustNetPremium   = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(1) > tbody > tr:nth-of-type(1) > th:nth-of-type(6)"));
            Fees_PremiumCommissionReceived = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(1) > tbody > tr:nth-of-type(1) > th:nth-of-type(7)"));
            Fees_PartialChargeBack  = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(1) > tbody > tr:nth-of-type(1) > th:nth-of-type(8)"));
            Fees_FullChargeBack     = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(1) > tbody > tr:nth-of-type(1) > th:nth-of-type(9)"));
            Fees_Revision           = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(2) > tbody > tr:nth-of-type(1) > th:nth-of-type(1)"));
            Fees_Created            = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(2) > tbody > tr:nth-of-type(1) > th:nth-of-type(2)"));
            Fees_Modified           = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(2) > tbody > tr:nth-of-type(1) > th:nth-of-type(3)"));
            Fees_UserName           = new WebElementProxy(driver, By.CssSelector("table:nth-of-type(2) > tbody > tr:nth-of-type(1) > th:nth-of-type(4)"));
            Fees_Edit               = new WebElementProxy(driver, By.CssSelector("div#bottom > a:nth-of-type(1)"));
            Fees_BackToList         = new WebElementProxy(driver, By.CssSelector("div#bottom > a:nth-of-type(2)"));
            Fees_FootSignature = new WebElementProxy(driver, By.CssSelector("footer > p"));

            //--------------View - Fees - Create
            CreateFees_NewEffectiveDate  = new WebElementProxy(driver, By.CssSelector("input#Effective_Date"));
            CreateFees_NewEffectiveDateWarningMessage   = new WebElementProxy(driver, By.CssSelector(".validation-summary-errors li"));
            CreateFees_BasedOn           = new WebElementProxy(driver, By.CssSelector("select#OldEffectiveDate"));
            CreateFees_BasedOnBoxOption1 = new WebElementProxy(driver, By.CssSelector("#OldEffectiveDate > option:nth-child(1)"));
            CreateFees_BasedOnBoxOption2 = new WebElementProxy(driver, By.CssSelector("#OldEffectiveDate > option:nth-child(2)"));
            CreateFees_BasedOnBoxOption3 = new WebElementProxy(driver, By.CssSelector("#OldEffectiveDate > option:nth-child(3)"));
            CreateFees_BasedOnBoxOption4 = new WebElementProxy(driver, By.CssSelector("#OldEffectiveDate > option:nth-child(4)"));
            CreateFees_BackToList       = new WebElementProxy(driver, By.CssSelector(".body-content.container > div > a"));
            CreateFees_Create           = new WebElementProxy(driver, By.CssSelector("input[value='Create']"));
            CreateFees_FootSignature    = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > footer > p"));


    }





        //==================================
        //--------- CLICK ----------------
        //==================================


        public void ClickCreateNew() { createNew.Get().Click(); }
        public void ClickEdditOption() { editOption.Get().Click(); }
        public void ClickDetailstOption() { detailsOption.Get().Click(); }
        public void ClickDeleteOption() { deleteOption.Get().Click(); }
        public void ClickDeleteButton() { deleteButton.Get().Click(); }
        public void ClickUDFsOption() { udfsOption.Get().Click(); }
        public void ClickQuickCommentOption() { quickCommentOption.Get().Click(); }
        public void ClickViewOption() { viewOption.Get().Click(); }
        public void ClickRowPerPageBox() { rowPerPageBox.Get().Click(); }
        public void ClickGoToPageButton() { goToPageButton.Get().Click(); }
        public void ClickwebTableRow1() { webTableRow1.Get().Click(); }
        public void ClickOrderBy() { orderBy.Get().Click(); }
        public void Clickt3r1c1() { t3r1c1.Get().Click(); }
        public void Clickt3r1c2() { t3r1c2.Get().Click(); }
        public void ClickwebTableRow(int rowNumber) { new WebElementProxy(driver, By.CssSelector("#relationshipTable > tbody > tr:nth-child("+ rowNumber + ")")).Get().Click(); }
        public void ClickClientBox_Create() { clientBox_Create.Get().Click(); }
        public void ClickDescExtensionBox_Create() { descExtensionBox_Create.Get().Click(); }
        public void ClickEffectiveDateBox_Create() { effectiveDateBox_Create.Get().Click(); }
        public void ClickProductBox_Create() { productBox_Create.Get().Click(); }
        public void ClickCreateButton_Create() { createButton_Create.Get().Click(); }
        public void ClickBackTolist_Create() { backTolist_Create.Get().Click(); }
        public void ClickFilters() { filters.Get().Click(); }
        public void Clickt1r1c1() { t1r1c1.Get().Click(); }
        public void Clickt1r1c2() { t1r1c2.Get().Click(); }
        public void ClickStatusBox_Edit() { statusBox_Edit.Get().Click(); }
        public void ClickinputCancelledDateBox_Edit() { cancelledDateBox_Edit.Get().Click(); }
        public void ClickCommissionOptionBox_Edit() { commissionOptionBox_Edit.Get().Click(); }
        public void ClickFeesOptionBox_Edit() { feesOptionBox_Edit.Get().Click(); }
        public void ClickRatesOptionBox_Edit() { ratesOptionBox_Edit.Get().Click(); }
        public void ClickIQQCUIDBox_Edit() { iQQCUIDBox_Edit.Get().Click(); }
        public void ClickInvoiceFormatBox_Edit() { invoiceFormatBox_Edit.Get().Click(); }
        public void ClickMaster_RelationshipBox_Edit() { masterRelationshipBox_Edit.Get().Click(); }
        public void ClickDefaultClassBox_Edit() { defaultClassBox_Edit.Get().Click(); }
        public void ClickEzAlertImpactBox_Edit() { ezAlertImpactBox_Edit.Get().Click(); }
        public void ClickSubjectBox_Edit() { subjectBox_Edit.Get().Click(); }
        public void ClickCommentBox_Edit() { commentBox_Edit.Get().Click(); }
        public void ClickSaveButton_Edit() { saveButton_Edit.Get().Click(); }
        public void ClickBackTolist_Details() { backTolist_Details.Get().Click(); }
        public void ClickCommissionsPanel() { commissionsPanel.Get().Click(); }
        public void ClickFeesPanel() { feesPanel.Get().Click(); }
        public void ClickRatesPanel() { ratesPanel.Get().Click(); }
        public void ClickProductsPanel() { productsPanel.Get().Click(); }
        public void ClickCommentsPanel() { commentsPanel.Get().Click(); }
        public void ClickGoToBottomButtun() { goToBottomButtun.Get().Click(); }
        public void ClickBackToTopButtun() { backToTopButtun.Get().Click(); }
        public void ClickCommentsSubjectBox() { commentsSubjectBox.Get().Click(); }
        public void ClickCommentsCommentBox() { commentsCommentBox.Get().Click(); }
        public void ClickCommentsCreateButton() { commentsCreateButton.Get().Click(); }
        public void ClickCommentsSaveButton() { commentsSaveButton.Get().Click(); }
        public void ClickCommentsBackToListButton() { commentsBackToListButton.Get().Click(); }
        public void ClickCommentEditOption() { commentEditOption.Get().Click(); }
        public void ClickCommentCreateNew() { commentCreateNew.Get().Click(); }
        public void ClickViewComments() { ViewComments.Get().Click(); }
        public void ClickViewCommissions() { ViewCommissions.Get().Click(); }
        public void ClickViewFees() { ViewFees.Get().Click(); }
        public void ClickViewImportExport() { ViewImportExport.Get().Click(); }
        public void ClickViewProducts() { ViewProducts.Get().Click(); }
        public void ClickViewRates() { ViewRates.Get().Click(); }
        public void ClickRatesCreateNew() { RatesCreateNew.Get().Click(); }
        public void ClickRatesBackToList() { RatesBackToList.Get().Click(); }
        public void ClickRatesBackToTop() { RatesBackToTop.Get().Click(); }
        public void ClickRatesDetails() { RatesDetails.Get().Click(); }
        public void ClickRatesEdit() { RatesEdit.Get().Click(); }
        public void ClickRatesDelete() { RatesDelete.Get().Click(); }
        public void ClickCreateRates_Create() { CreateRates_Create.Get().Click(); }
        public void ClickCreateRates_SubjectBox() { CreateRates_SubjectBox.Get().Click(); }
        public void ClickCreateRates_CommentsBox() { CreateRates_CommentsBox.Get().Click(); }
        public void ClickCreateRates_SaveButton() { CreateRates_SaveButton.Get().Click(); }
        public void ClickCreateRates_Class() { CreateRates_Class.Get().Click(); }
        public void ClickCreateRates_Rate() { CreateRates_Rate.Get().Click(); }
        public void ClickCreateRates_MaxEligibilityTerm() { CreateRates_MaxEligibilityTerm.Get().Click(); }
        public void ClickCreateRates_MaxCoverageTerm() { CreateRates_MaxCoverageTerm.Get().Click(); }
        public void ClickCreateRates_MaxAmt() { CreateRates_MaxAmt.Get().Click(); }
        public void ClickRatesDetailsTitle() { CreateRates_SaveButton.Get().Click(); }
        public void ClickRatesDetailsEdit() { RatesDetailsEdit.Get().Click(); }
        public void ClickRatesDetailsDelete() { RatesDetailsDelete.Get().Click(); }
        public void ClickRatesDetailsBackToList() { RatesDetailsBackToList.Get().Click(); }
        public void ClickCreateRates_NewEffectiveDateBox() { CreateRates_NewEffectiveDateBox.Get().Click(); }
        public void ClickRatesEdit_BackToList() { RatesEdit_BackToList.Get().Click(); }
        public void ClickRatesDelete_BackToList() { RatesEdit_BackToList.Get().Click(); }
        public void ClickRatesDelete_DeleteButton() { RatesDelete_DeleteButton.Get().Click(); }
        public void ClickFees_CreateNew() { Fees_CreateNew.Get().Click(); }
        public void ClickCreateFees_NewEffectiveDate() { CreateFees_NewEffectiveDate.Get().Click(); }
        public void ClickCreateFees_BasedOn() { CreateFees_BasedOn.Get().Click(); }
        public void ClickCreateFees_BackToList() { CreateFees_BackToList.Get().Click(); }
        public void ClickCreateFees_Create() { CreateFees_Create.Get().Click(); }




        
        public void ClearCreateRates_NewEffectiveDateBox() { CreateRates_NewEffectiveDateBox.Get().Clear(); }

            

        //==================================
        //--------- VALIDATE --------------
        //==================================

        public int WebTableRowNumber() { return table_main.getWebTableTotalRowNumbersOnPage(); }
        public int WebTableColumnNumber() { return table_main.getWebTableTotalColumnNumbers(); }
        public bool ValidatePageURL() { return pageURL.getURL().Contains(ExpectedPageURL); }
        public bool ValidatePageURL_Details() { return pageURL.getURL().Contains(ExpectedPageURL_Details); }
        public bool ValidatePageURL_Edit() { return pageURL.getURL().Contains(ExpectedPageURL_Edit); }
        public bool ValidatePageURL_Delete() { return pageURL.getURL().Contains(ExpectedPageURL_Delete); }
        public bool ValidatePageURL_UDFs() { return pageURL.getURL().Contains(ExpectedPageURL_UDFs); }
        public bool ValidatePageURL_QuickComment() { return pageURL.getURL().Contains(ExpectedPageURL_QuickComment); }
        public bool ValidatePageURL_CreateRates() { return pageURL.getURL().Contains(ExpectedPageURL_CreateRates); }
        public bool ValidatePageURL_RatesDetails() { return pageURL.getURL().Contains(ExpectedPageURL_RatesDetails); }
        public bool ValidatePageURL_RatesEdit() { return pageURL.getURL().Contains(ExpectedPageURL_RatesEdit); }
        public bool ValidatePageURL_RatesDelete() { return pageURL.getURL().Contains(ExpectedPageURL_RatesDelete); }
        public bool ValidatePageTitleEnabled() { return pageTitle.IsPresent() && pageTitle.IsInteractable(); }
        public bool ValidateFooterEnabled() { return footer.IsPresent() && footer.IsInteractable(); }
        public bool ValidateHelpButtonEnabled() { return help.IsPresent() && help.IsInteractable(); }
        public bool ValidateColumnDescriptionEnabled() { return columnDescription.IsPresent() && columnDescription.IsInteractable(); }
        public bool ValidateColumnStateEnabled() { return columnState.IsPresent() && columnState.IsInteractable(); }
        public bool ValidateColumnRelationshipIdNumberEnabled() { return columnRelationshipIdNumber.IsPresent() && columnRelationshipIdNumber.IsInteractable(); }
        public bool ValidateColumnCoverageTypeEnabled() { return columnCoverageType.IsPresent() && columnCoverageType.IsInteractable(); }
        public bool ValidateColumnEffectiveDateEnabled() { return columnEffectiveDate.IsPresent() && columnEffectiveDate.IsInteractable(); }
        public bool ValidateColumnTerminationDateEnabled() { return columnTerminationDate.IsPresent() && columnTerminationDate.IsInteractable(); }
        public bool ValidateColumnCancelledDateEnabled() { return columnCancelledDate.IsPresent() && columnCancelledDate.IsInteractable(); }
        public bool ValidateColumnStatusEnabled() { return columnStatus.IsPresent() && columnStatus.IsInteractable(); }
        public bool ValidateDetailsOptionEnabled() { return detailsOption.IsPresent() && detailsOption.IsInteractable(); }
        public bool ValidateEditOptionEnabled() { return editOption.IsPresent() && editOption.IsInteractable(); }
        public bool ValidateDeleteOptionEnabled() { return deleteOption.IsPresent() && deleteOption.IsInteractable(); }
        public bool ValidateUdfsOptionEnabled() { return udfsOption.IsPresent() && udfsOption.IsInteractable(); }
        public bool ValidateQuickCommentOptionEnabled() { return quickCommentOption.IsPresent() && quickCommentOption.IsInteractable(); }
        public bool ValidateViewOptionEnabled() { return viewOption.IsPresent() && viewOption.IsInteractable(); }
        public bool ValidateAreYouSureYouWantToDeleteThisMwsageEnabled() { return AreYouSureYouWantToDeleteThisMwsage.IsPresent() && AreYouSureYouWantToDeleteThisMwsage.IsInteractable(); }
        public bool ValidateRelationshipDeletedMesageEnabled() { return relationshipDeletedMwsage.IsPresent() && relationshipDeletedMwsage.IsInteractable(); }
        public bool ValidateOrderBy(OrderByOrderOrSortBy x , OrderByDirection y, int rowNumber) {
            orderByMethod(x, y);
            switch (x)
            {
                case OrderByOrderOrSortBy.Blank:
                    List<string> s1 = getWebTableColumnList(OrderByOrderOrSortBy.PrimaryKey.ToString(), rowNumber);
                    return Utilities.OrderValidationOfStringList(s1 , y.ToString());
                    break;
                case OrderByOrderOrSortBy.PrimaryKey:
                    List<string> s2 = getWebTableColumnList(OrderByOrderOrSortBy.PrimaryKey.ToString(), rowNumber);
                    return Utilities.OrderValidationOfStringList(s2, y.ToString());
                    break;
                case OrderByOrderOrSortBy.CoverageType:
                    List<string> s3 = getWebTableColumnList(OrderByOrderOrSortBy.CoverageType.ToString(), rowNumber);
                    return Utilities.OrderValidationOfStringList(s3, y.ToString());
                    break;
                case OrderByOrderOrSortBy.Relationship:
                    List<string> s4 = getWebTableColumnList(OrderByOrderOrSortBy.Relationship.ToString(), rowNumber);
                    return Utilities.OrderValidationOfStringList(s4, y.ToString());
                    break;
                case OrderByOrderOrSortBy.RelationshipIdNumber:
                    List<string> s5 = getWebTableColumnList(OrderByOrderOrSortBy.RelationshipIdNumber.ToString(), rowNumber);
                    return Utilities.OrderValidationOfStringList(s5, y.ToString());
                    break;
                case OrderByOrderOrSortBy.State:
                    List<string> s6 = getWebTableColumnList(OrderByOrderOrSortBy.State.ToString(), rowNumber);
                    return Utilities.OrderValidationOfStringList(s6, y.ToString());
                    break;
                case OrderByOrderOrSortBy.Status:
                    List<string> s7 = getWebTableColumnList(OrderByOrderOrSortBy.Status.ToString(), rowNumber);
                    return Utilities.OrderValidationOfStringList(s7, y.ToString());
                    break;
                case OrderByOrderOrSortBy.Created:
                    List<string> s8 = getWebTableColumnList(OrderByOrderOrSortBy.Created.ToString(), rowNumber);
                    return Utilities.OrderValidationOfStringList(s8, y.ToString());
                    break;
                case OrderByOrderOrSortBy.Modified:
                    List<string> s9 = getWebTableColumnList(OrderByOrderOrSortBy.Modified.ToString(), rowNumber);
                    return Utilities.OrderValidationOfStringList(s9, y.ToString());
                    break;
                default:
                    List<string> s10 = getWebTableColumnList(OrderByOrderOrSortBy.PrimaryKey.ToString(), rowNumber);
                    return Utilities.OrderValidationOfStringList(s10, y.ToString());
                    break;
            }

           
            
        }
        public bool ValidateClickedTableRowHighlighted (int rowNumber) 
        {
            EnterRowPerPage(rowNumber);
            ClickwebTableRow(rowNumber);
            string backround = getAtribute(getwebTableRowElement(rowNumber), "style"); // .GetAtribute()
            return backround.Contains("yellow"); 
        }
        public bool ValidateRandomlyClickedTableRowHighlighted()
        {
            int  s = Utilities.getRandomNumber(1, Int32.Parse(getRowPerPageNumber()));
            ClickwebTableRow(s);
            string backround = getAtribute(getwebTableRowElement(s), "style"); // .GetAtribute()
            return backround.Contains("yellow");
        }
        public bool ValidateNewRelationshipCreated(string newCreatedRelationship)
        {
            FilterRelationships(FiltersFilterBy.Relationship, newCreatedRelationship);
            string s = firstDescription.Get().Text.ToString();
            return newCreatedRelationship.Contains(s);

        }
        //public bool ValidateRelationshipUdatedMesageEnabled() { return relationshipUpdatedMesage_Edit.IsPresent(); }//&& relationshipUpdatedMesage_Edit.IsInteractable(); }
        public bool ValidateRelationshipUdatedMesageEnabled() { return relationshipUpdatedMesage_Edit.IsInteractable(); }
        public bool ValidateRelationshipEdited(string ContainingOrLike, string CancelledDate, string DescExtension)
        {
            string editRelationshipMesage = EdditRelationship(FiltersFilterBy.RelationshipIdNumber, ContainingOrLike, CancelledDate, DescExtension);

            bool bool1 = ValidateRelationshipUdatedMesageEnabled();
            bool bool2 = editRelationshipMesage.Contains("Relationship updated");
            FilterRelationships(FiltersFilterBy.RelationshipIdNumber, ContainingOrLike);                //!!!!!!!!
            ClickGoToPageButton();
            Thread.Sleep(3000);
            ClickDetailstOption();
            Console.WriteLine(getTextOfWebElement(cancelledDate).ToString());
            
            bool bool3 = getTextOfWebElement(cancelledDate).ToString().Equals(CancelledDate); // Contains("");
            bool bool4 = getTextOfWebElement(descExtension_Details).ToString().Equals(DescExtension); // Contains("");

            Console.WriteLine(DescExtension +"1111==========================");
            Console.WriteLine(getTextOfWebElement(descExtension_Details).ToString()+"2222==========================");

            //bool bool3 = getTextOfWebElement(cancelledDate).ToString().Equals(null); // Contains("");
            //bool bool3 = cancelledDate.TextIsPresent("");
            //bool bool3 = Int32.Parse(cancelledDate.getWebElementSize().ToString())<=1;
            Thread.Sleep(1000);
            ClickBackTolist_Details();
            Thread.Sleep(1000);
            if (bool1 == true && bool2 == true && bool3 == true && bool4 == true) return true;
            else return false;

        }
        public bool ValidateRelationshipEditedOnDatabase(string query, string CancelledDate, string columnName)
        {
            string DbCancelledDateValue = DatabaseHelper.getDatabaseTableCellValue(Utilities.GetConnectionString(), query, 1, columnName);
            Thread.Sleep(1000);
            return DbCancelledDateValue.Contains(CancelledDate);

        }
        public bool ValidateRelationshipRetesDetailsEffectiveDateOnDatabase(string query)
        {
            string dataFromUI = getRatesDetailsEffectiveDate();
            string dataFromDbTable = DatabaseHelper.getDatabaseTableCellValue(Utilities.GetConnectionString(), query, 1, "Effective_Date");
            Console.WriteLine("dataFromUI: " + dataFromUI);
            Console.WriteLine("dataFromDbTable: " + dataFromDbTable);
            
            return dataFromDbTable.Contains(dataFromUI);          //return dataFromUI.Contains(dataFromDbTable); 
        }

        public bool ValidateRelationshipRetesDetailsMaximumCoverageTermOnDatabase(string query)
        {
            string dataFromUI = getRatesDetailsMaximumCoverageTerm();
            string dataFromDbTable = DatabaseHelper.getDatabaseTableCellValue(Utilities.GetConnectionString(), query, 1, "Maximum_Coverage_Term");
            Console.WriteLine("dataFromUI: " + dataFromUI);
            Console.WriteLine("dataFromDbTable: " + dataFromDbTable);
            return dataFromDbTable.Contains(dataFromUI);        //return dataFromUI.Contains(dataFromDbTable);    
        }
        public bool ValidateRelationshipRetesDetailsCreatedOnDatabase(string query)
        {
            string dataFromUI = getRatesDetailsCreated();
            string dataFromDbTable = DatabaseHelper.getDatabaseTableCellValue(Utilities.GetConnectionString(), query, 1, "Created");
            Console.WriteLine("dataFromUI: " + dataFromUI);
            Console.WriteLine("dataFromDbTable: " + dataFromDbTable);
            return dataFromDbTable.Contains(dataFromUI);        // return dataFromUI.Contains(dataFromDbTable);   
        }
        public bool ValidateRelationshipRetesDetailsModifiedOnDatabase(string query)
        {
            string dataFromUI = getRatesDetailsModified();
            string dataFromDbTable = DatabaseHelper.getDatabaseTableCellValue(Utilities.GetConnectionString(), query, 1, "Modified");
            return dataFromDbTable.Contains(dataFromUI);        // returndataFromUI.Contains(dataFromDbTable);   
        }        
        public bool ValidateRelationshipRetesDetailsUserIDOnDatabase(string query)
        {
            string dataFromUI = getRatesDetailsUserName();
            string dataFromDbTable = DatabaseHelper.getDatabaseTableCellValue(Utilities.GetConnectionString(), query, 1, "User_ID");
            return dataFromDbTable.Contains(dataFromUI);        //return dataFromUI.Contains(dataFromDbTable);
        }


        public bool ValidateRelationshipDeleted(string relationshipIdNumber)
        {
            FilterRelationships(FiltersFilterBy.RelationshipIdNumber, relationshipIdNumber);
            ClickDeleteOption();
            bool bool1 = ValidateAreYouSureYouWantToDeleteThisMwsageEnabled();
            ClickDeleteButton();
            bool bool2 = ValidateRelationshipDeletedMesageEnabled();
            if (bool1 == true && bool2 == true) return true;
            else return false;

        }
        public bool ValidateItemDoesNotExistOnWebTableColum(string columnName, string item)                 // VALIDETS ALL ITEMS IN ONE PAGE
        {
            List<String> ColumnList = getWebTableColumnListAll(columnName);
            foreach (var element in ColumnList)
            {
                if (!element.Equals(item))
                {
                    return false; break;
                }
            }
            return true;
        }
        public bool ValidateNullColumnElemetNotExist(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPageButton.Click();
            int numberOfRow = table_main.getWebTableTotalRowNumbersOnPage();

            for (int i = 3; i <= numberOfRow; i++)
            {
                if (driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToString().Equals(""))
                {
                    Console.WriteLine("row number :" + i);
                    Console.WriteLine("cell element: " + driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToString());
                    return false; break;
                }
            }
            return true;
        }
        public bool ValidateParticularElementNotExistInColum(string columnName, string element)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPageButton.Click();
            int numberOfRow = table_main.getWebTableTotalRowNumbersOnPage();

            for (int i = 2; i <= numberOfRow; i++)
            {
                if ((driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToString()).Equals(element))
                {
                    Console.WriteLine("row number :" + i);
                    Console.WriteLine("cell element: " + driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToString());
                    return false; break;
                }

            }
            return true;
        }
        public bool ValidateNoTimeSteps2(string columnName)                                                 // VALIDETS ALL ITEMS IN ONE PAGE
        {
            List<String> ColumnList = getWebTableColumnListAll(columnName);
            foreach (var item in ColumnList)
            {
                if (!item.Equals(""))
                {
                    return false; break;
                }
            }
            return true;
        }
        public bool ValidateNoTimeSteps(int columnNumber)                                                   // PAGE BY PAGE
        {
            string page = "1";
            for (int i = 2; i <= table_main.getWebTableTotalRowNumbersOnPage(); i++)
            {
                if ((driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToLower()).Equals(""))
                {
                    Console.WriteLine("First Null Element find on page: " + page);
                    return false;
                    break;
                }
            }
            goToTheNextPageArrow.Click();
            page = pageNumberBox.GetAtribute("value");
            while (!page.Equals("1"))
            {
                for (int i = 2; i <= table_main.getWebTableTotalRowNumbersOnPage(); i++)
                {
                    if ((driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToLower()).Equals(""))
                    {
                        Console.WriteLine("First Null Element find on page: " + page);
                        return false;
                        break;
                    }
                }
                goToTheNextPageArrow.Click();
                page = pageNumberBox.GetAtribute("value");
            }
            Console.WriteLine("First Null Element find on page: " + page);
            return true;
        }
        public bool ValidateRowPerPage(int number)
        {
            EnterRowPerPage(number);
            for (int i = 0; i < 4; i++)
            {
                goToTheNextPageArrow.Click();
                if (table_main.getWebTableTotalRowNumbersOnPage() - 1 != number)
                {
                    Console.WriteLine(table_main.getWebTableTotalRowNumbersOnPage());
                    return false;
                }
            }
            return true;
        }
        public bool ValidateCommissionsPanelEnabled() { return commissionsPanel.IsPresent() && commissionsPanel.IsInteractable(); }
        public bool ValidateCommissionsPanelDefaultIsCollapsed()  { return commissionsPanelCond.GetAtribute("data-toggle").Contains("collapse"); }
        public bool ValidateCommissionsPanelIsPanOut()  { return commissionsPanelEffectiveDate.IsPresent() && commissionsPanelEffectiveDate.IsInteractable(); }
        public bool ValidateFeesPanelEnabled() { return feesPanel.IsPresent() && feesPanel.IsInteractable(); }
        public bool ValidateFeesPanelDefaultIsCollapsed() { return feesPanelCond.GetAtribute("data-toggle").Contains("collapse"); }
        public bool ValidateFeesPanelIsPanOut() { return feesPanelEffectiveDate.IsPresent() && feesPanelEffectiveDate.IsInteractable(); }
        public bool ValidateFeesPanelShowsRepresentativeAmountPercentage() { return feesPanelRepresentative.IsPresent() && feesPanelRepresentative.IsInteractable() 
                                                                                   && feesPanelAmount.IsPresent() && feesPanelAmount.IsInteractable() 
                                                                                   && feesPanelPercentage.IsPresent() && feesPanelPercentage.IsInteractable(); }
        public bool ValidateRatesPanelEnabled() { return ratesPanel.IsPresent() && ratesPanel.IsInteractable(); }
        public bool ValidateRatesPanelDefaultIsCollapsed() { return ratesPanelCond.GetAtribute("data-toggle").Contains("collapse"); }
        public bool ValidateRatesPanelIsPanOut() { return ratesPanelEffectiveDate.IsPresent() && ratesPanelEffectiveDate.IsInteractable(); }
        public bool ValidateProductsPanelEnabled() { return productsPanel.IsPresent() && productsPanel.IsInteractable(); }
        public bool ValidateProductsPanelDefaultIsCollapsed() { return productsPanelCond.GetAtribute("data-toggle").Contains("collapse"); }
        public bool ValidateProductsPanelIsPanOut() { return productsPanelEffectiveDate.IsPresent() && productsPanelEffectiveDate.IsInteractable(); }
        public bool ValidateCommentsPanelEnabled() { return commentsPanel.IsPresent() && commentsPanel.IsInteractable(); }
        public bool ValidateCommentsPanelDefaultIsCollapsed() { return commentsPanelCond.GetAtribute("data-toggle").Contains("collapse"); }
        public bool ValidateCommentsPanelIsPanOut() { return commentsPanelSubject.IsPresent() && commentsPanelSubject.IsInteractable(); }
        public bool ValidateCommentCreatedMessageEnabled() { return commentCreatedMessage.IsPresent() && commentCreatedMessage.IsInteractable(); }
        public bool ValidateCommentUpdatedMessageEnabled() { return commentUpdatedMessage.IsPresent() && commentUpdatedMessage.IsInteractable(); }
        public bool ValidateCommentPageTitle() { return commentPageTitleActual.GetText().ToString().Contains(commentPageTitleExpected); }
        public bool VerifyDescExtensionFieldWarningMesage(string DescExtension) 
        {
            string Client = "1st City CU MO", Product = "A Test";
            ClickCreateNew();
            Thread.Sleep(500);
            SelectElement select1 = new SelectElement(driver.FindElement(By.CssSelector("#Client_ID_Number")));
            select1.SelectByText(Client);
            descExtensionBox_Create.Get().SendKeys(DescExtension);
            ClickCreateButton_Create();
            Thread.Sleep(1000);

            try
            {
                return descExtensionWarningMessage_Create.IsPresent() || descExtensionWarningMessage_Create.IsInteractable();
            }
            catch (Exception e)
            {
                Console.WriteLine("\"Desc Extension\" Box Warning Mesage is not enabled");
                return false;
            }
            
        }
        public bool ValidateNewCreatedRelationshipForDescExtension(string newCreatedRelationshipIdNumber, string DescExtension)
        {
            //FilterRelationships(FiltersFilterBy.RelationshipIdNumber, newCreatedRelationshipIdNumber);
            ClickDetailstOption();
            Console.WriteLine(getTextOfWebElement(descExtension_Details));
            return DescExtension.ToUpper().Contains(getTextOfWebElement(descExtension_Details).ToUpper());
        }
        public bool ValidateViewCommentsEnabled() { return ViewComments.IsPresent() && ViewComments.IsInteractable(); }
        public bool ValidateViewCommissionsEnabled() { return ViewCommissions.IsPresent() && ViewCommissions.IsInteractable(); }
        public bool ValidateViewFeesEnabled() { return ViewFees.IsPresent() && ViewFees.IsInteractable(); }
        public bool ValidateViewImportExportEnabled() { return ViewImportExport.IsPresent() && ViewImportExport.IsInteractable(); }
        public bool ValidateViewProductsEnabled() { return ViewProducts.IsPresent() && ViewProducts.IsInteractable(); }
        public bool ValidateViewRatesEnabled() { return ViewRates.IsPresent() && ViewRates.IsInteractable(); }
        public bool ValidateRatesTitleEnabled() { return RatesTitle.IsPresent() && RatesTitle.IsInteractable(); }
        public bool ValidateRatesClassCodeEnabled() { return RatesClassCode.IsPresent() && RatesClassCode.IsInteractable(); }
        public bool ValidateRatesClassEnabled() { return RatesClass.IsPresent() && RatesClass.IsInteractable(); }
        public bool ValidateRatesRateEnabled() { return RatesRate.IsPresent() && RatesRate.IsInteractable(); }
        public bool ValidateRatesUnitEnabled() { return RatesUnit.IsPresent() && RatesUnit.IsInteractable(); }
        public bool ValidateRatesCreateNewEnabled() { return RatesCreateNew.IsPresent() && RatesCreateNew.IsInteractable(); }
        public bool ValidateRatesBackToListEnabled() { return RatesBackToList.IsPresent() && RatesBackToList.IsInteractable(); }
        public bool ValidateRatesBackToTopEnabled() { return RatesBackToTop.IsPresent() && RatesBackToTop.IsInteractable(); }
        public bool ValidateRatesDetailsEnabled() { return RatesDetails.IsPresent() && RatesDetails.IsInteractable(); }
        public bool ValidateRatesEditEnabled() { return RatesEdit.IsPresent() && RatesEdit.IsInteractable(); }
        public bool ValidateRatesDeleteEnabled() { return RatesDelete.IsPresent() && RatesDelete.IsInteractable(); }
        public bool ValidateFirstRelationshipHighlighted()
        {
            Thread.Sleep(500);
            string backround = getAtribute(tableBody_FirstRow,"style");
            return backround.Contains("yellow");
        }
        public bool ValidateCreateRates_NewEffectiveDateBoxEnabled() { return CreateRates_NewEffectiveDateBox.IsPresent() && CreateRates_NewEffectiveDateBox.IsInteractable(); }
        public bool ValidateCreateRates_NewEffectiveDateWarningMessageEnabled() 
        {
            CreateRates_NewEffectiveDateBox.Get().Clear();
            ClickCreateRates_Create();
            return CreateRates_NewEffectiveDateWarningMessage.IsPresent() && CreateRates_NewEffectiveDateWarningMessage.IsInteractable(); 
        }
        public bool ValidateCreateRates_BasedOnBoxEnabled() { return CreateRates_BasedOnBox.IsPresent() && CreateRates_BasedOnBox.IsInteractable(); }
        public bool ValidateRatesDetailsTitleEnabled() { return RatesDetailsTitle.IsPresent() && RatesDetailsTitle.IsInteractable(); }
        public bool ValidateRatesDetailsEditEnabled() { return RatesDetailsEdit.IsPresent() && RatesDetailsEdit.IsInteractable(); }
        public bool ValidateRatesDetailsDeleteEnabled() { return RatesDetailsDelete.IsPresent() && RatesDetailsDelete.IsInteractable(); }
        public bool ValidateRatesDetailsBackToListEnabled() { return RatesDetailsBackToList.IsPresent() && RatesDetailsBackToList.IsInteractable(); }
        public bool ValidateRatesEdit_BackToListEnabled() { return RatesEdit_BackToList.IsPresent() && RatesEdit_BackToList.IsInteractable(); }
        public bool ValidateRatesEdit_BackToTopEnabled() { return RatesEdit_BackToTop.IsPresent() && RatesEdit_BackToTop.IsInteractable(); }
        public bool ValidateRates_RatesUpdatedMessageEnabled() { return Rates_RatesUpdatedMessage.IsPresent() && Rates_RatesUpdatedMessage.IsInteractable(); }
        public bool ValidateRatesDelete_RateDeletedMessageEnabled() { return RatesDelete_RateDeletedMessage.IsPresent() && RatesDelete_RateDeletedMessage.IsInteractable(); }
        public bool ValidateRatesDelete_TitleEnabled() { return RatesDelete_Title.IsPresent() && RatesDelete_Title.IsInteractable(); }
        public bool ValidateFees_PageTitleEnabled() { return Fees_PageTitle.IsPresent() && Fees_PageTitle.IsInteractable(); }
        public bool ValidateFees_RelationshipDescriptionEnabled() { return Fees_RelationshipDescription.IsPresent() && Fees_RelationshipDescription.IsInteractable(); }
        public bool ValidateFees_CreateNewEnabled() { return Fees_CreateNew.IsPresent() && Fees_CreateNew.IsInteractable(); }
        public bool ValidateFees_EffectiveDateEnabled() { return Fees_EffectiveDate.IsPresent() && Fees_EffectiveDate.IsInteractable(); }
        public bool ValidateFees_GoToRevisionEnabled() { return Fees_GoToRevision.IsPresent() && Fees_GoToRevision.IsInteractable(); }
        public bool ValidateFees_GoToBottomEnabled() { return Fees_GoToBottom.IsPresent() && Fees_GoToBottom.IsInteractable(); }
        public bool ValidateFees_BackToTopEnabled() { return Fees_BackToTop.IsPresent() && Fees_BackToTop.IsInteractable(); }
        public bool ValidateFees_DataSoldRadioButtonEnabled() { return Fees_DataSoldRadioButton.IsPresent() && Fees_DataSoldRadioButton.IsInteractable(); }
        public bool ValidateFees_DataForwardRadioButtonEnabled() { return Fees_DataForwardRadioButton.IsPresent() && Fees_DataForwardRadioButton.IsInteractable(); }
        public bool ValidateFees_FeeTypeEnabled() { return Fees_FeeType.IsPresent() && Fees_FeeType.IsInteractable(); }
        public bool ValidateFees_RepresentativeEnabled() { return Fees_Representative.IsPresent() && Fees_Representative.IsInteractable(); }
        public bool ValidateFees_AdjustNACEnabled() { return Fees_AdjustNAC.IsPresent() && Fees_AdjustNAC.IsInteractable(); }
        public bool ValidateFees_AdjustAdjNACEnabled() { return Fees_AdjustAdjNAC.IsPresent() && Fees_AdjustAdjNAC.IsInteractable(); }
        public bool ValidateFees_AdjustAdjAdjNACEnabled() { return Fees_AdjustAdjAdjNAC.IsPresent() && Fees_AdjustAdjAdjNAC.IsInteractable(); }
        public bool ValidateFees_AdjustNetPremiumEnabled() { return Fees_AdjustNetPremium.IsPresent() && Fees_AdjustNetPremium.IsInteractable(); }
        public bool ValidateFees_PremiumCommissionReceivedEnabled() { return Fees_PremiumCommissionReceived.IsPresent() && Fees_PremiumCommissionReceived.IsInteractable(); }
        public bool ValidateFees_PartialChargeBackEnabled() { return Fees_PartialChargeBack.IsPresent() && Fees_PartialChargeBack.IsInteractable(); }
        public bool ValidateFees_FullChargeBackEnabled() { return Fees_FullChargeBack.IsPresent() && Fees_FullChargeBack.IsInteractable(); }
        public bool ValidateFees_RevisionEnabled() { return Fees_Revision.IsPresent() && Fees_Revision.IsInteractable(); }
        public bool ValidateFees_CreatedEnabled() { return Fees_Created.IsPresent() && Fees_Created.IsInteractable(); }
        public bool ValidateFees_ModifiedEnabled() { return Fees_Modified.IsPresent() && Fees_Modified.IsInteractable(); }
        public bool ValidateFees_UserNameEnabled() { return Fees_UserName.IsPresent() && Fees_UserName.IsInteractable(); }
        public bool ValidateFees_EditEnabled() { return Fees_Edit.IsPresent() && Fees_Edit.IsInteractable(); }
        public bool ValidateFees_BackToListEnabled() { return Fees_BackToList.IsPresent() && Fees_BackToList.IsInteractable(); }
        public bool ValidateFees_FootSignatureEnabled() { return Fees_FootSignature.IsPresent() && Fees_FootSignature.IsInteractable(); }
        public bool ValidateFees_FootSignatureCurrent(string version) { return Fees_FootSignature.GetText().ToString().Contains(version); }
        public bool ValidateCreateFees_NewEffectiveDateWarningMessageEnabled() { return CreateFees_NewEffectiveDateWarningMessage.IsPresent() && CreateFees_NewEffectiveDateWarningMessage.IsInteractable(); }
        public bool ValidateCreateFees_FootSignatureEnabled() { return CreateFees_FootSignature.IsPresent() && CreateFees_FootSignature.IsInteractable(); }
        public bool ValidateCreateFees_FootSignatureCurrent(string version)   { return CreateFees_FootSignature.GetText().ToString().Contains(version); }



 



        //==================================
        //========== GET===================
        //==================================


        public string getURL() { return pageURL.getURL(); }
        public string getExpectedPageURL() { return ExpectedPageURL; }
        public string getPageSource() {  return driver.PageSource.ToString();   }
        public string getPageTitle() { return pageTitle.GetText().ToString(); }
        public string getfooter() { return footer.GetText().ToString(); }
        public string getRowPerPageNumber() { return rowPerPageBox.GetAtribute("value").ToString(); }
        public List<string> getWebTableHeaderList()
        {
            int colNums = table_main.getWebTableTotalColumnNumbers();
            List<string> TableHeaderList = new List<string>();
            for (int i = 2; i <= colNums; i++)
            {
                TableHeaderList.Add(driver.FindElement(By.CssSelector("#relationshipTable > tbody > tr:nth-child(1) > th:nth-child("+i+")")).Text.ToString());     //  #relationshipTable > tbody > tr:nth-child(1) > th:nth-child(2)

            }
            return TableHeaderList;
        }
        public int getWebTableSpecificColumnNumber(string columnName)
        {
            List<string> TableHeaderList = getWebTableHeaderList();
            return TableHeaderList.IndexOf(columnName) + 2;
        }
        public List<string> getWebTableColumnListForOnePage(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            List<String> TableColumnsList = new List<String>(); ;
            for (int i = 2; i <= table_main.getWebTableTotalRowNumbersOnPage(); i++)
            {
                TableColumnsList.Add(driver.FindElement(By.XPath("table#relationshipTable > tbody > tr:nth-of-type(" + i + ") > td:nth-of-type(" + columnNumber + ")")).Text);
            }
            return TableColumnsList;
        }
        public List<string> getWebTableColumnListAll(string columnName)
        {
            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPageButton.Click();
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            List<String> TableColumnsList = new List<String>();
            for (int i = 2; i <= table_main.getWebTableTotalRowNumbersOnPage(); i++)
            {
                TableColumnsList.Add(driver.FindElement(By.XPath("table#relationshipTable > tbody > tr:nth-of-type(" + i + ") > td:nth-of-type(" + columnNumber + ")")).Text);
            }
            return TableColumnsList;
        }
        public List<string> getWebTableColumnList(string columnName, int rowNumber)
        {
            string rowPerPage = rowNumber.ToString();
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPageButton.Click();
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            List<String> TableColumnsList = new List<String>();
            for (int i = 2; i <= table_main.getWebTableTotalRowNumbersOnPage(); i++)
            {
                TableColumnsList.Add(driver.FindElement(By.CssSelector("table#relationshipTable > tbody > tr:nth-of-type(" + i + ") > td:nth-of-type(" + columnNumber + ")")).Text);
            }
            return TableColumnsList;
        }
        public WebElementProxy getEditOption() { return editOption; }
        public WebElementProxy getdescExtension() { return descExtension_Details; }
        public WebElementProxy getRatesEffectiveDate() { return RatesEffectiveDate; }
        public WebElementProxy getCreateRates_ClassCode1() { return CreateRates_ClassCode1; }
        public WebElementProxy getCreateRates_NewEffectiveDateBox() { return CreateRates_NewEffectiveDateBox; }
        public WebElementProxy getCreateRates_BasedOnBox() { return CreateRates_BasedOnBox; }
        public string getAtribute(WebElementProxy element, string atribute)
        {
            return element.GetAtribute(atribute);  // <a href="/PimsSupport/ClientAliases/Details/1479">Details</a>
        }
        public string getTextOfWebElement(WebElementProxy element) { return element.GetText().ToString(); }
        public string getTextOfgetCreateRates_ClassCode1() { return CreateRates_ClassCode1.GetText().ToString(); }

        public string getTable1Title() { table1.Click();   return table1.GetText().ToString(); }
        public string getTable2Title() { table2.Click();   return table2.GetText().ToString(); }
        public string getTable3Title() { table3.Click();   return table3.GetText().ToString(); }
        public string getTable1ColumnNames() { table1.Click();   return tableHead1.GetText().ToString(); }
        public string getTable2ColumnNames() { table2.Click();   return tableHead2.GetText().ToString(); }
        public string getTable3ColumnNames() { table3.Click();   return tableHead3.GetText().ToString(); }
        public string getTableCellInfo(int rowNum, int columnNum)
        {
            RowPerPage(rowNum);
            string element = "";
            if (rowNum == 1)
            {
                try
                {
                    element = driver.FindElement(By.CssSelector("#relationshipTable > tbody > tr:nth-child(1) > th:nth-child(" + columnNum + ")")).Text.ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Column  or/and  Row NUMBER IS OUT OF RANGE !!!!!!!!!");
                    throw e;
                }
            }
            else
            {
                columnNum++;
                try
                {
                    element = driver.FindElement(By.CssSelector("#relationshipTable > tbody > tr:nth-child(" + rowNum + ") > td:nth-child(" + columnNum + ")")).Text.ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Column  and/or  Row NUMBER IS OUT OF RANGE !!!!!!!!!");
                    throw e;
                }
                
            }
            return element;                         
        }
        public WebElementProxy getwebTableRowElement(int rowNumber) { return new WebElementProxy(driver, By.CssSelector("#relationshipTable > tbody > tr:nth-child(" + rowNumber + ")")); }
        public string getRelationshipIdNumber (FiltersFilterBy selection, string ContainingOrLike)
        {
            FilterRelationships(selection, ContainingOrLike);
            Thread.Sleep(1000);
            string relationshipIdNmb = firstRowRelationshipIDNumber.Get().Text.ToString();
            return relationshipIdNmb;
        }
        public string getRatesDetailsEffectiveDate() { return getTextOfWebElement(RatesDetailsEffectiveDate).ToString(); }
        public string getRatesDetailsMaximumCoverageTerm() { return getTextOfWebElement(RatesDetailsMaximumCoverageTerm).ToString(); }
        public string getRatesDetailsCreated() { return getTextOfWebElement(RatesDetailsCreated).ToString(); }
        public string getRatesDetailsModified() { return getTextOfWebElement(RatesDetailsModified).ToString(); }
        public string getRatesDetailsUserName() { return getTextOfWebElement(RatesDetailsUserName).ToString(); }

        public int getDropdownListSize(WebElementProxy webElement)   {  return (webElement.getDropDownListSize());      }
        public List<string> getDropdownList(WebElementProxy webElement)
        {
            int listSize = getDropdownListSize(webElement);
            List<string> list = new List<string>();
            IList<IWebElement> ElementCount = webElement.getDropDownList();
            for (int i = 0; i < listSize; i++) list.Add(ElementCount.ElementAt(i).Text);
            return list;
        }

        public IList<IWebElement> getDropdownOptions(WebElementProxy webElement) { return webElement.getDropDownList(); }

        //==================================
        //========== NAVIGATE =============
        //==================================

        public void navigate()
        {
            driver.Navigate().Forward();
        }
        public void refrash()
        {
            driver.Navigate().Refresh();
        }
        public void navigateToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }




        //===============================
        //========== PRINT =============
        //===============================

        public void printWebTableColumnListForOnePage(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            //List<String> TableColumnsList = new List<String>(); 
            for (int i = 2; i <= table_main.getWebTableTotalRowNumbersOnPage(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("table#relationshipTable > tbody > tr:nth-of-type("+i+") > td:nth-of-type("+ columnNumber + ")")).Text);
            }
        }
        public void printWebTableColumnListAll(string columnName)
        {

            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPageButton.Click();
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            //List<String> TableColumnsList = new List<String>();
            for (int i = 2; i <= table_main.getWebTableTotalRowNumbersOnPage(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("table#relationshipTable > tbody > tr:nth-of-type(" + i + ") > td:nth-of-type(" + columnNumber + ")")).Text);
            }

        }
        //public void printWebTableColumnListAfterFiltered(string columnName, string filterBy)
        //{
        //    filterBox.Get().Clear();
        //    filterBox.Get().SendKeys(filterBy);
        //    filterByBox.selectElement("Value", "Client");
        //    string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
        //    string rowPerPage = totalRowNumberString + "0";
        //    rowPerPageBox.Get().Clear();
        //    rowPerPageBox.Get().SendKeys(rowPerPage);
        //    goToPage.Click();

        //    int columnNumber = getWebTableSpecificColumnNumber(columnName);
        //    for (int i = 2; i <= table_main.getWebTableTotalRowNumbersOnPage(); i++)
        //    {
        //        Console.WriteLine(driver.FindElement(By.XPath("table#relationshipTable > tbody > tr:nth-of-type(" + i + ") > td:nth-of-type(" + columnNumber + ")")).Text);
        //    }
        //    // return TableColumnsList;
        //}
        public void PrintWebTableColumnList(int columnNumber)
        {
            List<String> TableColumnsList = new List<String>(); ;
            for (int i = 2; i <= table_main.getWebTableTotalRowNumbersOnPage(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("table#relationshipTable > tbody > tr:nth-of-type(" + i + ") > td:nth-of-type(" + columnNumber + ")")).Text);
            }
        }
        public void PrintWebTableColumnList(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            List<String> TableColumnsList = new List<String>(); ;
            for (int i = 2; i <= table_main.getWebTableTotalRowNumbersOnPage(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("table#relationshipTable > tbody > tr:nth-of-type(" + i + ") > td:nth-of-type(" + columnNumber + ")")).Text);
            }
        }



        //======================================================
        //---------  OTHER METHODS ----------------------------
        //======================================================     
        
        private void ActivateSubMenus(WebElementProxy webElement)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(webElement.Get()).Click().Build().Perform();
        }
        public void GoToPage(int PageNumber)
        {
            pageNumberBox.Get().Clear();
            pageNumberBox.Get().SendKeys(PageNumber.ToString());
            goToPageButton.Click();
        }
        public void RowPerPage(int rowNumber)
        {
            rowPerPageBox.Get().Clear();
            //Thread.Sleep(4000);
            rowPerPageBox.Get().SendKeys(rowNumber.ToString());
            //Thread.Sleep(4000);
            ClickGoToPageButton();
            Thread.Sleep(1000);
        }

        public string CreateNewRelationship(string Client = "1st City CU MO", string Product= "A Test", string descExtension = "Test DescExtension ")
        {
            ClickCreateNew();
            Thread.Sleep(1000);

            clientBox_Create.selectElement("Text", Client);
            //SelectElement select1 = new SelectElement(driver.FindElement(By.CssSelector("#Client_ID_Number")));
            //select1.SelectByText(Client);
  
            descExtensionBox_Create.Get().Clear();
            descExtensionBox_Create.Get().SendKeys(descExtension);
            Thread.Sleep(1000);
            effectiveDateBox_Create.Get().SendKeys(Utilities.getRandomPastDate(2));
            effectiveDateBox_Create.Get().SendKeys(Keys.Escape);

            productBox_Create.selectElement("Text", Product);
            //SelectElement select2 = new SelectElement(driver.FindElement(By.CssSelector("#Product_ID_Number")));
            //select2.SelectByText(Product);
  
            createButton_Create.Click();
            Thread.Sleep(8000);
            String relationship = relationship_Edit.Get().Text.ToString();
            Thread.Sleep(1000);

            statusBox_Edit.selectElement("Text", "Inactive");
            //SelectElement select22 = new SelectElement(driver.FindElement(By.XPath("//select[@id='Active']")));
            //select22.SelectByText("Inactive");
  
            Thread.Sleep(1000);
            cancelledDateBox_Edit.Get().Clear();
            Thread.Sleep(1000);
            cancelledDateBox_Edit.Get().SendKeys(Utilities.getRandomPastDate(5));
            Thread.Sleep(1000);
            cancelledDateBox_Edit.Get().SendKeys(Keys.Escape);
            Thread.Sleep(1000);
            defaultClassBox_Edit.Get().Click();

            defaultClassBox_Edit.selectElement("Text", "test");
            //SelectElement select3= new SelectElement(driver.FindElement(By.CssSelector("select#Default_Class")));
            //select3.SelectByText("test");

            ezAlertImpactBox_Edit.Get().Click();
            ezAlertImpactBox_Edit.selectElement("Text", "Medium");
            //SelectElement select4 = new SelectElement(driver.FindElement(By.CssSelector("select#EZAlertImpact")));
            //select4.SelectByText("Medium");

            commentBox_Edit.Get().SendKeys("Automation Test Comment " + DateTime.Now.ToString("yyyyMMddhhmm"));
            saveButton_Edit.Get().Click();
            Thread.Sleep(1000);
            return relationship;
        }





        public void CreateRelationshipComments(string subject = "Automated Test Subject", string comment = "Automated Test Comment")
        {

            string s = DateTime.Now.ToString();
            Console.WriteLine(s);
            commentsSubjectBox.Get().Clear();
            commentsSubjectBox.Get().SendKeys(subject + s);
            Thread.Sleep(3000);
            commentsCommentBox.Get().Clear();
            commentsCommentBox.Get().SendKeys(comment + s);
            Thread.Sleep(3000);
            ClickCommentsCreateButton();

        }

        public void EditRelationshipComments(string subject = "Automated Test Subject", string comment = "Automated Test Comment")
        {

            string s = DateTime.Now.ToString();
            Console.WriteLine(s);
            commentsSubjectBox.Get().Clear();
            commentsSubjectBox.Get().SendKeys(subject + s);
            Thread.Sleep(3000);
            commentsCommentBox.Get().Clear();
            commentsCommentBox.Get().SendKeys(comment + s);
            Thread.Sleep(3000);
            ClickCommentsSaveButton();

        }



        public string EdditRelationship(FiltersFilterBy selection, string ContainingOrLike, string cancelledDate, string DescExtension)
        {
            FilterRelationships(selection, ContainingOrLike);
            ClickEdditOption();
            Thread.Sleep(1000);
            descExtensionBox_Create.Get().Clear();
            descExtensionBox_Create.Get().SendKeys(DescExtension);
            Thread.Sleep(1000);
            ClickStatusBox_Edit();
            SelectElement select1 = new SelectElement(driver.FindElement(By.CssSelector("select#Active")));
            select1.SelectByText("Inactive");
            cancelledDateBox_Edit.Get().Clear();
            Thread.Sleep(5000);
            cancelledDateBox_Edit.Get().SendKeys(cancelledDate);
            Thread.Sleep(5000);
            iQQCUIDBox_Edit.Get().SendKeys("1");
            Thread.Sleep(1000);
            ClickInvoiceFormatBox_Edit();
            SelectElement select2 = new SelectElement(driver.FindElement(By.CssSelector("select#Invoice_Format")));
            select2.SelectByText("Detail");

            masterRelationshipBox_Edit.Get().SendKeys("11");

            ClickCommissionOptionBox_Edit();
            SelectElement select3 = new SelectElement(driver.FindElement(By.CssSelector("select#Commission_Option")));
            select3.SelectByText("Date Sold");

            ClickFeesOptionBox_Edit();
            SelectElement select4 = new SelectElement(driver.FindElement(By.CssSelector("select#Fees_Option")));
            select4.SelectByText("Date Forward");

            ClickRatesOptionBox_Edit();
            SelectElement select5 = new SelectElement(driver.FindElement(By.CssSelector("select#Rates_Option")));
            select5.SelectByText("Date Forward");

            ClickEzAlertImpactBox_Edit();
            SelectElement select22 = new SelectElement(driver.FindElement(By.CssSelector("select#EZAlertImpact")));
            select22.SelectByText("Medium");
            int r = Utilities.getRandomNumber(100, 999);
            subjectBox_Edit.Get().SendKeys("Automation Test Edit Relationship-" + r);
            commentBox_Edit.Get().SendKeys("Automation Test Edit Comment-" + r);
            ClickSaveButton_Edit();
            Thread.Sleep(500);
            Console.WriteLine(getTextOfWebElement(relationshipUpdatedMesage_Edit) );
            return getTextOfWebElement(relationshipUpdatedMesage_Edit);     
        }
        public void FilterRelationships(FiltersFilterBy selection, string ContainingOrLike)
        {
            string selection1;
            switch (selection)
            {
                case FiltersFilterBy.Blank: selection1 = ""; break;
                case FiltersFilterBy.PrimaryKey: selection1 = "Primary Key"; break;
                case FiltersFilterBy.CoverageType: selection1 = "Coverage Type"; break;
                case FiltersFilterBy.Relationship: selection1 = "Relationship"; break;
                case FiltersFilterBy.RelationshipIdNumber: selection1 = "Relationship ID Number"; break;
                case FiltersFilterBy.State: selection1 = "State"; break;
                case FiltersFilterBy.Status: selection1 = "Status"; break;
                default: selection1 = "PrimaryKey"; break;
            }

            ClickFilters();
            Thread.Sleep(500);
            Clickt1r1c1();
            Thread.Sleep(500);

            t1r1c1.selectElement("Text", selection1);
            //SelectElement select1 = new SelectElement(driver.FindElement(By.CssSelector("#collapseOne .panel-body table tbody > tr:nth-child(2) > td:nth-child(1) [name='ddlPageFilter']")));
            //Thread.Sleep(1000);
            //select1.SelectByText(selection1);

            Thread.Sleep(1000);
            t1r1c2.Get().Clear();
            Thread.Sleep(1000);
            t1r1c2.Get().SendKeys(ContainingOrLike);
            Thread.Sleep(1000);
            t1r1c2.Get().SendKeys(Keys.Enter);
            ClickGoToPageButton();
            Thread.Sleep(1000);
        }
        public void EnterRowPerPage(int number)
        {
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(number.ToString());
            Thread.Sleep(2000);
            ClickGoToPageButton();
            Thread.Sleep(2000);
        }
        public void orderByMethod(OrderByOrderOrSortBy OrderOrSortBy, OrderByDirection Direction)
        {
            string selection1, selection2;
            switch (OrderOrSortBy)
            {
                case OrderByOrderOrSortBy.Blank: selection1 = ""; break;
                case OrderByOrderOrSortBy.PrimaryKey: selection1 = "Primary Key"; break;
                case OrderByOrderOrSortBy.CoverageType: selection1 = "Coverage Type"; break;
                case OrderByOrderOrSortBy.Relationship: selection1 = "Relationship"; break;
                case OrderByOrderOrSortBy.RelationshipIdNumber: selection1 = "Relationship ID Number"; break;
                case OrderByOrderOrSortBy.State: selection1 = "State"; break;
                case OrderByOrderOrSortBy.Status: selection1 = "Status"; break;
                case OrderByOrderOrSortBy.Created: selection1 = "Created"; break;
                case OrderByOrderOrSortBy.Modified: selection1 = "Modified"; break;
                default: selection1 = "PrimaryKey"; break;
            }
            switch (Direction)
            {
                case OrderByDirection.Blank: selection2 = ""; break;
                case OrderByDirection.Ascending: selection2 = "Ascending"; break;
                case OrderByDirection.Descending: selection2 = "Descending"; break;
                default: selection2 = "Ascending"; break;
            }

            ClickOrderBy();
            Thread.Sleep(500);
            Clickt3r1c1();
            Thread.Sleep(500);
            SelectElement select1 = new SelectElement(driver.FindElement(By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(2) > td:nth-child(1) [name='ddlOrderBy']")));
            Thread.Sleep(500);
            select1.SelectByText(selection1);
            Thread.Sleep(500);
            Clickt3r1c2();
            SelectElement select2 = new SelectElement(driver.FindElement(By.CssSelector("#collapseThree .panel-body table tbody > tr:nth-child(2) > td:nth-child(2) [name='ddlOrderDirection']")));
            Thread.Sleep(500);
            select2.SelectByText(selection2);
            ClickGoToPageButton();
            Thread.Sleep(1000);
        }

        public void EditNewRates()
        {
            Thread.Sleep(1000);
            RatesEdit_EffectiveDate.Get().Clear();
            RatesEdit_EffectiveDate.Get().SendKeys(Utilities.getRandomPastDate(5));

            RatesEdit_Rate.Get().Clear();
            RatesEdit_Rate.Get().SendKeys(Utilities.getRandomNumber(1000,100000).ToString());

            RatesEdit_Rate.Get().Clear();
            RatesEdit_Rate.Get().SendKeys(Utilities.getRandomNumber(1000, 100000).ToString());

            RatesEdit_MaximumEligibilityTerm.Get().Clear();
            RatesEdit_MaximumEligibilityTerm.Get().SendKeys(Utilities.getRandomNumber(24, 240).ToString());

            RatesEdit_MaximumCoverageTerm.Get().Clear();
            RatesEdit_MaximumCoverageTerm.Get().SendKeys(Utilities.getRandomNumber(24, 240).ToString());

            RatesEdit_Unit.Get().Click();
            RatesEdit_Unit.selectElement("Index", "1");

            RatesEdit_MaximumAmount.Get().Clear();
            RatesEdit_MaximumAmount.Get().SendKeys(Utilities.getRandomNumber(24, 240).ToString());

            RatesEdit_OverrideFee1.Get().Click();
            RatesEdit_OverrideFee1.selectElement("Index", Utilities.getRandomNumber(4, 44).ToString());

            RatesEdit_Amount11.Get().Clear();
            RatesEdit_Amount11.Get().SendKeys(Utilities.getRandomNumber(100, 1000).ToString());

            RatesEdit_Unit11.Get().Click();
            RatesEdit_Unit11.selectElement("Index", "1");
            Console.WriteLine("Random double: "+Utilities.getRandomDouble(0, 1).ToString());
            RatesEdit_Percentage11.Get().Clear();
            RatesEdit_Percentage11.Get().SendKeys("0.50");    //(Utilities.getRandomDouble(0, 1).ToString());
            Thread.Sleep(1000);

            RatesEdit_Formula11.Get().Click();
            RatesEdit_Formula11.selectElement("Index", Utilities.getRandomNumber(1, 5).ToString());
            
            RatesEdit_OverrideCommission1.Get().Click();
            RatesEdit_OverrideCommission1.selectElement("Index", Utilities.getRandomNumber(2, 18).ToString());

            RatesEdit_Amount21.Get().Clear();
            RatesEdit_Amount21.Get().SendKeys(Utilities.getRandomNumber(100, 1000).ToString());

            RatesEdit_Unit21.Get().Click();
            RatesEdit_Unit21.selectElement("Index", "1");

            RatesEdit_Percentage21.Get().Clear();
            RatesEdit_Percentage21.Get().SendKeys("0.50");    //(Utilities.getRandomDouble(0, 1).ToString());
            Thread.Sleep(1000);

            RatesEdit_Formula21.Get().Click();
            RatesEdit_Formula21.selectElement("Index", Utilities.getRandomNumber(1, 5).ToString());
            
            string s = Utilities.getRandomNumber(0, 1000).ToString();
            RatesEdit_Subject.Get().Clear();
            RatesEdit_Subject.Get().SendKeys("AutomatedTestSubject"+ s);
            RatesEdit_Comments.Get().Clear();
            RatesEdit_Comments.Get().SendKeys("AutomatedTestComments" + s);
            
            RatesEdit_Save.Get().Click(); 
            Thread.Sleep(2000);


        }



        public void CreateNewRates(string NewEffectiveDate = "01/01/2020", string index = "0")
        {
            //ClickRatesCreateNew();
            CreateRates_NewEffectiveDateBox.Get().Clear();
            Thread.Sleep(1000);
            CreateRates_NewEffectiveDateBox.Get().SendKeys(NewEffectiveDate);

            Thread.Sleep(1000);
            if (CreateRates_BasedOnBox.getDropDownListSize() != 0) CreateRates_BasedOnBox.selectElement("Index", index);
            CreateRates_NewEffectiveDateBox.Get().SendKeys(Keys.Escape);
            Thread.Sleep(1000);
            ClickCreateRates_Create(); 
            Thread.Sleep(5000);

            int CreateRates_NewRowNumber = CreateRates_Table1.getWebTableTotalRowNumbersOnPage();
            if (CreateRates_NewRowNumber > 1) { CreateRates_AddClass.Get().Click(); }
            else CreateRates_NewRowNumber --;
            Console.WriteLine("CreateRates_NewRowNumber: " + CreateRates_NewRowNumber);
            string indx = Utilities.getRandomNumber(1, 200).ToString();
            Console.WriteLine("index : "+indx);

            CreateRates_NewClass = new WebElementProxy(driver, By.XPath("//select[@id='newRates_"+ CreateRates_NewRowNumber + "__Class_Code']"));      //  ("select[name='newRates["+ CreateRates_NewRowNumber + "].Class_Code']"));
            CreateRates_NewRate = new WebElementProxy(driver, By.XPath("//input[@id='newRates_" + CreateRates_NewRowNumber + "__Rate']"));
            CreateRates_NewMaxEligibilityTerm = new WebElementProxy(driver, By.XPath("//input[@id='newRates_" + CreateRates_NewRowNumber + "__Max_Term']"));
            CreateRates_NewMaxCoverageTerm = new WebElementProxy(driver, By.XPath("//input[@id='newRates_" + CreateRates_NewRowNumber + "__Maximum_Coverage_Term']"));
            CreateRates_NewMaxAmt = new WebElementProxy(driver, By.XPath("//input[@id='newRates_" + CreateRates_NewRowNumber + "__Max_Amount']"));


            CreateRates_NewClass.Get().Click();
            Thread.Sleep(1000);
            CreateRates_NewClass.selectElement("Index", indx);
            CreateRates_NewRate.Get().Clear();
            CreateRates_NewRate.Get().SendKeys(Utilities.getRandomNumber(100, 500).ToString());
            CreateRates_NewMaxEligibilityTerm.Get().Clear();
            CreateRates_NewMaxEligibilityTerm.Get().SendKeys(Utilities.getRandomNumber(12, 120).ToString());
            CreateRates_NewMaxCoverageTerm.Get().Clear();
            CreateRates_NewMaxCoverageTerm.Get().SendKeys(Utilities.getRandomNumber(12, 120).ToString());
            CreateRates_NewMaxAmt.Get().Clear();
            CreateRates_NewMaxAmt.Get().SendKeys(Utilities.getRandomNumber(900, 1000).ToString());
            CreateRates_SubjectBox.Get().Clear();
            CreateRates_SubjectBox.Get().SendKeys("Rates");
            ClickCreateRates_CommentsBox();
            CreateRates_CommentsBox.Get().Clear();
            CreateRates_CommentsBox.Get().SendKeys("Automation Test Comment " + DateTime.Now.ToString("yyyyMMddhhmm"));
            ClickCreateRates_SaveButton();
            Thread.Sleep(10000);

        }
        public void DeleteNewRates()
        {
            ClickRatesDelete();
            ClickRatesDelete_DeleteButton();
        }


        //======================================================
        //---------  E N U M S ---------------------------------
        //======================================================     

        public enum FiltersFilterBy
        {
            Blank,                              //= "";
            PrimaryKey,                         // = "Primary Key";
            CoverageType,                       // = "Coverage Type";
            Relationship,                       // = "Relationship";
            RelationshipIdNumber,               // = "Relationship ID Number";
            State,                              // = "State";
            Status,                             // = "Status";
        }

        public enum OrderByOrderOrSortBy
        {
            Blank,                              //= "";
            PrimaryKey,                         // = "Primary Key";
            CoverageType,                       // = "Coverage Type";
            Relationship,                       // = "Relationship";
            RelationshipIdNumber,               // = "Relationship ID Number";
            State,                              // = "State";
            Status,                             // = "Status";
            Created,                            // = "Created";
            Modified,                           // = "Modified";
        }

        public enum OrderByDirection
        {
            Blank,                              // = "";
            Ascending,                          // = "Ascending";
            Descending,                         // = "Descending";
        }

        public enum DataFiltersFilterBy
        {
            Blank,                              // = "";
            Created,                            // = "Created";
            Modified,                           // = "Modified";
        }

        public enum DataFiltersBox1
        {
            Blank,                              // = "";
            Between,                            // = "Created";
            GreaterAndEqual,                    // = ">=";
            Greater,                            // = ">";
            NotNULL,                            // = "Not NULL";
        }
        public enum DataFiltersBox2
        {
            Blank,                              // = "";
            And,                                  // = "and";
            LessAndEqual,                         // = "<=";
            Less,                                  // = "<";
        }

    }

}


//      //tbody/tr/th[1]        //tbody/tr/th[2]        //tbody/tr/th[3]        //tbody/tr/th[4]        //tbody/tr/th[5]       --->//tbody/tr[1]     
//      //tbody/tr[2]/td[1]     //tbody/tr[2]/td[2]     //tbody/tr[2]/td[3]     //tbody/tr[2]/td[4]     //tbody/tr[2]/td[5]   ---->//tbody/tr[2]
//      //tbody/tr[3]/td[1]     //tbody/tr[3]/td[2]     //tbody/tr[3]/td[3]     //tbody/tr[3]/td[4]     //tbody/tr[3]/td[5]   ---->//tbody/tr[2]

//     tr:nth-of-type(3) > td:nth-of-type(2) > select#ddlOrderDirection

//     #collapseThree .panel-body table tbody > tr:nth-child(2) > td:nth-child(1) [name='ddlOrderBy']
//     #collapseThree .panel-body table tbody > tr:nth-child(2) > td:nth-child(2) [name='ddlOrderDirection']
//     #collapseThree .panel-body table tbody > tr:nth-child(3) > td:nth-child(1) [name='ddlOrderBy']
//     #collapseThree .panel-body table tbody > tr:nth-child(4) > td:nth-child(1) [name='ddlOrderBy']