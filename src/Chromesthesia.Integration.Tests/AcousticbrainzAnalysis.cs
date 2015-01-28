using System.Collections.Generic;
using Chromesthesia.Test.Helpers;
using Chromesthesia.WebInterface.Parsing;
using Chromesthesia.WebInterface.Services;
using NUnit.Framework;

namespace Chromesthesia.Integration.Tests
{
	[TestFixture]
	public class AcousticbrainzAnalysis
	{
		private Mbid _testMbid;

		[SetUp]
		public void Setup()
		{
			_testMbid = new Mbid("0310e92c-331c-4f61-bc4d-3c3ba6e88aec");
		}

		[Test]
		public void Should_get_high_level_analysis_for_track()
		{
			var expectedStrings = new List<string>
				{
					"danceability",
					"mood",
					"gender"
				};

			var analysis = new AcousticbrainzExchange().GetAnalysis(_testMbid, AnalysisLevels.High);

			Assert.That(analysis.ContainsAll(expectedStrings));
		}

		[Test]
		public void Should_get_low_level_analysis_for_track()
		{
			var expectedStrings = new List<string>
				{
					"average_loudness",
					"chords_histogram",
					"barkbands"
				};

			var actual = new AcousticbrainzExchange().GetAnalysis(_testMbid, AnalysisLevels.Low);

				Assert.That(actual.ContainsAll(expectedStrings));
		}
	}
}
