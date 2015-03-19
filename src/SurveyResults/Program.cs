using SurveyResults.Analysis;

namespace SurveyResults
{
	static class Program
	{
		static void Main(string[] args)
		{
			var userInterface = new ConsoleUi();
			var validator = new Validator();
			var interaction = new UserInteraction(userInterface, validator);
			var analysisService = new AnalysisService(interaction);
			analysisService.Start();
		}
	}
}
