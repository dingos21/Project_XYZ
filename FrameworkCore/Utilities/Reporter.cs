using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Configuration;

namespace FrameworkCore.Utilities
{
    internal class Reporter
    {
        private static Reporter Instance;
        private ExtentReports ExtentWrapper;
        private ExtentHtmlReporter Html;
        private ExtentTest TestInExecution;
        internal int passedTests, failedTests;
        internal static Reporter GetInstance()
        {
            if (Instance == null)
                Instance = new Reporter();

            return Instance;
        }
        /// <summary>
        /// Method automatically used on the start of the test suite to initialize the report
        /// </summary>
        /// <param name="reportName"></param>
        public void InitializeReport(string reportName, string browser)
        {
            if (ExtentWrapper == null)
            {
                ExtentWrapper = new ExtentReports();
                bool reportIsKlov = false;
                try
                {
                    reportIsKlov = ConfigurationManager.AppSettings["REPORT_IS_KLOV"].Equals("1");
                    if (reportIsKlov)
                    {
                        var klovReporter = new ExtentKlovReporter();

                        // specify mongoDb connection
                        klovReporter.InitMongoDbConnection("localhost", 27017);

                        // specify project ! you must specify a project, other a "Default project will be used"
                        klovReporter.ProjectName = reportName;

                        // you must specify a reportName otherwise a default timestamp will be used
                        klovReporter.ReportName =
                            ConfigurationManager.AppSettings["REPORT_DOCUMENT_TITLE"] + " - " +
                            ConfigurationManager.AppSettings["REPORT_NAME"];

                        // URL of the KLOV server
                        klovReporter.InitKlovServerConnection("http://localhost");

                        ExtentWrapper.AttachReporter(klovReporter);
                    }
                    else
                    {
                        string reportPath = ConfigurationManager.AppSettings["REPORT_FILE_PATH"];
                        string user = Environment.UserName;
                        reportPath = reportPath + "\\" + user + "\\" + DateTime.Now.ToString("ddMMyyyyTHHmmss");
                        System.IO.Directory.CreateDirectory(reportPath);

                        string reportFullPath = String.Format(reportPath + @"//{0}.html", reportName + DateTime.Now.ToString("ddMMyyyyTHHmmss"));

                        Html = new ExtentHtmlReporter(reportFullPath);
                        Html.Config.DocumentTitle = ConfigurationManager.AppSettings["REPORT_DOCUMENT_TITLE"];
                        Html.Config.ReportName = ConfigurationManager.AppSettings["REPORT_NAME"];
                        // Html.Configuration().ChartLocation = ChartLocation.Top;
                        string browserENV;
                        switch (browser)
                        {
                            case "ie":
                                browserENV = "Internet Explorer";
                                break;
                            case "firefox":
                                browserENV = "Mozilla FireFox";
                                break;
                            default:
                                browserENV = "Chrome";
                                break;
                        }
                        //get environment 
                        string testingEnvironment = Utilities.GetEnvironmentUrl();
                        switch (testingEnvironment)
                        {
                            case "http://pims-test.alliedsolutions.net/PimsSupport/Account/Login":
                                testingEnvironment = "QA";
                                break;
                            case "http://pims-staging.alliedsolutions.net/PimsSupport/Account/Login":
                                testingEnvironment = "STAGING";
                                break;
                            case "http://pims-dev.alliedsolutions.net/PimsSupport/Account/Login":
                                testingEnvironment = "DEV";
                                break;
                            default:
                                browserENV = "PRODUCTION";
                                break;
                        }
                        var test1 = Environment.GetEnvironmentVariables();
                        var test = Environment.GetEnvironmentVariable("USERNAME");
                        //ExtentWrapper.AddSystemInfo("NUnit Version", env.Attribute("nunit-version").Value);
                        ExtentWrapper.AddSystemInfo("Environment", testingEnvironment);
                        ExtentWrapper.AddSystemInfo("OS Version", Environment.GetEnvironmentVariable("OS"));
                        //ExtentWrapper.AddSystemInfo("Platform", env.Attribute("platform").Value);
                        //ExtentWrapper.AddSystemInfo("CLR Version", env.Attribute("clr-version").Value);
                        ExtentWrapper.AddSystemInfo("Browser", browserENV);

                        ExtentWrapper.AddSystemInfo("Machine Name", Environment.GetEnvironmentVariable("COMPUTERNAME"));
                        ExtentWrapper.AddSystemInfo("User", Environment.GetEnvironmentVariable("USERNAME"));
                        // ExtentWrapper.AddSystemInfo("User Domain",  Environment.GetEnvironmentVariable("USERDOMAIN"));
                        ExtentWrapper.AttachReporter(Html);
                    }
                }
                catch (ConfigurationErrorsException)
                {

                }
            }
        }

        internal void AddTest(string category, string testName, string description)
        {
            try
            {
                ExtentTest testCase = this.ExtentWrapper.CreateTest(testName, description);
                testCase.AssignCategory(category);

                this.TestInExecution = testCase;
            }
            catch (InvalidOperationException)
            {

            }
        }

        internal void PassTest(string details)
        {
            try
            {
                this.TestInExecution.Pass(details);
            }
            catch (InvalidOperationException)
            {

            }
        }

        internal void FailTest(string details)
        {
            try
            {
                this.TestInExecution.Fail(details);
            }
            catch (InvalidOperationException)
            {

            }
        }

        internal void GenerateReport()
        {
            try
            {
                this.ExtentWrapper.Flush();

            }
            catch (InvalidOperationException)
            {

            }
        }
    }
}
