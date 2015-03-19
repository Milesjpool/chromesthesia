using System.Configuration;

namespace SurveyResults.Analysis
{
	public class AllAnalysis : IAnalysis
	{
		public void Analyse()
		{
			int maxTrackId = int.Parse(ConfigurationManager.AppSettings["NumTracks"]);
			for (int trackId = 0; trackId < maxTrackId; trackId++)
			{
				new DataForTrack(trackId).PrintVerbose();
			}
		}
	}
}