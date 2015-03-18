namespace SurveyResults
{
	static class Program
	{
		private const int MaxTrackId = 48;

		static void Main(string[] args)
		{
			var userInput = new UserInput(new ConsoleUi());
			do
			{
				if (userInput.AnalyseAll())
				{
					Analysis.All(MaxTrackId);
				}
				else
				{
					Analysis.Single(MaxTrackId, userInput);
				}
			} while (userInput.AnalyseAgain());
		}
	}
}
