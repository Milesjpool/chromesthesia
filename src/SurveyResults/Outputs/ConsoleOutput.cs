using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyResults.Outputs
{
	class ConsoleOutput
	{
		private readonly Result _track;
		private readonly Calculate _calculate;

		public ConsoleOutput(TrackData data)
		{
			_track = data.Results.First();
			_calculate = new Calculate(data);
		}

		public void TrackHeader()
		{
			Console.WriteLine("Analysis for track " + _track.TrackId + ": " + _track.TrackString);
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
			Console.WriteLine(_calculate.ExaggeratedMean(1));
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