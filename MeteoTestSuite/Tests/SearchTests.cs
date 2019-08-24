using MeteoTestSuite.Pages;
using NUnit.Framework;

namespace MeteoTestSuite.Tests
{
    [TestFixture]
    public class SearchTests : TestsBase
    {
        private HomePage _homePage;
        private SearchPage _searchPage;

        [SetUp]
        public void InitiatePages()
        {
            _homePage = new HomePage(Driver);
            _searchPage = new SearchPage(Driver);
        }

        [TestCase("Vilnius")]
        [TestCase("harum harum")]
        public void SearchShouldFindResult(string keyword)
        {
            _homePage.TopMenuBar.Search.For(keyword);
            Assert.IsTrue(_searchPage.IsResultExists(), "Result should exist: " + keyword);
        }

        [TestCase("London")]
        public void SearchShouldNotFindResult(string keyword)
        {
            _homePage.TopMenuBar.Search.For(keyword);
            Assert.IsFalse(_searchPage.IsResultExists(), "Result should not exist: " + keyword);
        }
    }
}