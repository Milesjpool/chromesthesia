namespace SurveyResults
{
	public interface IUserInterface
	{
		string ReadLine();
		void AskWhichTrack();
		void AskHowManyTracks();
		void AskToAnalyseAgain();
		void NotifyInvalidTrackId();
		void NotifyInvalidResponse();
	}
}