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
	}
}