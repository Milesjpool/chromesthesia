using System;
using System.Collections.Generic;
using System.Configuration;

namespace SurveyResults.Analysis
{
	public class SlowAnalysis : IAnalysis
	{
		private readonly IUserInterface _ui;

		public SlowAnalysis(IUserInterface ui)
		{
			_ui = ui;
		}

		public void Analyse(IOutput output)
		{
			int maxTrackId = int.Parse(ConfigurationManager.AppSettings["NumTracks"]);
			for (int trackId = 0; trackId < maxTrackId; trackId++)
			{
				output.Print(trackId);
				_ui.WaitForInteraction();
			}
		}

		public void PrintOutputTypes()
		{
			Console.WriteLine("1. Simple");
			Console.WriteLine("2. Verbose");
		}

		public bool ValidOutputOption(string input)
		{
			var validOptions = new List<string> { "1", "2" };
			return validOptions.Contains(input);
		}

		public IOutput GetOutputType(string input)
		{
			if (input.Equals("1"))
				return new SimpleOutput();
			if (input.Equals("2"))
				return new VerboseOutput();
			throw new Exception();
		}
	}
}