using MeteoTestSuite.Pages;
using NUnit.Framework;

namespace MeteoTestSuite.Tests
{
    [TestFixture]
    public class NavigationTests : TestsBase
    {
        private LtClimatePage _ltClimatePage;
        private HomePage _homePage;

        [SetUp]
        public void InitiatePages()
        {
            _ltClimatePage = new LtClimatePage(Driver);
            _homePage = new HomePage(Driver);
        }
        [Test]
        public void ShouldAirTemperatureSectionsExist()
        {
            _homePage.TopMenuBar.GoToLithuaniaClimatePage();
            Assert.IsTrue(_ltClimatePage.AirTemperatureButtonExist(), "Air temperature section should exist");
        }
    }
}