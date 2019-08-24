using MeteoTestSuite.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MeteoTestSuite.Tests
{
    [TestFixture]
    public class TestsBase
    {
        public static IWebDriver Driver;

        public MyLogger Log;

        [SetUp]
        public void SetUp()
        {
            Driver = MyDriver.CreateNewDriver();
            Driver.SetMinimumWindowSize();
            Driver.SetDefault(WaitEnum.PageLoad);
            Driver.SetDefault(WaitEnum.Implicit);
            Driver.OpenAppBaseUrl();

            Log = new MyLogger()
                .TestStart(Driver.GetBrowserName());
        }

        [TearDown]
        public void TearDown()
        {
            Log.TestEnd();
            Driver.TakeScreenShotOnFailure();
            Driver.CloseDriver();
        }
    }
}