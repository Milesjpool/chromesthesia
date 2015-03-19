﻿using System.Collections.Generic;

namespace SurveyResults.Outputs
{
	public class SimpleOutputType : IOutputType
	{
		private ConsoleOutput _consoleOut;

		public void Print(IList<Result> results)
		{
			_consoleOut = new ConsoleOutput(results);
			_consoleOut.Divider();
			_consoleOut.TrackHeader();
			_consoleOut.MeanColour();
			_consoleOut.ExaggeratedMeanColour();
			_consoleOut.ModeColours();
			_consoleOut.Divider();
		}
	}
}