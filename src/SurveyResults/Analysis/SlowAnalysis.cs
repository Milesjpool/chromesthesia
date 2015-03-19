using System;
using System.Collections.Generic;
using System.Configuration;
using SurveyResults.Outputs;

namespace SurveyResults.Analysis
{
	public class SlowAnalysis : IAnalysis
	{
		private readonly IUserInterface _ui;

		public SlowAnalysis(IUserInterface ui)
		{
			_ui = ui;
		}

		public void Analyse(IOutputType outputType)
		{
			int maxTrackId = int.Parse(ConfigurationManager.AppSettings["NumTracks"]);
			for (int trackId = 0; trackId < maxTrackId; trackId++)
			{
				var results = ParseApi.GetResultsFor(trackId);
				outputType.Print(results);
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

		public IOutputType GetOutputType(string input)
		{
			if (input.Equals("1"))
				return new SimpleOutputType();
			if (input.Equals("2"))
				return new VerboseOutputType();
			throw new Exception();
		}
	}
}