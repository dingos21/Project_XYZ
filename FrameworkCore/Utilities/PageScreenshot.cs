using System;
using OpenQA.Selenium;
using System.Configuration;
using NUnit.Framework;
using System.IO;

namespace FrameworkCore.Utilities
{
    public class PageScreenshot
    {
        //TODO: figure out AddResultFile in net core
        //https://github.com/Microsoft/testfx/issues/394

        /// <summary>
        /// Takes a screenshot of the current web page and attaches it to the test context.
        /// </summary>
        /// <param name="driver">Selenium web driver object</param>
        /// <param name="descriptor">String to be included as part of the file name, usually either the
        /// current test name or a step comment</param>
        /// 


        public static void Take(IWebDriver driver, string descriptor)
        {
            //string filePath = ConfigurationManager.AppSettings.Get("filePath");
            string filePath = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
            try
            {

                string dateTime = DateTime.Now.ToString("yyyyMMddhhmmss");
                string date = DateTime.Now.ToString("yyyyMMdd");
                string path = filePath + "\\Screenshots\\" + date + "\\";
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string fullPath = path + descriptor + dateTime + ".png";

                bool exists = System.IO.Directory.Exists(path);

                if (!exists)
                    System.IO.Directory.CreateDirectory(path);

                screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
                Console.WriteLine("StackTrace: {0}", Environment.StackTrace);
            }
        }
    }
}

