using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace FrameworkCore.Utilities
{
    public class Utilities
    {
//============================================
// Get EnvironmentUrl from config (xml) file 
//============================================
        public static string GetEnvironmentUrl()
        {
            string webAppUrl = TestContext.Parameters.Get("webAppUrl");
            if (string.IsNullOrEmpty(webAppUrl))
            {
                webAppUrl = ConfigurationManager.AppSettings.Get("webAppUrl").ToString();
            }
            return webAppUrl;
        }
//============================================
// Get RemoteFlag value from config (xml) file 
//============================================
        public static string GetRemoteFlag()
        {
            string flag = TestContext.Parameters.Get("IsRemote");
            if (string.IsNullOrEmpty(flag))
            {
                flag = ConfigurationManager.AppSettings.Get("IsRemote").ToString();
            }
            return flag;
        }


//===========================================
// Get user name from config (xml) file 
//===========================================
        public static string GetUserName(string go=null)
        {
            string userName = TestContext.Parameters.Get("userName"+go);
            if (string.IsNullOrEmpty(userName))
            {
                userName = ConfigurationManager.AppSettings.Get("userName" + go).ToString();
            }
            return userName;
        }
//===========================================
// Get password from config (xml) file 
//===========================================
        public static string GetPassword(string go=null)
        {
            string password = TestContext.Parameters.Get("password"+go);
            if (string.IsNullOrEmpty(password))
            {
                password = ConfigurationManager.AppSettings.Get("password" + go).ToString();
            }
            return password;
        }

//=============================================
// Get connectionString from config (xml) file 
//=============================================
        public static string GetConnectionString()
        {
            string value = TestContext.Parameters.Get("connectionString");
            if (string.IsNullOrEmpty(value))
            {
                value = ConfigurationManager.AppSettings.Get("connectionString").ToString();
            }
            return value;
        }

        //===========================================
        // Get user name from config (xml) file 
        //===========================================
        public static string GetValueFromConfigXMLfile(string key = null)
        {
            string value = TestContext.Parameters.Get(key);
            if (string.IsNullOrEmpty(value))
            {
                value = ConfigurationManager.AppSettings.Get(key).ToString();
            }
            return value;
        }


//============================================
// Generates a random int number within a range.
//============================================
        public static int getRandomNumber(int min, int max) { return RandomNumber(min, max); }
        private static readonly Random _random1 = new Random();
        public static int RandomNumber(int min, int max)
        {
            return _random1.Next(min, max);
        }
        //============================================
        // Generates a random double number within a range.
        //============================================
        public static double getRandomDouble(int min, int max) { return RandomNumber(min, max); }
        private static readonly Random _random2 = new Random();
        public static double RandomDouble(int min, int max)
        {
            min = min * 100;
            max = max * 100;
            int number = _random2.Next(min, max);
            return number / 100;
        }
        //===========================================
        // Generates a random past date.
        //===========================================
        public static string getRandomPastDate(int years)
        {
            Random gen = new Random();
            int range = years * 365;          
            DateTime randomDate = DateTime.Today.AddDays(-gen.Next(range));
            var dateTime = randomDate.ToString().Split(' ');
            return dateTime[0];
        }
//===========================================
// Generates a random future date.
//===========================================
        public static string getRandomFuturetDate(int years)
        {
            Random gen = new Random();
            int range = years * 365; 
            DateTime randomDate = DateTime.Today.AddDays(gen.Next(range));
            var dateTime = randomDate.ToString().Split(' ');
            return dateTime[0];
        }


//===========================================
// Order validation of List<string>
//===========================================

        public static bool AscendingOrderValidationOfStringList(List<string> a )
        {

           var isOrderedAscending = a.SequenceEqual(a.OrderBy(x => x));
           return isOrderedAscending;
        }
        public static bool DescendingOrderValidationOfStringList(List<string> a)
        {
            var isOrderedDescending = a.SequenceEqual(a.OrderByDescending(x => x));
            return isOrderedDescending;
        }

        public static bool OrderValidationOfStringList(List<string> a, string AscendingOrDescending)
        {
            if (AscendingOrDescending.ToLower().Contains("descending"))
            {
                var isOrderedDescending = a.SequenceEqual(a.OrderByDescending(x => x));
                return isOrderedDescending;
            }
            else
            {
                var isOrderedAscending = a.SequenceEqual(a.OrderBy(x => x));
                return isOrderedAscending;
            }

        }






    }
}

