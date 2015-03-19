namespace SurveyResults
{
	public class SimpleOutput : IOutput
	{
		private ConsoleOutput _consoleOut;

		public void Print(int trackId)
		{
			_consoleOut = new ConsoleOutput(trackId);
			_consoleOut.Divider();
			_consoleOut.TrackHeader();
			_consoleOut.MeanColour();
			_consoleOut.ExaggeratedMeanColour();
			_consoleOut.ModeColours();
			_consoleOut.Divider();
		}
	}
}