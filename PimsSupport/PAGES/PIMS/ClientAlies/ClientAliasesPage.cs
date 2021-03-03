using FrameworkCore.PageObject;
using FrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PimsSupport.PAGES
{
    public class ClientAliasesPage : BaseComponent
    {
        public LandingPage landingPage;
        public string ExpectedPageURL;
        public string columnNameEfectiveDate;
        public string columnNameSLXID; 
        private WebElementProxy pageURL;
        private WebElementProxy footerClientAliases;
        private WebElementProxy columnEfectiveDate;
        private WebElementProxy columnSLXID;
        private WebElementProxy pageTitleClientAliases;
        private WebElementProxy deleteNumberNine;
        private WebElementProxy deleteButton;

        private WebElementProxy table; 
        private WebElementProxy tableHead; 
        private WebElementProxy tableBody;
        private IWebElement table2;
        private IWebElement tableHead2;
        private IWebElement tableBody2;

        private WebElementProxy goToPage;
        private WebElementProxy pageNumberBox;
        private WebElementProxy goToTheNextPage;
        private WebElementProxy rowPerPageBox;
        private WebElementProxy orderByAllies;
        private WebElementProxy orderByClient;
        private WebElementProxy filterByAllies;
        private WebElementProxy filterByClient;
        private WebElementProxy filterByBox;
        private WebElementProxy filterBox;
        private WebElementProxy createNew;
        private WebElementProxy aliasAsterix;
        private WebElementProxy client;
        private WebElementProxy alias;
        private WebElementProxy effectiveDate;
        private WebElementProxy clientBox;
        private WebElementProxy aliasBox; 
        private WebElementProxy effectiveDateBox;
        private WebElementProxy slxidBox;
        private WebElementProxy create;
        private WebElementProxy totalRowNumber;
        private WebElementProxy PageTitleCreateClientAliases;



        public ClientAliasesPage(IWebDriver driver,LandingPage landingPage) : base(driver)
        {
            this.landingPage = landingPage;
             InitializeElements();
        }
        private void InitializeElements()
        {            
            ExpectedPageURL = "PimsSupport/ClientAliases";
            columnNameEfectiveDate = "Effective Date";
            columnNameSLXID = "SLX ID";
            table = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > table"));   // //table[@class='table']
            tableHead = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > table > tbody > tr:nth-child(1)"));
            tableBody = new WebElementProxy(driver, By.XPath("/html/body/div[2]/table/tbody"));                 // css: tbody

            //table2 = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > table"));   // //table[@class='table']
            //tableHead2 = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > table > tbody > tr:nth-child(1)"));
            //tableBody2 = new WebElementProxy(driver, By.XPath("/html/body/div[2]/table/tbody"));

            pageURL = new WebElementProxy(driver);
            pageTitleClientAliases = new WebElementProxy(driver, By.CssSelector(".body-content.container > h4:nth-of-type(1)"));
            footerClientAliases = new WebElementProxy(driver, By.CssSelector("footer > p"));
            columnEfectiveDate = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(1) > th:nth-of-type(4)"));
            columnSLXID = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(1) > th:nth-of-type(5)"));
            goToPage = new WebElementProxy(driver, By.CssSelector("button[name='bsubmit']"));
            pageNumberBox = new WebElementProxy(driver, By.CssSelector("#pageNumber"));
            goToTheNextPage = new WebElementProxy(driver, By.CssSelector("input[alt='Next >']"));
            rowPerPageBox = new WebElementProxy(driver, By.Id("numberOfRows"));
            orderByAllies = new WebElementProxy(driver, By.CssSelector("#item_OrderBy > option:nth-child(2)")); ;
            orderByClient = new WebElementProxy(driver, By.CssSelector("#item_OrderBy > option:nth-child(3)")); ;
            filterByAllies = new WebElementProxy(driver, By.CssSelector("#item_FilterBy > option:nth-child(2)")); ;
            filterByClient = new WebElementProxy(driver, By.CssSelector("#item_FilterBy > option:nth-child(2)")); ;
            filterBox = new WebElementProxy(driver, By.CssSelector("#filter"));
            filterByBox = new WebElementProxy(driver, By.CssSelector("#item_FilterBy"));        
            deleteNumberNine = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(10) > td:nth-of-type(1) > a:nth-of-type(3)"));
            deleteButton = new WebElementProxy(driver, By.CssSelector("input[value = 'Delete']"));
            createNew = new WebElementProxy(driver, By.CssSelector("p > a"));       //LinkText("Create New"));
            aliasAsterix = new WebElementProxy(driver, By.XPath("//span[contains(text(),'*')]"));
            client = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > form > div > div > div:nth-child(1) > label"));
            alias = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > form > div > div > div:nth-child(2) > label"));
            effectiveDate = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > form > div > div > div:nth-child(3) > label"));
            clientBox = new WebElementProxy(driver, By.XPath("/html[1]/body[1]/div[2]/form[1]/input[1]"));        // #Client_ID_Number
            aliasBox = new WebElementProxy(driver, By.CssSelector("#Client_Alias"));
            effectiveDateBox = new WebElementProxy(driver, By.CssSelector("#Effective_Date"));
            slxidBox = new WebElementProxy(driver, By.CssSelector("#Effective_Date"));
            create = new WebElementProxy(driver, By.CssSelector("input[value='Create']"));
            totalRowNumber = new WebElementProxy(driver, By.CssSelector("#item_NumberOfPages"));
            PageTitleCreateClientAliases = new WebElementProxy(driver, By.LinkText("Create Client Aliases"));




        }
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        string slxID;


        public void ChangeWindow()
        {
            //string parent = driver.getWindowHandle();
           // Window myCurrentWindow = Window.GetWindow(this);
          //  List<IntPtr> windowHandles = new List<IntPtr>();

        }
        public string FilterNewClientAlies(string AliasName)
        {
            filterBox.Get().Clear();
            filterBox.Get().SendKeys(AliasName);
            filterByBox.Get().Click();
            SelectElement select = new SelectElement(driver.FindElement(By.CssSelector("#item_FilterBy")));
            select.SelectByValue("Alias");
            goToPage.Click();
            return (driver.FindElement(By.CssSelector("body > div.container.body-content > table > tbody > tr:nth-child(2) > td:nth-child(2)")).Text.ToString());
        }

        public bool ValidateNewClientAlliesIsCreated(string AliasName) { return AliasName.Equals(FilterNewClientAlies(AliasName)); }



        public int WebTableRowNumber() { return table.getWebTableTotalRowNumbers(); }
        public int WebTableColumnNumber() { return table.getWebTableTotalColumnNumbers(); }
        public bool ValidatePageURL() { return pageURL.getURL().Contains(ExpectedPageURL); }
        public bool ValidatePageTitleEnabled() { return pageTitleClientAliases.IsPresent() && pageTitleClientAliases.IsInteractable(); }
        public bool ValidateFooterEnabled() { return footerClientAliases.IsPresent() && footerClientAliases.IsInteractable(); }
        public bool ValidatecolumnEfectiveDateEnabled() { return columnEfectiveDate.IsPresent() && columnEfectiveDate.IsInteractable(); }
        public bool ValidatecolumnSLXIDEnabled() { return columnSLXID.IsPresent() && columnSLXID.IsInteractable(); }
        public bool ValidateColumnNameEfectiveDate() { return columnEfectiveDate.GetText().ToString().Equals(columnNameEfectiveDate); }
        public bool ValidateColumnNameSLXID() { return columnSLXID.GetText().ToString().Equals(columnNameSLXID); }
        public string getURL() { return pageURL.getURL(); }
        public string getPageTitle_ClientAliases() { return pageTitleClientAliases.GetText().ToString(); }
        public bool ValidateOrderByAlliesEnabled() { return orderByAllies.IsPresent() && orderByAllies.IsInteractable(); }
        public bool ValidateOrderByClientEnabled() { return orderByClient.IsPresent() && orderByClient.IsInteractable(); }
        public bool ValidateFilterByAlliesEnabled() { return filterByAllies.IsPresent() && filterByAllies.IsInteractable(); }
        public bool ValidateFilterByClientEnabled() { return filterByClient.IsPresent() && filterByClient.IsInteractable(); }
        public void ClickcreateNew() { createNew.Get().Click(); }



        //public bool ValidateEnabled() { return .IsPresent() && .IsInteractable(); }



        private void ActivateSubMenus(WebElementProxy webElement)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(webElement.Get()).Click().Build().Perform();
        }

        public List<string> getWebTableHeaderList()
        {
            int colNums = table.getWebTableTotalColumnNumbers();
            List<string> TableHeaderList = new List<string>();
            for (int i = 2; i <= colNums; i++)
            {
                TableHeaderList.Add(driver.FindElement(By.XPath("//tbody/tr/th["+i+"]")).Text);
            }
            return TableHeaderList;
        }
        public int getWebTableSpecificColumnNumber(string columnName)
        {
            List<string> TableHeaderList = getWebTableHeaderList();
            return TableHeaderList.IndexOf(columnName)+2;
        }

        public List <string> getWebTableColumnListForOnePage(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            List<String> TableColumnsList = new List<String>(); ;
            for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
            {
                TableColumnsList.Add(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td["+ columnNumber + "]")).Text);
            }
            return TableColumnsList;
        }

        public List<string> getWebTableColumnListAll(string columnName)
        {
            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPage.Click();
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            List<String> TableColumnsList = new List<String>(); 
            for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
            {
                TableColumnsList.Add(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
            return TableColumnsList;
        }

        public void printWebTableColumnListForOnePage(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            //List<String> TableColumnsList = new List<String>(); ;
            for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
        }

        public void printWebTableColumnListAll(string columnName)
        {

            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPage.Click();
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            //List<String> TableColumnsList = new List<String>();
            for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
            
        }


        public void printWebTableColumnListAfterFiltered(string columnName, string filterBy)
        {
            filterBox.Get().Clear();
            filterBox.Get().SendKeys(filterBy);
            filterByBox.selectElement("Value", "Client");
            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPage.Click();

            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
            // return TableColumnsList;
        }
        public List<string> getWebTableColumnListAfterFiltered(string columnName, string filterBy)
        {
            filterBox.Get().Clear();
            filterBox.Get().SendKeys(filterBy);
            filterByBox.selectElement("Value", "Client");
            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPage.Click();

            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            List<String> filterdTableColumnsList = new List<String>();
            for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
            {
                filterdTableColumnsList.Add(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
            return filterdTableColumnsList;
        }

        public void PrintWebTableColumnList(int columnNumber)
        {
            List<String> TableColumnsList = new List<String>(); ;
            for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
        }

        public void PrintWebTableColumnList(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            List<String> TableColumnsList = new List<String>(); ;
            for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
        }

        public bool ValidateNullColumnElemetNotExist(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPage.Click();
            int numberOfRow = table.getWebTableTotalRowNumbers();
            
            for (int i = 3; i <= numberOfRow; i++)
            {
                if (driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToString().Equals("")) 
                {
                    Console.WriteLine("row number :" + i);
                    Console.WriteLine("cell element: "+ driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToString());
                    return false; break;
                }
            }return true;
        }

        public bool ValidateParticularElementNotExistInColum(string columnName, string element)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPage.Click();
            int numberOfRow = table.getWebTableTotalRowNumbers();

            for (int i = 2; i <= numberOfRow; i++)
            {
                if ((driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToString()).Equals(element))
                {
                    Console.WriteLine("row number :" + i);
                    Console.WriteLine("cell element: " + driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToString());
                    return false; break;
                }
               
            }
            return true;
        }

        public bool ValidateNoTimeSteps2(string columnName)               // VALIDETS ALL ITEMS IN ONE PAGE
        {
            List<String> ColumnList = getWebTableColumnListAll(columnName);
            foreach (var item in ColumnList)
            {
                if (!item.Equals(""))
                {
                    return false; break;
                }
            }
            return true;
        }

        public bool ValidateItemDoesNotExistOnWebTableColum(string columnName, string item)               // VALIDETS ALL ITEMS IN ONE PAGE
        {
            List<String> ColumnList = getWebTableColumnListAll(columnName);
            foreach (var element in ColumnList)
            {
                if (!element.Equals(item))
                {
                    return false; break;
                }
            }
            return true;
        }




        public bool ValidateNoTimeSteps(int columnNumber)               // PAGE BY PAGE
        {
            string page = "1";
            for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
            {
                if ((driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToLower()).Equals(""))
                {
                    Console.WriteLine("First Null Element find on page: " + page);
                    return false;
                    break;
                }
            }
            goToTheNextPage.Click();
            page = pageNumberBox.GetAtribute();
            while (!page.Equals("1"))
            {
                for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
                {
                    if ((driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToLower()).Equals(""))
                    {
                        Console.WriteLine("First Null Element find on page: " + page);
                        return false;
                        break;
                    }
                }
                goToTheNextPage.Click();
                page = pageNumberBox.GetAtribute();
            }
            Console.WriteLine("First Null Element find on page: " + page);
            return true;
        }

        //public bool ValidateNullColumnElemetNotExist3(int columnNumber)     // PAGE BY PAGE    
        //{
        //    bool result = true;
        //    string page = "1";
        //    do
        //    {
        //        for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
        //        {
        //            if ((driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToLower()).Equals(""))
        //            {
        //                Console.WriteLine("First Null Element find on page: " + page);
        //                return result = false;
        //                break;
        //            } else goToTheNextPage.Click();
        //        }
        //        page = pageNumberBox.GetAtribute();
        //        for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
        //        {
        //            if ((driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToLower()).Equals(""))
        //            {
        //                Console.WriteLine("First Null Element find on page: " + page);
        //                return result = false;
        //                break;
        //            } else goToTheNextPage.Click();
        //        }
        //        page = pageNumberBox.GetAtribute();
        //        return result;
        //    }
        //    while (!page.Equals("1"));
        //}
        public bool ValidateRowPerPage(int number)
        {
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(number.ToString());
            for (int i = 0; i < 4; i++)
            {
                goToTheNextPage.Click();
                if (table.getWebTableTotalRowNumbers() - 1 != number)
                {
                    Console.WriteLine(table.getWebTableTotalRowNumbers());
                    return false;
                }
            }
            return true;
        }

        //public bool ValidateFilterBoxByClient(string client, int columnNumber)   // T R A S H - T R A S H -T R A S H - T R A S H 
        //{
        //    filterBox.Get().Clear();
        //    filterBox.Get().SendKeys(client);
        //    filterByBox.Get().Click();
        //    SelectElement select = new SelectElement(driver.FindElement(By.CssSelector("#item_FilterBy")));
        //    select.SelectByValue("Client");
        //    goToPage.Click();
        //    string page = "1";
        //    for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
        //    {
        //        if (!driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.Contains(client))
        //        {
        //            return false;
        //            break;
        //        }
        //    }
        //    goToTheNextPage.Click();
        //    page = pageNumberBox.GetAtribute();
        //    while (!page.Equals("1"))
        //    {
        //        for (int i = 2; i <= table.getWebTableTotalRowNumbers(); i++)
        //        {
        //            if (!driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.Contains(client))
        //            {
        //                return false;
        //                break;
        //            }
        //        }
        //        goToTheNextPage.Click();
        //        page = pageNumberBox.GetAtribute();
        //    }
        //    return true;
        //}

        public bool ValidateFilteredTableByClient(string columnName, string filterByItem)                      //  **********
        {
            List<String> ColumnList = getWebTableColumnListAfterFiltered(columnName, filterByItem);
            foreach (var item in ColumnList)
            {
                if (!item.Contains(filterByItem))
                {
                    return false; break;
                }
            }return true;
        }


        private void Select(WebElementProxy webElement)
        {
            //TODO: Try in multiple browsers
            //Try click first...
            //webElement.Get().Click();
            //or this
            //HERE IS AN EXAMPLE OF USING A MOUSEOVER EVENT IN SELENIUM
            SelectElement select = new SelectElement(driver.FindElement(By.CssSelector("#item_FilterBy")));
            select.SelectByValue("Client");
        }



        public void DeleteClientAliase(int number)
        {
            for (int i = 0; i < number; i++)
            {
                deleteNumberNine.Click();
                deleteButton.Click();
            }

        }

        public void GoToPage(int PageNumber)
        {
            pageNumberBox.Get().Clear();
            pageNumberBox.Get().SendKeys(PageNumber.ToString());
            goToPage.Click();
        }



    }
}


//      //tbody/tr/th[1]        //tbody/tr/th[2]        //tbody/tr/th[3]        //tbody/tr/th[4]        //tbody/tr/th[5]       --->//tbody/tr[1]     
//      //tbody/tr[2]/td[1]     //tbody/tr[2]/td[2]     //tbody/tr[2]/td[3]     //tbody/tr[2]/td[4]     //tbody/tr[2]/td[5]   ---->//tbody/tr[2]
//      //tbody/tr[3]/td[1]     //tbody/tr[3]/td[2]     //tbody/tr[3]/td[3]     //tbody/tr[3]/td[4]     //tbody/tr[3]/td[5]   ---->//tbody/tr[2]


