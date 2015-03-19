using System;
using System.Collections.Generic;

namespace SurveyResults.Unit.Tests
{
	class MockUi : IUserInterface
	{
		private List<string> _userInputs = new List<string> { "0" };
		private int _inputElement;
		public bool NotifiedOfInvalidId { get; private set; }
		public bool AskedForTrackId { get; private set; }

		public MockUi()
		{
			NotifiedOfInvalidId = false;
			AskedForTrackId = false;
			_inputElement = 0;
		}

		public string ReadLine()
		{
			var input = _userInputs[_inputElement];
			_inputElement++;
			Console.WriteLine(input);
			return input;
		}

		public void WaitForInteraction()
		{
			throw new NotImplementedException();
		}

		public void AskToAnalyseAgain()
		{
			throw new NotImplementedException();
		}

		public void NotifyInvalidTrackId()
		{
			NotifiedOfInvalidId = true;
		}

		public void NotifyInvalidResponse()
		{
			throw new NotImplementedException();
		}

		public void EasterEgg()
		{
			throw new NotImplementedException();
		}

		public void AskWhichTrack()
		{
			AskedForTrackId = true;
		}

		public void AskHowManyTracks()
		{
			throw new NotImplementedException();
		}

		public void MockUserInput(List<string> userInput)
		{
			_inputElement = 0;
			_userInputs = userInput;
		}
	}
}