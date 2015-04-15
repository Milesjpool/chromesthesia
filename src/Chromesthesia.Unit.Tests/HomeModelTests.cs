using Chromesthesia.WebInterface.Services;
using NUnit.Framework;

namespace Chromesthesia.Unit.Tests
{
	[TestFixture]
	class HomeModelTests
	{
		[Test]
		public void Model_should_contain_tracks_with_Id7d()
		{
			var model = new HomeControllerService().GetHomeModel();
			Assert.That(model.ExampleTracks[0].Id7D, Is.Not.Null);
		}
	}
}
