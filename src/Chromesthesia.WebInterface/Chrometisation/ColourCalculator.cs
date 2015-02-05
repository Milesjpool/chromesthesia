using System.Drawing;
using Chromesthesia.WebInterface.AcousticbrainzHelpers;

namespace Chromesthesia.WebInterface.Chrometisation
{
	public class ColourCalculator
	{
		public Color From(Analysis analysis)
		{
			return GetGenderAspect(analysis);
		}

		private Color GetGenderAspect(Analysis analysis)
		{
			if (analysis.highlevel.gender.value.ToLower().Equals("female"))
				return Color.Orange;
			return Color.Green;
		}
	}
}