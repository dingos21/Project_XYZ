
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
        private string ExpectedPageURL;
        private WebElementProxy pageURL;
        private WebElementProxy footer;
        private string homeURL;
        private string LoginPageURL;
        public LoginPage loginPage;
        public HeadbarMainMenu headbarMainMenu;
        public WebElementProxy logoff;
        public WebElementProxy log_in;


        public LandingPage(IWebDriver driver, LoginPage loginPage) : base(driver)
        {
            this.loginPage = loginPage;
            InitializeElements();
            
        }

        private void InitializeElements()
        {
            ExpectedPageURL = "http://pims-test.alliedsolutions.net/PimsSupport/";    //"PimsSupport /";           //  http://pims-test.alliedsolutions.net/PimsSupport/
            homeURL         = "PimsSupport/";
            LoginPageURL = "http://pims-test.alliedsolutions.net/PimsSupport/Account/Login";
            pageURL         = new WebElementProxy(driver);
            footer = new WebElementProxy(driver, By.CssSelector("footer > p"));
            logoff = new WebElementProxy(driver, By.CssSelector("#logoutForm > ul > li:nth-child(2) > a"));
            log_in = new WebElementProxy(driver, By.CssSelector("loginLink"));
        }


        //  CLICK

        public void clickLogOff()
        {
            logoff.Get().Click();
        }
        public void clickLog_in()
        {
            log_in.Get().Click();
        }


        //   GET

        public string getPageSource()
        {
            return driver.PageSource.ToString();
        }
        public string getURL() { return pageURL.getURL(); }
        public string getExpectedPageURL() { return ExpectedPageURL; }
        public string getFooter() { return footer.GetText().ToString (); }



        //   VALIDATRE

        protected override bool EvaluateLoadedStatus()
        {
            return driver.Url.Contains(homeURL);
        }
        public bool ValidatePageURL() { return pageURL.getURL().Equals(ExpectedPageURL); }
        public bool ValidateFooterEnabled() { return footer.IsPresent() && footer.IsInteractable(); }


        //  OTHER

        protected override void ExecuteLoad()
        {
            loginPage.Load();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(drv => drv.Url.Contains(homeURL));
        }

        // Navigate

        public void navigateToLoginPage() {  driver.Navigate().GoToUrl(LoginPageURL); }



    }
}


