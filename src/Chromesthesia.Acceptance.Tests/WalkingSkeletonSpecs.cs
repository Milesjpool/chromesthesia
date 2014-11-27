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
        }

        [TestCase("f989fa05-7e2b-4e88-8a95-b5d68480b539", 167.186660767)]
        public void Chrometise_page_should_display_length_of_song_with_musicbrainz_id(string mbid, double expectedLength)
        {
            When_I_navigate_to_the_chometise_page_for_musicbrainz_id(mbid);
            Then_the_webpage_should_contain(expectedLength);
        }
    }
}