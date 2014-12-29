using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests
{
    [TestFixture]
    public class WalkingSkeletonSpecs : WalkingSkeletonSteps
    {
        [Test]
        public void Should_be_able_to_access_homepage()
        {
            When_I_navigate_to_the_website_url();
            Then_the_webpage_should_be_available();
            And_the_webpage_should_contain_chromesthesia();
            And_the_webpage_should_contain_an_example_chrometise_link();
        }

        [Test]
        public void Status_page_should_display_required_info()
        {
            When_I_navigate_to_the_status_page();
            Then_the_page_should_display_the_server_time();
            And_the_page_should_display_acousticbrainz_status();
            And_the_page_should_display_a_200_status_code();
            And_the_page_should_contain_a_version_number();
        }
        
        [Test]
        public void Analyse_page_should_display_the_length_of_a_song()
        {
            When_I_navigate_to_the_analyse_page_for_a_valid_musicbrainz_id();
            Then_the_webpage_should_contain_the_expected_length();
        }

        [Test]
        public void Chrometise_page_should_display_a_colour_for_musicbrainz_id()
        {
            When_I_navigate_to_the_chrometise_page_for_a_valid_musicbrainz_id();
            Then_the_webpage_should_contain_a_valid_hex_code();
        }
    }
}