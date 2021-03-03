using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Utilities
{
    public class UITestSettings
    {
        public SystemUnderTestSettings SystemUnderTestSettings { get; set; }
        public TimeoutSettings TimeoutSettings { get; set; }
        public WebDriverSettings WebDriverSettings { get; set; }
        public TestResults TestResults { get; set; }
        public List<Dataset> Datasets { get; set; }
    }

    public class SystemUnderTestSettings
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string BaseUrl { get; set; }

        public string UsersDatabaseConnectionString { get; set; }
        public string AlliedDatabaseConnectionString { get; set; }
        public string LenderDatabaseConnectionString { get; set; }
        public string DatahubDatabaseConnectionString { get; set; }

        public List<User> Users { get; set; }

    }

    public class TimeoutSettings
    {
        public int WaitForAjaxTimeout { get; set; }
        public int SleepInterval { get; set; }
        public int ElementToBeVisibleTimeout { get; set; }
        public int ElementToExistTimeout { get; set; }
        public int ElementToNotExistTimeout { get; set; }
        public int ElementToBeClickableTimeout { get; set; }
        public int ElementNotToBeVisibleTimeout { get; set; }
        public int ElementToHaveContentTimeout { get; set; }
    }

    public class WebDriverSettings
    {
        public string BrowserType { get; set; }
        public bool RunHeadless { get; set; }
        public int HeadlessScreenWidth { get; set; } = 1920;
        public int HeadlessScreenHeight { get; set; } = 1080;
        public bool ReopenBrowserEveryTest { get; set; } = false;
        public bool CloseBrowserOnExit { get; set; } = false;
        public bool MaximizeBrowser { get; set; } = true;
        public bool RunRemote { get; set; } = false;
        public string SeleniumGridUrl { get; set; }
        public BrowserStackSettings BrowserStackSettings { get; set; }

    }

    public class BrowserStackSettings
    {
        public string UserName { get; set; }
        public string ApiKey { get; set; }
        public string Browser { get; set; }
        public string BrowserVersion { get; set; }
        public string Os { get; set; }
        public string OsVersion { get; set; }
        public string Resolution { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ConsoleLog { get; set; }
        public bool NetworkLog { get; set; }
        public bool Debug { get; set; }
        public bool UseBrowserStackLocal { get; set; }
    }


    public class User
    {
        public string userRole { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
    }

    public class TestResults
    {
        public string outputDirectory { get; set; }
        public string baselineImageDirectory { get; set; }
        public bool screenShotOnError { get; set; } = true;
        public bool baseLineScreenshots { get; set; } = false;
        public bool screenshotCompare { get; set; } = false;
    }


    public class Dataset
    {
        public string type { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
}

