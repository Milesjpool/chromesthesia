using Chromesthesia.WebInterface.Exceptions;
using Chromesthesia.WebInterface.Parsing;
using NUnit.Framework;

namespace Chromesthesia.Integration.Tests
{
	[TestFixture]
	class Conversion_from_7digital_to_Musicbrainz_id
	{
		[Test]
		public void Should_convert_from_7dID_to_MBID_correctly()
		{
			var sevenDigitalId = new SevenDigitalId(12345);
			var actualMbid = sevenDigitalId.ToMbid();

			var expectedMbid = new Mbid("BFF3BC49-7E55-4701-8A86-1F8B86784166");

			Assert.That(actualMbid.ToString(), Is.EqualTo(expectedMbid.ToString()));
		}

		[Test]
		public void Should_throw_exception_if_given_unlinked_7dID()
		{
			var sevenDigitalId = new SevenDigitalId(999999);
			Assert.Throws<MusicbrainzIdNotFoundException>( () => sevenDigitalId.ToMbid());
		}

		[Test]
		public void Should_throw_exception_if_given_invalid_7dID()
		{
			var sevenDigitalId = new SevenDigitalId("abc123");
			Assert.Throws<Invalid7DigitalIdException>(() => sevenDigitalId.ToMbid());
		}
	}
}