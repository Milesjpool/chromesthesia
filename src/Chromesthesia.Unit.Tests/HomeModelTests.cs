using Chromesthesia.WebInterface.Models;
using Chromesthesia.WebInterface.Parsing;
using Chromesthesia.WebInterface.Services;
using NUnit.Framework;

namespace Chromesthesia.Unit.Tests
{
	[TestFixture]
	class HomeModelTests
	{
		[Test]
		public void Model_should_contain_tracks_with_Mbid_and_Id7d()
		{
			var model = new HomeControllerService().GetHomeModel();
			Assert.That(model.Tracks[0].Mbid, Is.Not.Null);
			Assert.That(model.Tracks[0].Id7D, Is.Not.Null);
		}
	}
}
