using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests.Specs.Chrometise
{
	public class ChrometiseEndpointSpecs : ChrometiseEndpointSteps
	{
		[Test]
		public void Chrometise_page_should_display_a_colour_for_musicbrainz_id()
		{
			Given_a_valid_musicbrainz_id();
			When_I_navigate_to_the_chrometise_page();
			Then_the_webpage_should_contain_a_valid_hex_code();
		}

		[Test]
		public void Chrometise_page_should_display_a_colour_for_7digital_id()
		{
			Given_a_valid_7digital_id();
			When_I_navigate_to_the_chrometise_page();
			Then_the_webpage_should_contain_a_valid_hex_code();
		}
	}
}