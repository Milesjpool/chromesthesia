namespace SurveyResults
{
	public class SingleAnalysis : IAnalysis
	{
		private readonly UserInteraction _interaction;

		public SingleAnalysis(UserInteraction interaction)
		{
			_interaction = interaction;
		}

		public void Analyse()
		{
			var trackId = _interaction.GetTrackId();
			new DataForTrack(trackId).PrintVerbose();
		}
	}
}