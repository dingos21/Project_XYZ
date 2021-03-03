
namespace FrameworkCore.Driver
{
    /// <summary>
    /// Returns a driver session for the browser configured in the run parameters
    /// </summary>
    public static class DriverSessions
    {
        public static IDriverSession GetSessionType(string session)
        {

            switch (session)
            {
                case "firefox":
                    return new FirefoxSession();
                case "ie":
                    return new IESession();
                case "chrome":
                    return new ChromeSession();
                default:
                    return new IESession();
            }
        }
    }
}

