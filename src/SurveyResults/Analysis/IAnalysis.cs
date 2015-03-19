namespace SurveyResults.Analysis
{
	public interface IAnalysis
	{
		void Analyse(IOutput output);
		void PrintOutputTypes();
		bool ValidOutputOption(string input);
		IOutput GetOutputType(string input);
	}
}