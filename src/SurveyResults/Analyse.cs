using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyResults
{
	static class Analyse
	{
		public static void All(int maxTrackId)
		{
			for (int trackId = 0; trackId < maxTrackId; trackId++)
			{
				OutputAnalysis(trackId);
			}
		}

		public static void Single(int maxTrackId)
		{
			var trackId = UserInput.GetTrackId(maxTrackId);
			OutputAnalysis(trackId);
			if (UserInput.AnalyseAnother())
				Single(maxTrackId);
		}

		private static void OutputAnalysis(int trackId)
		{
			var results = new TrackData(trackId).Results();
			Console.WriteLine("====================");
			OutputTrackHeader(trackId, results);
			OutputMeanColour(results);
			OuputAllColours(results);
		}

		private static void OutputTrackHeader(int trackId, IEnumerable<Result> results)
		{
			var trackString = results.First(t => t.TrackId == trackId).TrackString;
			Console.WriteLine("Analysis for track " + trackId + ": " + trackString);
		}

		private static void OutputMeanColour(IList<Result> results)
		{
			var meanRed = (int) results.Average(result => result.Redness);
			var meanGreen = (int) results.Average(result => result.Greenness);
			var meanBlue = (int) results.Average(result => result.Blueness);
			var meanColour = new Colour(meanRed, meanGreen, meanBlue);
			Console.WriteLine("Mean colour: " + meanColour);
		}

		private static void OuputAllColours(IEnumerable<Result> results)
		{
			Console.WriteLine("------ All data ------");
			var colours = new List<Colour>();
			foreach (var result in results)
			{
				var colour = new Colour(result.Redness, result.Greenness, result.Blueness);
				colours.Add(colour);
			}
			Console.WriteLine("----------------------");
		}

		public class Colour
		{
			private readonly int _red;
			private readonly int _green;
			private readonly int _blue;

			public Colour(int red, int green, int blue)
			{
				_red = red;
				_green = green;
				_blue = blue;
			}

			public override string ToString()
			{
				return string.Format("[{0}, {1}, {2}]", _red, _green, _blue);
			}

			public int Red
			{
				get { return _red; }
			}

			public int Green
			{
				get { return _green; }
			}

			public int Blue
			{
				get { return _blue; }
			}
		}
	}
}