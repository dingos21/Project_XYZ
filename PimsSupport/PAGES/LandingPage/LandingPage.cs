
using FrameworkCore;
using FrameworkCore.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PimsSupport.PAGES
{
    public class LandingPage : BasePage
    {
        public string homeURL = "pimssupport/";
        public LoginPage loginPage;
        public HeadbarMainMenuComponents headbarMainMenuComponents;

        public LandingPage(IWebDriver driver, LoginPage loginPage) : base(driver)
        {
            this.loginPage = loginPage;
            InitializeElements();
            headbarMainMenuComponents = new HeadbarMainMenuComponents(driver);
        }

        private void InitializeElements()
        {


        }

        protected override void ExecuteLoad()
        {
            loginPage.Load();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(drv => drv.Url.Contains(homeURL));
        }

        protected override bool EvaluateLoadedStatus()
        {
            return driver.Url.Contains(homeURL);
        }
    }
}
