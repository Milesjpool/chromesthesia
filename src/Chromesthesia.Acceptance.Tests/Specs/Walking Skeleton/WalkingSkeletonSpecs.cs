﻿using NUnit.Framework;

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

		[Test]
		public void Status_page_should_display_required_info()
		{
			When_I_navigate_to_the_status_page();
			Then_the_page_should_display_the_server_time();
			And_the_page_should_contain_a_version_number();
			And_the_page_should_display_a_machine_name();
			And_the_page_should_display_acousticbrainz_status();
		}
	}
}