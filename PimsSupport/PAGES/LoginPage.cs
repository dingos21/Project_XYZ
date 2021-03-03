using FrameworkCore.PageObject;
using FrameworkCore.Utilities;
using FrameworkCore.DataFiles;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PimsSupport.PAGES
{
    public class LoginPage : BasePage
    {
        public readonly string expectedURL = "PimsSupport/Account/Login";
        private WebElementProxy userName;
        private WebElementProxy password;
#pragma warning disable CS0649 // Field 'LoginPage.landingPage' is never assigned to, and will always have its default value null
        private LandingPage landingPage;
#pragma warning restore CS0649 // Field 'LoginPage.landingPage' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'LoginPage.headbarMainMenuComponents' is never assigned to, and will always have its default value null
        private HeadbarMainMenuComponents headbarMainMenuComponents;
#pragma warning restore CS0649 // Field 'LoginPage.headbarMainMenuComponents' is never assigned to, and will always have its default value null
        public WebElementProxy WarningUserNameRequired;
        public WebElementProxy WarningPasswordRequired;
        public WebElementProxy WarningInvalidCredentials;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            InitializeElements();
        }

        private void InitializeElements()
        {
            userName = new WebElementProxy(driver, By.Id("Email"));
            password = new WebElementProxy(driver, By.Id("Password"));
            WarningUserNameRequired = new WebElementProxy(driver, By.XPath("//span[contains(text(),'The User Name field is required.')]"));
            WarningPasswordRequired = new WebElementProxy(driver, By.XPath("//span[contains(text(),'The Password field is required.')]"));     //css: #loginForm > form > div:nth-child(4) > div > span > span
            WarningInvalidCredentials = new WebElementProxy(driver, By.XPath("//li[contains(text(),'Invalid username or password.')]"));              //css:
        }
        public void Login(string UserName, string Password)
        {
            userName.Get().Clear();
            userName.Get().SendKeys(UserName);
            Thread.Sleep(2000);
            password.Get().Clear();
            password.Get().SendKeys(Password);
            password.Get().Submit();
            Thread.Sleep(3000);

        }


        public void Login(FrameworkCore.DataFiles.User user)   //User.USER1
        {
            EnterUserName(user);
            EnterPassword(user);
        }

        private void EnterUserName(FrameworkCore.DataFiles.User user)
        {
            userName.Get().Clear();
            userName.Get().SendKeys(user.UserName);
        }

        private void EnterPassword(FrameworkCore.DataFiles.User user)
        {
            Thread.Sleep(1000);
            password.Get().Clear();
            password.Get().SendKeys(user.Password);
            password.Get().Submit();
            Thread.Sleep(5000);
        }

        protected override void ExecuteLoad()
        {
            driver.Navigate().GoToUrl(Utilities.GetEnvironmentUrl());
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.Url.Contains(expectedURL));
        }

        protected override bool EvaluateLoadedStatus()
        {
            return driver.Url.Contains(expectedURL);
        }

        //==========================================================================


        private void Login(FrameworkCore.DataFiles.FileDirectory fileDirectory, string SheeSheetName = "Sheet1", int line = 1)
        {
            try
            {
                ExcelOperations1.PopulateInColection(FileDirectory.FileLoc1, "Sheet1");

                Console.WriteLine("first userName : " + ExcelOperations1.ReadData(line, "userName"));
                Console.WriteLine("first password : " + ExcelOperations1.ReadData(line, "password"));
                //Thread.Sleep(5000);
                Login(ExcelOperations1.ReadData(line, "userName"), ExcelOperations1.ReadData(line, "password"));


            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }


        //-----------------------------------------------------------------------------
        public void LoginDD0(string fileUrl, string SheetName = "Sheet1", int line = 1)
        {
            try
            {
                ExcelOperations1.PopulateInColection(FileDirectory.FileLoc1, "Sheet1");

                Console.WriteLine("first userName : " + ExcelOperations1.ReadData(line, "userName"));
                Console.WriteLine("first password : " + ExcelOperations1.ReadData(line, "password"));
                //Thread.Sleep(5000);
                Login(ExcelOperations1.ReadData(line, "userName"), ExcelOperations1.ReadData(line, "password"));


            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }

        //---------------------------
        public void LoginDD1(string fileUrly, string SheetName = "Sheet1")
        {
            try
            {
                ExcelOperations1.PopulateInColection(FileDirectory.FileLoc1, "Sheet1");

                for (int i = 1; i < 11; i++)
                {
                    Console.WriteLine("userName" + i + " :  " + ExcelOperations1.ReadData(i, "userName"));
                    Console.WriteLine("password" + i + " :  " + ExcelOperations1.ReadData(i, "password"));
                    Console.WriteLine();
                    Login(ExcelOperations1.ReadData(i, "userName"), ExcelOperations1.ReadData(i, "password"));
                    Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
                    headbarMainMenuComponents.GoToLogout();
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        //======================================================================================

        public bool ValidateUserNameWarningIsAppeared(string text) { return WarningUserNameRequired.TextIsPresent(text); }
        public bool ValidatePasswordWarningIsAppeared(string text) { return WarningPasswordRequired.TextIsPresent(text); }

        public bool ValidateInvalidCredentialsWarningIsAppeared(string text) { return WarningInvalidCredentials.TextIsPresent(text); }

    }
}
