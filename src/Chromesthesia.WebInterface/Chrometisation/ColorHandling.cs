using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Chromesthesia.WebInterface.Chrometisation
{
	public static class ColorHandling
	{
		public static List<Color> GetColoursIn(List<string> words)
		{
			var colours = new List<Color>();
			foreach (var word in words)
			{
				var color = Color.FromName(word.ToLower());
				if (color.IsKnownColor)
				{
					colours.Add(color);
				}
			}
			return colours;
		}

		public static void AddList(this List<WeightedColour> weightedColours, List<WeightedColour> colours, int totalWeight)
		{
			double weightMultiplier = 1;
			foreach (var colour in colours)
			{
				weightMultiplier = weightMultiplier/colour.Weight;
			}

			foreach (var colour in colours)
			{
				var colourWeight = (totalWeight * weightMultiplier * colour.Weight) / colours.Count;
				weightedColours.Add(new WeightedColour(colour.Color, colourWeight));
			}
		}

		public static void AddList(this List<WeightedColour> weightedColours, List<Color> colours, int totalWeight)
		{
			foreach (var colour in colours)
			{
				var colourWeight = ((double)totalWeight) / colours.Count;
				weightedColours.Add(new WeightedColour(colour, colourWeight));
			}
		}

		public static Color Aggregate(List<WeightedColour> weightedColours)
		{
			var totalWeight = weightedColours.Sum(colour => colour.Weight);
			var meanRed = 0;
			var meanGreen = 0;
			var meanBlue = 0;
			foreach (var weightedColour in weightedColours)
			{
				var weighting = weightedColour.Weight / totalWeight;
				meanRed += (int)(weightedColour.Color.R * weighting);
				meanGreen += (int)(weightedColour.Color.G * weighting);
				meanBlue += (int)(weightedColour.Color.B * weighting);
			}
			return Color.FromArgb(meanRed, meanGreen, meanBlue);
		}

		public static Color Negative(this Color colour)
		{
			int r = 255 - colour.R;
			int g = 255 - colour.G;
			int b = 255 - colour.B;
			return Color.FromArgb(r, g, b);
		}

		public static Color ExaggerateColour(int iterations, Color color)
		{
			var red = (int)color.R;
			var green = (int)color.G;
			var blue = (int)color.B;
			for (int i = 0; i < iterations; i++)
			{
				red = Extremise(red);
				green = Extremise(green);
				blue = Extremise(blue);
			}
			return Color.FromArgb(red, green, blue);
		}

		private static int Extremise(int value)
		{
			double rads = (value - 127) * (Math.PI / 255);
			value = (int)((Math.Sin(rads) * 128) + 127.5);
			return value;
		}
	}
}