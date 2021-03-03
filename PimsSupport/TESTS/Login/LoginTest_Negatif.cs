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
    class LoginTest_Negatif : BaseTest
    {
        private LoginPage loginPage;
        public HeadbarMainMenuComponents headbarMainMenuComponents;
        private LandingPage landingPage;
        public LoginTest_Negatif(string browser) : base(browser) { }

        [SetUp]
        public void SetUp()
        {
            loginPage = new LoginPage(driver);
            loginPage.Load();
            landingPage = new LandingPage(driver, loginPage);
            headbarMainMenuComponents = new HeadbarMainMenuComponents(driver);
        }

        [Test, Description("Validate Login with valid password, without user name")]
        [Category("SmokeTesting")]
        [Order(1)]
        public void ValidateLogin_NoUsername()
        {
            loginPage.Login(User.NoUserName);
            Assert.Multiple(() =>
            {
                Assert.True(loginPage.ValidateUserNameWarningIsAppeared("The User Name field is required."), "\"The User Name field is required.\" is not appered");
                Assert.AreEqual(loginPage.WarningUserNameRequired.GetText(), "The User Name field is required.");
                Assert.True(driver.Url.ToString().Contains(loginPage.expectedURL), "\"" + driver.Url.ToString() + "\" is not a correct url");
            });

        }

        [Test, Description("Validate Login with valid user name, without password")]
        [Category("SmokeTesting")]
        [Order(2)]
        public void ValidateLogin_NoPassword()
        {
            loginPage.Login(User.NoPassword);
            Assert.Multiple(() =>
            {
                Assert.True(loginPage.ValidatePasswordWarningIsAppeared("The Password field is required."), "\"The Password field is required.\" is not appered");
                Assert.AreEqual(loginPage.WarningPasswordRequired.GetText(), "The Password field is required.");
                Assert.True(driver.Url.ToString().Contains(loginPage.expectedURL), "\"" + driver.Url.ToString() + "\" is not a correct url");
            });

        }

        [TestCase("turkakin", "ho17%#AK")]
        [TestCase("oturkaki", "ho17%#AK")]
        [TestCase("oturakin", "ho17%#AK")]
        [TestCase("0turkakin", "ho17%#AK")]
        [Description("Validate Login with invalid user name, valid password")]
        [Category("SmokeTesting")]
        [Order(3)]
        public void ValidateLogin_InvalidUsernames(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.Multiple(() =>
            {
                Assert.True(loginPage.ValidateInvalidCredentialsWarningIsAppeared("Invalid username or password."), "\"The User Name field is required.\" is not appered");
                Assert.AreEqual(loginPage.WarningInvalidCredentials.GetText(), "Invalid username or password.");
                Assert.True(driver.Url.ToString().Contains(loginPage.expectedURL), "\"" + driver.Url.ToString() + "\" is not a correct url");
            });

        }

        [Test, Description("Validate Login with invalid password and valid user name ")]
        [TestCaseSource("Credentials")]
        [Category("SmokeTesting")]
        [Order(4)]
        public void ValidateLogin_InvalidPasswords(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.Multiple(() =>
            {
                Assert.True(loginPage.ValidateInvalidCredentialsWarningIsAppeared("Invalid username or password."), "\"The User Name field is required.\" is not appered");
                Assert.AreEqual(loginPage.WarningInvalidCredentials.GetText(), "Invalid username or password.");
                Assert.True(driver.Url.ToString().Contains(loginPage.expectedURL), "\"" + driver.Url.ToString() + "\" is not a correct url");
            });
        }
        static object[] Credentials =
        {
            new object[] { "iince", "almanya2016" },
            new object[] { "oturkakin", "ho17%#Ak" },
            new object[] { "iince", "lmanya2016" },
            new object[] { "oturkakin", "ho17%#A" },
        };


        [TearDown]
        public void LogoutPimsSupport()
        {
            landingPage.EvaluateScreenshotSourcePageSaving();
            loginPage.Load();
        }
    }
}
