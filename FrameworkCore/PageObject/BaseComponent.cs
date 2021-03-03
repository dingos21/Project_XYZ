using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace FrameworkCore.PageObject
{
    /// <summary>
    /// A component is defined as a section of the UI that can be broken off. They are
    /// typically instantiated in the relevant page object classes.
    /// </summary>
    public abstract class BaseComponent
    {
        protected IWebDriver driver;

        public BaseComponent(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Execute JS to scroll the browser to the bottom of the page
        public void ScrollBrowserDownToBottom()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public void ScrollBrowserUpToTop()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(document.body.scrollHeight, 0)");
        }
    }
}
