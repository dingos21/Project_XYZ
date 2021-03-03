using NUnit.Framework;
using System;
using User = FrameworkCore.DataFiles.User;
using System.Net;
using FrameworkCore.Utilities;
using PimsSupport.PAGES;
using FrameworkCore.DataFiles;

namespace PimsSupport.TESTS
{
    [TestFixture("chrome")]
    //  [TestFixture("ie")]
    //  [TestFixture("firefox")]
    //  [Parallelizable]
    class LoginTest_Pozitif : BaseTest
    {
        private LoginPage loginPage;
        public HeadbarMainMenuComponents headbarMainMenuComponents;
        private LandingPage landingPage;

        public LoginTest_Pozitif(string browser) : base(browser) { }

        [SetUp]
        public void SetUp()
        {
            loginPage = new LoginPage(driver);
            loginPage.Load();
            landingPage = new LandingPage(driver, loginPage);
            headbarMainMenuComponents = new HeadbarMainMenuComponents(driver);
        }

        //[Test,  Description("Login as a USER1 and validate landingPage URL is exist")]
        //[Category("SmokeTesting")]
        //[Order(1)]
        //public void ValidateLoginUser1()
        //{
        //    loginPage.Login(User.USER1);
        //    Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
        //}

        [Test,  Description("Login as a USER1 and validate landingPage URL is exist")]
        [Category("SmokeTesting")]
        [Order(2)]
        public void ValidateLoginUser2()
        {
            loginPage.Login(User.USER2);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
        }

        [TestCase("oturkakin", "ho17%#AK")]
        [TestCase("oturkakin", "ho17%#AK")]
        [TestCase("oturkakin", "ho17%#AK")]
        [TestCase("oturkakin", "ho17%#AK")]
        [Description("Login with valid credentials and validate landingPage URL is exist")]
        [Category("SmokeTesting")]
        [Order(3)]
        public void ValidateLoginUsers_01(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
        }

        [Test, Description("Login with valid credentials and validate landingPage URL is exist")]
        [TestCaseSource("Credentials")]
        [Category("SmokeTesting")]
        [Order(4)]
        public void ValidateLoginUsers_02(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
        }
        static object[] Credentials =
        {
            new object[] { "oturkakin", "ho17%#AK" },
            new object[] { "oturkakin", "ho17%#AK" },
            //new object[] { "oturkakin", "ho17%#AK" },
            //new object[] { "oturkakin", "ho17%#AK" },
        };

        [Test, Description("Login validation using DataManager source file ")]
        [Category("SmokeTesting")]
        [Order(5)]
        [TestCaseSource(typeof(DataManager))]
        public void ReadingCredentialsFromDataManager_01(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
        }

        [Test, Description("Login validation using xml data source file for first row")]
        [Category("SmokeTesting")]
        [Order(6)]
        public void ReadingCredentialsFromExel_02()
        {
            loginPage.LoginDD0(FileDirectory.FileLoc1, "Sheet1", 1);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
        }

        [Test, Description("Login validation using xml data source file for second row")]
        [Category("SmokeTesting")]
        [Order(7)]
        [TestCaseSource(typeof(ExelLoginTestDataAttribute))]
        public void ReadingCredentialsFromExel_03(String userName, String password)
        {
            loginPage.Login(userName, password);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
        }


        [TearDown]
        public void LogoutCenterPoint()
        {
            landingPage.EvaluateScreenshotSourcePageSaving();
            headbarMainMenuComponents.GoToLogout();
        }
    }
}
