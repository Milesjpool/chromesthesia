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

		public static void Single(int maxTrackId)
		{
			var trackId = UserInput.GetTrackId(maxTrackId);
			new DataForTrack(trackId).Verbose();
		}
	}
}