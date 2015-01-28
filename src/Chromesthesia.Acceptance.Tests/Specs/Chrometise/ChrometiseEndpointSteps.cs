using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests.Specs.Chrometise
{
	public class ChrometiseEndpointSteps
	{
		private AcceptanceTestDriver _driver;
		private string _id;
		private string _idType = "mbid";

		[TestFixtureSetUp]
		public void Setup()
		{
			_driver = new AcceptanceTestDriver();
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
		
		protected void When_I_navigate_to_the_chrometise_page()
		{
			_driver.NavigateToChrometise(_idType, _id);
		}

		protected void Then_the_webpage_should_contain_a_valid_hex_code()
		{
			const string hexCodeRegex = "\'#[A-Fa-f0-9]{6}\'";
			_driver.CheckResponseMatchesRegex(hexCodeRegex);
		}
	}
}