using FrameworkCore.PageObject;
using FrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using FrameworkCore.Utilities;

namespace PimsSupport.PAGES
{
    public class ClientAliasesPage : BaseComponent
    {
        public LandingPage landingPage;
        public string ExpectedPageURL;
        public string ExpectedPageURL_Details;
        public string ExpectedPageURL_Edit;
        public string ExpectedPageURL_Delete;
        public string ExpectedPageURL_Clients;
        public string ExpectedPageURL_ClientsView;
        public string ExpectedPageURL_ClientsEditClients;
        public string columnNameAlias;
        public string columnNameClient;
        public string columnNameEfectiveDate;
        public string columnNameSLXID;
        public string ExpectedClientsEditButtonLink;
        public string ExpectedClientsBackToListButtonLink;
        public string ExpectedClientsEditClientBackToListButtonLink;

        public string password;

        private WebElementProxy pageURL;
        private WebElementProxy pageTitle;
        private WebElementProxy footer;
        private WebElementProxy columnAlias;
        private WebElementProxy columnClient;
        private WebElementProxy columnEfectiveDate;
        private WebElementProxy columnSLXID;
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
        private WebElementProxy detailsOption;
        private WebElementProxy randomDetailsOption;
        private WebElementProxy editOption;
        private WebElementProxy randomEditOption;
        private WebElementProxy deleteOption;
        private WebElementProxy randomDeleteOption;
        private WebElementProxy clientOption;
        private WebElementProxy createButton;
        private WebElementProxy clientIDisRequired;
        private WebElementProxy aliasIsRequired;
        private WebElementProxy effectiveDateIsRequired;
        private WebElementProxy backTolist;
        private WebElementProxy clientAliasUpdated;
        private WebElementProxy saveButton;
        private WebElementProxy detailsClient;
        private WebElementProxy detailsAlias;
        private WebElementProxy detailsEffectiveDate;
        private WebElementProxy detailsSlxID;
        private WebElementProxy detailsID;
        private WebElementProxy detailsClientID;
        private WebElementProxy detailsCreated;
        private WebElementProxy detailsModified;
        private WebElementProxy detailsUserName;
        private WebElementProxy detailsEditButton;
        private WebElementProxy detailsBackToListButton;
        private WebElementProxy areYouSureYouWantToDeleteThis;
        private WebElementProxy deleteRedBbutton;
        private WebElementProxy clientAliasDeleted;
        private WebElementProxy backToListFromDelete;
        private WebElementProxy clientsEditButton;
        private WebElementProxy clientsBackToListButton;
        private WebElementProxy clientsEditClientsBackToListButton;
        private WebElementProxy clientsEditClientsSaveButton;
        private WebElementProxy clientsEditClientsFDICBox;
        private WebElementProxy clientsEditClientsNCUABox;
        private WebElementProxy clientsClientUpdatedSign;






        public ClientAliasesPage(IWebDriver driver, LandingPage landingPage) : base(driver)
        {
            this.landingPage = landingPage;
            InitializeElements();
        }
        private void InitializeElements()
        {
            ExpectedPageURL = "PimsSupport/ClientAliases";
            ExpectedPageURL_Details = "PimsSupport/ClientAliases/Details";
            ExpectedPageURL_Edit = "PimsSupport/ClientAliases/Edit";
            ExpectedPageURL_Delete = "PimsSupport/ClientAliases/Delete";
            ExpectedPageURL_Clients = "PimsSupport/Clients/Details";
            ExpectedPageURL_ClientsView = "PimsSupport/Clients";
            ExpectedPageURL_ClientsEditClients = "PimsSupport/Clients/Edit";
            columnNameEfectiveDate = "Effective Date";
            columnNameSLXID = "SLX ID";
            columnNameAlias = "Alias";
            columnNameClient = "Client";
            password = Utilities.GetPassword();


            table = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > table"));   // //table[@class='table']
            tableHead = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > table > tbody > tr:nth-child(1)"));
            tableBody = new WebElementProxy(driver, By.XPath("/html/body/div[2]/table/tbody"));                 // css: tbody
            pageURL = new WebElementProxy(driver);
            pageTitle = new WebElementProxy(driver, By.CssSelector(".body-content.container > h4:nth-of-type(1)"));
            footer = new WebElementProxy(driver, By.CssSelector("footer > p"));
            columnAlias = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(1) > th:nth-of-type(2)"));
            columnClient = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(1) > th:nth-of-type(3)"));
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
            totalRowNumber = new WebElementProxy(driver, By.CssSelector("#item_NumberOfPages"));
            detailsOption = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > td:nth-of-type(1) > a:nth-of-type(1)"));
            randomDetailsOption = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(" + Utilities.getRandomNumber(2, 11) + ") > td:nth-of-type(1) > a:nth-of-type(1)"));
            editOption = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > td:nth-of-type(1) > a:nth-of-type(2)"));
            randomEditOption = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(" + Utilities.getRandomNumber(2, 11) + ") > td:nth-of-type(1) > a:nth-of-type(2)"));
            deleteOption = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > td:nth-of-type(1) > a:nth-of-type(3)"));
            randomDeleteOption = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(" + Utilities.getRandomNumber(2, 11) + ") > td:nth-of-type(1) > a:nth-of-type(3)"));
            clientOption = new WebElementProxy(driver, By.CssSelector("tr:nth-of-type(2) > td:nth-of-type(1) > a:nth-of-type(4)"));

            //------------------- Edit
            footer = new WebElementProxy(driver, By.CssSelector("p"));
            pageTitle = new WebElementProxy(driver, By.CssSelector("h4"));   //By.LinkText("Create Client Aliases"));
            aliasAsterix = new WebElementProxy(driver, By.XPath("//span[contains(text(),'*')]"));
            client = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > form > div > div:nth-child(3) > label"));
            alias = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > form > div > div:nth-child(4) > label"));
            effectiveDate = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > form > div > div:nth-child(5) > label"));
            clientBox = new WebElementProxy(driver, By.CssSelector("#Client_ID_Number"));    //("html[1]/body[1]/div[2]/form[1]/input[1]"));        // #Client_ID_Number
            aliasBox = new WebElementProxy(driver, By.CssSelector("#Client_Alias"));
            effectiveDateBox = new WebElementProxy(driver, By.CssSelector("#Effective_Date"));
            slxidBox = new WebElementProxy(driver, By.CssSelector("input#Alias_SLXID"));
            createButton = new WebElementProxy(driver, By.CssSelector("input[value='Create']"));
            clientIDisRequired = new WebElementProxy(driver, By.XPath("//span[contains(text(),'Client is required')]"));            // By.CssSelector(".field-validation-error.text-danger > span")); 
            aliasIsRequired = new WebElementProxy(driver, By.XPath("//span[contains(text(),'Alias is required')]"));      // By.CssSelector(".field-validation-error.text-danger > span")); 
            effectiveDateIsRequired = new WebElementProxy(driver, By.XPath("//span[contains(text(),'Effective Date is required')]"));   // By.CssSelector(".field-validation-error.text-danger > span")); 
            backTolist = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > div > a"));
            saveButton = new WebElementProxy(driver, By.CssSelector("input[value='Save']"));
            clientAliasUpdated = new WebElementProxy(driver, By.XPath("//h4[contains(text(),'* Client alias updated')]"));    // "* Client alias updated"

            //------------------------ details
            detailsClient = new WebElementProxy(driver, By.CssSelector("dl > dd:nth-of-type(1)"));
            detailsAlias = new WebElementProxy(driver, By.CssSelector("dl > dd:nth-of-type(2)"));
            detailsEffectiveDate = new WebElementProxy(driver, By.CssSelector("dl > dd:nth-of-type(3)"));
            detailsSlxID = new WebElementProxy(driver, By.CssSelector("dl > dd:nth-of-type(4)"));
            detailsID = new WebElementProxy(driver, By.CssSelector("dl > dd:nth-of-type(6)"));
            detailsClientID = new WebElementProxy(driver, By.CssSelector("dl > dd:nth-of-type(7)"));
            detailsCreated = new WebElementProxy(driver, By.CssSelector("dl > dd:nth-of-type(8)"));
            detailsModified = new WebElementProxy(driver, By.CssSelector("dl > dd:nth-of-type(9)"));
            detailsUserName = new WebElementProxy(driver, By.CssSelector("dl > dd:nth-of-type(10)"));
            detailsEditButton = new WebElementProxy(driver, By.CssSelector("p > a:nth-of-type(1)"));
            detailsBackToListButton = new WebElementProxy(driver, By.CssSelector("p > a:nth-of-type(2)"));
            //--------------------------- delete
            areYouSureYouWantToDeleteThis = new WebElementProxy(driver, By.CssSelector(".text-danger"));
            deleteRedBbutton = new WebElementProxy(driver, By.CssSelector("input[value='Delete']"));
            clientAliasDeleted = new WebElementProxy(driver, By.CssSelector(".text-success"));
            backToListFromDelete = new WebElementProxy(driver, By.CssSelector(".form-actions [href]"));
            //------------------------ client
            clientsEditButton = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > p > a:nth-child(1)"));
            clientsBackToListButton = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > p > a:nth-child(3)"));
            ExpectedClientsEditButtonLink = "/PimsSupport/Clients/Edit";
            ExpectedClientsBackToListButtonLink = "/PimsSupport/Clients";
            ExpectedClientsEditClientBackToListButtonLink = "/PimsSupport/Clients";
            clientsEditClientsBackToListButton = new WebElementProxy(driver, By.CssSelector(".body-content.container > div > a"));
            clientsEditClientsSaveButton = new WebElementProxy(driver, By.CssSelector("input[value='Save']"));
            clientsEditClientsFDICBox = new WebElementProxy(driver, By.CssSelector("input#FDIC_Certificate_Number"));
            clientsEditClientsNCUABox = new WebElementProxy(driver, By.CssSelector("input#NCUA_Number"));
            clientsClientUpdatedSign = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > h4.text-success"));
        }





        // CLICK
        public void ClickCreateNew() { createNew.Get().Click(); }
        public void ClickDetailsOption() { detailsOption.Get().Click(); }
        public void ClickRandomDetailsOption() { randomDetailsOption.Get().Click(); }
        public void ClickEditOption() { editOption.Get().Click(); }
        public void ClickRandomEditOption() { randomEditOption.Get().Click(); }
        public void ClickDeleteOption() { deleteOption.Get().Click(); }
        public void ClickRandomDeleteOption() { randomDeleteOption.Get().Click(); }
        public void ClickClientOption() { clientOption.Get().Click(); }
        public void ClickSaveButton() { saveButton.Get().Click(); }
        public void ClickDetailsEditButton() { detailsEditButton.Get().Click(); }
        public void ClickDetailsBackToListButton() { detailsBackToListButton.Get().Click(); }
        public void ClickClientsEditButton() { clientsEditButton.Get().Click(); }
        public void ClickClientsBackToListButton() { clientsBackToListButton.Get().Click(); }
        public void ClickDeleteRedBbutton() { deleteRedBbutton.Get().Click(); }
        public void ClickBackTolist() { backTolist.Get().Click(); }
        public void ClickBackToListFromDelete() { backToListFromDelete.Get().Click(); }
        public void ClickcClientsEditClientsBackToListButton() { clientsEditClientsBackToListButton.Get().Click(); }
        public void ClickClientsEditClientsSaveButton() { clientsEditClientsSaveButton.Get().Click(); }
        public void ClickClientsEditClientsFDICBox() { clientsEditClientsFDICBox.Get().Click(); }
        public void ClickClientsEditClientsNCUABox() { clientsEditClientsNCUABox.Get().Click(); }



        //VALIDATE
        public bool ValidateNewClientAliasIsCreated(string AliasName) { return AliasName.Equals(getAliasFromList(AliasName)); }
        public bool ValidateClientAliasIsUpdated() { return clientAliasUpdated.IsPresent() && clientAliasUpdated.IsInteractable(); }
        public bool ValidateClientAliasIsUpdated(string AliasName)
        {
            string EffectiveDate = Utilities.getRandomPastDate(3);
            string SLX_ID = "Test" + Utilities.getRandomNumber(100, 999).ToString();
            edditClientAlias(AliasName, EffectiveDate, SLX_ID);
            return clientAliasUpdated.IsPresent() && clientAliasUpdated.IsInteractable();
        }
        public int WebTableRowNumber() { return table.getWebTableTotalRowNumbersOnPage(); }
        public int WebTableColumnNumber() { return table.getWebTableTotalColumnNumbers(); }
        public bool ValidatePageURL() { return pageURL.getURL().Contains(ExpectedPageURL); }
        public bool ValidatePageURL_Details() { return pageURL.getURL().Contains(ExpectedPageURL_Details); }
        public bool ValidatePageURL_Edit() { return pageURL.getURL().Contains(ExpectedPageURL_Edit); }
        public bool ValidatePageURL_Delete() { return pageURL.getURL().Contains(ExpectedPageURL_Delete); }
        public bool ValidatePageURL_Clients() { return pageURL.getURL().Contains(ExpectedPageURL_Clients); }
        public bool ValidatePageURL_ClientsView() { return pageURL.getURL().Contains(ExpectedPageURL_ClientsView); }
        public bool ValidatePageURL_ClientsEditClients() { return pageURL.getURL().Contains(ExpectedPageURL_ClientsEditClients); }
        public bool ValidatePageTitleEnabled() { return pageTitle.IsPresent() && pageTitle.IsInteractable(); }
        public bool ValidateFooterEnabled() { return footer.IsPresent() && footer.IsInteractable(); }
        public bool ValidateColumnAliasEnabled() { return columnAlias.IsPresent() && columnAlias.IsInteractable(); }
        public bool ValidateColumnClientEnabled() { return columnClient.IsPresent() && columnClient.IsInteractable(); }
        public bool ValidateColumnEfectiveDateEnabled() { return columnEfectiveDate.IsPresent() && columnEfectiveDate.IsInteractable(); }
        public bool ValidateColumnSLX_IDEnabled() { return columnSLXID.IsPresent() && columnSLXID.IsInteractable(); }
        public bool ValidateColumnNameAlias() { return columnAlias.GetText().ToString().Equals(columnNameAlias); }
        public bool ValidateColumnNameClient() { return columnClient.GetText().ToString().Equals(columnNameClient); }
        public bool ValidateColumnNameEfectiveDate() { return columnEfectiveDate.GetText().ToString().Equals(columnNameEfectiveDate); }
        public bool ValidateColumnNameSLXID() { return columnSLXID.GetText().ToString().Equals(columnNameSLXID); }
        public bool ValidateOrderByAlliesEnabled() { return orderByAllies.IsPresent() && orderByAllies.IsInteractable(); }
        public bool ValidateOrderByClientEnabled() { return orderByClient.IsPresent() && orderByClient.IsInteractable(); }
        public bool ValidateFilterByAlliesEnabled() { return filterByAllies.IsPresent() && filterByAllies.IsInteractable(); }
        public bool ValidateFilterByClientEnabled() { return filterByClient.IsPresent() && filterByClient.IsInteractable(); }
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
        public bool ValidateNullColumnElemetNotExist(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPage.Click();
            int numberOfRow = table.getWebTableTotalRowNumbersOnPage();

            for (int i = 3; i <= numberOfRow; i++)
            {
                if (driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToString().Equals(""))
                {
                    Console.WriteLine("row number :" + i);
                    Console.WriteLine("cell element: " + driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToString());
                    return false; break;
                }
            }
            return true;
        }

        public bool ValidateParticularElementNotExistInColum(string columnName, string element)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPage.Click();
            int numberOfRow = table.getWebTableTotalRowNumbersOnPage();

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
        public bool ValidateNoTimeSteps(int columnNumber)               // PAGE BY PAGE
        {
            string page = "1";
            for (int i = 2; i <= table.getWebTableTotalRowNumbersOnPage(); i++)
            {
                if ((driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToLower()).Equals(""))
                {
                    Console.WriteLine("First Null Element find on page: " + page);
                    return false;
               
                }
            }
            goToTheNextPage.Click();
            page = pageNumberBox.GetAtribute("value");
            while (!page.Equals("1"))
            {
                for (int i = 2; i <= table.getWebTableTotalRowNumbersOnPage(); i++)
                {
                    if ((driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text.ToLower()).Equals(""))
                    {
                        Console.WriteLine("First Null Element find on page: " + page);
                        return false;
                      
                    }
                }
                goToTheNextPage.Click();
                page = pageNumberBox.GetAtribute("value");
            }
            Console.WriteLine("First Null Element find on page: " + page);
            return true;
        }

        public bool ValidateRowPerPage(int number)
        {
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(number.ToString());
            for (int i = 0; i < 4; i++)
            {
                goToTheNextPage.Click();
                if (table.getWebTableTotalRowNumbersOnPage() - 1 != number)
                {
                    Console.WriteLine(table.getWebTableTotalRowNumbersOnPage());
                    return false;
                }
            }
            return true;
        }
        public bool ValidateFilteredTable(string columnName, string filterItem, string filterBy = "Client")                      //  **********
        {
            List<String> ColumnList = getWebTableColumnListAfterFiltered(columnName, filterItem, filterBy);
            foreach (var item in ColumnList)
            {
                if (!item.Contains(filterItem))
                {
                    return false; break;
                }
            }
            return true;
        }
        public bool ValidateClientHaveAnAsterisk()
        {
            Console.WriteLine(client.GetText().ToString());
            return client.GetText().ToString().Contains("*");
        }
        public bool ValidateAliesHaveAnAsterisk()
        {
            Console.WriteLine(alias.GetText().ToString());
            return alias.GetText().ToString().Contains("*");
        }
        public bool ValidateEffectiveDateHaveAnAsterisk()
        {
            Console.WriteLine(effectiveDate.GetText().ToString());
            return effectiveDate.GetText().ToString().Contains("*");
        }
        public bool ValidateClientIDisRequiredForEdditting()
        {
            edditClientAlias("Select...", "Test Reqired Field Messege", "01/01/2001", "test01");
            return clientIDisRequired.IsPresent() && clientIDisRequired.IsInteractable();
        }
        public bool ValidateAliesIsRequiredForEdditting()
        {
            edditClientAlias("02ICK Credit Corp (SC0054) SC", "", "01/01/2001", "test01");
            return aliasIsRequired.IsPresent() && aliasIsRequired.IsInteractable();
        }
        public bool ValidateEffectiveDateIsRequiredForEdditting()
        {
            edditClientAlias("121 Financial CU FL", "Test Reqired Field Messege", "", "test01");
            return effectiveDateIsRequired.IsPresent() && effectiveDateIsRequired.IsInteractable();
        }
        public bool ValidateAbleToSelectClientIDFromDropDownList()
        {
            clientBox.Get().Click();
            clientBox.selectElement("Text", "Zia CU NM");
            saveButton.Get().Click();
            return clientAliasUpdated.IsPresent();

        }

        public bool ValidateDetailsClientEnabled() { return detailsClient.IsPresent() && detailsClient.IsInteractable(); }
        public bool ValidateDetailsAliasEnabled() { return detailsAlias.IsPresent() && detailsAlias.IsInteractable(); }
        public bool ValidateDetailsEffectiveDateEnabled() { return detailsEffectiveDate.IsPresent() && detailsEffectiveDate.IsInteractable(); }
        public bool ValidateDetailsSlxIDEnabled() { return detailsSlxID.IsPresent() && detailsSlxID.IsInteractable(); }
        public bool ValidateDetailsIDEnabled() { return detailsID.IsPresent() && detailsID.IsInteractable(); }
        public bool ValidateDetailsClientIDEnabled() { return detailsClientID.IsPresent() && detailsClientID.IsInteractable(); }
        public bool ValidateDetailsCreatedEnabled() { return detailsCreated.IsPresent() && detailsCreated.IsInteractable(); }
        public bool ValidateDetailsModifiedEnabled() { return detailsModified.IsPresent() && detailsModified.IsInteractable(); }
        public bool ValidateDetailsUserNameEnabled() { return detailsUserName.IsPresent() && detailsUserName.IsInteractable(); }
        public bool ValidateAreYouSureYouWantToDeleteThisEnabled() { return areYouSureYouWantToDeleteThis.IsPresent() && areYouSureYouWantToDeleteThis.IsInteractable(); }
        public bool ValidateClientAliasDeletedEnabled() { return clientAliasDeleted.IsPresent() && clientAliasDeleted.IsInteractable(); }
        public bool ValidateClientsEditButtonEnabled() { return clientsEditButton.IsPresent() && clientsEditButton.IsInteractable(); }
        public bool ValidateClientsBackToListButtonEnabled() { return clientsBackToListButton.IsPresent() && clientsBackToListButton.IsInteractable(); }
        public bool ValidateClientsEditButtonLink() { return getClientsEditButtonLink().Contains(ExpectedClientsEditButtonLink); }
        public bool ValidateClientsBackToListButtonLink() { return getClientsBackToListButtonLink().Contains(ExpectedClientsBackToListButtonLink); }
        public bool ValidateClientsEditClientsBackToListButtonEnabled() { return clientsEditClientsBackToListButton.IsPresent() && clientsEditClientsBackToListButton.IsInteractable(); }
        public bool ValidateClientsEditClientsSaveButtonEnabled() { return clientsEditClientsSaveButton.IsPresent() && clientsEditClientsSaveButton.IsInteractable(); }
        public bool ValidateClientsEditClientsBackToListButtonLink() { return getClientsEditClientsBackToListButtonLink().Contains(ExpectedClientsEditClientBackToListButtonLink); }
        public bool ValidateClientsClientUpdatedSignEnabled() { return clientsClientUpdatedSign.IsPresent() && clientsClientUpdatedSign.IsInteractable(); }







        //GET

        public string getURL() { return pageURL.getURL(); }
        public string getExpectedPageURL() { return ExpectedPageURL; }
        public string getExpectedPageURL_Details() { return ExpectedPageURL_Details; }
        public string getExpectedPageURL_Edit() { return ExpectedPageURL_Edit; }
        public string getExpectedPageURL_Delete() { return ExpectedPageURL_Delete; }
        public string getExpectedPageURL_Clients() { return ExpectedPageURL_Clients; }
        public string getExpectedPageURL_ClientsView() { return ExpectedPageURL_ClientsView; }
        public string getExpectedPageURL_ClientsEditClients() { return ExpectedPageURL_ClientsView; }
        public string getPageSource()
        {
            return driver.PageSource.ToString();
        }
        public string getPageTitle() { return pageTitle.GetText().ToString(); }
        public string getfooter() { return footer.GetText().ToString(); }
        public List<string> getWebTableHeaderList()
        {
            int colNums = table.getWebTableTotalColumnNumbers();
            List<string> TableHeaderList = new List<string>();
            for (int i = 2; i <= colNums; i++)
            {
                TableHeaderList.Add(driver.FindElement(By.XPath("//tbody/tr/th[" + i + "]")).Text);
            }
            return TableHeaderList;
        }
        public int getWebTableSpecificColumnNumber(string columnName)
        {
            List<string> TableHeaderList = getWebTableHeaderList();
            return TableHeaderList.IndexOf(columnName) + 2;
        }
        public List<string> getWebTableColumnListForOnePage(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            List<String> TableColumnsList = new List<String>(); ;
            for (int i = 2; i <= table.getWebTableTotalRowNumbersOnPage(); i++)
            {
                TableColumnsList.Add(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
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
            for (int i = 2; i <= table.getWebTableTotalRowNumbersOnPage(); i++)
            {
                TableColumnsList.Add(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
            return TableColumnsList;
        }
        public List<string> getWebTableColumnListAfterFiltered(string columnName, string filterItem, string filterBy = "Client")
        {
            filterBox.Get().Clear();
            filterBox.Get().SendKeys(filterItem);
            filterByBox.selectElement("Value", filterBy);
            string totalRowNumberString = totalRowNumber.Get().GetAttribute("value");
            string rowPerPage = totalRowNumberString + "0";
            rowPerPageBox.Get().Clear();
            rowPerPageBox.Get().SendKeys(rowPerPage);
            goToPage.Click();

            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            List<String> filterdTableColumnsList = new List<String>();
            for (int i = 2; i <= table.getWebTableTotalRowNumbersOnPage(); i++)
            {
                filterdTableColumnsList.Add(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
            return filterdTableColumnsList;
        }
        public WebElementProxy getEditOption() { return editOption; }
        public string getAtribute(WebElementProxy element, string atribute)
        {
            return element.GetAtribute(atribute);  // <a href="/PimsSupport/ClientAliases/Details/1479">Details</a>
        }
        public string getDetailsUserName() { return detailsUserName.GetText().ToString(); }
        public string getClientsEditButtonLink() { return clientsEditButton.GetAtribute("href").ToString(); }
        public string getClientsBackToListButtonLink() { return clientsBackToListButton.GetAtribute("href").ToString(); }
        public string getClientsEditClientsBackToListButtonLink() { return clientsEditClientsBackToListButton.GetAtribute("href").ToString(); }





        //  NAVIGATE


        public void navigate()
        {
            driver.Navigate().Forward();
        }
        public void refrash()
        {
            driver.Navigate().Refresh();
        }
        public void navigateToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }


        //PRINT
        public void printWebTableColumnListForOnePage(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            //List<String> TableColumnsList = new List<String>(); 
            for (int i = 2; i <= table.getWebTableTotalRowNumbersOnPage(); i++)
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
            for (int i = 2; i <= table.getWebTableTotalRowNumbersOnPage(); i++)
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
            for (int i = 2; i <= table.getWebTableTotalRowNumbersOnPage(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
            // return TableColumnsList;
        }
        public void PrintWebTableColumnList(int columnNumber)
        {
            List<String> TableColumnsList = new List<String>(); ;
            for (int i = 2; i <= table.getWebTableTotalRowNumbersOnPage(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
        }
        public void PrintWebTableColumnList(string columnName)
        {
            int columnNumber = getWebTableSpecificColumnNumber(columnName);
            List<String> TableColumnsList = new List<String>(); ;
            for (int i = 2; i <= table.getWebTableTotalRowNumbersOnPage(); i++)
            {
                Console.WriteLine(driver.FindElement(By.XPath("//tbody/tr[" + i + "]/td[" + columnNumber + "]")).Text);
            }
        }




        //OTHER METHODS
        private void ActivateSubMenus(WebElementProxy webElement)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(webElement.Get()).Click().Build().Perform();
        }

        public void GoToPage(int PageNumber)
        {
            pageNumberBox.Get().Clear();
            pageNumberBox.Get().SendKeys(PageNumber.ToString());
            goToPage.Click();
        }
        public string getAliasFromList(string AliasName)
        {
            filterClientAliesListbyAlias(AliasName);
            return (driver.FindElement(By.CssSelector("body > div.container.body-content > table > tbody > tr:nth-child(2) > td:nth-child(2)")).Text.ToString());
        }

        public List<string> getListOfAliasBelongsToClient(string Client)
        {
            filterClientAliesListbyAlias(Client);
            List<string> AliasListOfClient = getWebTableColumnListAfterFiltered("Alias", Client);
            return AliasListOfClient;
        }

        public void filterClientAliesListbyAlias(string Alias)
        {
            filterBox.Get().Clear();
            filterBox.Get().SendKeys(Alias);
            //Thread.Sleep(1000);
            filterByBox.Get().Click();
            //Thread.Sleep(1000);
            filterByBox.selectElement("Value", "Alias");
            Thread.Sleep(2000);
            goToPage.Click();

        }

        public void filterClientAliesListbyClient(string Client)
        {
            filterBox.Get().Clear();
            filterBox.Get().SendKeys(Client);
            Thread.Sleep(3000);
            filterByBox.Get().Click();
            Thread.Sleep(3000);

            filterByBox.selectElement("Value", "Client");

            //SelectElement select = new SelectElement(driver.FindElement(By.CssSelector("#item_FilterBy")));
            //Thread.Sleep(3000);
            //select.SelectByValue("Client");
            Thread.Sleep(3000);
            goToPage.Click();
            Thread.Sleep(3000);
        }


        public void edditClientAlias(string Alias, string EffectiveDate, string SLX_ID)
        {
            aliasBox.Get().Clear();
            aliasBox.Get().SendKeys(Alias);
            Thread.Sleep(1000);
            effectiveDateBox.Get().Clear();
            effectiveDateBox.Get().SendKeys(EffectiveDate);
            Thread.Sleep(1000);
            effectiveDateBox.Get().SendKeys(Keys.Escape);
            Thread.Sleep(1000);
            slxidBox.Get().Clear();
            slxidBox.Get().SendKeys(SLX_ID);
            Thread.Sleep(1000);
            saveButton.Get().Click();
            Thread.Sleep(1000);
        }

        public void edditClientAlias(string Client, string Alias, string EffectiveDate, string SLX_ID)
        {
            clientBox.Get().Click();
            clientBox.selectElement("Text", Client);
            //Thread.Sleep(1000);
            aliasBox.Get().Clear();
            aliasBox.Get().SendKeys(Alias);
            //Thread.Sleep(1000);
            effectiveDateBox.Get().Clear();
            effectiveDateBox.Get().SendKeys(EffectiveDate);
            //Thread.Sleep(1000);
            effectiveDateBox.Get().SendKeys(Keys.Escape);
            //Thread.Sleep(1000);
            slxidBox.Get().Clear();
            slxidBox.Get().SendKeys(SLX_ID);
            //Thread.Sleep(1000);
            saveButton.Get().Click();
            Thread.Sleep(2000);
        }



        public void FillEditClientForm()
        {
            clientsEditClientsFDICBox.Get().Clear();                                                        //Thread.Sleep(4000);
            clientsEditClientsFDICBox.Get().SendKeys(Utilities.getRandomNumber(1000, 100000).ToString());   //Thread.Sleep(4000);
            clientsEditClientsNCUABox.Get().Click();                                                        //Thread.Sleep(4000);
            clientsEditClientsNCUABox.Get().SendKeys(Utilities.getRandomNumber(1000, 100000).ToString());   //Thread.Sleep(4000);
            ClickClientsEditClientsSaveButton();                                                            //Thread.Sleep(4000);
        }

    }
}



