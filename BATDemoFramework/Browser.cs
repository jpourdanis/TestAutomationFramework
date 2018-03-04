using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BATDemoFramework
{
    public static class Browser
    {
        private static string baseUrl = "http://localhost:12142/";

        //Here needs to add as parameter the path of driver
        public static IWebDriver webDriver =new ChromeDriver("C:\\chromedriver_win32");

        public static void Initialize()
        {
            Goto("");
        }

        public static string Title
        {
            get { return webDriver.Title; }
        }

        public static ISearchContext Driver
        {
            get { return webDriver; }
        }

        public static void Goto(string url)
        {
            webDriver.Url = baseUrl + url;
        }

        public static void Close()
        {
             webDriver.Close();
             webDriver.Dispose();
        }
    }
}
