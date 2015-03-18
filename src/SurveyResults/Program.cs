namespace SurveyResults
{
	static class Program
	{
		private const int MaxTrackId = 48;

		static void Main(string[] args)
		{
			var userInterface = new ConsoleUi();
			var validator = new Validator(MaxTrackId);
			var interaction = new UserInteraction(userInterface, validator);
			do
			{
				if (interaction.AnalyseAll())
				{
					Analysis.All(MaxTrackId);
				}
				else
				{
					Analysis.Single(interaction);
				}
			} while (interaction.AnalyseAgain());
		}
	}
}
