using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using FrameworkCore.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkCore.PageObject
{
    /// <summary>
    /// Base page to be inherited by all page objects.  Inherits from LoadableComponent and provides an interface for extending base functionality.
    /// </summary>
    public abstract class BasePage : LoadableComponent<BasePage>
    {
        protected IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //public void CloseWalkMeDialogIfPresent()
        //{
        //    //Force Sleep statement due to Load Time of WalkMe Links
        //    Thread.Sleep(5000);
        //    List<IWebElement> closeWalkMeLinks = new List<IWebElement>();
        //    closeWalkMeLinks.AddRange(driver.FindElements(By.CssSelector(".walkme-action-close")));

        //    if (closeWalkMeLinks.Count > 0) { closeWalkMeLinks[0].Click(); }
        //}

        //testing local run 
        public void EvaluateScreenshotSourcePageSaving()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != ResultState.Success.Status)
            {
                string testName = TestContext.CurrentContext.Test.MethodName + "_";
                if (Convert.ToBoolean(ConfigurationManager.AppSettings.Get("ScreenOnFail?")))
                {
                    PageScreenshot.Take(driver, testName);
                }
                if (Convert.ToBoolean(ConfigurationManager.AppSettings.Get("SourceOnFail?")))
                {
                    PageSource.Save(driver, testName);
                }
            }
        }

        //Execute JS to scroll the browser to the bottom of the page
        public void ScrollBrowserDownToBottom()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
    }
}

