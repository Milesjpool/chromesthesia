using System;
using System.Collections.Generic;

namespace SurveyResults.Analysis
{
	public class SingleAnalysis : IAnalysis
	{
		private readonly UserInteraction _interaction;

		public SingleAnalysis(UserInteraction interaction)
		{
			_interaction = interaction;
		}

		public void Analyse(IOutput output)
		{
			var trackId = _interaction.GetTrackId();
			output.Print(trackId);
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