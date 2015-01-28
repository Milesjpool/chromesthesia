using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests.Specs.Analyse
{
	public class AnalyseEndpointSpecs : AnalyseEndpointSteps
	{
		[Test]
		public void Analyse_page_should_display_the_details_of_a_song_from_its_mbid()
		{
			Given_a_valid_musicbrainz_id();
			When_I_request_analysis_for_the_track();
			Then_the_webpage_should_contain_the_expected_details();
		}

		[Test]
		public void Analyse_page_should_display_the_details_of_a_song_from_its_7did()
		{
			Given_a_valid_7digital_id();
			When_I_request_analysis_for_the_track();
			Then_the_webpage_should_contain_the_expected_details();
		}

		[Test]
		public void Should_return_error_if_analyse_request_isnt_for_valid_GUID()
		{
			Given_a_non_GUID_Musicbrainz_ID();
			When_I_request_analysis_for_the_track();
			Then_the_page_should_display_an_error_message();
		}
	}
}