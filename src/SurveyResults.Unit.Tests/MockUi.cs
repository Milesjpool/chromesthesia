using System;
using System.Collections.Generic;

namespace SurveyResults.Unit.Tests
{
	class MockUi : IUserInterface
	{
		private List<string> _userInputs = new List<string> {"0"};
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
		
		public void NotifyInvalidTrackId()
		{
			NotifiedOfInvalidId = true;
		}

		public void AskForTrackId()
		{
			AskedForTrackId = true;
		}

		public void MockUserInput(List<string> userInput)
		{
			_inputElement = 0;
			_userInputs = userInput;
		}
	}
}