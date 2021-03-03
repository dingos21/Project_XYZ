using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace FrameworkCore.Driver
{
    public class IESession : IDriverSession
    {
        IWebDriver IDriverSession.GetDriver()
        {
            return new InternetExplorerDriver(GetInternetExplorerOptions());
        }

        private InternetExplorerOptions GetInternetExplorerOptions()
        {
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();
            //fixes slow typing in ie webdriver
            ieOptions.RequireWindowFocus = true;
            //ieOptions.EnsureCleanSession = true;
            return ieOptions;

        }
    }
}
