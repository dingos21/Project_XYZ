using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkCore.PageObject
{
    public class WebElementProxy :IWebElement
    {
        private By locator;
        private IWebDriver driver;

        // COSTRUCTORS
        public WebElementProxy(IWebDriver driver, By locator)
        {
            this.locator = locator;
            this.driver = driver;
        }
        public WebElementProxy(IWebDriver driver)
        {
            this.driver = driver;
        }




        // GET________________


        public IWebElement Get()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(drv => drv.FindElement(locator));
        }
        public string GetText()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(drv => drv.FindElement(locator).Text);
        }
        public string GetAtribute(string atribute)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(drv => drv.FindElement(locator).GetAttribute(atribute));
        }
        public string getURL() { return driver.Url.ToString(); }
        public int getWebTableTotalRowNumbersOnPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return driver.FindElement(locator).FindElements(By.TagName("tr")).Count;
        }
        public int getWebTableTotalColumnNumbers()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return driver.FindElement(locator).FindElements(By.TagName("th")).Count;
        }





        // CLICK_________________

        public void Click()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.FindElement(locator).Click();
        }


        //  BOOL_________________


        public bool IsInteractable()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(drv => Get().Enabled);
        }
        public bool IsPresent()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(drv => Get().Displayed);
        }
        public bool TextIsPresent(string text)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(drv => drv.FindElement(locator).Text.ToLower().Equals(text.ToLower()));
        }
        public Size getWebElementSize()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            return wait.Until(drv => drv.FindElement(locator).Size);
        }

        public int getDropDownListSize()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            SelectElement selectList = new SelectElement(driver.FindElement(locator));
            IList<IWebElement> options = selectList.Options;
            return options.Count;

            //return FindElements(By.TagName("option"));
        }

        public IList<IWebElement> getDropDownList()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            SelectElement selectList = new SelectElement(driver.FindElement(locator));
            IList<IWebElement> options = selectList.Options;
            return options;

            //return FindElements(By.TagName("option"));
        }



    // SELECT

    public void selectElement(string Index_Text_Value, string equivalant)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            string a = Index_Text_Value.ToLower().Trim();
            string b = equivalant.ToLower().Trim();
            SelectElement select = new SelectElement(driver.FindElement(locator));
            switch (a)
            {
                case "index":
                    select.SelectByIndex(Convert.ToInt32(equivalant));
                    break;
                case "text":
                    select.SelectByText(equivalant);
                    break;
                case "value":
                    select.SelectByValue(equivalant);
                    break;
                default:
                    select.SelectByValue(equivalant);
                    break;
            }
        }



        // NOT IMPLEMENTED

        bool IWebElement.Enabled => throw new NotImplementedException();
        bool IWebElement.Selected => throw new NotImplementedException();
        System.Drawing.Point IWebElement.Location => throw new NotImplementedException();
        Size IWebElement.Size => throw new NotImplementedException();
        bool IWebElement.Displayed => throw new NotImplementedException();
        string IWebElement.TagName => throw new NotImplementedException();
        string IWebElement.Text => throw new NotImplementedException();
        void IWebElement.Clear()
        {
            throw new NotImplementedException();
        }
        void IWebElement.SendKeys(string text)
        {
            throw new NotImplementedException();
        }
        void IWebElement.Submit()
        {
            throw new NotImplementedException();
        }
        void IWebElement.Click()
        {
            throw new NotImplementedException();
        }
        string IWebElement.GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }
        string IWebElement.GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }
        string IWebElement.GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }
        IWebElement ISearchContext.FindElement(By by)
        {
            throw new NotImplementedException();
        }
        ReadOnlyCollection<IWebElement> ISearchContext.FindElements(By by)
        {
            throw new NotImplementedException();
        }



        //=============================================

        public bool isPresent()
        {
            bool flag = true;
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                return wait.Until(drv => Get().Displayed);
            }
            catch (Exception e)
            {
                flag = false;
            }
            return flag;
        }

        //=============================================

    }
}

