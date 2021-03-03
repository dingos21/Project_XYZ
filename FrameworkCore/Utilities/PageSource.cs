using System;
using OpenQA.Selenium;
using System.IO;
using NUnit.Framework;
using System.Configuration;

namespace FrameworkCore.Utilities
{
    public class PageSource
    {
        /// <summary>
        /// Saves the current page source as an html file and attaches it to the test context.
        /// </summary>
        /// <param name="driver">Selenium web driver object</param>
        /// <param name="descriptor">String to be included as part of the file name, usually either the
        /// current test name or a step comment</param>

        public static void Save(IWebDriver driver, string descriptor)
        {
            //string filePath = ConfigurationManager.AppSettings.Get("filePath");
            string filePath = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
            try
            {
                string dateTime = DateTime.Now.ToString("yyyyMMddhhmmss");
                string date = DateTime.Now.ToString("yyyyMMdd");
                string path = filePath + "PageSource\\" + date + "\\";
                string fullPath = path + descriptor + dateTime + ".html";

                bool exists = Directory.Exists(path);

                if (!exists)
                    Directory.CreateDirectory(path);

                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    sw.Write(driver.PageSource);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
                Console.WriteLine("StackTrace: {0}", Environment.StackTrace);
            }
        }
    }
}

