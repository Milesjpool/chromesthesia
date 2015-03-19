using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyResults
{
	class ConsoleOutput
	{
		private readonly int _trackId;
		private readonly IList<Result> _results;
		private readonly Calculate _calculate;
		private readonly IEnumerable<Colour> _colours;

		public ConsoleOutput(int trackId)
		{
			_trackId = trackId;
			_results = new TrackData(trackId).Results();
			_colours = _results.Select(r => new Colour(r));
			_calculate = new Calculate(_colours);
		}

		public void TrackHeader()
		{
			var trackString = _results.First(t => t.TrackId == _trackId).TrackString;
			Console.WriteLine("Analysis for track " + _trackId + ": " + trackString);
		}

		public void MeanColour()
		{
			Console.WriteLine();
			Console.WriteLine("----- MEAN COLOUR -----");
			Console.WriteLine(_calculate.MeanColour());
		}

		public void ExaggeratedMeanColour()
		{
			Console.WriteLine();
			Console.WriteLine("-- EXAGGERATED MEAN ---");
			Console.WriteLine(_calculate.ExaggeratedMean());
		}

		public void ModeColours()
		{
			Console.WriteLine();
			Console.WriteLine("--- MODE COLOUR(S) ----");
			var modeCount = _calculate.ModeCount();
			var modeColours = _calculate.ModeColour();
			foreach (var colour in new Calculate(modeColours).OrderedColours())
			{
				Console.WriteLine(modeCount + " votes:	" + colour);
			}
		}

		public void RawData()
		{
			Console.WriteLine();
			Console.WriteLine("------ ALL DATA -------");
			var orderedColours = _calculate.OrderedColours();
			for (var i = 0; i < orderedColours.Count(); i++)
			{
				Console.WriteLine((i+1) + ":	" + orderedColours[i]);
			}
		}

		public void Divider()
		{
			Console.WriteLine("=======================");
		}
	}
}