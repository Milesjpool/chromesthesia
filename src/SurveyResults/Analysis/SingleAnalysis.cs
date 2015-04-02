using System;
using System.Collections.Generic;
using SurveyResults.Outputs;

namespace SurveyResults.Analysis
{
	public class SingleAnalysis : IAnalysis
	{
		private readonly UserInteraction _interaction;

		public SingleAnalysis(UserInteraction interaction)
		{
			_interaction = interaction;
		}

		public void Analyse(IOutputType outputType)
		{
			var trackId = _interaction.GetTrackId();
			var trackResults = ParseApi.GetResultsFor(trackId);
			outputType.Print(trackResults);
		}

		public void PrintOutputTypes()
		{
			Console.WriteLine("1. Simple");
			Console.WriteLine("2. Verbose");
			Console.WriteLine("3. Swatch");
		}

		public bool ValidOutputOption(string input)
		{
			var validOptions = new List<string>{"1","2","3"};
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