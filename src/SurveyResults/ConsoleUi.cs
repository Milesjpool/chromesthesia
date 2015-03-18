using System;

namespace SurveyResults
{
	public class ConsoleUi : IUserInterface
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}

		public void AskWhichTrack()
		{
			Console.WriteLine("Which track would you like to analyse?");
		}

		public void AskHowManyTracks()
		{
			Console.WriteLine("Would you like to:");
			Console.WriteLine("1. Analyse a single track?");
			Console.WriteLine("2. Analyse all tracks?");
			Console.Write("> ");
		}

		public void AskToAnalyseAgain()
		{
			Console.Write("Would you like to carry out another analysis? (Y/n) ");
		}

		public void NotifyInvalidTrackId()
		{
			Console.WriteLine("Sorry, that's not a valid ID");
		}

		public void NotifyInvalidResponse()
		{
			Console.WriteLine("Sorry, that's not a valid answer.");
		}
	}
}