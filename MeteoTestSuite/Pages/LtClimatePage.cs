using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MeteoTestSuite.Pages
{
    public class LtClimatePage
    {
        public TopMenuBar TopMenuBar;

        public LtClimatePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

            TopMenuBar = new TopMenuBar(driver);
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/oro-temperatura']")]
        private IWebElement AirTemperatureButton { get; set; }

        public bool AirTemperatureButtonExist()
        {
            return AirTemperatureButton.Displayed;
        }
    }
}