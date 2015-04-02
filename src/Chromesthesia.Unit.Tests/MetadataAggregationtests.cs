using System;
using System.Collections.Generic;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;
using Chromesthesia.WebInterface.Chrometisation;
using NUnit.Framework;

namespace Chromesthesia.Unit.Tests
{
	[TestFixture]
	class MetadataAggregationtests
	{
		[Test]
		public void Should_handle_special_characters_correctly()
		{
			var analysis = new Analysis
				{
					metadata = new Analysis.Metadata
						{
							tags = new Analysis.Metadata.Tags
								{
									artist = new []{"  p!nk/ke$ha  "},
									album = new []{"Iron&Wine>cheese\\   ham~eggs"},
									title = new []{"fight-for(your)[right]to.progr@m!"}
								}
						}
				};
			var actual =new MetadataAnalysis(analysis).Aggregate();
			var expected = new List<string>{ "pink", "kesha", "iron", "wine", "cheese",
				"ham", "eggs", "fight", "for", "your", "right", "to", "program"};
			foreach (var word in actual)
			{
				Console.WriteLine(word);
				Assert.That(expected.Contains(word), "Actual contained the unexpected word: " + word);
			}
			Assert.That(actual.Count, Is.EqualTo(expected.Count));
		}
	}
}