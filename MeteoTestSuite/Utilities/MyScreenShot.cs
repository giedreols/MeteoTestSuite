using System;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace MeteoTestSuite.Utilities
{
    public static class MyScreenShot
    {
        private static readonly string ScreenshotsDir = AppDomain.CurrentDomain.BaseDirectory + "Result/Screenshots/";

        public static string TakeScreenShotOnFailure(this IWebDriver driver)
        {
            return TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed
                ? TakeScreenShot(driver)
                : default(string);
        }

        public static string TakeScreenShot(IWebDriver driver)
        {
            Directory.CreateDirectory(ScreenshotsDir);
            var testName = TestContext.CurrentContext.Test.FullName.Replace("\"", "");
            var filename = ScreenshotsDir + testName + ".png";
            return CaptureScreenShot(driver, filename);
        }

        private static string CaptureScreenShot(IWebDriver driver, string fileName)
        {
            var ss = driver.TakeScreenshot();
            ss.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            return fileName;
        }
    }
}