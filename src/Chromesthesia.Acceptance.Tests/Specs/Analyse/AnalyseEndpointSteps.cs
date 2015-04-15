using Chromesthesia.WebInterface;
using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests.Specs.Analyse
{
	public class AnalyseEndpointSteps
	{
		private AcceptanceTestDriver _driver;
		private string _id;
		private string _idType;

		[TestFixtureSetUp]
		public void Setup()
		{
			_driver = new AcceptanceTestDriver();
		}

		protected void Given_a_non_GUID_Musicbrainz_ID()
		{
			_id = "not-a-GUID";
			_idType = "mbid";
		}

		protected void Given_a_valid_musicbrainz_id()
		{
			_id = "0310E92C-331C-4F61-BC4D-3C3BA6E88AEC";
			_idType = "mbid";
		}

		protected void Given_a_valid_7digital_id()
		{
			_id = "28905854";
			_idType = "7d";
		}

		protected void When_I_request_analysis_for_the_track()
		{
			_driver.NavigateToAnalyse(_idType, _id);
		}

		protected void Then_the_webpage_should_contain_the_expected_details()
		{
			const string expectedTitle = "Get Lucky (radio edit)";
			_driver.CheckResponseContains(expectedTitle);

			var trackLength = "\"length\":[0-9]+\\.[0-9]{9},";
			_driver.CheckResponseMatchesRegex(trackLength);
		}

		protected void Then_the_page_should_display_an_error_message()
		{
			_driver.CheckResponseContains(_id);
			_driver.CheckResponseContains("This is not a valid Musicbrainz track ID");
		}
	}
}