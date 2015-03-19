namespace SurveyResults.Analysis
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
				var outputType = _interaction.GetOutputType(analysis);
				analysis.Analyse(outputType);
			} while (_interaction.GetWhetherToAnalyseAgain());
		}
	}
}