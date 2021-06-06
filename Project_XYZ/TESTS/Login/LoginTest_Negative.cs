using NUnit.Framework;
using System;
using User = FrameworkCore.DataFiles.User;
using FrameworkCore.Utilities;
using PimsSupport.PAGES;

namespace PimsSupport.TESTS
{
    [TestFixture("chrome")]
    //  [TestFixture("ie")]
    //  [TestFixture("firefox")]
    //  [Parallelizable]
    class LoginTest_Negative : BaseTest
    {
        private LoginPage loginPage;
        public HeadbarMainMenu headbarMainMenu;
        private LandingPage landingPage;
        public LoginTest_Negative(string browser) : base(browser) { }

        [SetUp]
        public void SetUp()
        {
            loginPage = new LoginPage(driver);
            loginPage.Load();
            landingPage = new LandingPage(driver, loginPage);
            headbarMainMenu = new HeadbarMainMenu(driver, landingPage);
        }
        //[Ignore("Ignore a test")]
        [Test, Description("Validate Login with valid password, without user name")]
        [Category("Regression")]
        [Order(1)]
        public void ValidateLogin_NoUsername()
        {
            loginPage.Login(User.NoUserName);
            Assert.Multiple(() =>
            {
                Assert.True(loginPage.ValidateUserNameWarningIsAppeared("The User Name field is required."), "\"The User Name field is required.\" is not appered");
                Assert.AreEqual(loginPage.WarningUserNameRequired.GetText(), "The User Name field is required.");
                Assert.True(landingPage.getURL().ToString().Contains(landingPage.getExpectedPageURL()), "\"" + driver.Url.ToString() + "\" is not a correct url");
            });
        }
        //[Ignore("Ignore a test")]
        [Test, Description("Validate Login with valid user name, without password")]
        [Category("Regression")]
        [Order(2)]
        public void ValidateLogin_NoPassword()
        {
            loginPage.Login(User.NoPassword);
            Assert.Multiple(() =>
            {
                Assert.True(loginPage.ValidatePasswordWarningIsAppeared("The Password field is required."), "\"The Password field is required.\" is not appered");
                Assert.AreEqual(loginPage.WarningPasswordRequired.GetText(), "The Password field is required.");
                Assert.True(landingPage.getURL().ToString().Contains(landingPage.getExpectedPageURL()), "\"" + driver.Url.ToString() + "\" is not a correct url");
            });

        }
        //[Ignore("Ignore a test")]
        [TestCase("....", "....")]
        [TestCase("userName1"   , "password1.")]
        [TestCase("userName.2"  , "password2")]
        [TestCase("userName.3." , "password3.")]
        [TestCase("userName4."  , "password44")]
        [Description("Validate Login with invalid user name, valid password")]
        [Category("Regression")]
        [Order(3)]
        public void ValidateLogin_InvalidUsernames_DD1(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.Multiple(() =>
            {
                Assert.True(loginPage.ValidateInvalidCredentialsWarningIsAppeared("Invalid username or password."), "\"The User Name field is required.\" is not appered");
                Assert.AreEqual(loginPage.WarningInvalidCredentials.GetText(), "Invalid username or password.");
                Assert.True(landingPage.getURL().ToString().Contains(landingPage.getExpectedPageURL()), "\"" + driver.Url.ToString() + "\" is not a correct url");
            });

        }
        //[Ignore("Ignore a test")]
        [Test, Description("Validate Login with invalid password and valid user name ")]
        [TestCaseSource("Credentials")]
        [Category("Regression")]
        [Order(4)]
        public void ValidateLogin_InvalidPasswords_DD2(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.Multiple(() =>
            {
                Assert.True(loginPage.ValidateInvalidCredentialsWarningIsAppeared("Invalid username or password."), "\"The User Name field is required.\" is not appered");
                Assert.AreEqual(loginPage.WarningInvalidCredentials.GetText(), "Invalid username or password.");
                Assert.True(landingPage.getURL().ToString().Contains(landingPage.getExpectedPageURL()), "\"" + driver.Url.ToString() + "\" is not a correct url");
            });
        }
        static object[] Credentials =
        {
            new object[] { "userName1.."    , "password1" },
            new object[] { "userName.2"     , "password2" },
            new object[] { "userName.3."    , "password.3." },
            new object[] { "userName4"      , "password4." },
        };


        [TearDown]
        public void LogoutPimsSupport()
        {
            landingPage.EvaluateScreenshotSourcePageSaving();
            loginPage.Load();
        }
    }
}
