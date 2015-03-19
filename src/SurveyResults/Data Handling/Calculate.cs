using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyResults
{
	public class Calculate
	{
		private readonly IEnumerable<Colour> _colours;

		public Calculate(IEnumerable<Colour> colours)
		{
			_colours = colours;
		}

		public Colour MeanColour()
		{
			var meanRed = (int) _colours.Average(c => c.Redness);
			var meanGreen = (int) _colours.Average(c => c.Greenness);
			var meanBlue = (int) _colours.Average(c => c.Blueness);
			return new Colour(meanRed, meanGreen, meanBlue);
		}

		public List<Colour> OrderedColours()
		{
			return new List<Colour>(_colours.OrderBy(c => c.Value));
		}


		public int ModeCount()
		{
			var colourCounts = new List<int>();
			foreach (var colour in _colours)
			{
				colourCounts.Add(_colours.Count(c => (c.Value == colour.Value)));
			}
			return colourCounts.Max();
		}

		public List<Colour> ColoursWithNVotes(int numVotes)
		{
			var colours = new List<Colour>();
			var voteGroups = _colours.GroupBy(colour => colour.Value);
			foreach (var group in voteGroups)
			{
				if (group.Count() == numVotes)
					colours.Add(group.First());
			}
			return colours;
		}
	}
}