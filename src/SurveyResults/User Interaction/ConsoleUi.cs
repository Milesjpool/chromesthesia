﻿using System;
using SurveyResults.Analysis;

namespace SurveyResults
{
	public class ConsoleUi : IUserInterface
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}

		public void WaitForInteraction()
		{
			Console.ReadKey();
		}

		public void AskWhichTrack()
		{
			Console.WriteLine("Which track would you like to analyse?");
		}

		public void AskHowManyTracks()
		{
			Console.WriteLine("Would you like to:");
			Console.WriteLine("1. Analyse a single track?");
			Console.WriteLine("2. Analyse all tracks?");
			Console.WriteLine("3. Analyse all tracks? (Individually)");
			Console.Write("> ");
		}

		public void AskWhichOutputType(IAnalysis analysis)
		{
			Console.WriteLine("How would you like to output the results:");
			analysis.PrintOutputTypes();
			Console.Write("> ");
		}

		public void AskToAnalyseAgain()
		{
			Console.Write("Would you like to carry out another analysis? (Y/n) ");
		}

		public void NotifyInvalidTrackId()
		{
			Console.WriteLine("Sorry, that's not a valid ID");
		}

		public void NotifyInvalidResponse()
		{
			Console.WriteLine("Sorry, that's not a valid answer.");
		}

		public void EasterEgg()
		{
				Console.WriteLine("  ,________");
				Console.WriteLine("  |        \\");
				Console.WriteLine("  |         \\");
				Console.WriteLine("  |________  \\");
				Console.WriteLine("       /     /");
				Console.WriteLine("      /     /");
				Console.WriteLine("      \\    /");
				Console.WriteLine("       \\  /");
				Console.WriteLine("        \\/");
		}
	}
}