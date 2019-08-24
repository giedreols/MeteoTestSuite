using System;
using System.Configuration;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace MeteoTestSuite.Utilities
{
    public static class MyDriver
    {
        private static readonly string AppBaseUrl = ConfigurationManager.AppSettings["AppBaseUrl"];

        private static readonly TimeSpan DefaultWaitMs =
            TimeSpan.FromMilliseconds(int.Parse(ConfigurationManager.AppSettings["DefaultWaitMs"]));

        private static readonly Size MinSize = new Size(int.Parse(ConfigurationManager.AppSettings["MinWindowWidth"]),
            int.Parse(ConfigurationManager.AppSettings["MinWindowHeight"]));

        private static readonly string TestBrowser = ConfigurationManager.AppSettings["SeleniumBrowser"];

        public static void OpenAppBaseUrl(this IWebDriver driver)
        {
            driver.Url = AppBaseUrl;
        }

        public static void SetMinimumWindowSize(this IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            var tempSize = driver.Manage().Window.Size;

            if (tempSize.Width < MinSize.Width) tempSize.Width = MinSize.Width;
            if (tempSize.Height < MinSize.Height) tempSize.Height = MinSize.Height;

            driver.Manage().Window.Size = tempSize;
        }

        public static void CloseDriver(this IWebDriver driver)
        {
            driver.Close();
        }

        public static string GetBrowserName(this IWebDriver driver)
        {
            return driver.GetType().Name;
        }

        public static IWebDriver CreateNewDriver()
        {
            string path;

            switch (TestBrowser)
            {
                case var value when new Regex(@"[C|c]hrome").IsMatch(value):
                    path = $"{AppDomain.CurrentDomain.BaseDirectory}Drivers\\Chrome";
                    return new ChromeDriver(path);

                case var value when new Regex(@"[F|f]irefox").IsMatch(value):
                    path = $"{AppDomain.CurrentDomain.BaseDirectory}Drivers\\Firefox";
                    return new FirefoxDriver(path);

                case var value when new Regex(@"[I|i]+[E|e]+|[E|e]xplorer").IsMatch(value):
                    path = $"{AppDomain.CurrentDomain.BaseDirectory}Drivers\\Ie";
                    return new InternetExplorerDriver(path);

                default:
                    throw new Exception("Browser is not detected: " + TestBrowser);
            }
        }

        public static void TurnOn(this IWebDriver driver, WaitEnum waitEnum, int ms)
        {
            SetWait(driver, waitEnum, TimeSpan.FromMilliseconds(ms));
        }

        public static void TurnOff(this IWebDriver driver, WaitEnum waitEnum)
        {
            SetWait(driver, waitEnum, TimeSpan.Zero);
        }

        public static void SetDefault(this IWebDriver driver, WaitEnum waitEnum)
        {
            SetWait(driver, waitEnum, DefaultWaitMs);
        }

        private static void SetWait(IWebDriver driver, WaitEnum waitEnum, TimeSpan time)
        {
            switch (waitEnum)
            {
                case WaitEnum.Implicit:
                    driver.Manage().Timeouts().ImplicitWait = time;
                    break;
                case WaitEnum.PageLoad:
                    driver.Manage().Timeouts().PageLoad = time;
                    break;
                case WaitEnum.ExplicitWait:
                    Thread.Sleep(time);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(waitEnum), waitEnum, "No such enum type");
            }
        }
    }
}