namespace Chromesthesia.WebInterface.Services
{
	public abstract class AnalysisLevels
	{
		public static string High
		{
			get { return Properties.Settings.Default.HighLevel; }
		}

		public static string Low
		{
			get { return Properties.Settings.Default.LowLevel; }
		}
	}
}