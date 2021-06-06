using NUnit.Framework;
using System;
using User = FrameworkCore.DataFiles.User;
using System.Net;
using FrameworkCore.Utilities;
using PimsSupport.PAGES;
using FrameworkCore.DataFiles;
using System.Configuration;
using static PimsSupport.PAGES.LoginPage;

namespace PimsSupport.TESTS
{
    //  [TestFixture("ie")]
    //  [TestFixture("firefox")]
    [TestFixture("chrome")]
    [Parallelizable]
    class LoginTest_Positive : BaseTest
    {
        private LoginPage loginPage;
        public HeadbarMainMenu headbarMainMenuComponents;
        private LandingPage landingPage;

        public LoginTest_Positive(string browser) : base(browser) { }

        [SetUp]
        public void SetUp()
        {
            loginPage = new LoginPage(driver);
            loginPage.Load();
            landingPage = new LandingPage(driver, loginPage);
            headbarMainMenuComponents = new HeadbarMainMenu(driver, landingPage);
        }

        [Test, Description("Login as a USER1 and validate landingPage URL is loded")]
        [Category("Regression"), Category("SmokeTesting")]
        [Order(1)]
        public void ValidateLoginUser1()
        {
            loginPage.Login(User.USER1);
            Assert.Multiple(() =>
            {
                Assert.True(landingPage.ValidatePageURL(), "Pims Support Login Page did not loaded");
                Assert.True(landingPage.ValidateFooterEnabled(), "Pims Support Login Page Footer is not enabled");
            });
        }

        [Test, Description("Login as a USER2 and validate landingPage URL is loded")]
        [Category("Regression"), Category("SmokeTesting")]
        [Order(2)]
        public void ValidateLoginUser2()
        {
            loginPage.Login(User.USER2);
            Assert.Multiple(() =>
            {
                Assert.True(landingPage.ValidatePageURL(), "Pims Support Login Page did not loaded");
                Assert.True(landingPage.ValidateFooterEnabled(), "Pims Support Login Page Footer is not enabled");
            });
        }
        //[Ignore("Ignore a test")]
        //[TestCase("userName1", "password1")]
        //[TestCase("userName2", "password2")]
        //[TestCase("userName3", "password3")]
        [TestCase("userName4", "password4")]
        [Description("Login with valid credentials and validate landingPage URL is loded")]
        [Category("SmokeTesting")]
        [Order(3)]
        public void ValidateLoginUsers_TestCase_DataDriven1(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.Multiple(() =>
            {
                Assert.True(landingPage.ValidatePageURL(), "Pims Support Login Page did not loaded");
                Assert.True(landingPage.ValidateFooterEnabled(), "Pims Support Login Page Footer is not enabled");
            });
        }

        [Test, Description("Login with valid credentials and validate landingPage URL is exist")]
        [TestCaseSource("Credentials")]
        [Category("Regression"), Category("SmokeTesting")]
        [Order(3)]
        public void ValidateLoginUsers_TestCaseSourceCollection_DataDriven2(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.Multiple(() =>
            {
                Assert.True(landingPage.ValidatePageURL(), "Pims Support Login Page did not loaded");
                Assert.True(landingPage.ValidateFooterEnabled(), "Pims Support Login Page Footer is not enabled");
            });
        }

        static object[] Credentials =
        {
            new object[] { "userName1", "password1" },
            //new object[] { "userName2", "password2" },
            //new object[] { "userName3", "password3"  },
            //new object[] { "userName4", "password4"  },
        };

        [Test, Description("Login validation using DataManager source file ")]
        [Category("Regression"), Category("SmokeTesting")]
        [Order(4)]
        [TestCaseSource(typeof(DataManager))]
        public void ValidateLoginUsers_TestCaseSourceAtributeClass_DataDriven3(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.Multiple(() =>
            {
                Assert.True(landingPage.ValidatePageURL(), "Pims Support Login Page did not loaded");
                Assert.True(landingPage.ValidateFooterEnabled(), "Pims Support Login Page Footer is not enabled");
            });
        }

        [Test, Description("Login validation using xml data source file for first row")]
        [Category("Regression"), Category("SmokeTesting")]
        [Order(5)]
        public void ValidateLoginUser_ExcelSource_DataDriven4()
        {
            loginPage.LoginDD(FileDirectory.FileLoc2, "Sheet1", 1);
            Assert.Multiple(() =>
            {
                Assert.True(landingPage.ValidatePageURL(), "Pims Support Login Page did not loaded");
                Assert.True(landingPage.ValidateFooterEnabled(), "Pims Support Login Page Footer is not enabled");
            });
        }

        [Test, Description("Login validation using xml data source file for second row")]
        [Category("Regression"), Category("SmokeTesting")]
        [Order(6)]
        [TestCaseSource(typeof(ExelLoginTestDataAttributes1))]
        public void ValidateLoginUsers_ExcelSource_DataDriven5(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.Multiple(() =>
            {
                Assert.True(landingPage.ValidatePageURL(), "Pims Support Login Page did not loaded");
                Assert.True(landingPage.ValidateFooterEnabled(), "Pims Support Login Page Footer is not enabled");
            });
        }

        [Test, Description("Login as a USER1 and validate landingPage URL is loded")]
        [Category("Regression"), Category("SmokeTesting")]
        [Order(7)]
        public void ValidateLoginUser_xmlSource_DataDriven6()
        {
            loginPage.LoginXML(UserFromXml.USER1);
            Assert.Multiple(() =>
            {
                Assert.True(landingPage.ValidatePageURL(), "Pims Support Login Page did not loaded");
                Assert.True(landingPage.ValidateFooterEnabled(), "Pims Support Login Page Footer is not enabled");
            });
        }


        [TearDown]
        public void Logout()
        {
            landingPage.EvaluateScreenshotSourcePageSaving();
            headbarMainMenuComponents.GoToLogout();
        }
    }
}
