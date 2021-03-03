using NUnit.Framework;
using User = FrameworkCore.DataFiles.User;
using FrameworkCore.Utilities;
using PimsSupport.PAGES;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace PimsSupport.TESTS
{
    [TestFixture("chrome")]
    //  [TestFixture("ie")]
    //  [TestFixture("firefox")]
    //  [Parallelizable]
    public class ClientAliasesTest : BaseTest
    {
        LoginPage loginPage;
        HeadbarMainMenuComponents headbarMainMenuComponents;
        LandingPage landingPage;
        ClientAliasesPage clientAliasesPage;
        CreateClientAliasesPage createClientAliasesPage;

        public ClientAliasesTest(string browser) : base(browser) { }

        [SetUp]
        public void SetUp()
        {
            loginPage = new LoginPage(driver);
            loginPage.Load();
            landingPage = new LandingPage(driver, loginPage);
            headbarMainMenuComponents = new HeadbarMainMenuComponents(driver);
            clientAliasesPage = new ClientAliasesPage(driver, landingPage);
            createClientAliasesPage = new CreateClientAliasesPage(driver, clientAliasesPage);
        }

        [Test, Description("ClientAliases_675")]
        [Category("SmokeTesting")]
        [Order(1)]
        public void ClientAliases_675A()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            headbarMainMenuComponents.ClickClientAliases();
            Console.WriteLine("----------------------  :" + clientAliasesPage.getURL());
            Console.WriteLine("----------------------  :" + clientAliasesPage.getPageTitle_ClientAliases());
            Assert.Multiple(() =>
            {
                Assert.True(clientAliasesPage.getURL().Contains(clientAliasesPage.ExpectedPageURL), "Page URL does not include " + clientAliasesPage.ExpectedPageURL);
                Assert.True(clientAliasesPage.ValidatePageURL(), "Page URL does not include " + clientAliasesPage.getURL());
                Assert.True(clientAliasesPage.ValidatePageTitleEnabled(), "Page title \"Client Aliases\" is not enabled");
                Assert.True(clientAliasesPage.ValidateFooterEnabled(), "Page footer \"© 2021 - Allied Solutions, LLC - Version 19.8 (2-10-2021)\" is not appeared");
                Assert.True(clientAliasesPage.ValidatecolumnEfectiveDateEnabled(), "Column name: \"Efective Date\" is not enabled");
                Assert.True(clientAliasesPage.ValidateColumnNameEfectiveDate(), "Column name: " + clientAliasesPage.columnNameEfectiveDate + " is not enabled");
                Assert.True(clientAliasesPage.ValidateColumnNameSLXID(), "Column name: " + clientAliasesPage.columnNameSLXID + " is not enabled");

            });
        }

        [Test, Description("ClientAliases_675")]
        [Category("SmokeTesting")]
        [Order(2)]
        public void ClientAliases_675B()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            headbarMainMenuComponents.ClickClientAliases();
            Console.WriteLine("----------------------  :" + clientAliasesPage.getURL());
            Console.WriteLine("----------------------  :" + clientAliasesPage.getPageTitle_ClientAliases());
            Assert.Multiple(() =>
            {
                Assert.True(clientAliasesPage.ValidateNoTimeSteps(4), "Column name \"Effective Date\" has null elements");
                Assert.True(clientAliasesPage.ValidateNullColumnElemetNotExist("Effective Date"), "Column name \"Effective Date\" has null elements");
                Assert.True(clientAliasesPage.ValidateParticularElementNotExistInColum("Effective Date", ""), "element \"\" is exist in column \"Effective Date\".");
                Assert.True(clientAliasesPage.ValidateRowPerPage(5), "Rows per page is not aranged by 4");

            });
        }

        [Test, Description("ClientAliases_675C")]
        [Category("SmokeTesting")]
        [Order(3)]
        public void ClientAliases_675C()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            headbarMainMenuComponents.ClickClientAliases();
            Console.WriteLine("----------------------  :" + clientAliasesPage.getURL());
            Console.WriteLine("----------------------  :" + clientAliasesPage.getPageTitle_ClientAliases());
            Assert.Multiple(() =>
            {
                
                Assert.True(clientAliasesPage.ValidateOrderByAlliesEnabled(), "Order List By Allies is not Enabled");
                Assert.True(clientAliasesPage.ValidateOrderByClientEnabled(), "Order List By Client is not Enabled");
                Assert.True(clientAliasesPage.ValidateFilterByAlliesEnabled(), "Filter List By Allies is not Enabled");
                Assert.True(clientAliasesPage.ValidateFilterByClientEnabled(), "Filter List By Client is not Enabled");
                Assert.True(clientAliasesPage.ValidateFilteredTableByClient("Client", "121 Financial CU"), "List is not filterd by client: \"02ICK Credit Corp (SC0054)\"");
            });
        }


        [Test, Description("ClientAliases_676A")]
        [Category("SmokeTesting")]
        [Order(4)]
        public void ClientAliases_676A()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            headbarMainMenuComponents.ClickClientAliases();
            clientAliasesPage.ClickcreateNew();
            Console.WriteLine("url      : " + createClientAliasesPage.getURL());
            Console.WriteLine("title    : " + createClientAliasesPage.getPageTitle_CreateClientAliases());
            Console.WriteLine("footer   : " + createClientAliasesPage.getfooterCreateClientAliases());
            Assert.Multiple(() =>
            {
                Assert.True(createClientAliasesPage.getURL().Contains(createClientAliasesPage.getURL()), "Page URL does not include " + createClientAliasesPage.ExpectedPageURL);
                Assert.True(createClientAliasesPage.ValidatePageURL(), "Page URL does not include " + clientAliasesPage.ExpectedPageURL);
                Assert.True(createClientAliasesPage.ValidatePageTitleEnabled(), "Page title \"Client Aliases\" is not enabled");
                Assert.True(createClientAliasesPage.ValidateFooterEnabled(), "Page footer \"© 2021 - Allied Solutions, LLC - Version 19.8 (2-10-2021)\" is not appeared");
            });

            //createClientAliasesPage.CreateNewClientAlies("Alies Name Test");
            //Assert.True(clientAliasesPage.ValidateNewClientAlliesIsCreated("001 AliasTest"), "new Client Aliase is not able to created.");

        }

        [Test, Description("ClientAliases_676B_Verify required fields have an asterisk * : Client, Alias, and Effective Date")]
        [Category("SmokeTesting")]
        [Order(5)]
        public void ClientAliases_676B()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            headbarMainMenuComponents.ClickClientAliases();
            clientAliasesPage.ClickcreateNew();
            Assert.Multiple(() =>
            {
                Assert.True(createClientAliasesPage.ValidateAliesHaveAnAsterisk(), "\"Alies\" Do Not Have An Asterisk");
                Assert.True(createClientAliasesPage.ValidateClientHaveAnAsterisk(), "\"Client\" Do Not Have An Asterisk");
                Assert.True(createClientAliasesPage.ValidateEffectiveDateHaveAnAsterisk(), "Effective Date Do Not Have An Asterisk");
                Assert.True(createClientAliasesPage.ValidateFooterEnabled(), "Page footer \"© 2021 - Allied Solutions, LLC - Version 19.8 (2-10-2021)\" is not appeared");
            });

            //createClientAliasesPage.CreateNewClientAlies("Alies Name Test");
            //Assert.True(clientAliasesPage.ValidateNewClientAlliesIsCreated("001 AliasTest"), "new Client Aliase is not able to created.");

        }
        
        
        [Test, Description("ClientAliases_676C1_ Verify not able to create New Client Alies without filling the required field: Client ID")]
        [Category("SmokeTesting")]
        [Order(6)]
        public void ClientAliases_676C1()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            headbarMainMenuComponents.ClickClientAliases();
            clientAliasesPage.ClickcreateNew();
            createClientAliasesPage.CreateNewClientAlies("","abcd","03/03/2020");
            Assert.True(createClientAliasesPage.ValidateClientIDisRequiredEnabled(), "\"Client ID # is required\" messages is not displayed.");
        }

        [Test, Description("ClientAliases_676C2_ Verify not able to create New Client Alies without filling the required field: Alies")]
        [Category("SmokeTesting")]
        [Order(7)]
        public void ClientAliases_676C2()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            headbarMainMenuComponents.ClickClientAliases();
            clientAliasesPage.ClickcreateNew();
            createClientAliasesPage.CreateNewClientAlies("5151", "", "03/03/2020");
            Assert.True(createClientAliasesPage.ValidateAliasIsRequiredEnabled(), "\"Alies is required\" messages is not displayed.");
        }

        [Test, Description("ClientAliases_676C3_ Verify not able to create New Client Alies without filling the required field: Effective Date")]
        [Category("SmokeTesting")]
        [Order(8)]
        public void ClientAliases_676C3()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            headbarMainMenuComponents.ClickClientAliases();
            clientAliasesPage.ClickcreateNew();
            createClientAliasesPage.CreateNewClientAlies("5151", "abcd", "");
            Assert.True(createClientAliasesPage.ValidateEffectiveDateIsRequiredEnabled(), "\"Effective Date is required\" messages is not displayed.");
        }

        [Test, Description("ClientAliases_676D1_ Verify able to create new Client Alies")]
        [Category("SmokeTesting")]
        [Order(9)]
        public void ClientAliases_676D1()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            headbarMainMenuComponents.ClickClientAliases();
            clientAliasesPage.ClickcreateNew();
            string test = Utilities.getRandomNumber(1001, 1999).ToString();
            createClientAliasesPage.CreateNewClientAlies("001 Alias Test"+ test);
            Assert.True(clientAliasesPage.ValidateNewClientAlliesIsCreated("001 Alias Test" + test), "new Client Aliase is not able to created.");
        }

        [Test, Description("ClientAliases_676D2_ Verify able to navigate back from the Create Client Alies to the Client Alies list")]
        [Category("SmokeTesting")]
        [Order(10)]
        public void ClientAliases_676D2()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            headbarMainMenuComponents.ClickClientAliases();
            clientAliasesPage.ClickcreateNew();
            Assert.True(createClientAliasesPage.ValidatePageTitleEnabled(), "Client Alies title is not enabled");
            createClientAliasesPage.ClickcBackTolist();
            Assert.True(clientAliasesPage.ValidatePageTitleEnabled(), "Client Alies title is not enabled");
        }



        //-----------------------------------------------------------


        // [Test, Description("testingtest")]
        public void ClientAliases_GetColumnList()
        {
            loginPage.Login(User.USER2);
            headbarMainMenuComponents.ClickPIMSMenu();
            headbarMainMenuComponents.ClickClientAliases();
            //clientAliasesPage.printWebTableColumnListForOnePage("Client");
            //clientAliasesPage.printWebTableColumnListAll("Client");


        }

       
        //-------------------------------------------------------



        [TearDown]
        public void LogoutCenterPoint()
        {
            landingPage.EvaluateScreenshotSourcePageSaving();
            headbarMainMenuComponents.GoToLogout();
        }
    }
}



