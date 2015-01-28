using System;
using NUnit.Framework;

namespace Chromesthesia.Acceptance.Tests
{
	public class WalkingSkeletonSteps
	{
		private AcceptanceTestDriver _driver;

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
			const string versionNumberRegex = @"Version: [0-9]+.[0-9]+.[0-9]+.[0-9]+";
			_driver.CheckResponseMatchesRegex(versionNumberRegex);
		}

		protected void And_the_page_should_display_a_machine_name()
		{
			const string machineNameRegex = "Machine Name: .+";
			_driver.CheckResponseMatchesRegex(machineNameRegex);
		}

		protected void And_the_page_should_display_acousticbrainz_status()
		{
			const string acousticbrainsStatus = "Acousticbrainz Status: [0-9]{3} \\([a-zA-Z]+\\)";
			_driver.CheckResponseMatchesRegex(acousticbrainsStatus);
		}

		protected void And_the_webpage_should_contain_chromesthesia()
		{
			_driver.CheckResponseContains("Chromesthesia");
		}
	}
}