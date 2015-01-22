using System;
using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests
{
	public class WalkingSkeletonSteps
	{
		private AcceptanceTestDriver _driver;
		private Track _track;

		[TestFixtureSetUp]
		public void Setup()
		{
			_driver = new AcceptanceTestDriver();
			_track = new Track
			{
				Mbid = "f989fa05-7e2b-4e88-8a95-b5d68480b539",
				Title = "9 to 5"
			};
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
			_driver.NavigateToAnalyseMbid(_track.Mbid);
		}

		protected void When_I_navigate_to_the_chrometise_page_for_a_valid_musicbrainz_id()
		{
			_driver.NavigateToChrometiseMbid(_track.Mbid);
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

		protected void And_the_page_should_display_a_machine_name()
		{
			var machineNameRegex = "Machine Name: .+";
			_driver.CheckResponseMatchesRegex(machineNameRegex);
		}

		protected void And_the_page_should_display_acousticbrainz_status()
		{
			var acousticbrainsStatus = "Acousticbrainz Status: [0-9]{3} \\([a-zA-Z]+\\)";
			_driver.CheckResponseMatchesRegex(acousticbrainsStatus);
		}

		protected void And_the_webpage_should_contain_chromesthesia()
		{
			_driver.CheckResponseContains("Chromesthesia");
		}

		protected void Then_the_webpage_should_contain_the_expected_details()
		{
			_driver.CheckResponseContains(_track.Title);
			var trackLength = "\"length\":[0-9]+\\.[0-9]{9},";
			_driver.CheckResponseMatchesRegex(trackLength);
		}

		protected void Then_the_webpage_should_contain_a_valid_hex_code()
		{
			var hexCodeRegex = "\'#[A-Fa-f0-9]{6}\'";
			_driver.CheckResponseMatchesRegex(hexCodeRegex);
		}
	}
}