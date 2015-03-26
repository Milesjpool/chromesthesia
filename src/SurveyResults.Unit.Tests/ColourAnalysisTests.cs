using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SurveyResults.Unit.Tests
{
	[TestFixture]
	class ColourAnalysisTests
	{
		private readonly Colour _white = new Colour(255, 255, 255);
		private readonly Colour _black = new Colour(0, 0, 0);
		private readonly Colour _midGrey = new Colour(127,127,127);

		[Test]
		public void Should_give_correct_mean()
		{
			var colours = new List<Colour>{_black, _white};
			var calculate = new Calculate(colours);
			Assert.That(calculate.MeanColour().ToString(), Is.EqualTo(_midGrey.ToString()));
		}

		[Test]
		public void Should_give_correct_mode_when_there_is_one()
		{
			var colours = new List<Colour> { _black, _black, _white };
			var calculate = new Calculate(colours);
			Assert.That(calculate.ModeCount(), Is.EqualTo(2));
			Assert.That(calculate.ModeColour().Single(), Is.EqualTo(_black));
		}

		[Test]
		public void Should_give_correct_modes_when_there_are_many()
		{
			var colours = new List<Colour> { _black, _white };
			var calculate = new Calculate(colours);
			Assert.That(calculate.ModeCount(), Is.EqualTo(1));
			Assert.That(calculate.ModeColour(), Is.EqualTo(new List<Colour>{_black,_white}));
		}

		[Test]
		public void Should_give_correct_exaggerated_means()
		{
			for (int i = 0; i < 256; i++)
			{
				var colour = new Colour(i, i, i);
				var calculate = new Calculate(new List<Colour> { colour });
				var exaggeratedMean = calculate.ExaggeratedMean(1);
				Assert.That(exaggeratedMean.Redness, Is.EqualTo(exaggeratedMean.Blueness));
				Assert.That(exaggeratedMean.Redness, Is.EqualTo(exaggeratedMean.Greenness));
				Assert.That(exaggeratedMean.Redness, Is.AtLeast(0));
				Assert.That(exaggeratedMean.Redness, Is.AtMost(255));
				if(i <= 126)
					Assert.That(exaggeratedMean.Redness, Is.LessThan(126));
				if(i >= 129)
					Assert.That(exaggeratedMean.Redness, Is.GreaterThan(129));
			}
		}
	}
}
