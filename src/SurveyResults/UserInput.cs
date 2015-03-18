using System;

namespace SurveyResults
{
	public class UserInput
	{
		private IUserInterface _consoleUi;

		public UserInput(IUserInterface consoleUi)
		{
			_consoleUi = consoleUi;
		}

		public int GetTrackId(int maxTrackId)
		{
			bool validId = false;
			int trackId = 0;
			while (!validId)
			{
				Console.WriteLine("Which track would you like to analyse?");
				validId = (int.TryParse(_consoleUi.ReadLine(), out trackId) && trackId <= maxTrackId);
				if (!validId)
					Console.WriteLine("Sorry, that's not a valid ID");
			}
			return trackId;
		}

		public bool AnalyseAll()
		{
			while (true)
			{
				Console.WriteLine("Would you like to:");
				Console.WriteLine("1. Analyse a single track?");
				Console.WriteLine("2. Analyse all tracks?");
				Console.Write("> ");
				var input = Console.ReadLine();
				if (input.Equals("1"))
					return false;
				if (input.Equals("2"))
					return true;
				Console.WriteLine("Sorry, that's not a valid answer.");
			}
		}

		public bool AnalyseAgain()
		{
			Console.Write("Would you like to carry out another analysis? (Y/n) ");
			return Console.ReadLine().ToLower().Equals("y");
		}
	}
	public interface IUserInterface
	{
		string ReadLine();
	}
}