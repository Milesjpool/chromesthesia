using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyResults
{
	static class Program
	{
		private const int MaxTrackId = 48;

		static void Main(string[] args)
		{
			if (UserInput.AnalyseAll())
			{
				Analyse.All(MaxTrackId);
			}
			else
			{
				Analyse.Single(MaxTrackId);
			}
		}
	}
}
