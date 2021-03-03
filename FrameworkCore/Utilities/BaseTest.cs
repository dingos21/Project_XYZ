using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using FrameworkCore.Driver;

namespace FrameworkCore.Utilities
{
    /// <summary>
    /// Base test class for all test classes to inherit.  Handles driver creation and teardown.
    /// </summary>
    public abstract class BaseTest
    {
        public TestContext TestContext;
        protected IDriverSession driverSession;
        protected IWebDriver driver;
        protected Dictionary<string, string> inputParameters;
        private readonly string browser;


        public BaseTest(string browserType)
        {
            browser = browserType;
        }

        private void ChooseDriverInstance(string browser)
        {

            if (Convert.ToBoolean(Utilities.GetRemoteFlag()) == false)
            {

                driverSession = DriverSessions.GetSessionType(browser);
                driver = driverSession.GetDriver();
            }
            else
            {
                if (browser == "chrome")
                {
                    var options = new ChromeOptions();
                    options.PlatformName = Platform.CurrentPlatform.ToString();
                    options.AcceptInsecureCertificates = true;
                    //Marks the remote run of Chrome browsers to be headless
                    options.AddArgument("--headless");
                    options.AddArgument("--no-sandbox");
                    //Sets resolution size for browser when headless
                    options.AddArgument("window-size=1280,1024");
                    driver = new RemoteWebDriver(new Uri("http://10.8.7.40:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));
                }
                else if (browser == "firefox")
                {
                    var options = new FirefoxOptions();
                    options.PlatformName = Platform.CurrentPlatform.ToString();
                    options.AcceptInsecureCertificates = true;
                    options.AddArgument("--headless");
                    driver = new RemoteWebDriver(new Uri("http://10.8.7.40:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));
                }
                else if (browser == "ie")
                {
                    var options = new InternetExplorerOptions();
                    options.PlatformName = Platform.CurrentPlatform.ToString();
                    options.AcceptInsecureCertificates = true;
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    driver = new RemoteWebDriver(new Uri("http://10.8.7.40:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(600));
                }
            }
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Reporter.GetInstance().InitializeReport(ToString().Split('.')[0], browser);
        }

        /// <summary>
        /// Called the start of tests.  Merges run parameters and creates the web driver.
        /// </summary>
        [SetUp]
        public void SetupTest()
        {
            string testCategory = TestContext.CurrentContext.Test.ClassName;
            string testName = TestContext.CurrentContext.Test.Name;
            string testDescription = (string)TestContext.CurrentContext.Test.Properties.Get("Description");
            Reporter.GetInstance().AddTest(testCategory, testName, testDescription);

            ChooseDriverInstance(browser);
            driver.Manage().Window.Maximize();

            //-------------------------------------------------------------


            //var s = (IList)TestContext.CurrentContext.Test.Properties["UserRole"];
            //UserRole userRole;

            //if (s.Count >= 1)
            //{
            //    userRole = (UserRole)s[0];
            //}
            //else
            //{
            //    // If no user role is spcified log in as the system admin
            //    userRole = UserRole.AutomationSystemAdmin;
            //}

            //user = settings.SystemUnderTestSettings.Users.Find(delegate (User u) { return u.userRole == userRole.ToString(); });

            //-------------------------------------------------------------



        }



        /// <summary>
        /// Handles test cleanup including optional reporting of screenshots and page source on failure.
        /// </summary>
        [TearDown]
        public void EndTest()
        {

            // prepare results paragraph for the report
            string testResult = String.Format("<p>{0}</p>", TestContext.CurrentContext.Result.Message);
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            string stackTrace = String.Format("<p>{0}</p>", TestContext.CurrentContext.Result.StackTrace);

            string fullTestResult =
                       testResult +
                       stackTrace;

            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    Reporter.GetInstance().FailTest(fullTestResult);
                    Reporter.GetInstance().failedTests++;
                    break;
                default:
                    Reporter.GetInstance().PassTest(fullTestResult);
                    Reporter.GetInstance().passedTests++;
                    break;
            }
            if (driver != null) { driver.Close(); driver.Quit(); driver.Dispose(); }
        }
        /// <summary>
        /// Already built in and ready to use NUNit annotation. Currently used to create the report file upon finishing of the tests
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Reporter.GetInstance().GenerateReport();
        }
    }
}
