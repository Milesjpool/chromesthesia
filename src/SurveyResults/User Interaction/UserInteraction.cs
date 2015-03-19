using SurveyResults.Analysis;

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
				_userInterface.AskWhichTrack();
				var input = _userInterface.ReadLine();
				if (int.TryParse(input, out trackId) && _validator.IsValidTrackId(trackId))
					return trackId;
				_userInterface.NotifyInvalidTrackId();
			}
		}

		public IAnalysis GetAnalysisType()
		{
			while (true)
			{
				_userInterface.AskHowManyTracks();
				var input = _userInterface.ReadLine();
				if (input.Equals("1"))
					return new SingleAnalysis(this);
				if (input.Equals("2"))
					return new AllAnalysis();
				if (input.Equals("3"))
					return new SlowAnalysis(_userInterface);
				if (input.Equals("7"))
					_userInterface.EasterEgg();
				_userInterface.NotifyInvalidResponse();
			}
		}

		public bool GetWhetherToAnalyseAgain()
		{
			_userInterface.AskToAnalyseAgain();
			var input = _userInterface.ReadLine();
			return _validator.IsYes(input);
		}
	}
}