using System;
using System.Collections.Generic;
using System.Configuration;

namespace SurveyResults.Analysis
{
	public class AllAnalysis : IAnalysis
	{
		public void Analyse(IOutput output)
		{
			int maxTrackId = int.Parse(ConfigurationManager.AppSettings["NumTracks"]);
			for (int trackId = 0; trackId < maxTrackId; trackId++)
			{
				output.Print(trackId);
			}
		}

		public void PrintOutputTypes()
		{
			Console.WriteLine("1. Simple");
			Console.WriteLine("2. Verbose");
			Console.WriteLine("3. Swatch");
		}

		public bool ValidOutputOption(string input)
		{
			var validOptions = new List<string> { "1", "2", "3" };
			return validOptions.Contains(input);
		}

		public IOutput GetOutputType(string input)
		{
			if (input.Equals("1"))
				return new SimpleOutput();
			if (input.Equals("2"))
				return new VerboseOutput();
			if (input.Equals("3"))
				return new SwatchOutput();
			throw new Exception();
		}
	}
}