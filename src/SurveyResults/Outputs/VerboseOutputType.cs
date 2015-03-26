using System.Collections.Generic;

namespace SurveyResults.Outputs
{
	public class VerboseOutputType : IOutputType
	{
		private ConsoleOutput _consoleOut;

		public void Print(IList<TrackData> allData)
		{
			foreach (var trackData in allData)
			{
				Print(trackData);
			}
		}

		public void Print(TrackData data)
		{
			_consoleOut = new ConsoleOutput(data);
			_consoleOut.Divider();
			_consoleOut.TrackHeader();
			_consoleOut.MeanColour();
			_consoleOut.ExaggeratedMeanColour();
			_consoleOut.ModeColours();
			_consoleOut.RawData();
			_consoleOut.Divider();
		}
	}
}