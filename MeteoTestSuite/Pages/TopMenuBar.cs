using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace MeteoTestSuite.Pages
{
    public class TopMenuBar
    {
        private readonly IWebDriver _driver;
        public SearchPage Search;

        public TopMenuBar(IWebDriver driver)
        {
            Search = new SearchPage(driver);
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".nav a[href*='/klimatas']")]
        private IWebElement ClimateButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[role=menu] a[href*='/lietuvos-klimatas']")]
        private IWebElement LtClimateButton { get; set; }

        public TopMenuBar GoToLithuaniaClimatePage()
        {
            var action = new Actions(_driver);
            action.MoveToElement(ClimateButton).Perform();

            LtClimateButton.Click();
            return this;
        }
    }
}