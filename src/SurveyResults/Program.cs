namespace SurveyResults
{
	static class Program
	{
		private const int MaxTrackId = 48;

		static void Main(string[] args)
		{
			do
			{
				if (UserInput.AnalyseAll())
				{
					Analysis.All(MaxTrackId);
				}
				else
				{
					Analysis.Single(MaxTrackId);
				}
			} while (UserInput.AnalyseAgain());
		}
	}
}
