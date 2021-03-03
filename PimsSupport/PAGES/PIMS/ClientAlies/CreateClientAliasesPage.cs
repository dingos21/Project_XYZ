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
    public class CreateClientAliasesPage : BaseComponent
    {
        public ClientAliasesPage clientAliasesPage;
        public string ExpectedPageURL;
        private WebElementProxy pageURL;
        private WebElementProxy footerCreateClientAliases;
        private WebElementProxy pageTitleCreateClientAliases;

        private WebElementProxy aliasAsterix;
        private WebElementProxy client;
        private WebElementProxy alias;
        private WebElementProxy effectiveDate;
        private WebElementProxy clientBox;
        private WebElementProxy aliasBox;
        private WebElementProxy effectiveDateBox;
        private WebElementProxy slxidBox;
        private WebElementProxy createButton;
        private WebElementProxy totalRowNumber;
        private WebElementProxy clientIDisRequired;
        private WebElementProxy aliasIsRequired;
        private WebElementProxy effectiveDateIsRequired;
        private WebElementProxy backTolist;

        public CreateClientAliasesPage(IWebDriver driver, ClientAliasesPage clientAliasesPage) : base(driver)
        {
            this.clientAliasesPage = clientAliasesPage;
            InitializeElements();
        }
        private void InitializeElements()
        {
            ExpectedPageURL = "PimsSupport/ClientAliases/Create";
            pageURL = new WebElementProxy(driver);
            footerCreateClientAliases = new WebElementProxy(driver, By.CssSelector("p"));
            pageTitleCreateClientAliases = new WebElementProxy(driver, By.CssSelector("h4"));   //By.LinkText("Create Client Aliases"));

            aliasAsterix            = new WebElementProxy(driver, By.XPath("//span[contains(text(),'*')]"));
            client                  = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > form > div > div > div:nth-child(1) > label"));
            alias                   = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > form > div > div > div:nth-child(2) > label"));
            effectiveDate           = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > form > div > div > div:nth-child(3) > label"));
            clientBox               = new WebElementProxy(driver, By.XPath("/html[1]/body[1]/div[2]/form[1]/input[1]"));        // #Client_ID_Number
            aliasBox                = new WebElementProxy(driver, By.CssSelector("#Client_Alias"));
            effectiveDateBox        = new WebElementProxy(driver, By.CssSelector("#Effective_Date"));
            slxidBox                = new WebElementProxy(driver, By.CssSelector("input#Alias_SLXID"));
            createButton            = new WebElementProxy(driver, By.CssSelector("input[value='Create']"));
            totalRowNumber          = new WebElementProxy(driver, By.CssSelector("#item_NumberOfPages"));
            clientIDisRequired      = new WebElementProxy(driver, By.XPath("//span[contains(text(),'Client ID # is required')]"));            // By.CssSelector(".field-validation-error.text-danger > span")); 
            aliasIsRequired         = new WebElementProxy(driver, By.XPath("//span[contains(text(),'Alias is required')]"));      // By.CssSelector(".field-validation-error.text-danger > span")); 
            effectiveDateIsRequired = new WebElementProxy(driver, By.XPath("//span[contains(text(),'Effective Date is required')]"));   // By.CssSelector(".field-validation-error.text-danger > span")); 
            backTolist              = new WebElementProxy(driver, By.CssSelector("body > div.container.body-content > div > a"));   // By.CssSelector(".field-validation-error.text-danger > span")); 
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


        public void CreateNewClientAlies(string AliasName)
        {
            SelectElement select = new SelectElement(driver.FindElement(By.CssSelector("#Client_ID_Number")));
            select.SelectByValue("5151");
            aliasBox.Get().SendKeys(AliasName);
            effectiveDateBox.Get().SendKeys("03/01/2021");
            effectiveDateBox.Get().SendKeys(Keys.Escape);
            slxidBox.Get().SendKeys(RandomNumber(1000, 1999).ToString());
            createButton.Click();
        }
        public void CreateNewClientAlies(string Client, string Alias, string EffectiveDate)
        {
            SelectElement select = new SelectElement(driver.FindElement(By.CssSelector("#Client_ID_Number")));
            select.SelectByValue(Client);
            aliasBox.Get().SendKeys(Alias);
            effectiveDateBox.Get().SendKeys(EffectiveDate);
            effectiveDateBox.Get().SendKeys(Keys.Escape);
            slxidBox.Get().SendKeys(RandomNumber(1000, 1999).ToString());
            createButton.Click();
        }


        public int getRandomNumber(int min, int max) { return RandomNumber(min, max); }


        //==============================================================================================================================================================================
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }


        public void ChangeWindow()
        {
            //string parent = driver.getWindowHandle();
            // Window myCurrentWindow = Window.GetWindow(this);
            //  List<IntPtr> windowHandles = new List<IntPtr>();

        }


        //public bool ValidateNewClientAlliesIsCreated(string AliasName) { return AliasName.Equals(FilterNewClientAlies(AliasName)); }



        // public int WebTableRowNumber() { return table.getWebTableTotalRowNumbers(); }
        //public int WebTableColumnNumber() { return table.getWebTableTotalColumnNumbers(); }
        public bool ValidatePageURL() { return pageURL.getURL().Contains(ExpectedPageURL); }
        public bool ValidatePageTitleEnabled() { return pageTitleCreateClientAliases.IsPresent() && pageTitleCreateClientAliases.IsInteractable(); }
        public string getPageTitle_CreateClientAliases() { return pageTitleCreateClientAliases.GetText().ToString(); }
        public bool ValidateFooterEnabled() { return footerCreateClientAliases.IsPresent() && footerCreateClientAliases.IsInteractable(); }
        public bool ValidateClientIDisRequiredEnabled() { return clientIDisRequired.IsPresent() && clientIDisRequired.IsInteractable(); }
        public bool ValidateAliasIsRequiredEnabled() { return aliasIsRequired.IsPresent() && aliasIsRequired.IsInteractable(); }
        public bool ValidateEffectiveDateIsRequiredEnabled() { return effectiveDateIsRequired.IsPresent() && effectiveDateIsRequired.IsInteractable(); }
        public void ClickcBackTolist() { backTolist.Get().Click(); }

        //public bool ValidateEnabled() { return .IsPresent() && .IsInteractable(); }


        public string getfooterCreateClientAliases() { return footerCreateClientAliases.GetText().ToString(); }

        public string getURL() { return pageURL.getURL(); }





        //public bool ValidateEnabled() { return .IsPresent() && .IsInteractable(); }



        private void ActivateSubMenus(WebElementProxy webElement)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(webElement.Get()).Click().Build().Perform();
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







    }
}




