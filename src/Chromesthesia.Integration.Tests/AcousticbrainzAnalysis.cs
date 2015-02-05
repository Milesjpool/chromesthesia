using System.Collections.Generic;
using Chromesthesia.Test.Helpers;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;
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
		public void Should_get_json_analysis_for_track()
		{
			var highLevelProperties = new List<string>
				{
					"danceability",
					"mood",
					"gender"
				};

			var lowLevelProperties = new List<string>
				{
					"barkbands",
					"dynamic_complexity",
					"chords_key"
				};

			var llJson = new AcousticbrainzExchange().GetAnalysisOf(_testMbid).LowLevelJson;
			var hlJson = new AcousticbrainzExchange().GetAnalysisOf(_testMbid).HighLevelJson;

			Assert.That(llJson.ContainsAll(lowLevelProperties));
			Assert.That(hlJson.ContainsAll(highLevelProperties));
		}

		[Test]
		public void Should_get_analysis_object_for_track()
		{
			var analysis = new AcousticbrainzExchange().GetAnalysisOf(_testMbid).Deserialize();

			Assert.That(analysis.highlevel, Is.Not.Null);
		}
	}
}
