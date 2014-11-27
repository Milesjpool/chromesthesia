using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests
{
    public class WalkingSkeletonSteps
    {
        private AcceptanceTestDriver _driver;

        [TestFixtureSetUp]
        public void Setup()
        {
            _driver = new AcceptanceTestDriver();
        }

        protected void When_I_navigate_to_the_website_url()
        {
            _driver.NavigateToRoot();
        }

        protected void Then_the_webpage_should_be_available()
        {
            _driver.CheckWebpageIsOkay();
        }

        protected void And_the_webpage_should_contain_chromesthesia()
        {
            _driver.CheckResponseContains("Chromesthesia");
        }

        protected void When_I_navigate_to_the_chometise_page_for_musicbrainz_id(string mbid)
        {
            _driver.NavigateToChrometiseMbid(mbid);
        }

        protected void Then_the_webpage_should_contain(double expectedLength)
        {
            _driver.CheckResponseContains(expectedLength.ToString());
        }
    }
}