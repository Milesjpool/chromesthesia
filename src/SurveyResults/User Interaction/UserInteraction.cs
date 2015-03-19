using SurveyResults.Analysis;
using SurveyResults.Outputs;

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

		public IOutputType GetOutputType(IAnalysis analysis)
		{
			while (true)
			{
				_userInterface.AskWhichOutputType(analysis);
				var input = _userInterface.ReadLine();
				if (analysis.ValidOutputOption(input))
					return analysis.GetOutputType(input);
				if (input.Equals("7"))
					_userInterface.EasterEgg();
				_userInterface.NotifyInvalidResponse();
			}
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

		public bool GetWhetherToAnalyseAgain()
		{
			_userInterface.AskToAnalyseAgain();
			var input = _userInterface.ReadLine();
			return _validator.IsYes(input);
		}
	}
}