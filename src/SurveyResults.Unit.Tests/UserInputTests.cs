using NUnit.Framework;

namespace SurveyResults.Unit.Tests
{
	[TestFixture]
	public class UserInputTests
	{
		[Test]
		public void Console_should_ask_again_when_user_give_an_invalid_trackId()
		{
			var console = new MockConsoleUi();
			new UserInput(console).GetTrackId(int.MaxValue);
			Assert.That(console.HasAskedUserAgain, Is.True);
		}
	}

	class MockConsoleUi : IUserInterface
	{
		public bool HasAskedUserAgain { get; private set; }

		public MockConsoleUi()
		{
			HasAskedUserAgain = false;
		}

		public string ReadLine()
		{
			HasAskedUserAgain = true;
			return "1";
		}
	}

}
