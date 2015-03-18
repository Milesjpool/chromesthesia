namespace SurveyResults
{
	public interface IUserInterface
	{
		string ReadLine();
		void NotifyInvalidTrackId();
		void AskForTrackId();
	}
}