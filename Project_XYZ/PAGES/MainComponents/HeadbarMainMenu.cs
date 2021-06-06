using FrameworkCore.PageObject;
using FrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;


namespace PimsSupport.PAGES
{
    public class HeadbarMainMenu : BaseComponent
    {
        private LandingPage landingPage;
        public string logoutURL = "PimsSupport/";
        public string footerText = "© 2021 - Allied Solutions, LLC - Version 19.8 (2-10-2021)";
        private WebElementProxy pageURL;
        private WebElementProxy pageTitle;
        private WebElementProxy footer;
        private WebElementProxy pimsSupportMenu;
        private WebElementProxy bondMenu;
        private WebElementProxy capsMenu;
        private WebElementProxy cftMenu;
        private WebElementProxy icpiSetupMenu;   // link
        private WebElementProxy lspdMenu;
        private WebElementProxy pimsMenu;
        private WebElementProxy securityMenu;
        private WebElementProxy systemMaintenanceMenu;
        private WebElementProxy dataStoreMenu;
        private WebElementProxy helloUser;                                  //  css: #logoutForm > ul > li:nth-child(1) > a
        private WebElementProxy logoutMenu;
        //  Bond SubMenu
        private WebElementProxy Relationships;
        //  CAPS SubMenu
        private WebElementProxy ClaimsPolicyNumbers, GAP, GAPCarrierRetention, CAPSInstitutions,
                                CaseManagement, RemarketingServices, RepoPlusTrackingFees, CAPSProducts,
                                ClientServices, CPIProducts, DRNSetup;
        //  CFT SubMenu
        private WebElementProxy Akcelerant;
        //  LSPD SubMenu
        private WebElementProxy InsCompanyPhoneList, AlliedProtectClients;
        //  PIMS SubMenu
        private WebElementProxy EnrollmentNumberLookup, VINChanges, Batches, CancelCommissionWorksheets,
                                Clients, ClientAliases, CoverageTypeApprovals, CoverageTypes,
                                MaintainReportRepresentatives, Products, Relationships2,
                                Representatives, Underwriters, OtherPIMSTables;
        //  Security SubMenu
        private WebElementProxy DataStore, PIMSUsers, PIMSRoles;


        //public string rolesURL = "roles/search";
        //public string groupsURL = "groups/search";
        //public string profilesURL = "profiles/search";
        //public string lendersURL = "lenderprofile/search";
        //public string systemAdminURL = "users/search";
        //public string contactAlliedURL = "";
        //public string myProfileURL = "profile/detail";



        public HeadbarMainMenu(IWebDriver driver, LandingPage landingPage) : base(driver)
        {
            this.landingPage = landingPage;
            InitializeElements();
        }

        private void InitializeElements()
        {
            pageURL = new WebElementProxy(driver);
            pageTitle = new WebElementProxy(driver, By.CssSelector("................"));
            pimsSupportMenu = new WebElementProxy(driver, By.LinkText("PIMS Support"));
            bondMenu = new WebElementProxy(driver, By.LinkText("Bond"));
            capsMenu = new WebElementProxy(driver, By.LinkText("CAPS"));
            cftMenu = new WebElementProxy(driver, By.LinkText("CFT"));
            icpiSetupMenu = new WebElementProxy(driver, By.LinkText("iCPI Setup"));
            lspdMenu = new WebElementProxy(driver, By.LinkText("LSPD"));
            pimsMenu = new WebElementProxy(driver, By.LinkText("PIMS"));
            securityMenu = new WebElementProxy(driver, By.LinkText("Security"));
            systemMaintenanceMenu = new WebElementProxy(driver, By.LinkText("System Maintenance"));
            dataStoreMenu = new WebElementProxy(driver, By.LinkText("Data Store"));
            helloUser = new WebElementProxy(driver, By.CssSelector("#logoutForm > ul > li:nth-child(1) > a"));
            logoutMenu = new WebElementProxy(driver, By.LinkText("Log off"));

            // Bond ddm
            Relationships2 = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(1) > ul[role='menu']  a"));
            // CAPS ddm
            ClaimsPolicyNumbers = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(2) > ul[role='menu'] > li:nth-of-type(1) > a"));
            GAP = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(2) > ul[role='menu'] > li:nth-of-type(2) > a"));
            GAPCarrierRetention = new WebElementProxy(driver, By.LinkText("GAP Carrier Retention"));//CssSelector("ul[role='menu'] > li:nth-of-type(3) > a"));
            CAPSInstitutions = new WebElementProxy(driver, By.LinkText("CAPS Institutions"));
            CaseManagement = new WebElementProxy(driver, By.LinkText("Case Management"));
            RemarketingServices = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(2) > ul[role='menu'] > li:nth-of-type(7) > a"));
            RepoPlusTrackingFees = new WebElementProxy(driver, By.LinkText("Repo Plus Tracking Fees"));
            CAPSProducts = new WebElementProxy(driver, By.LinkText("CAPS Products"));
            ClientServices = new WebElementProxy(driver, By.LinkText("Client Services"));
            CPIProducts = new WebElementProxy(driver, By.LinkText("CPI Products"));
            DRNSetup = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(2) > ul[role='menu'] > li:nth-of-type(14) > a"));
            // CFT ddm
            Akcelerant = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(3) > ul[role='menu']  a"));
            // LSPD ddm
            InsCompanyPhoneList = new WebElementProxy(driver, By.LinkText("Ins. Company Phone List"));
            AlliedProtectClients = new WebElementProxy(driver, By.LinkText("Allied Protect Clients"));
            // PIMS ddm
            EnrollmentNumberLookup = new WebElementProxy(driver, By.LinkText("Enrollment Number Lookup"));
            VINChanges = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(5) > ul[role='menu'] > li:nth-of-type(2) > a"));
            Batches = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(5) > ul[role='menu'] > li:nth-of-type(4) > a"));
            CancelCommissionWorksheets = new WebElementProxy(driver, By.LinkText("Cancel Commission Worksheets"));
            Clients = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(5) > ul[role='menu'] > li:nth-of-type(6) > a"));
            ClientAliases = new WebElementProxy(driver, By.LinkText("Client Aliases"));
            CoverageTypeApprovals = new WebElementProxy(driver, By.LinkText("Coverage Type Approvals"));
            CoverageTypes = new WebElementProxy(driver, By.LinkText("Coverage Types"));
            MaintainReportRepresentatives = new WebElementProxy(driver, By.LinkText("Maintain Report Representatives"));
            Products = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(5) > ul[role='menu'] > li:nth-of-type(11) > a"));
            Relationships = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(5) > ul[role='menu'] > li:nth-of-type(12) > a"));
            Representatives = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(13) > a"));
            Underwriters = new WebElementProxy(driver, By.CssSelector("li:nth-of-type(5) > ul[role='menu'] > li:nth-of-type(14) > a"));
            OtherPIMSTables = new WebElementProxy(driver, By.LinkText("Other PIMS Tables"));
        }

        //GET
        public string getURL() { return pageURL.getURL(); }
        public string getPageSource()
        {
            return driver.PageSource.ToString();
        }
        public string getPageTitle() { return pageTitle.GetText().ToString(); }
        public string getHelloMessage() { return helloUser.GetText().ToString(); }
        public string getUserName()
        {
            var vs = helloUser.GetText().ToString().Split(' ');
            return vs[1].Substring(0, vs[1].Length - 1);
        }

        //   CLICK

        public void ClickBondMenu() { bondMenu.Click(); }
        public void ClickCapsMenu() { capsMenu.Click(); }
        public void ClickCFTMenu() { cftMenu.Click(); }
        public void ClickICPISetupMenu() { icpiSetupMenu.Click(); }
        public void ClickLSPDMenu() { lspdMenu.Click(); }
        public void ClickPIMSMenu() { pimsMenu.Click(); }
        public void ClickSecurityMenu() { securityMenu.Click(); }
        public void ClickSystemMaintenanceMenu() { systemMaintenanceMenu.Click(); }
        public void ClickDataStoreMenu() { dataStoreMenu.Click(); }
        public void ClickHelloUser() { helloUser.Click(); }
        public void ClickLogout() { logoutMenu.Click(); }
        public void ClickClientAliases() { ClientAliases.Click(); }
        public void ClickRelationships() { Relationships.Click(); }





        //  VALIDATE

        public bool ValidatePimsSupportMenuEnabled() { return pimsSupportMenu.IsPresent() && pimsSupportMenu.IsInteractable(); }
        public bool ValidateBondMenuEnabled() { return bondMenu.IsPresent() && bondMenu.IsInteractable(); }
        public bool ValidateCapsMenuEnabled() { return capsMenu.IsPresent() && capsMenu.IsInteractable(); }
        public bool ValidateCftMenuEnabled() { return cftMenu.IsPresent() && cftMenu.IsInteractable(); }
        public bool ValidateIcpiSetupMenuEnabled() { return icpiSetupMenu.IsPresent() && icpiSetupMenu.IsInteractable(); }
        public bool ValidateLspdMenuEnabled() { return lspdMenu.IsPresent() && lspdMenu.IsInteractable(); }
        public bool ValidatePimsMenuEnabled() { return pimsMenu.IsPresent() && pimsMenu.IsInteractable(); }
        public bool ValidateSecurityMenuEnabled() { return securityMenu.IsPresent() && securityMenu.IsInteractable(); }
        public bool ValidateSystemMaintenanceMenuEnabled() { return systemMaintenanceMenu.IsPresent() && systemMaintenanceMenu.IsInteractable(); }
        public bool ValidateDataStoreMenuEnabled() { return dataStoreMenu.IsPresent() && dataStoreMenu.IsInteractable(); }
        public bool ValidateHelloUser() { return helloUser.IsPresent() && helloUser.IsInteractable(); }
        public bool ValidateUserNameAppearedOnHelloMesage(string username) { return getHelloMessage().ToLower().Contains(username.ToLower()); }
        public bool ValidateBondRelationshipsEnabled() { return Relationships2.IsPresent() && Relationships2.IsInteractable(); }
        public bool ValidateClaimsPolicyNumbersEnabled() { return ClaimsPolicyNumbers.IsPresent() && ClaimsPolicyNumbers.IsInteractable(); }
        public bool ValidateGAPEnabled() { return GAP.IsPresent() && GAP.IsInteractable(); }
        public bool ValidateGAPCarrierRetentionEnabled() { return GAPCarrierRetention.IsPresent() && GAPCarrierRetention.IsInteractable(); }
        public bool ValidateCAPSInstitutionsEnabled() { return CAPSInstitutions.IsPresent() && CAPSInstitutions.IsInteractable(); }
        public bool ValidateCaseManagementEnabled() { return CaseManagement.IsPresent() && CaseManagement.IsInteractable(); }
        public bool ValidateRemarketingServicesEnabled() { return RemarketingServices.IsPresent() && RemarketingServices.IsInteractable(); }
        public bool ValidateRepoPlusTrackingFeesEnabled() { return RepoPlusTrackingFees.IsPresent() && RepoPlusTrackingFees.IsInteractable(); }
        public bool ValidateCAPSProductsEnabled() { return CAPSProducts.IsPresent() && CAPSProducts.IsInteractable(); }
        public bool ValidateClientServicesEnabled() { return ClientServices.IsPresent() && ClientServices.IsInteractable(); }
        public bool ValidateCPIProductsEnabled() { return CPIProducts.IsPresent() && CPIProducts.IsInteractable(); }
        public bool ValidateDRNSetupEnabled() { return DRNSetup.IsPresent() && DRNSetup.IsInteractable(); }
        public bool ValidateAkcelerantEnabled() { return Akcelerant.IsPresent() && Akcelerant.IsInteractable(); }
        public bool ValidateInsCompanyPhoneListEnabled() { return InsCompanyPhoneList.IsPresent() && InsCompanyPhoneList.IsInteractable(); }
        public bool ValidateAlliedProtectClientsEnabled() { return AlliedProtectClients.IsPresent() && AlliedProtectClients.IsInteractable(); }
        public bool ValidateEnrollmentNumberLookupEnabled() { return EnrollmentNumberLookup.IsPresent() && EnrollmentNumberLookup.IsInteractable(); }
        public bool ValidateVINChangesEnabled() { return VINChanges.IsPresent() && VINChanges.IsInteractable(); }
        public bool ValidateBatchesEnabled() { return Batches.IsPresent() && Batches.IsInteractable(); }
        public bool ValidateCancelCommissionWorksheetsEnabled() { return CancelCommissionWorksheets.IsPresent() && CancelCommissionWorksheets.IsInteractable(); }
        public bool ValidateClientsEnabled() { return Clients.IsPresent() && Clients.IsInteractable(); }
        public bool ValidateClientAliasesEnabled() { return ClientAliases.IsPresent() && ClientAliases.IsInteractable(); }
        public bool ValidateCoverageTypeApprovalsEnabled() { return CoverageTypeApprovals.IsPresent() && CoverageTypeApprovals.IsInteractable(); }
        public bool ValidateCoverageTypesEnabled() { return CoverageTypes.IsPresent() && CoverageTypes.IsInteractable(); }
        public bool ValidateMaintainReportRepresentativesEnabled() { return MaintainReportRepresentatives.IsPresent() && MaintainReportRepresentatives.IsInteractable(); }
        public bool ValidateProductsEnabled() { return Products.IsPresent() && Products.IsInteractable(); }
        public bool ValidatePimsRelationshipsEnabled() { return Relationships.IsPresent() && Relationships.IsInteractable(); }
        public bool ValidateRepresentativesEnabled() { return Representatives.IsPresent() && Representatives.IsInteractable(); }
        public bool ValidateUnderwritersEnabled() { return Underwriters.IsPresent() && Underwriters.IsInteractable(); }
        public bool ValidateOtherPIMSTablesEnabled() { return OtherPIMSTables.IsPresent() && OtherPIMSTables.IsInteractable(); }


        //public bool ValidateEnabled() { return .IsPresent() && .IsInteractable(); }








        //  OTHER

        public void GoToLogout()
        {
            logoutMenu.Get().Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.Url.Contains(logoutURL));
        }
        private void ActivateSubMenus(WebElementProxy webElement)
        {
            //TODO: Try in multiple browsers
            //Try click first...
            //webElement.Get().Click();
            //or this
            //HERE IS AN EXAMPLE OF USING A MOUSEOVER EVENT IN SELENIUM
            Actions action = new Actions(driver);
            action.MoveToElement(webElement.Get()).Click().Build().Perform();
        }



    }
}




