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
}