namespace SurveyResults
{
	public interface IUserInterface
	{
		string ReadLine();
		void WaitForInteraction();
		void AskWhichTrack();
		void AskHowManyTracks();
		void AskToAnalyseAgain();
		void NotifyInvalidTrackId();
		void NotifyInvalidResponse();
		void EasterEgg();
	}
}