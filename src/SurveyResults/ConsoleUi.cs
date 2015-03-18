using System;

namespace SurveyResults
{
	public class ConsoleUi : IUserInterface
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}

		public void AskForTrackId()
		{
			Console.WriteLine("Which track would you like to analyse?");
		}

		public void NotifyInvalidTrackId()
		{
			Console.WriteLine("Sorry, that's not a valid ID");
		}
	}
}