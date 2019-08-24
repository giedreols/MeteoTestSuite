using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace MeteoTestSuite.Pages
{
    public class HomePage
    {
        public TopMenuBar TopMenuBar;

        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            TopMenuBar = new TopMenuBar(driver);
        }
    }
}