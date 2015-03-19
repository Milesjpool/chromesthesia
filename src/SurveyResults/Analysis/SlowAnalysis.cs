using System.Configuration;

namespace SurveyResults.Analysis
{
	public class SlowAnalysis : IAnalysis
	{
		private readonly IUserInterface _ui;

		public SlowAnalysis(IUserInterface ui)
		{
			_ui = ui;
		}

		public void Analyse()
		{
			int maxTrackId = int.Parse(ConfigurationManager.AppSettings["NumTracks"]);
			for (int trackId = 0; trackId < maxTrackId; trackId++)
			{
				new DataForTrack(trackId).PrintVerbose();
				_ui.WaitForInteraction();
			}
		}
	}
}