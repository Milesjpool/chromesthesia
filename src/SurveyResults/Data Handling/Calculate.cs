﻿using System;
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

		public Calculate(TrackData trackData)
		{
			_colours = trackData.Results.Select(r => new Colour(r));
		}

		public List<Colour> OrderedColours()
		{
			return new List<Colour>(_colours.OrderBy(c => c.Value));
		}

		public Colour MeanColour()
		{
			var meanRed = (int) _colours.Average(c => c.Redness);
			var meanGreen = (int) _colours.Average(c => c.Greenness);
			var meanBlue = (int) _colours.Average(c => c.Blueness);
			return new Colour(meanRed, meanGreen, meanBlue);
		}

		public Colour ExaggeratedMean(int iterations)
		{
			var mean = MeanColour();
			return ExaggerateColour(iterations, mean);
		}

		private Colour ExaggerateColour(int iterations, Colour mean)
		{
			var redness = Extremise(mean.Redness, iterations);
			var greenness = Extremise(mean.Greenness, iterations);
			var blueness = Extremise(mean.Blueness, iterations);
			return new Colour(redness, greenness, blueness);
		}

		private int Extremise(int value, int iterations)
		{
			for (int i = 0; i < iterations; i++)
			{
				double rads = (value - 127) * (Math.PI / 255);
				value = (int)((Math.Sin(rads) * 128) + 127.5);
			}
			return value;
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

		public IEnumerable<Colour> ModeColour()
		{
			return ColoursWithNVotes(ModeCount());
		}

		private IEnumerable<Colour> ColoursWithNVotes(int numVotes)
		{
			var colours = new List<Colour>();
			var voteGroups = _colours.GroupBy(colour => colour.Value);
			foreach (var group in voteGroups)
			{
				if (@group.Count() == numVotes)
					colours.Add(@group.First());
			}
			return colours;
		}
	}
}