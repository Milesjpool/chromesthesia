using Chromesthesia.WebInterface.Interfaces;
using Chromesthesia.WebInterface.Services;
using Moq;
using NUnit.Framework;

namespace Chromesthesia.Unit.Tests
{
	[TestFixture]
	public class AcousticBrainzStatus
	{
		[Test,Ignore]
		public void should_request_status_with_HEAD()
		{
			var acousticBrainzExchange = new Mock<IAcousticbrainzExchange>();
			acousticBrainzExchange.Setup(abs => abs.GetStatus()).Returns("200(OK)");

			var statusControllerService = new StatusControllerService(acousticBrainzExchange.Object);

			Assert.That(statusControllerService.GetStatusModel().AcousticbrainzStatus, Is.EqualTo("200(OK)"));
		}
	}
}
