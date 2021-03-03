using NUnit.Framework;
using User = FrameworkCore.DataFiles.User;
using FrameworkCore.Utilities;
using PimsSupport.PAGES;

namespace PimsSupport.TESTS
{
    [TestFixture("chrome")]
    //  [TestFixture("ie")]
    //  [TestFixture("firefox")]
    //  [Parallelizable]
    class HeadbarMainMenuTest : BaseTest
    {
        private LoginPage loginPage;
        public HeadbarMainMenuComponents headbarMainMenuComponents;
        private LandingPage landingPage;

        public HeadbarMainMenuTest(string browser) : base(browser) { }

        [SetUp]
        public void SetUp()
        {
            loginPage = new LoginPage(driver);
            loginPage.Load();
            landingPage = new LandingPage(driver, loginPage);
            headbarMainMenuComponents = new HeadbarMainMenuComponents(driver);
        }

        [Test,  Description("Navigate to Home/Dashboard page and validate head menu components")]
        [Category("SmokeTesting")]
        [Order(1)]
        public void ValidateHeaderComponents()
        {
            loginPage.Login(User.USER2);
            Assert.Multiple(() =>
            {
                Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
                Assert.True(headbarMainMenuComponents.ValidatePimsSupportMenuEnabled(), "Pims Support Menu is not enabled");
                Assert.True(headbarMainMenuComponents.ValidateBondMenuEnabled(), "Bond Menu is not enabled");
                Assert.True(headbarMainMenuComponents.ValidateCapsMenuEnabled(), "CAPS Menu is not enabled");
                Assert.True(headbarMainMenuComponents.ValidateCftMenuEnabled(), "CFT Menu is not enabled");
                //Assert.True(headbarMainMenuComponents.ValidateIcpiSetupMenuEnabled(), "ICPI Menu is not enabled");
                Assert.True(headbarMainMenuComponents.ValidateLspdMenuEnabled(), "LSPD Menu is not enabled");
                Assert.True(headbarMainMenuComponents.ValidatePimsMenuEnabled(), "PIMS Menu is not enabled");
                Assert.True(headbarMainMenuComponents.ValidateSecurityMenuEnabled(), "Security Menu is not enabled");
                Assert.True(headbarMainMenuComponents.ValidateSystemMaintenanceMenuEnabled(), "System Maintenance Menu is not enabled");
                Assert.True(headbarMainMenuComponents.ValidateDataStoreMenuEnabled(), "Data Store Menu is not enabled");
            });

        }

        [Test,  Description("Navigate to Home/Dashboard page and validate \"Hello User!\" exist")]
        [Category("SmokeTesting")]
        [Order(2)]
        public void ValidateHelloUser()
        {
            loginPage.Login(User.USER2);
            Assert.Multiple(() =>
            {
                Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
                Assert.True(headbarMainMenuComponents.ValidateHelloUser(), "Hello User not appeared");
                Assert.True(headbarMainMenuComponents.ValidateUserNameAppeared("Hello " + User.USER2.UserName + "!"), "\"Hello Oturkakin!\" is not appeared");
            });
        }

        [Test,  Description("Navigate to Home/Dashboard page and validate \"Bond\" drop-down menu")]
        [Category("SmokeTesting")]
        [Order(3)]
        public void ValidateBondsDropdownMenu()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickBondMenu();
            Assert.True(headbarMainMenuComponents.ValidateRelationshipsEnabled(), "Relationships is not enabled");
        }

        [Test,  Description("Navigate to Home/Dashboard page and validate \"CAPS\"  drop-down menu")]
        [Category("SmokeTesting")]
        [Order(4)]
        public void ValidateCapsDropdownMenu()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickCapsMenu();
            Assert.Multiple(() =>
            {
                Assert.True(headbarMainMenuComponents.ValidateClaimsPolicyNumbersEnabled(), "\"Claims Policy Numbers\" not appeared");
                Assert.True(headbarMainMenuComponents.ValidateGAPEnabled(), "\"GAP\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateGAPCarrierRetentionEnabled(), "\"GAP Carrier Retention\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateCAPSInstitutionsEnabled(), "\"CAPS Institutions\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateCaseManagementEnabled(), "\"Case Management\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateRemarketingServicesEnabled(), "\"Remarketing Services\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateCAPSProductsEnabled(), "\"CAPS Products\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateClientServicesEnabled(), "\"Client Services\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateCPIProductsEnabled(), "\"CPI Products\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateDRNSetupEnabled(), "\"DRN Setup\" is not appeared");
            });
        }

        [Test]
        [Description("Navigate to Home/Dashboard page and validate \"CFT\" drop-down menu")]
        [Category("SmokeTesting")] // [Order(1)]
        public void ValidateCFTDropdownMenu()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickCFTMenu();
            Assert.Multiple(() =>
            {
                Assert.True(headbarMainMenuComponents.ValidateAkcelerantEnabled(), "\"Akcelerant\" not appeared");
            });
        }

        [Test]
        [Description("Navigate to Home/Dashboard page and validate \"LSPD \" drop-down menu")]
        [Category("SmokeTesting")] // [Order(1)]
        public void ValidateLSPDDropdownMenu()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickLSPDMenu();
            Assert.Multiple(() =>
            {
                Assert.True(headbarMainMenuComponents.ValidateInsCompanyPhoneListEnabled(), "\"Ins. Company Phone List\" not appeared");
                Assert.True(headbarMainMenuComponents.ValidateAlliedProtectClientsEnabled(), "\"Allied Protect Clients\" not appeared");
            });
        }

        [Test, Description("Navigate to Home/Dashboard page and validate \"PIMS\"  drop-down menu")]
        [Category("SmokeTesting")]
        [Order(4)]
        public void ValidatePIMSDropdownMenu()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            Assert.Multiple(() =>
            {
                Assert.True(headbarMainMenuComponents.ValidateEnrollmentNumberLookupEnabled(), "\"Enrollment Number Lookup\" not appeared");
                Assert.True(headbarMainMenuComponents.ValidateVINChangesEnabled(), "\"VIN Changes\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateBatchesEnabled(), "\"Batches\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateCancelCommissionWorksheetsEnabled(), "\"Cancel Commission Worksheets \" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateClientsEnabled(), "\"Clients\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateClientAliasesEnabled(), "\"Client Aliases \" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateCoverageTypeApprovalsEnabled(), "\"Coverage Type Approvals\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateCoverageTypesEnabled(), "\"Coverage Types\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateMaintainReportRepresentativesEnabled(), "\"Maintain Report Representatives\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateProductsEnabled(), "\"Products\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateRelationships2Enabled(), "\"Relationships\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateRepresentativesEnabled(), "\"Representatives\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateUnderwritersEnabled(), "\"Underwriters\" is not appeared");
                Assert.True(headbarMainMenuComponents.ValidateOtherPIMSTablesEnabled(), "\"Other PIMS Tables\" is not appeared");

            });
        }

        [TearDown]
        public void LogoutCenterPoint()
        {
            landingPage.EvaluateScreenshotSourcePageSaving();
            headbarMainMenuComponents.GoToLogout();
        }
    }
}


