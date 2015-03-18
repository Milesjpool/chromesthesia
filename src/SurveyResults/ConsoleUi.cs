using System;

namespace SurveyResults
{
	public class ConsoleUi : IUserInterface
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}