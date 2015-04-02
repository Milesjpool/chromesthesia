using System;
using System.Collections.Generic;
using System.Configuration;
using SurveyResults.Outputs;

namespace SurveyResults.Analysis
{
	public class AllAnalysis : IAnalysis
	{
		private readonly UserInteraction _interaction;

		public AllAnalysis(UserInteraction interaction)
		{
			_interaction = interaction;
		}

		public void Analyse(IOutputType outputType)
		{
			int maxTrackId = int.Parse(ConfigurationManager.AppSettings["NumTracks"]);
			var allData = new List<TrackData>();
			var loadingBar = new LoadingBar("Fetching Data", maxTrackId);
			loadingBar.Start();
			for (int trackId = 0; trackId < maxTrackId; trackId++)
			{
				allData.Add(ParseApi.GetResultsFor(trackId));
				loadingBar.Next();
			}
			outputType.Print(allData);
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

		public IOutputType GetOutputType(string input)
		{
			if (input.Equals("1"))
				return new SimpleOutputType();
			if (input.Equals("2"))
				return new VerboseOutputType();
			if (input.Equals("3"))
				return new SwatchOutputType(_interaction);
			throw new Exception();
		}
	}
}