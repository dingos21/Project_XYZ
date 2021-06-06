using FrameworkCore.PageObject;
using FrameworkCore.Utilities;
using FrameworkCore.DataFiles;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Configuration;

namespace PimsSupport.PAGES
{
    public class LoginPage : BasePage
    {
        private LandingPage landingPage;
        public string ExpectedPageURL;
        private WebElementProxy pageURL;
        private WebElementProxy userName;
        private WebElementProxy password;
        private WebElementProxy pageTitle;
        private WebElementProxy footer;
        private HeadbarMainMenu headbarMainMenuComponents;
        public WebElementProxy WarningUserNameRequired;
        public WebElementProxy WarningPasswordRequired;
        public WebElementProxy WarningInvalidCredentials;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            InitializeElements();
        }

        private void InitializeElements()
        {
            ExpectedPageURL = "PimsSupport/Account/Login"; // http://pims-test.alliedsolutions.net/PimsSupport/Account/Login
            pageURL = new WebElementProxy(driver);
            userName = new WebElementProxy(driver, By.Id("Email"));
            password = new WebElementProxy(driver, By.Id("Password"));
            pageTitle = new WebElementProxy(driver, By.CssSelector(".body-content.container > h4:nth-of-type(1)"));
            footer = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > footer"));
            WarningUserNameRequired = new WebElementProxy(driver, By.XPath("//span[contains(text(),'The User Name field is required.')]"));
            WarningPasswordRequired = new WebElementProxy(driver, By.XPath("//span[contains(text(),'The Password field is required.')]"));     //css: #loginForm > form > div:nth-child(4) > div > span > span
            WarningInvalidCredentials = new WebElementProxy(driver, By.XPath("//li[contains(text(),'Invalid username or password.')]"));              //css:
        }


        //  LOGIN

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

        public void LoginXML(UserFromXml usr)
        {
            switch (usr)
            {
                case UserFromXml.USER1:
                    Login(Utilities.GetUserName("1"), Utilities.GetPassword("1")); 
                    break;
                case UserFromXml.USER2:
                    Login(Utilities.GetUserName("2"), Utilities.GetPassword("2"));
                    break;
                case UserFromXml.USER3:
                    Login(Utilities.GetUserName("3"), Utilities.GetPassword("3"));
                    break;
                case UserFromXml.USER4:
                    Login(Utilities.GetUserName("4"), Utilities.GetPassword("4"));
                    break;
                default:
                    Login(Utilities.GetUserName(), Utilities.GetPassword());
                    break;
            }

        }



        public void Login(FrameworkCore.DataFiles.User user)   //User.USER1
        {
            EnterUserName(user);
            EnterPassword(user);
        }

        public void LoginDD(string fileUrl, string SheetName = "Sheet1", int line = 1)
        {
            try
            {
                ExcelOperations1.PopulateInColection(FileDirectory.FileLoc1, "Sheet1");
                Login(ExcelOperations1.ReadData(line, "userName"), ExcelOperations1.ReadData(line, "password"));
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        //------  enter userName and password methods ------------

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




        //  GET

        public string getURL() { return pageURL.getURL(); }
        public string getPageSource()
        {
            return driver.PageSource.ToString();
        }
        public string getPageTitle_ClientAliases() { return pageTitle.GetText().ToString(); }


        // VALIDATE

        public bool ValidatePageURL() { return getURL().Contains(ExpectedPageURL); }
        public bool ValidatePageTitleEnabled() { return pageTitle.IsPresent() && pageTitle.IsInteractable(); }
        protected override bool EvaluateLoadedStatus()
        {
            return pageURL.getURL().Contains(ExpectedPageURL);
        }
        public bool ValidateFooterEnabled() { return footer.IsPresent() && footer.IsInteractable(); }
        public bool ValidateUserNameWarningIsAppeared(string text) { return WarningUserNameRequired.TextIsPresent(text); }
        public bool ValidatePasswordWarningIsAppeared(string text) { return WarningPasswordRequired.TextIsPresent(text); }
        public bool ValidateInvalidCredentialsWarningIsAppeared(string text) { return WarningInvalidCredentials.TextIsPresent(text); }


        //   OTHER

        protected override void ExecuteLoad()
        {
            driver.Navigate().GoToUrl(Utilities.GetEnvironmentUrl());
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.Url.Contains(ExpectedPageURL));
        }







        //======================================================
        //---------   Enums   ---------------------------------
        //=======================================================   
        public enum UserFromXml
        {
            USER1,
            USER2,
            USER3,
            USER4,
        }




    }
}




