using System.Configuration;

namespace SurveyResults
{
	public class AnalysisService
	{
		private readonly UserInteraction _interaction;

		public AnalysisService(UserInteraction interaction)
		{
			_interaction = interaction;
		}

		public void Start()
		{
			do
			{
				var analysis = _interaction.GetAnalysisType();
				analysis.Analyse();
			} while (_interaction.GetWhetherToAnalyseAgain());
		}
	}

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