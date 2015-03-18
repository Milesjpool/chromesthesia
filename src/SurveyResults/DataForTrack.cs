using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyResults
{
	class DataForTrack
	{
		private readonly int _trackId;
		private readonly IList<Result> _results;

		public DataForTrack(int trackId)
		{
			_trackId = trackId;
			_results = new TrackData(trackId).Results();
		}

		public void Verbose()
		{
			Divider();
			TrackHeader(_trackId, _results);
			MeanColour(_results);
			ModeColour(_results);
			RawData(_results);
			Divider();
		}

		private static void TrackHeader(int trackId, IEnumerable<Result> results)
		{
			var trackString = results.First(t => t.TrackId == trackId).TrackString;
			Console.WriteLine("Analysis for track " + trackId + ": " + trackString);
		}

		private static void MeanColour(IList<Result> results)
		{
			Console.WriteLine("Mean colour: " + CalculateMeanColour(results));
		}

		private void ModeColour(IList<Result> results)
		{
			Console.WriteLine("Mode colour: " + "##TODO##");
		}

		private static Colour CalculateMeanColour(IList<Result> results)
		{
			var meanRed = (int) results.Average(result => result.Redness);
			var meanGreen = (int) results.Average(result => result.Greenness);
			var meanBlue = (int) results.Average(result => result.Blueness);
			return new Colour(meanRed, meanGreen, meanBlue);
		}

		private static void RawData(IEnumerable<Result> results)
		{
			Console.WriteLine("------ ALL DATA ------");
			var colours = results.Select(r => new Colour(r)).ToList();
			var sortedColours = colours.OrderBy(c => c.Value);
			foreach (var colour in sortedColours)
			{
				Console.WriteLine(colour);
			}
		}

		private static void Divider()
		{
			Console.WriteLine("======================");
		}
	}
}