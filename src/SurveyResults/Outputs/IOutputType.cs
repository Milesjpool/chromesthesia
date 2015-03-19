using System.Collections.Generic;

namespace SurveyResults.Outputs
{
	public interface IOutputType
	{
		void Print(IList<Result> results);
	}
}