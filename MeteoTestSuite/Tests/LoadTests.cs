using MeteoTestSuite.Pages;
using NUnit.Framework;

namespace MeteoTestSuite.Tests
{
    [TestFixture]
    public class LoadTests : TestsBase
    {
        private HomePage _homePage;
        private SearchPage _searchPage;

        [SetUp]
        public void InitiatePages()
        {
            _homePage = new HomePage(Driver);
            _searchPage = new SearchPage(Driver);
        }

        [TestCase(3280)]
        public void SearchShouldNotExceedLoadTime(int ms)
        {
            _homePage.TopMenuBar.Search.For("Vilnius");
            Assert.IsTrue(_searchPage.IsResultLoadsIn(ms), $"Search result should be loaded in: {ms} ms");
        }
    }
}