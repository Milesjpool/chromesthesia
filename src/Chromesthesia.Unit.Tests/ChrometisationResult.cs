using System.Drawing;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;
using Chromesthesia.WebInterface.Chrometisation;
using NUnit.Framework;

namespace Chromesthesia.Unit.Tests
{
	[TestFixture]
	class ChrometisationResult
	{
		[Test]
		public void Female_song_should_be_orange()
		{
			var gender = new Analysis.HighLevel.Gender {value = "female"};
			var analysis = new Analysis{highlevel = new Analysis.HighLevel{gender = gender}};
			Color actual = new ColourCalculator().From(analysis);
			Assert.That(actual, Is.EqualTo(Color.Orange));
		}

		[Test]
		public void Male_song_should_be_green()
		{
			var gender = new Analysis.HighLevel.Gender { value = "male" };
			var analysis = new Analysis { highlevel = new Analysis.HighLevel { gender = gender } };
			Color actual = new ColourCalculator().From(analysis);
			Assert.That(actual, Is.EqualTo(Color.Green));
		}
	}
}
