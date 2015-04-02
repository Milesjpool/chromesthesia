using System;
using System.Text;
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

		public void NotifySavingTo(string location)
		{
			Console.WriteLine("Saving swatch to: \"" + location + "\"");
		}

		public void AskHowManyIterations()
		{
			Console.WriteLine("How many iterations would you like to display?");
		}

		public void NotifyInvalidInterations()
		{
			Console.WriteLine("Woah, that's not a valid number.");
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

	public class LoadingBar
	{
		private readonly string _label;
		private int _currentValue;
		private readonly int _completeValue;
		private bool _started;


		public LoadingBar(string label, int completeValue)
		{
			_label = label;
			_completeValue = completeValue;
		}

		public void Start()
		{
			_started = true;
			_currentValue = 0;
			PrintLevel(false);
		}

		public void Next()
		{
			if (!_started) throw new LoadingNotStartedException();
			_currentValue++;
			PrintLevel(true);
			if (_currentValue == _completeValue) _started = false;
		}
		
		private void PrintLevel(bool overwrite)
		{
			var length = 20;
			var bar = BuildProgressBar(length);
			if (overwrite)
			{
				Console.SetCursorPosition(0, Console.CursorTop-1);
			}
			Console.WriteLine(bar);
		}

		private string BuildProgressBar(int length)
		{
			var progress = (_currentValue * length) / _completeValue;
			var builder = new StringBuilder(_label + " [");
			builder.Append('=',progress);
			builder.Append(' ', (length - progress));
			builder.Append("]");
			return builder.ToString();
		}
	}
}