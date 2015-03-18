using System;

namespace SurveyResults
{
	public class UserInteraction
	{
		private readonly IUserInterface _userInterface;
		private readonly Validator _validator;

		public UserInteraction(IUserInterface userInterface, Validator validator)
		{
			_userInterface = userInterface;
			_validator = validator;
		}

		public int GetTrackId()
		{
			while (true)
			{
				int trackId;
				_userInterface.AskForTrackId();
				var input = _userInterface.ReadLine();
				if (_validator.ValidateUserInputAndValidateTrackId(input, out trackId))
					return trackId;
				_userInterface.NotifyInvalidTrackId();
			}
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
}