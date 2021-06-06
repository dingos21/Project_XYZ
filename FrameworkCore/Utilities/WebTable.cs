using FrameworkCore.PageObject;
using FrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Collections;

namespace FrameworkCore.Utilities
{
    public class WebTable : BaseComponent
    {
        public string ExpectedPageURL;
        public List<String> columnNames;               

        public Hashtable ColumnNamesDirectoryFromList ;
        public Hashtable ColumnNamesDirectoryFromWeb;
        public string column1Name = null;
        public string column2Name = null;
        public string column3Name = null;
        public string column4Name = null;
        private WebElementProxy pageURL;
        private WebElementProxy columnSLXID;
        private WebElementProxy pageTitleClientAliases;
        private WebElementProxy footerClientAliases;
        private WebElementProxy columnEfectiveDate;
        public WebTable(IWebDriver driver) : base(driver)
        {
            InitializeElements();
            InitializeColumnNamesDirectory(columnNames);
        }
        private void InitializeElements()
        {
            ExpectedPageURL = "PimsSupport/ClientAliases";
            
            pageURL = new WebElementProxy(driver);
            pageTitleClientAliases = new WebElementProxy(driver, By.CssSelector(".body-content.container > h4:nth-of-type(1)"));
            footerClientAliases = new WebElementProxy(driver, By.CssSelector("footer > p"));
            columnEfectiveDate = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(1) > th:nth-of-type(4)"));
            columnSLXID = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(1) > th:nth-of-type(5)"));
        }
        private void InitializeColumnNamesDirectory(List<String> columnNames)
        {
            int NumberOfColums = columnNames.Count;
            ColumnNamesDirectoryFromList = new Hashtable();
            for (int i = 1; i <= NumberOfColums; i++)
            {
                string key = "column" + i + "_Name";
                string value = columnNames[i];
                ColumnNamesDirectoryFromList.Add(key, value);
            }
        }

        public string getColumnNameFromList(List<String> columnNames, int columnNumber)
        {
            return columnNames[columnNumber];
        }

        private void InitializeColumnNamesDirectoryFromWeb(List<String> columnNames)
        {

            int NumberOfColums = columnNames.Count;
            ColumnNamesDirectoryFromList = new Hashtable();
            for (int i = 1; i <= NumberOfColums; i++)
            {
                string key = "column" + i + "_Name";
                string value = columnNames[i];
                ColumnNamesDirectoryFromList.Add(key, value);
            }
        }




        private void ActivateSubMenus(WebElementProxy webElement)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(webElement.Get()).Click().Build().Perform();
        }


    }
}
