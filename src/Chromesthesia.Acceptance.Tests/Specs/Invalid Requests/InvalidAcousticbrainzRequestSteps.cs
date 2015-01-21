namespace Chromesthesia.Acceptance.Tests.Specs.Invalid_Requests
{
	internal class InvalidAcousticbrainzRequestSteps
	{
		private string _mbid;
		private AcceptanceTestDriver _driver;

		protected void Given_a_non_GUID_Musicbrainz_ID()
		{
			_mbid = "not-a-GUID";
		}

		protected void When_I_request_analysis_for_the_track()
		{
			_driver = new AcceptanceTestDriver();
			_driver.NavigateToAnalyseMbid(_mbid);
		}

		protected void Then_the_page_should_display_an_error_message()
		{
			_driver.CheckResponseContains(string.Format("'{0}' is not a valid Musicbrainz ID", _mbid));
		}
	}
}