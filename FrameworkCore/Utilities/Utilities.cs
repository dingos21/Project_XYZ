using NUnit.Framework;
using System;
using System.Configuration;

namespace FrameworkCore.Utilities
{
    public class Utilities
    {
        //NO LONGER NEED THIS METHOD SINCE WE ARE NOT SETTING IT IN RUNSETTING OR APP.CONFIG
        //WE GET BROWSER TYPE FROM THE TESTS PASSING IN THE VALUE
        //public string GetBrowserType()
        //{
        //    string browser = TestContext.Parameters.Get("browser");
        //    if (string.IsNullOrEmpty(browser))
        //    {
        //        browser = ConfigurationManager.AppSettings.Get("browser").ToString();
        //    }
        //    return browser;
        //}

        public static string GetEnvironmentUrl()
        {
            string webAppUrl = TestContext.Parameters.Get("webAppUrl");
            if (string.IsNullOrEmpty(webAppUrl))
            {
                webAppUrl = ConfigurationManager.AppSettings.Get("webAppUrl").ToString();
            }
            return webAppUrl;
        }

        public static string GetRemoteFlag()
        {
            string flag = TestContext.Parameters.Get("IsRemote");
            if (string.IsNullOrEmpty(flag))
            {
                flag = ConfigurationManager.AppSettings.Get("IsRemote").ToString();
            }
            return flag;
        }
        // Generates a random number within a range.      
        public static int getRandomNumber(int min, int max) { return RandomNumber(min, max); }
        private static readonly Random _random = new Random();
        public static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}

