using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests.Specs.Invalid_Requests
{
	[TestFixture]
	class InvalidAcousticbrainzRequestSpecs : InvalidAcousticbrainzRequestSteps
	{
		[Test]
		public void Should_return_error_if_analyse_request_isnt_for_valid_GUID()
		{
			Given_a_non_GUID_Musicbrainz_ID();
			When_I_request_analysis_for_the_track();
			Then_the_page_should_display_an_error_message();
		}
	}
}
