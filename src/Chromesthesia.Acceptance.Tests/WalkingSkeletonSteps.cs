using System;
using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests
{
    public class WalkingSkeletonSteps
    {
        private AcceptanceTestDriver _driver;
        private const string ValidMbid = "f989fa05-7e2b-4e88-8a95-b5d68480b539";
        private const string ExpectedLength = "167.18";

        [TestFixtureSetUp]
        public void Setup()
        {
            _driver = new AcceptanceTestDriver();
        }

        protected void When_I_navigate_to_the_website_url()
        {
            _driver.NavigateToRoot();
        }

        protected void When_I_navigate_to_the_status_page()
        {
            _driver.NavigateToStatusPage(); ;
        }

        protected void When_I_navigate_to_the_analyse_page_for_a_valid_musicbrainz_id()
        {
            _driver.NavigateToAnalyseMbid(ValidMbid);
        }

        protected void When_I_navigate_to_the_chrometise_page_for_a_valid_musicbrainz_id()
        {
            _driver.NavigateToChrometiseMbid(ValidMbid);
        }

        protected void Then_the_webpage_should_be_available()
        {
            _driver.CheckWebpageIsOkay();
        }

        protected void Then_the_page_should_display_the_server_time()
        {
            var dateString = DateTime.Today.ToString("dd/MM/yyyy");
            var expected = "Server Time: " + dateString;
            _driver.CheckResponseContains(expected);
        }

        protected void And_the_page_should_contain_a_version_number()
        {
            var versionNumberRegex = @"Version: [0-9]+.[0-9]+.[0-9]+.[0-9]+";
            _driver.CheckResponseMatchesRegex(versionNumberRegex);
        }

        protected void And_the_page_should_display_a_200_status_code()
        {
            _driver.CheckResponseContains("Chromesthesia Status: 200 (OK)");
        }

        protected void And_the_page_should_display_acousticbrainz_status()
        {
            _driver.CheckResponseContains("Acousticbrainz Status: 200 (OK)");
        }

        protected void And_the_webpage_should_contain_chromesthesia()
        {
            _driver.CheckResponseContains("Chromesthesia");
        }

        protected void And_the_webpage_should_contain_an_example_chrometise_link()
        {
            const string relativeUrl = "/chrometise/mbid/" + ValidMbid;
            const string chrometiseLinkRegex = "Chrometise MBID: <a href='" + relativeUrl + "'>" + ValidMbid + "</a>";
            _driver.CheckResponseMatchesRegex(chrometiseLinkRegex);
        }

        protected void Then_the_webpage_should_contain_the_expected_length()
        {
            _driver.CheckResponseContains(ExpectedLength);
        }

        protected void Then_the_webpage_should_contain_a_valid_hex_code()
        {
            var hexCodeRegex = "\'#[A-Fa-f0-9]{6}\'";
            _driver.CheckResponseMatchesRegex(hexCodeRegex);
        }
    }
}