using System;

namespace SurveyResults
{
	public class Colour
	{
		private readonly int _red;
		private readonly int _green;
		private readonly int _blue;

		public Colour(int red, int green, int blue)
		{
			_red = red;
			_green = green;
			_blue = blue;
		}

		public Colour(Result result)
		{
			_red = result.Redness;
			_green = result.Greenness;
			_blue = result.Blueness;
		}

		public int Redness { get { return _red; } }
		public int Greenness { get { return _green; } }
		public int Blueness { get { return _blue; } }

		public override string ToString()
		{
			var redStr = PadToThree(_red);
			var greenStr = PadToThree(_green);
			var blueStr = PadToThree(_blue);
			return String.Format("rgb({0}, {1}, {2})", redStr, greenStr, blueStr);
		}

		private string PadToThree(int colourValue)
		{
			return colourValue.ToString().PadLeft(3, '0');
		}

		public int Value
		{
			get { return ((_red * 1000000) + (_green * 1000) + _blue); }
		}
	}
}