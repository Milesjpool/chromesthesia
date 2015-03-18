namespace SurveyResults
{
	static class Analysis
	{
		public static void All(int maxTrackId)
		{
			for (int trackId = 0; trackId < maxTrackId; trackId++)
			{
				new DataForTrack(trackId).Verbose();
			}
		}

		public static void Single(UserInteraction interaction)
		{
			var trackId = interaction.GetTrackId();
			new DataForTrack(trackId).Verbose();
		}
	}
}