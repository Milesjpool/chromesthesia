using SurveyResults.Outputs;

namespace SurveyResults.Analysis
{
	public interface IAnalysis
	{
		void Analyse(IOutputType outputType);
		void PrintOutputTypes();
		bool ValidOutputOption(string input);
		IOutputType GetOutputType(string input);
	}
}