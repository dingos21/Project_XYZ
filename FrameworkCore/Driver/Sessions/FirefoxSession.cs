using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace FrameworkCore.Driver
{
    public class FirefoxSession : IDriverSession
    {
        IWebDriver IDriverSession.GetDriver()
        {
            return new FirefoxDriver(GetFirefoxOptions());
        }

        private FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            //Debugging statement for testing headless browsing
            //options.AddArgument("--headless");
            return options;
        }
    }
}
