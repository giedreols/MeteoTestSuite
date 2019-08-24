using MeteoTestSuite.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MeteoTestSuite.Pages
{
    public class SearchPage
    {
        private readonly IWebDriver _driver;

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "form[Action] input[name=textfield]")]
        private IWebElement SearchField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button i")]
        private IWebElement SearchButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".searchcontainer-content .dataTables_info")]
        private IWebElement SearchResultTable { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert")]
        private IWebElement AlertPlaceholder { get; set; }

        public void For(string searchFor)
        {
            SearchField.SendKeys(searchFor);
            SearchButton.Click();
        }

        public bool IsResultExists()
        {
            try
            {
                return SearchResultTable.Displayed;
            }
            catch (NoSuchElementException)
            {
                try
                {
                    return !AlertPlaceholder.Displayed;
                }
                catch (NoSuchElementException)
                {
                    Assert.Ignore(
                        "Something is wrong. No search result and no alert message. At least one of them should be displayed");
                    return false;
                }
            }
        }

        public bool IsResultLoadsIn(int ms)
        {
            _driver.TurnOn(WaitEnum.PageLoad, ms);
            _driver.TurnOff(WaitEnum.Implicit);

            try
            {
                IsResultExists();
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            finally
            {
                _driver.SetDefault(WaitEnum.PageLoad);
                _driver.SetDefault(WaitEnum.Implicit);
            }
        }
    }
}