using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SurveyResults.Unit.Tests
{
	[TestFixture]
	public class UserInputTests
	{
		private MockUi _console;
		private Validator _validator;

		[SetUp]
		public void Setup()
		{
			_console = new MockUi();
			_validator = new Validator(int.MaxValue);
		}

		[Test]
		public void Console_should_ask_for_a_trackId()
		{
			new UserInteraction(_console, _validator).GetTrackId();
			Assert.That(_console.AskedForTrackId, Is.True);
		}

		[Test]
		public void User_input_should_return_valid_trackId_when_supplied()
		{
			var userInput = new List<string>{"5"};
			_console.MockUserInput(userInput);
			var actual = new UserInteraction(_console, _validator).GetTrackId();
			const int expected = 5;
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void Console_should_notify_when_user_gives_a_non_numerical_trackId()
		{
			var userInput = new List<string>{ "a", "5" };
			_console.MockUserInput(userInput);
			new UserInteraction(_console, _validator).GetTrackId();
			Assert.That(_console.NotifiedOfInvalidId, Is.True);
		}
	}
}
